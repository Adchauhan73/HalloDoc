using HalloDocRepository.DataModels;
using HalloDocServices.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HalloDocServices.Interfaces
{
    public interface IPatientRequestService
    {
        void CreateConceirgeRequest(Conceirgerequest1 model);
        void CreateFamilyRequest(Familyrequest model);
        void CreatePatientRequest(Patientrequest patientRequest);
      
        void Documentupload(ViewDocument model, int id);
        Task<byte[]> DownLoadAll(int requestid);
        //string GenerateToken();
        void PaProfile(string email, User model);
        PatientDashboard PatientDashboard(PatientDashboard dashboard , string email);
        User ProfileService(string Email);
        //void SendMail(SendMail details, string resetLink);
        ViewDocument ViewDocument(int id);


    }
}