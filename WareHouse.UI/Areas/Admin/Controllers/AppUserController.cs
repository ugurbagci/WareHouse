using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouse.Model.Entity;
using WareHouse.UI.Areas.Admin.Models.DTO;

namespace WareHouse.UI.Areas.Admin.Controllers
{
    public class AppUserController : BaseController
    {

        public ActionResult AddUser()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult AddUser(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Password = model.Password;
                user.Role = model.Role;
                user.Gender = model.Gender;
                db.AppUsers.Add(user);
                db.SaveChanges();
                ViewBag.ProcessCondition = 1;
                return View();
            }
            else
            {
                ViewBag.ProcessCondition = 2;
                return View();
            }
        }

        public ActionResult UserList()
        {
            List<UserDTO> model = db.AppUsers.Where(x => x.Status == WareHouse.Model.Enum.Status.Active || x.Status == WareHouse.Model.Enum.Status.Updated).Select(x => new UserDTO()
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                Email = x.Email,
                Password = x.Password,
                Role = x.Role,
                Gender = x.Gender
            }).ToList();

            return View(model);
        }

        public ActionResult UpdateUser(int id)
        {
            AppUser user = db.AppUsers.FirstOrDefault(x => x.ID == id);
            UserDTO model = new UserDTO();
            model.ID = user.ID;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.UserName = user.UserName;
            model.Email = user.Email;
            model.Password = user.Password;
            model.Role = user.Role;
            model.Gender = user.Gender;                        
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = db.AppUsers.FirstOrDefault(x => x.ID == model.ID);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Password = model.Password;
                user.Role = model.Role;
                user.Gender = model.Gender;

                user.Status = WareHouse.Model.Enum.Status.Updated;
                user.UpdateDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/AppUser/UserList");
            }
            else
            {
                return Redirect("/Admin/AppUser/UserList");
            }
        }

        public ActionResult DeleteUser(int id)
        {
            if (ModelState.IsValid)
            {
                AppUser appuser = db.AppUsers.FirstOrDefault(x => x.ID == id);
                appuser.Status = WareHouse.Model.Enum.Status.Deleted;
                appuser.DeleteDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/AppUser/UserList");
            }
            else
            {
                return Redirect("/Admin/AppUser/UserList");
            }
            
        }
    }
}
    
