<%@ Control Language="VB"  Inherits="BaseUserControl" %>
<%@ Import Namespace="System.Web.Security.Membership" %>
<!--Begin CSSMenuWriter/cssmw0/menu.js -->

<script language="javascript" src="../../CSSMenuWriter/cssmw0/menu.js"></script>

<!--End CSSMenuWriter/cssmw0/menu.js -->
<!-- Begin CSSMenuWriter/cssmw0/menu.css-->
<link rel="Stylesheet" href="../../CSSMenuWriter/cssmw0/menu.css" />
<!-- End CSSMenuWriter/cssmw0/menu.css-->
<!--Below replace ONLY "@import url("CSSMenuWriter/cssmw0/menu_ie.css");" with code-->
<!--[if lte IE 6]>
<link rel="Stylesheet" href="CSSMenuWriter/cssmw0/menu_ie.css" />
<![endif]-->

<style type="text/css">
#MainMenuDiv {
background-color:#877C74;
border-bottom-color:#4F4742;
border-bottom-style:solid;
border-bottom-width:3px;
border-top-color:#9F998E;
border-top-style:solid;
border-top-width:3px;
clear:both;
height:18px;
padding-left:15px;

}
</style>
<div id="TopDiv">
 
    <div id="UserLoginStatusTextDiv">
    <a href="https://checkout.netsuite.com/s.nl?c=317540&sc=1&login=T&reset=T&newcust=T&ck=emNh05hXARUBQLiX&vid=emNh05hXASYBQOsV&cktime=87960">Create Account</a>&nbsp;|
    <%
        If IsNothing(GetUser) Then
	        
    %>
        <a href="Login.aspx?ReturnUrl=<%=HttpContext.Current.Items("_path") %>">Log In</a>
    <%
    Else
        %>
        <span><%=GetUser.UserName.ToString%></span>
        <%
        End If
    %>
    </div>
</div>
<div id="LogoDiv">
    <div align="right">
        <img height="50" border="0" width="160" vspace="0" usemap="#Map" alt="MedStudy Logo"
            src="../../images/HeaderMedStudyLogo.jpg" />
        <map id="Map" name="Map">
            <area href="Default.aspx" coords="3,6,156,48" shape="rect" />
        </map>
    </div>
</div>
<div id="TopMenuBarDiv">
    <ul style="margin-bottom: 0pt;">
        <li><a href="../../Default.aspx">HOME </a></li>
        <li><a href="../../About.aspx">ABOUT MEDSTUDY</a></li>
        <li><a href="../../Contact_Us.aspx">CONTACT US</a></li>
        <li><a href="http://www.medstudy.com/s.nl/sc.3/.f">SHOPPING CART</a></li>
        <li><a href="../../Track_My_Order.aspx">TRACK MY ORDER</a></li>
        <li><a href="https://checkout.netsuite.com/app/center/nlvisitor.nl?c=317540&n=1&sc=6&ck=emNh05hXARUBQLiX&vid=emNh05hXASYBQOsV&cktime=87960">MY ACCOUNT</a></li>
        <li><a href="https://checkout.netsuite.com/s.nl?c=317540&sc=1&login=T&reset=T&newcust=T&ck=emNh05hXARUBQLiX&vid=emNh05hXASYBQOsV&cktime=87960">CREATE ACCOUNT</a></li>
    </ul>
</div>
<div id="MainMenuDiv" >
    <ul id="cssmw0" class="level-0">
        <li><a href="#">PRODUCTS</a>
            <ul class="level-1-Product">
                <li><span><a href="#"><b>INTERNAL MEDICINE</b></a></span></li>
                <li><span><a href="../../IM_Core_Curriculum.aspx">- Core Curriculum</a></span></li>
                <li><span><a href="../../QAndAOverview.aspx">- Board-Style Q&As</a></span></li>
                <li><span><a href="../../Internal_Medicine_DVD_Video_Board_Review.aspx">- Video Board Review
                    of Internal Medicine on DVD</a></span></li>
                <li><span><a href="../../BoardReviewCourse.aspx">- IM Intensive Certification Board Review
                    Course</a></span></li>
                <li><span><a href="../../RecertificationCourse.aspx">- IM Recertification Board Review Course</a></span></li>
                <li><span><a href="#"><b>PEDIATRICS</b></a></span></li>
                <li><span><a href="../../Pediatrics_Core_Curriculum.aspx">- Core Curriculum</a></span></li>
                <li><span><a href="../../Pediatrics_QandA_Overview.aspx">- Board-Style Q&As</a></span></li>
                <li><span><a href="../../Pediatrics_DVD_Video_Board_Review.aspx">- Video Board Review of Pediatrics
                    on DVD</a></span></li>
                <li><span><a href="../../Pediatrics_Board_Review_Course.aspx">- Pediatrics Intensive Review
                    Course</a></span></li>
            </ul>
        </li>
        <li><a href="#">CATALOGS / BROCHURES</a>
            <ul class="level-1-Catalog">
                <li><span><a href="#"><b>INTERNAL MEDICINE</b></a></span></li>
                <li><span><a target="_blank" href="http://ms-webpdfs.s3.amazonaws.com/2010_IM_Main_Catalog_V1.pdf">
                    - Internal Medicine Main Catalog (3 MB PDF file)</a></span></li>
                <li><span><a target="_blank" href="http://ms-webpdfs.s3.amazonaws.com/2010_IM_Recert_Catalog_V1.pdf">
                    - Internal Medicine Recertification Catalog (1.9 MB PDF file)</a></span></li>
                <li><span><a target="_blank" href="http://ms-webpdfs.s3.amazonaws.com/2010_IM_Recert_Conference_Brochure_Vegas.pdf">
                    - IM Recertification Board Review Course Brochure - Las Vegas (1 MB pdf file)</a></span></li>
                <li><span><a href="#"><b>PEDIATRICS</b></a></span></li>
                <li><span><a target="_blank" href="http://ms-webpdfs.s3.amazonaws.com/2010_Pediatrics_Main_Catalog.pdf">
                    - Pediatrics Main Catalog (1.3MB PDF file)</a></span></li>
                <li><span><a target="_blank" href="http://ms-webpdfs.s3.amazonaws.com/2010_Pediatrics_Recert_Catalog.pdf">
                    - Pediatrics Recertification Catalog (1.2MB PDF file)</a></span></li>
            </ul>
        </li>
        <li><a href="#">ORDER FORMS</a>
            <ul class="level-1-Forms">
                <li><span><a target="_blank" href="http://ms-webpdfs.s3.amazonaws.com/2010_MedStudy_Individual_Order_Form.pdf">
                    Order Form for Individuals (56KB PDF file)</a></span></li>
                <li><span><a target="_blank" href="http://ms-webpdfs.s3.amazonaws.com/2010IMGroupOrderForm.pdf">
                    Order Form for Internal Medicine Groups (240KB PDF file)</a></span></li>
                <li><span><a target="_blank" href="http://ms-webpdfs.s3.amazonaws.com/2010PedsGroupOrderForm.pdf">
                    Order Form for Pediatrics Groups (220KB PDF file)</a></span></li>
            </ul>
        </li>
        <li><a href="#">SUPPORT</a>
            <ul class="level-1-Support">
                <li><span><a href="../../Technical_Support.aspx">Technical Support</a></span></li>
                <li><span><a href="../../Customer_Service.aspx">Customer Service</a></span></li>
            </ul>
        </li>
        <li><a href="../../FAQs.aspx">FAQs</a></li>
        <li><a href="../../Software_Downloads.aspx">Q&A DOWNLOADS</a></li>
        <li><a href="../../CME_Information.aspx">CME</a></li>
        <li><a href="../../Errata.aspx">ERRATA</a></li>
        <li><a href="../../News.aspx">NEWS</a></li>
        <li><a href="../../Customer_Comments.aspx">CUSTOMER COMMENTS</a></li>
    </ul>
  

</div>
