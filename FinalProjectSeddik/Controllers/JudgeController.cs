using FinalProjectSeddik.Data;
using FinalProjectSeddik.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace FinalProjectSeddik.Controllers
{
    public class JudgeController : Controller
    {
        private AppDbContext db;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public JudgeController(AppDbContext context, UserManager<ApplicationUser> applicationUser, SignInManager<ApplicationUser> signInManager)
        {
            db = context;
            _userManager = applicationUser;
            _signInManager = signInManager;
        }

        // صفحه البروفايل بتاع الجادج
        public async Task<IActionResult> ProfileUg()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }


        // صفحه مراجعة المشروع بتاع الجادج
        public async Task< IActionResult> JudgeDeg()
        {
            var user = await _userManager.GetUserAsync(User);
            var proj = db.Projects.Where(p => p.Specialization == user.Specialization).ToList();
            
            return View(proj);
        }

        public IActionResult CompRate(int id)
        {

            var CompRate = db.Projects.Where(x => x.Id == id).FirstOrDefault();

            return View(CompRate);
        }
        [HttpPost]
        public async Task<IActionResult> CompRate(int id , Projects model)
        {
            
            var Project = db.Projects.Where(b => b.Id == model.Id).FirstOrDefault();
            Project.Result = model.Result;
            var Comp = db.compRegs.Where(c => c.Id == Project.CompId).FirstOrDefault();
            Comp.Result = model.Result;
            var user = await _userManager.Users.Where(u => u.Email == Comp.Email).FirstOrDefaultAsync();
            user.Result = model.Result;
            db.Update(Project);
            db.Update(Comp);
            db.SaveChanges();
            await _userManager.UpdateAsync(user);
            return RedirectToAction("JudgeDeg", "Judge");
        }
    }
}
