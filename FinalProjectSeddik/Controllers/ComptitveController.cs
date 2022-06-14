using FinalProjectSeddik.Data;
using FinalProjectSeddik.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSeddik.Controllers
{
    public class ComptitveController : Controller
    {
        private AppDbContext db;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public ComptitveController(AppDbContext context, UserManager<ApplicationUser> applicationUser, SignInManager<ApplicationUser> signInManager)
        {
            db = context;
            _userManager = applicationUser;
            _signInManager = signInManager;
        }

        //  صفحه ارسال المشروع

        public async Task<IActionResult> UploadProject() 
        {
            ViewBag.user = await _userManager.GetUserAsync(User);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadProject(Projects model)
        {

            var user = await _userManager.GetUserAsync(User);
            var Comp = db.compRegs.Where(c => c.Email == user.Email).FirstOrDefault();
            model.Name = user.Name;
            model.Specialization = user.Specialization;
            model.Email = user.Email;
            model.CompId = Comp.Id;
            db.Projects.Add(model);
            
            db.SaveChanges();
            user.IsProjSent = true;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Home");
        }
        // نهايه صفحه ارسال المشروع

        // بروفايل ال Comptitve
        public IActionResult ComptitveProfile()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = db.compRegs.FirstOrDefault();

            return View(user);
        }
    }
}
