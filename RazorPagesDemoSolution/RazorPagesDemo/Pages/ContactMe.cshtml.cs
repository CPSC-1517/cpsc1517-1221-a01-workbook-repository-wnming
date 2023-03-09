using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;

namespace RazorPagesDemo.Pages
{
    public class ContactMeModel : PageModel
    {
        private readonly IConfiguration Configuration;

        public ContactMeModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Comments { get; set; }
        [BindProperty]
        public bool SubScribe { get; set; }

        public string? InfoMessage { get; private set; }
        public string? ErrorMessage { get; private set; }

        public string defaltRequired = "is required and cannot be blank.";

        public void OnPostSendMessage()
        { 
            if(string.IsNullOrWhiteSpace(Name))
            {
                ErrorMessage = $"Name {defaltRequired}";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Email))
                {
                    ErrorMessage = $"Email {defaltRequired}";
                }
                else
                {
                    if(string.IsNullOrWhiteSpace(Comments) || Comments.Length < 10)
                    {
                        ErrorMessage = $"Comments {defaltRequired} And requied at least 10 characters.";
                    }
                    else
                    {
                        string subscribe = SubScribe ? "Yes" : "No";
                        InfoMessage =$"Name: {Name} <br />" +
                                     $"Email: {Email} <br />" +
                                     $"Comments: {Comments} <br />" +
                                     $"Subscribe to email: {subscribe} <br />";

                        SmtpClient sendMailClient = new SmtpClient();
                        sendMailClient.Host = Configuration["MailServerSettings:SmtpHost"];
                        sendMailClient.Port = int.Parse(Configuration["MailServerSettings:Port"]);
                        sendMailClient.EnableSsl = bool.Parse(Configuration["MailServerSettings:EnableSsl"]);

                        NetworkCredential mailCredentials = new NetworkCredential();
                        mailCredentials.UserName = Configuration["MailServerSettings:Username"];
                        mailCredentials.Password = Configuration["MailServerSettings:AppPassword"];
                        sendMailClient.Credentials = mailCredentials;

                        string mailToAddress = Email ?? "mingr_napat@hotmail.com";
                        string mailFromAddress = Configuration["MailServerSettings:Email"];

                        MailMessage mailMessage = new MailMessage(mailFromAddress, mailToAddress);
                        mailMessage.Subject = "[CPSC1517] New contact me form submission";
                        mailMessage.Body = InfoMessage;

                        try
                        {
                            sendMailClient.Send(mailMessage);
                            Name = null;
                            Email = null;
                            Comments = null;
                            InfoMessage = "Your message has been sent!";
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = $"Error sending mail with exception: {ex.Message}";
                        }
                    }
                }
            }
        }

        public void OnPostReset()
        {
            Comments = null;
        }

        public IActionResult OnPostClear()
        {
            Name = null;
            Email = null;
            Comments = null;
            SubScribe = false;
            InfoMessage = null;
            ErrorMessage = null;
            return RedirectToPage();
        }

        public void OnGet()
        {
        }
    }
}
