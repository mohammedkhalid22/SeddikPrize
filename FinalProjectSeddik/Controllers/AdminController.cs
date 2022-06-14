using FinalProjectSeddik.Data;
using FinalProjectSeddik.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSeddik.Controllers
{
    public class AdminController : Controller
    {
        private AppDbContext _App;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        public AdminController(AppDbContext App, UserManager<ApplicationUser> applicationUser, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _App = App;
            _userManager = applicationUser;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        
        public IActionResult Index(string id)
        {
           // var contacts = _App.ContactUs.ToList();
            int Comps = 0;
            int Judges = 0;
            foreach (var item in _roleManager.Roles)
            {
                if (item.Name == "Comp")
                {
                    Comps++;
                }
                if (item.Name == "Judge")
                {
                    Judges++;
                }
            }
            ViewBag.CompsCount = Comps;
            ViewBag.JudgesCount = Judges;
            ViewBag.compReg = _App.compRegs.Where(b=>b.IsAccepted==false).ToList();
           // ViewBag.contact = _App.ContactUs.Where(r => r.Id == id).FirstOrDefault();
            //ViewBag.requests = _App.ContactUs.Where(r => r.Id == id).FirstOrDefault();
            return View();
        }
        //public IActionResult Index()

        public  IActionResult CompRequest(int id)
        {
            var RequestComp = _App.compRegs.Where(d => d.Id == id).FirstOrDefault();
            return View(RequestComp);
        }
        [HttpPost]
        public async Task<IActionResult> CompRequest(int id,string fake)
        {
            var requests = _App.compRegs.Where(r => r.Id == id).FirstOrDefault();
            var user = _userManager.Users.Where(u => u.Email == requests.Email).FirstOrDefault();
            requests.IsAccepted = true;
            user.IsAccepted = true;
            await _userManager.RemoveFromRoleAsync(user, "User");
            await _userManager.AddToRoleAsync(user, "Comp");
            _App.SaveChanges();
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index","Admin");
        }

        //public IActionResult Contact(string id)
        //{
        //    var contact = _App.ContactUs.Where(d => d.Id == id).FirstOrDefault();
           
        //    return View(contact);
        //}
        public IActionResult Result()
        {
            var result = _App.compRegs.ToList();
            return View(result);
        }
        public  IActionResult UserMangment()
        {
            var users = _userManager.Users.Select(user => new UserVm
            {
                Id = user.Id,
                Name = user.Name,
                Specialization = user.Specialization,
                Email = user.Email,
                user = user
            }).ToList();
            foreach (var user in users)
            {
                user.Roles = _userManager.GetRolesAsync(user.user).Result;
            }
            return View(users);
        }


        public IActionResult JopSelction(string id)
        {

            var JopSelction = _userManager.Users.Where(x => x.Id == id).FirstOrDefault();

            return View(JopSelction);
        }
        [HttpPost]
        public async Task<IActionResult> JopSelction(string id, ApplicationUser _user)
        {
            var user = _userManager.Users.Where(x => x.Id == id).FirstOrDefault();

            user.Specialization = _user.Specialization;

            var role = _userManager.GetRolesAsync(user).Result[0];
            if (_user.Role == "متحكم")
            {
                await _userManager.RemoveFromRoleAsync(user, role);
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else if (_user.Role == "مستخدم")
            {
                await _userManager.RemoveFromRoleAsync(user, role);
                await _userManager.AddToRoleAsync(user, "User");
            }
            else if (_user.Role == "مصحح")
            {
                await _userManager.RemoveFromRoleAsync(user, role);
                await _userManager.AddToRoleAsync(user, "Judge");
            }

            await _userManager.UpdateAsync(user);

            return RedirectToAction("UserMangment");
        }

        public IActionResult CompInfo(string id)
        {
            var CompInfo = _userManager.Users.Where(d => d.Id == id).FirstOrDefault();

            return View(CompInfo);
        }
        public IActionResult JudgeInfo(string id)
        {
            var JudgeInfo = _userManager.Users.Where(d => d.Id == id).FirstOrDefault();

            return View(JudgeInfo);
        }
        public IActionResult AdminInfo(string id)
        {
            var AdminInfo = _userManager.Users.Where(d => d.Id == id).FirstOrDefault();

            return View(AdminInfo);
        }
    }
}
