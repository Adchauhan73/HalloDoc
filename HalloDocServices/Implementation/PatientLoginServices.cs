using HalloDocServices.Interfaces;
using HalloDocRepository.DataModels;
using HalloDocServices.ViewModels;
using HalloDocRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using HalloDocRepository.DataContext;
using MimeKit;

namespace HalloDocServices.Implementation
{
    public class PatientLoginServices : IPatientLoginServices

    {
        private IPatientloginRepository _PatientLoginRepository;
        private readonly IPatientLoginServices patientLoginServices;
        private readonly ApplicationDbContext _context;
   

        public PatientLoginServices(IPatientloginRepository PatientLoginRepository , ApplicationDbContext context)
        {
            _PatientLoginRepository = PatientLoginRepository;
            _context = context;
        }


        public async Task<User> Patient_login(AspNetUser model)
        {
            var aspnetuser = await _context.AspNetUsers.FirstOrDefaultAsync(u => u.Email == model.Email && u.PasswordHash == model.PasswordHash);
            if (aspnetuser != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                return user!;
            }
            else
            {
                return null!;
            }
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var emailToSend = new MimeMessage();
            emailToSend.From.Add(MailboxAddress.Parse("anil.chauhan@etatvasoft.com"));
            emailToSend.To.Add(MailboxAddress.Parse(email));
            emailToSend.Subject = subject;
            emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message };

            using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
            {
                emailClient.Connect("mail.etatvasoft.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("anil.chauhan@etatvasoft.com","jKAO+h]uA+vk");
                emailClient.Send(emailToSend);
                emailClient.Disconnect(true);
                return Task.CompletedTask;
            }
        }

        public void ResetPassword(string email)
        {
            var user = _context.AspNetUsers.Where(u => u.Email == email).FirstOrDefault();

            if (user != null)
            {
                SendEmailAsync("ankita.ramna@etatvasoft.com", "Hello Ankita", $"Password Yad Rakho.. <a href=\"https://localhost:44305/Home/Patient_login/{email}\">Reset</a>");
            }
        }

    }
}
