<%@ Page Language="C#" MasterPageFile="~/Pages/Public/MasterPagePublic.master" AutoEventWireup="true" CodeFile="JoinOutcome.aspx.cs" Inherits="Pages_Public_JoinOutcome" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div class="contentheading">Submit Payment</div>
    <div style="float:left; width:48%">
        There is a $120 fee to access the features of our website.  
        We have 2 payment options available to you.  You can pay now using Paypal, or by check.  
        Paypal is a fast, easy and secure way to join our site with your credit card.
        <br /><br />  
        Accounts processed with a credit card through Paypal are now activated instantly.  
        To allow instant activation, you must complete the transaction the day you joined. 
        Please follow instructions on the Paypal site.  After your transaction is successful, 
        you will be redirected back to our site.  You <b>must</b> allow Paypal to redirect you for instant activation.  
        If there is an error in the activation your account will be active within 1 business day. 
        <br /><br />  
        Accounts processed by check are activated once the payment is received. If the check does not clear, 
        the account is disabled.
        
        <div style="margin-top:20px;">
            <input type="hidden" name="cmd" value="_s-xclick">
            <input type="image" src="https://www.paypal.com/images/x-click-but6.gif" border="0" name="submit" alt="Make payments with PayPal - it's fast, free and secure!">
            <input type="hidden" name="encrypted" value="-----BEGIN PKCS7-----MIIH+QYJKoZIhvcNAQcEoIIH6jCCB+YCAQExggEwMIIBLAIBADCBlDCBjjELMAkGA1UEBhMCVVMxCzAJBgNVBAgTAkNBMRYwFAYDVQQHEw1Nb3VudGFpbiBWaWV3MRQwEgYDVQQKEwtQYXlQYWwgSW5jLjETMBEGA1UECxQKbGl2ZV9jZXJ0czERMA8GA1UEAxQIbGl2ZV9hcGkxHDAaBgkqhkiG9w0BCQEWDXJlQHBheXBhbC5jb20CAQAwDQYJKoZIhvcNAQEBBQAEgYAPSZXk4yciBJKHY5AkEbLgiJU617NEi1h1y7+i4QWTH8Jbklmhr8BtUj1SEAvwnJ492wNWBoHhlyJuSz9P8pZLnDhE2e1h08Mum3FXdAD9yu5pqc6/4XXryzWOs8a8Qeo29bEpsntAPjCvEweU1bzI1m019Fc101DsP49Ba0a1gTELMAkGBSsOAwIaBQAwggF1BgkqhkiG9w0BBwEwFAYIKoZIhvcNAwcECAJR2rUGDtFjgIIBUItyf+Y9RsQP/9lhfQGZ8ftlhAnI/sNHjhq7ujt1CZrpxIe8jt7nwG8Qi4b1HiBnW7rfeaf6B7ZHEX5jOIcMSeFKy01oxMmmA7j9TIfWO8R9oVrwA1U3ZnPYj1U6uCcm59jkfPobyS0krAad3Q/pDyPKsv96fXc0LerKndTX04IkdM9QIFyCut06P+wFL3jgly6zCZ03z42P13eAxy6GlyH1GCsB0F1hVu//KpJZEoo74S0FZCYLLG8uXbLlAALsubM2ATSFzhgaxXZTfqiDmUXkk4HlATmIJJ8bwiL8Rlo5l43wQEJZecbf7407Dn9sVCyj+H10VVqY/UNNB0AgCTGTibv2rjAyIuNSQcZ5dfsbQrmJ0l+h2pAORymG3dBWBA9rVkhV+6azPZFGFI7uEiEpsf+fsF1zJy5kBzIOqWdzhcq+JxlebR/hCseKyPGOiaCCA4cwggODMIIC7KADAgECAgEAMA0GCSqGSIb3DQEBBQUAMIGOMQswCQYDVQQGEwJVUzELMAkGA1UECBMCQ0ExFjAUBgNVBAcTDU1vdW50YWluIFZpZXcxFDASBgNVBAoTC1BheVBhbCBJbmMuMRMwEQYDVQQLFApsaXZlX2NlcnRzMREwDwYDVQQDFAhsaXZlX2FwaTEcMBoGCSqGSIb3DQEJARYNcmVAcGF5cGFsLmNvbTAeFw0wNDAyMTMxMDEzMTVaFw0zNTAyMTMxMDEzMTVaMIGOMQswCQYDVQQGEwJVUzELMAkGA1UECBMCQ0ExFjAUBgNVBAcTDU1vdW50YWluIFZpZXcxFDASBgNVBAoTC1BheVBhbCBJbmMuMRMwEQYDVQQLFApsaXZlX2NlcnRzMREwDwYDVQQDFAhsaXZlX2FwaTEcMBoGCSqGSIb3DQEJARYNcmVAcGF5cGFsLmNvbTCBnzANBgkqhkiG9w0BAQEFAAOBjQAwgYkCgYEAwUdO3fxEzEtcnI7ZKZL412XvZPugoni7i7D7prCe0AtaHTc97CYgm7NsAtJyxNLixmhLV8pyIEaiHXWAh8fPKW+R017+EmXrr9EaquPmsVvTywAAE1PMNOKqo2kl4Gxiz9zZqIajOm1fZGWcGS0f5JQ2kBqNbvbg2/Za+GJ/qwUCAwEAAaOB7jCB6zAdBgNVHQ4EFgQUlp98u8ZvF71ZP1LXChvsENZklGswgbsGA1UdIwSBszCBsIAUlp98u8ZvF71ZP1LXChvsENZklGuhgZSkgZEwgY4xCzAJBgNVBAYTAlVTMQswCQYDVQQIEwJDQTEWMBQGA1UEBxMNTW91bnRhaW4gVmlldzEUMBIGA1UEChMLUGF5UGFsIEluYy4xEzARBgNVBAsUCmxpdmVfY2VydHMxETAPBgNVBAMUCGxpdmVfYXBpMRwwGgYJKoZIhvcNAQkBFg1yZUBwYXlwYWwuY29tggEAMAwGA1UdEwQFMAMBAf8wDQYJKoZIhvcNAQEFBQADgYEAgV86VpqAWuXvX6Oro4qJ1tYVIT5DgWpE692Ag422H7yRIr/9j/iKG4Thia/Oflx4TdL+IFJBAyPK9v6zZNZtBgPBynXb048hsP16l2vi0k5Q2JKiPDsEfBhGI+HnxLXEaUWAcVfCsQFvd2A1sxRr67ip5y2wwBelUecP3AjJ+YcxggGaMIIBlgIBATCBlDCBjjELMAkGA1UEBhMCVVMxCzAJBgNVBAgTAkNBMRYwFAYDVQQHEw1Nb3VudGFpbiBWaWV3MRQwEgYDVQQKEwtQYXlQYWwgSW5jLjETMBEGA1UECxQKbGl2ZV9jZXJ0czERMA8GA1UEAxQIbGl2ZV9hcGkxHDAaBgkqhkiG9w0BCQEWDXJlQHBheXBhbC5jb20CAQAwCQYFKw4DAhoFAKBdMBgGCSqGSIb3DQEJAzELBgkqhkiG9w0BBwEwHAYJKoZIhvcNAQkFMQ8XDTA1MDcyNjEzNDMyNVowIwYJKoZIhvcNAQkEMRYEFGaeIYu4LoQWpHpu1Jp3SR7PCcukMA0GCSqGSIb3DQEBAQUABIGADKp+9bh8H3EQ5RgQIj2tqgFa4jZ90EUS98R55Zq6hV4vEHJCFR2z2/+sDhMzOvpWRUH6+/CL9BOz84t8/2CKluruOaLnAyY5CihBtjIzojsWnThjycIRCAwyNgvzx2YNqccoM9GIiWyZwRylxMkr4hdGlg1wFN7RplayeohivXQ=-----END PKCS7-----">
            <a href="paybycheck.asp">
            <img border="0" src="/Images/bycheck.gif"></a>
        </div>    
    </div>
    <div style="float:right; width:48%">
        <i>
            We hope our methods of accepting payment are convenient for you.  
            Determining the most appropriate payment method was a difficult decision.  
            We decided that since a large number of our members will be from public agencies or larger organizations, 
            most payments would be made by check through an accounts payable department.  Also, unlike credit 
            card companies, Paypal takes less than 1% of a transaction, allowing us to charge less for our members.  
            If you would like to express any feelings about our payment methods please feel free to contact us. 
        </i>
    </div>
    <div class="clearfloating"></div>
</asp:Content>

