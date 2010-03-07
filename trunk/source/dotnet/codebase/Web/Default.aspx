<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>    
    <link href="/CSS/Styles.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="/JavaScripts/jquery-1.3.2.min.js"></script>
    
    <script language="javascript" type="text/javascript">
        $(document).ready(function(){            
            ResetLogoPosition();
        });
        function ResetLogoPosition()
        {
            var position = $('#divTopContainer').position();
            $('#divLogoContainer').css({'left' : position.left, 'top' : (position.top + 40)});
        }
        $(window).resize(function(){
            ResetLogoPosition();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="parentcontaniner">
        <div class="bodycontaniner">
            <!-- Top Banner Section Starts -->
            <div id="divTopContainer" class="topcontainer">            
                <img src="/Images/HomepageBanner.jpg" />
                <div id="divLogoContainer" class="bannerlogo">PlanningPrep.com</div>
            </div>
            <!-- Top Banner Section Ends -->
            <div class="menuecontainer">
                <div style="width:800px; margin-left:auto; margin-right:auto">
                    <div class="menuitem">Home</div>
                    <div class="menuitem">About Us</div>
                    <div class="menuitem">Contant Us</div>
                    <div class="menuitem">FAQ</div>
                    <div class="menuitem">Join</div>
                    <div class="menuitem"><a href="Login.aspx" class="headermenu">Log In</a></div>
                    <div class="clearfloating"></div>
                </div>
            </div>
            <div class="bottomcontainer">
                <div class="bottomcontentcontainer">
                    <div class="homepagecontentbox">
                        <div class="contentheading">Lorem ipsum dolor sit amet, consectetur</div>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non quam ut libero dictum pharetra. In neque risus, consectetur vehicula vestibulum luctus, venenatis at purus. Maecenas aliquet, elit nec sagittis laoreet, ligula odio iaculis dolor, venenatis aliquet sem metus quis arcu. Etiam cursus orci eu nisi rhoncus malesuada. Etiam mi lorem, cursus in bibendum ut, dapibus vitae dui. Etiam mollis egestas viverra. Donec ipsum justo, condimentum id accumsan et, gravida a massa. Curabitur eget magna quam. Mauris luctus justo in tortor rhoncus eu auctor risus fringilla. Nullam non libero vitae nulla suscipit malesuada vel ut velit. Praesent at urna et libero interdum facilisis.
                    </div>
                    <div class="homepagecontentbox">
                    <div class="contentheading">Lorem ipsum dolor sit amet, consectetur</div>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non quam ut libero dictum pharetra. In neque risus, consectetur vehicula vestibulum luctus, venenatis at purus. Maecenas aliquet, elit nec sagittis laoreet, ligula odio iaculis dolor, venenatis aliquet sem metus quis arcu. Etiam cursus orci eu nisi rhoncus malesuada. Etiam mi lorem, cursus in bibendum ut, dapibus vitae dui. Etiam mollis egestas viverra. Donec ipsum justo, condimentum id accumsan et, gravida a massa. Curabitur eget magna quam. Mauris luctus justo in tortor rhoncus eu auctor risus fringilla. Nullam non libero vitae nulla suscipit malesuada vel ut velit. Praesent at urna et libero interdum facilisis.
                    </div>
                    <div class="clearfloating"></div>
                    <div class="OnePixelBorder"></div>
                    
                    <div class="homepagenewscontentbox">
                        <img src="/Images/news1.jpg" align="left" alt="News 1" title="News 1" style="margin-right:20px;" />                        
                        <div class="newsheading">First News</div>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non quam ut libero dictum pharetra.                     
                    </div>
                    <div class="homepagenewscontentbox">
                        <img src="/Images/news2.jpg" align="left" alt="News 2" title="News 2" style="margin-right:20px;" />
                        <div class="newsheading">Second News</div>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non quam ut libero dictum pharetra. 
                    </div>
                    <div class="homepagenewscontentbox">
                        <img src="/Images/news3.jpg" align="left" alt="News 3" title="News 3" style="margin-right:20px;"  />
                        <div class="newsheading">Third News</div>                        
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non quam ut libero dictum pharetra. 
                    </div>
                    <div class="clearfloating"></div>
                    
                </div>                
            </div>
            <div class="footercontainer">Copyright&copy; PlanningPrep.com <%=DateTime.Now.Year.ToString() %>, All Rights Reserved</div>
        </div>
    </div>
    </form>
</body>
</html>
