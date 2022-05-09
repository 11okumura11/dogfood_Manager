#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using food_manager.Models.Data;
using food_manager.Models;

namespace food_manager.Controllers
{
    public class UsersController : Controller
    {
        private readonly food_managerContext _context;

        public UsersController(food_managerContext context)
        {
            _context = context;
        }

        public IActionResult UserSetting()
        {
            return View();
        }


        //ログイン
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Name,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                IQueryable query = from u in _context.Users
                                   select new
                                   {
                                      Name = u.Name,
                                      Password = u.Password,
                                   };
            }
            return View(user);
        }

        //ユーザー新規登録
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                var query = from u in _context.Users
                            select u.Id;

                _context.Add(new User
                {
                    Id = query.Max() + 1,
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    CreatedAt = DateTime.Now
                });

                // SaveChangesが呼び出された段階で初めてInsert文が発行される
                _context.SaveChanges();
                return RedirectToAction("UserSetting");
            }
              return View(user);
        }

    }
}
