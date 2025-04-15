using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiDangKiCSharp.Models;

namespace QuanLiDangKiC_.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        public ActionResult Index()
        {
            if (Session["TenDangNhap"] == null)
            {
                return RedirectToAction("DangNhap", "User");
            }
            var users = db.Users.Include(u => u.HocVien);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
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

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.MaHocVien = new SelectList(db.HocViens, "MaHocVien", "HoTen");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenDangNhap,MatKhau,VaiTro,MaHocVien")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHocVien = new SelectList(db.HocViens, "MaHocVien", "HoTen", user.MaHocVien);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.MaHocVien = new SelectList(db.HocViens, "MaHocVien", "HoTen", user.MaHocVien);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenDangNhap,MatKhau,VaiTro,MaHocVien")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHocVien = new SelectList(db.HocViens, "MaHocVien", "HoTen", user.MaHocVien);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
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

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: NguoiDung/DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }

        // POST: NguoiDung/DangNhap
        [HttpPost]
        public ActionResult DangNhap(string tenDangNhap, string matKhau)
        {
            var nd = db.Users.SingleOrDefault(x => x.TenDangNhap == tenDangNhap && x.MatKhau == matKhau);
            if (nd != null)
            {
                Session["TenDangNhap"] = nd.TenDangNhap;
                Session["VaiTro"] = nd.VaiTro; // true = Admin, false = Học viên
                Session["MaHocVien"] = nd.MaHocVien; // Lưu nếu cần dùng

                return RedirectToAction("Index", "Home"); // Vào trang chính
            }

            ViewBag.ThongBao = "Sai tên đăng nhập hoặc mật khẩu!";
            return View();
        }

        // Đăng xuất
        public ActionResult DangXuat()
        {
            Session["TenDangNhap"] = null;
            Session["VaiTro"] = null;
            return RedirectToAction("DangNhap", "User");
        }

        // GET: Users/DangKy
        public ActionResult DangKy()
        {
            //ViewBag.MaHocVien = new SelectList(db.HocViens, "MaHocVien", "HoTen");     
            return View();
        }

        // Fixing the issue in the DangKy method where MaHocVien is being assigned a string instead of an int.
        // Updated the code to generate an integer ID instead of a GUID string.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy([Bind(Include = "TenDangNhap,MatKhau,MaHocVien")] User user)
        {
            if (ModelState.IsValid)
            {
                // Generate a new integer ID for MaHocVien
                HocVien hv = new HocVien
                {
                    MaHocVien = db.HocViens.Any() ? db.HocViens.Max(h => h.MaHocVien) + 1 : 1, // Increment max ID or start from 1
                    HoTen = HoTenHocVien
                };
                db.HocViens.Add(hv);
                db.SaveChanges();

                // Create a user account
                user.MaHocVien = hv.MaHocVien;
                user.VaiTro = false; // Default role is student
                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("DangNhap");
            }

            return View(user);
        }

    }

}

