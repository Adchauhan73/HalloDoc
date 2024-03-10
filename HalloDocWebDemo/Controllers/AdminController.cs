using HalloDocRepository.DataContext;
using HalloDocRepository.DataModels;
using HalloDocServices.Admin;
using HalloDocServices.Implementation;
using HalloDocServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HalloDocWebDemo.Controllers
{
    public class AdminController : Controller
    {

  
        private readonly IAdminService _AdminService;
        private readonly ApplicationDbContext _context;
        //private readonly IJwtService _jwtService;

        public AdminController(IAdminService AdminService, ApplicationDbContext context)
        {
            _AdminService = AdminService;
            _context = context;
            //_jwtService = jwtService;

        }

        public IActionResult AdminDashboard()
        {
            DashboardDetails details = new DashboardDetails();
            details.newRequest = _AdminService.newDashboard().Count;
            details.pendingRequest = _AdminService.pendingDashboard().Count;
            details.tocloseRequest = _AdminService.ToCloseDashboard().Count;    
            return View(details);


        }

        public IActionResult NewTable()
        {
            DashboardDetails details = new();
            details.clients = _AdminService.newDashboard();
            return PartialView(details);
        }

        

        public IActionResult PendingTable()
        {
            DashboardDetails details = new();
            details.clients = _AdminService.pendingDashboard();
            
            return PartialView(details);
        }

        public IActionResult ActiveTable()
        {
            DashboardDetails details2 = new();
            details2.clients = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 3).ToList();
            return PartialView(details2);
        }

        public IActionResult ConcludeTable()
        {
            DashboardDetails details3 = new();
            details3.clients = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 4).ToList();
            return PartialView(details3);
        }

        public IActionResult ToCloseTable()
        {
            DashboardDetails details = new();
            details.clients = _AdminService.ToCloseDashboard();
            return PartialView(details);
        }


        public IActionResult UnpaidTable()
        {
            DashboardDetails details5 = new();
            details5.clients = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 6).ToList();
            return PartialView(details5);
        }
        public IActionResult ViewCase(int reqid)
        {

            var data = _AdminService.ViewCase(reqid);
            return View(data);
        }

        public IActionResult ViewNotes()
        {
            var data = _AdminService.ViewNotes();
            return View(data);
        }

        public IActionResult Addnote(ViewNotes model)
        {
           
            _AdminService.Addnote(model);
            return RedirectToAction("AdminDashboard", "Admin");
        }

        public IActionResult CancelCase(int id)
        {
            var details = _AdminService.CancelCase(id);
            return PartialView("CancelCase", details);
        }

        [HttpPost]
        public IActionResult CancelCaseAction(DashboardDetails details , int cancelid)
        {
             _AdminService.CancelPatientRequest(details, cancelid);
            return RedirectToAction("AdminDashboard", "Admin");
        }

        public IActionResult _AssignCase( int id)
        {
            var details = _AdminService.AssignCase(id);

            return PartialView("_AssignCase", details);

        }

        public IActionResult AssignCaseAction(DashboardDetails details , int assignid)
        {
            _AdminService.AssignCaseRequest(details, assignid);
            return RedirectToAction("AdminDashboard", "Admin");
        }

        public IActionResult _BlockRequest( int id )
        {
            var details = _AdminService.BlockCase(id);
            return PartialView("_BlockRequest" , details);
        }

        public IActionResult BlockCaseAction(DashboardDetails details, int blockid)
        {
            _AdminService.BlockPatient(details , blockid);
            return RedirectToAction("AdminDashboard", "Admin");
        }


        [HttpGet]
        public IActionResult ViewUploads( int id)
        {
            var data = _AdminService.ViewUpload(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult ViewUploads (Viewupload model , int id)
        {
            _AdminService.ViewUpload(model, id);
             return RedirectToAction("ViewUploads" , new { id = id });
        }

        public IActionResult Delete(int DocumentId, int RequestId)
        {
            _AdminService.Delete(DocumentId);
            return RedirectToAction("ViewUploads", new { request_id = RequestId });
        }

        public IActionResult SentOrder()
        {
            return View();
        }

        public IActionResult _ClearCase()
        {
            return PartialView("_ClearCase");
        }
       
    }
}



