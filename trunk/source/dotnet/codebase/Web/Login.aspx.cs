using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using App.Domain.Users;
using App.Models.Users;

public partial class Login : BasePage
{
    protected UserManager userManager = new UserManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Log In");
        if (!IsPostBack)
        {
            if (String.Compare(Request[AppConstants.QueryString.LOG_OUT], "True", true) == 0)
            {
                //TODO: Shubho, Check the following line of code. It is creating problem. If I use this then I never can go to the members pages.
                //base.SignoutUser();

                LogOutUser();
            }
            CheckForAutoLogin();
            txtUserName.Focus();
        }
    }

    private void CheckForAutoLogin()
    {
        bool rememberMe = String.Compare(AppUtil.GetCookie(AppConstants.Cookie.REMEMBER_ME), "Yes", true) == 0 ? true : false;
        if (rememberMe)
        {
            String value = AppUtil.GetCookie(AppConstants.Cookie.AUTHOR_ID);
            int userId = 0;
            int.TryParse(value, out userId);
            String userCode = AppUtil.GetCookie(AppConstants.Cookie.USER_CODE);
            
            PlanningPrepUser user = userManager.Get(userId);
            if (user != null && String.Compare(user.User_code, userCode, false) == 0)
            {
                LoginUser(user, user.Username, rememberMe);
            }
        }
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (SessionCache.FailedLoginAttemptCount >= 5)
            {
                Response.Redirect(AppConstants.Pages.ALERT, false);
                return;
            }
            String userName = txtUserName.Text;
            String password = txtPassword.Text;
            userName = ReplaceBadWords(userName);

            PlanningPrepUser user = userManager.GetUserByUserNamePassword(userName, password);
            LoginUser(user, userName, chkRememberMe.Checked);
        }
    }
    protected void LoginUser(PlanningPrepUser user, String userName, bool rememberMe)
    {
        if (user != null)
        {
            if (!user.Active)
            {
                String message = @"Your login information is valid, however if your account has been disabled.  
                                If you have recently submitted a payment, your account may not yet be active.
                                Accounts processed through Paypal are activated within 24 hours.  
                                Accounts processed by check are activated upon receipt of check. 
                                If you believe this is in error, please <a href='/Pages/Public/ContactUs.aspx'>contact us</a>.";
                divMessage.Style["height"] = "70px;";
                AppUtil.ShowMessageBox(divMessage, message, true);
                SessionCache.FailedLoginAttemptCount = SessionCache.FailedLoginAttemptCount + 1;
                SessionCache.AttemptedUserName = userName;
                return;
            }            

            ///Set the Login Hit Counter
            user.LastLogin = DateTime.Now;
            user.LoginNumber = user.LoginNumber + 1;
            
            userManager.SaveOrUpdate(user);
            if (string.IsNullOrEmpty(user.Rights))
            {
                user.Rights = AppConstants.UserRoles.MEMBER;
            }
            else
            {
                user.Rights = AppConstants.UserRoles.ADMINISTRATOR;
            }
            SessionCache.CurrentUser = user;

            ///Set the cookies if remember me selected
            //if (rememberMe)
            //{
                //AppUtil.SetCookie(AppConstants.Cookie.USER_CODE, user.User_code);
                //AppUtil.SetCookie(AppConstants.Cookie.AUTHOR_ID, user.Author_ID.ToString());
                //AppUtil.SetCookie(AppConstants.Cookie.MODE, user.Mode);
                //AppUtil.SetCookie(AppConstants.Cookie.REMEMBER_ME, "Yes");
            //}
            //else
            //{
                //AppUtil.SetCookie(AppConstants.Cookie.USER_CODE, String.Empty);
                //AppUtil.SetCookie(AppConstants.Cookie.AUTHOR_ID, String.Empty);
                //AppUtil.SetCookie(AppConstants.Cookie.MODE, String.Empty);
                //AppUtil.SetCookie(AppConstants.Cookie.REMEMBER_ME, String.Empty);
            //}

            ///Track the Login Data
            String IP = Request.ServerVariables["REMOTE_ADDR"];
            //IP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            userManager.TrackLoginData(user.Author_ID, IP, DateTime.Now);

            ///TODO: Promo Stuff Is Not Implemented. Because it uses a static user name "dburnham".
            ///But we have taken it in the watch list.

            ///Check for Terms of Use
            if (!user.YesTermsofAgreement)
            {
                SessionCache.CurrentUser = null;
                SessionCache.AttemptedUserName = userName;
                SessionCache.FailedLoginAttemptCount = SessionCache.FailedLoginAttemptCount + 1;
                Response.Redirect(AppConstants.Pages.TERMS_OF_USE, false);
                return;
            }            
            ///After Successfull Login Redirect to the Requested Page
            FormsAuthenticationUtil.RedirectFromLoginPage(user.Username, user.Rights, rememberMe);
        }
        else //Failed
        {
            SessionCache.AttemptedUserName = userName;
            SessionCache.FailedLoginAttemptCount = SessionCache.FailedLoginAttemptCount + 1;
            AppUtil.ShowMessageBox(divMessage, "Login Failed. Your login was unsuccessful. Please check your Username and Password and try again.", true);
        }
    }
    protected void LogOutUser()
    {
        FormsAuthentication.SignOut();
        SessionCache.ClearSession();

        Response.Cookies[AppConstants.Cookie.BASE].Expires = DateTime.Now.AddYears(-100);
        Response.Cookies[AppConstants.Cookie.BASE_PLANNINGPREP_ANSWER].Expires = DateTime.Now.AddYears(-100);
    }    
    protected String ReplaceBadWords(String text)
    {
        text = text.Replace("password", String.Empty);
        text = text.Replace("author", String.Empty);
        text = text.Replace("code", String.Empty);
        text = text.Replace("username", String.Empty);
        return text;
    }
}
