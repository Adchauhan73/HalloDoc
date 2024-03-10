using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalloDocRepository.DataModels;
using HalloDocServices.ViewModels;

namespace HalloDocServices.Interfaces
{
    public interface IPatientLoginServices
    {
        Task<User> Patient_login(AspNetUser model);
        void ResetPassword(string email);
        Task SendEmailAsync(string email, string subject, string message);
    }
}



