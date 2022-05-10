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
using Microsoft.AspNetCore.Http;

namespace food_manager.Controllers
{
    public class UsersController : Controller
    {
        private readonly food_managerContext _context;

        public UsersController(food_managerContext context)
        {
            _context = context;
        }

        //画面表示
        public IActionResult User()
        {
            return View();
        }


        //ログイン
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Name,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                IQueryable<User> query = from u in _context.Users
                                         where u.Name == user.Name &&
                                               u.Password == user.Password
                                       select new User
                                       {
                                          Id = u.Id,
                                          Name = u.Name,
                                          Password = u.Password,
                                       };
                int Id = query.Select(q => q.Id).FirstOrDefault();
                String Name = query.Select(q => q.Name).FirstOrDefault();
                String Password = query.Select(q => q.Password).FirstOrDefault();

                if (Name == user.Name && Password == user.Password)
                {
                    // ユーザー認証 成功
                    HttpContext.Session.SetString("Name", Name);
                    HttpContext.Session.SetInt32("Id", Id);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // ユーザー認証 失敗
                    this.ModelState.AddModelError(string.Empty, "指定されたユーザー名またはパスワードが正しくありません。");
                    return View(user);
                }
            }
            return View("User");
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
              return View("User");
        }

        //パスワード再設定
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Resetting([Bind("Email")] User user)
        {
            if (ModelState.IsValid)
            {
                IQueryable query = from u in _context.Users
                                   select new
                                   {
                                       u.Name,
                                       u.Password,
                                   };
            }
            return View(user);
        }

        //ログアウト
        [Authorize]
        public ActionResult Logout()
        {
            return View();
        }


    }
}
