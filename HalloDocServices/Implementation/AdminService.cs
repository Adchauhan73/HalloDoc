using HalloDocRepository.DataContext;
using HalloDocRepository.DataModels;
using HalloDocServices.Admin;
using HalloDocServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HalloDocServices.Implementation
{
    public class AdminService : IAdminService
    {

        private readonly ApplicationDbContext _context;
        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<RequestClient> newDashboard()
        {
            List<RequestClient> newRequest = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 1).ToList();
            return newRequest;
        }

        public List<RequestClient> pendingDashboard()
        {
            List<RequestClient> pendingRequest = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 2).Include(u => u.Request.Physician).ToList();
            return pendingRequest;
        }

        public List<RequestClient> ToCloseDashboard()
        {
            List<RequestClient> tocloseRequest = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 3).ToList();
            return tocloseRequest;
        }

        public ViewCase ViewCase(int reqid)
        {

            var user = _context.RequestClients.FirstOrDefault(u => u.RequestClientId == reqid);
            DateTime dob = DateTime.ParseExact(user.IntYear.ToString() + "-" + user.StrMonth + "-" + user.IntDate.ToString(), "yyyy-M-d", System.Globalization.CultureInfo.InvariantCulture);
            ViewCase viewcase = new ViewCase()
            {
                PatientNotes = user.Notes,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = dob.ToString("yyyy-MM-dd"),
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            return viewcase;
        }

        public ViewNotes ViewNotes()
        {
            var user = _context.RequestNotes.FirstOrDefault();
            ViewNotes viewnotes = new ViewNotes()
            {
                PhysicianNotes = user.PhysicianNotes,
                AdminNotes = user.AdminNotes,
            };
            return viewnotes;
        }

        public void Addnote(ViewNotes model)
        {
            var notes = _context.RequestNotes.FirstOrDefault();
            notes.AdminNotes = model.AdminNotes;
            _context.RequestNotes.Update(notes);
            _context.SaveChanges();
        }

        public DashboardDetails CancelCase(int id)
        {
            var user = _context.RequestClients.FirstOrDefault(x => x.RequestId == id);
            DashboardDetails dashboarddetails = new DashboardDetails()
            {
                RequestId = user.RequestId,
                PatientName = user.FirstName + " " + user.LastName,
            };
            return dashboarddetails;
        }

        public void CancelPatientRequest(DashboardDetails details, int cancelid)
        {
            var patientRequest = _context.Requests.FirstOrDefault(u => u.RequestId == cancelid);
            patientRequest.Status = 3;
            //patientRequest.CaseTag = details.CaseTagName;
            var requestStatusLog = new RequestStatusLog
            {
                RequestId = cancelid,
                Status = 3,
                Notes = details.AdditionalNote,
                CreatedDate = DateTime.Now,
            };
            _context.Add(requestStatusLog);
            _context.SaveChanges();
        }

        public DashboardDetails AssignCase(int id)
        {
            var user = _context.RequestClients.FirstOrDefault(x => x.RequestId == id);
            DashboardDetails dashboarddetails = new DashboardDetails()
            {
                RequestId = user.RequestId,
                PatientName = user.FirstName + " " + user.LastName,
            };
            return dashboarddetails;
        }
        public void AssignCaseRequest(DashboardDetails details, int assignid)
        {
            var patientRequest = _context.Requests.FirstOrDefault(u => u.RequestId == assignid);
            patientRequest.Status = 2;

            var physician = new Physician
            {
                PhysicianId = assignid,
                FirstName = details.PhysicianName,
                LastName = details.PhysicianName,
                CreatedDate = DateTime.Now,
                Email = details.PhysicianName,
                BusinessName = details.PhysicianName,
                BusinessWebsite = details.PhysicianName,
            };
            _context.Add(physician);
            _context.SaveChanges();
        }

        public DashboardDetails BlockCase(int id)
        {
            var user = _context.RequestClients.FirstOrDefault(x => x.RequestId == id);
            DashboardDetails dashboarddetails = new DashboardDetails()
            {
                RequestId = user.RequestId,
                PatientName = user.FirstName + " " + user.LastName,
            };
            return dashboarddetails;
        }

        public void BlockPatient (DashboardDetails details , int blockid)
        {
            var blockrequest = _context.Requests.FirstOrDefault(x => x.RequestId == blockid);
            blockrequest.Status = 11;

            var blockpatientrequest = new BlockRequest
            {
                //RequestId = blockid,
                Email = blockrequest.Email,
                CreatedDate = DateTime.Now,
                Reason= details.BlockReason,
            };
            _context.Add(blockpatientrequest);
            _context.SaveChanges();
        }

        public Viewupload ViewUpload(int id)
        {
            Request data = _context.Requests.Where( a => a.RequestId == id).FirstOrDefault();
            RequestClient requestClient = _context.RequestClients.Where( a => a.RequestId == id).FirstOrDefault();
            List<RequestWiseFile> requestwisefile = _context.RequestWiseFiles.Where( a =>a.RequestId == id).ToList();

            Viewupload Viewdoc = new Viewupload()
            {
                Requests = data,
                RequestWiseFiles = requestwisefile,
                RequestClients = requestClient

            };

            Viewdoc.RequestId = id;
            return Viewdoc;

        }

        public void ViewUpload(Viewupload model , int id)
        {
           var data = _context.Requests.FirstOrDefault( a => a.RequestId == id);

            foreach (var item in model.File)
            {
                var Filename = item.FileName;
            
                if (model.File != null)
                {
                    string path = Directory.GetCurrentDirectory();
                   
                    string uploadFolder = path + "\\wwwroot\\Uploads";

                    string uniqueFilename = Guid.NewGuid().ToString() + "_" + Filename;
                    string FilePath = Path.Combine(uploadFolder, uniqueFilename);
                    item.CopyTo(target: new FileStream(FilePath, FileMode.Create));


                    RequestWiseFile requestWiseFile = new RequestWiseFile
                    {
                        RequestId = data.RequestId,
                        FileName = uniqueFilename,
                        Request = data,
                        CreatedDate = DateTime.Now
                    };
                    _context.RequestWiseFiles.Add(requestWiseFile);
                    _context.SaveChanges();

                }

            }
        }


        public void Delete(int DocumentId)
        {
            RequestWiseFile data = _context.RequestWiseFiles.Where(a => a.RequestWiseFileId == DocumentId).FirstOrDefault();
            _context.RequestWiseFiles.Remove(data);
            _context.SaveChanges();
        }
    }
}







