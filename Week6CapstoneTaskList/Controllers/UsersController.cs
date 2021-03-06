﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Week6CapstoneTaskList.Data;
using Week6CapstoneTaskList.Domain.Models;

namespace Week6CapstoneTaskList.Controllers
{
    
    public class UsersController : Controller
    {
        
        private Week6CapstoneTaskListContext db = new Week6CapstoneTaskListContext();
        [Authorize]
        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        [Authorize]
        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [Authorize]
        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
        [Authorize]
        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [Authorize]
        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        [Authorize]
        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [Authorize]
        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [AllowAnonymous]
        public ActionResult LogIn()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("LogIn")]
        public ActionResult LogIn(string UserName, string Password)
        {
            User user = db.Users.FirstOrDefault(u => u.Email == UserName && u.Password == Password);
            if (user != null)
            {
                HttpCookie UserLogin = new HttpCookie("UserLogin");
                if (Request.Cookies["UserLogin"] != null)
                {
                    UserLogin = Request.Cookies["UserLogin"];   
                }
                UserLogin.Value = user.Id.ToString();
                
                Response.Cookies.Add(UserLogin);

                var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Email, user.Email)
                },
                "ApplicationCookie");

                return RedirectToAction("Index","Tasks");
            }        
            return RedirectToAction("LogIn");            
        }
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("LogOut")]
        public ActionResult LogOut()
        {
            HttpCookie UserLogin = new HttpCookie("UserLogin");
            if (Request.Cookies["UserLogin"] != null)
            {
                UserLogin = null;
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
