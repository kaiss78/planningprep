#region History

/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: App.Core
 * Name: MessageReader.cs
 * Purpose: Message reader class from XML file
 *                   
 * Author: AFS
 * Language: C# SDK version 2.0
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    AFS  09/26/09
 * Description: Initial Development
 * -------------------------------------------------------------------------------- */

#endregion

#region References

using System;
using System.Net.Mail;
using App.Core.Exceptions;

#endregion

namespace App.Core.Mail
{
    /// <summary>
    /// Reads messages from XML file
    /// </summary>
    public sealed class MailManager
    {
        #region Methods
        public static void SendMail(string smtpHost, int smtpPort, string mailTo, string mailCc, string mailBcc, string mailFrom, string mailSubject, string mailBody)
        {
            try
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(mailFrom);

                    //Spliting the to addresses by ','
                    string[] emailAddesses = mailTo.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string to in emailAddesses)
                    {
                        mailMessage.To.Add(new MailAddress(to.Trim()));
                    }

                    //Spliting the cc Adresses by ','
                    string[] ccAddresses = mailCc.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string cc in ccAddresses)
                    {
                        mailMessage.CC.Add(new MailAddress(cc.Trim()));
                    }

                    //determining the BCC of the mail.
                    string[] bccAddresses = mailBcc.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string bcc in bccAddresses)
                    {
                        mailMessage.Bcc.Add(new MailAddress(bcc.Trim()));
                    }

                    mailMessage.Subject = mailSubject;
                    mailMessage.Body = mailBody;
                    mailMessage.IsBodyHtml = true;

                    //sending the mail.
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = smtpHost;
                    smtpClient.Port = smtpPort;
                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Exception excToUse = ex.InnerException ?? ex;
                throw new CommunicationException(excToUse.Message, excToUse);
            }
        }
        #endregion
    }
}
