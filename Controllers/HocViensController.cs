using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiDangKiCSharp.Models;

namespace QuanLiDangKiCSharp.Controllers
{
    public class HocViensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HocViens
        public ActionResult Index()
        {
            return View(db.HocViens.ToList());
        }

        // GET: HocViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocVien hocVien = db.HocViens.Find(id);
            if (hocVien == null)
            {
                return HttpNotFound();
            }
            return View(hocVien);
        }

        // GET: HocViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HocViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHocVien,HoTen,NgaySinh,SoDienThoai,Email,TaiKhoan,MatKhau")] HocVien hocVien)
        {
            if (ModelState.IsValid)
            {
                db.HocViens.Add(hocVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hocVien);
        }

        // GET: HocViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocVien hocVien = db.HocViens.Find(id);
            if (hocVien == null)
            {
                return HttpNotFound();
            }
            return View(hocVien);
        }

        // POST: HocViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHocVien,HoTen,NgaySinh,SoDienThoai,Email,TaiKhoan,MatKhau")] HocVien hocVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hocVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hocVien);
        }

        // GET: HocViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocVien hocVien = db.HocViens.Find(id);
            if (hocVien == null)
            {
                return HttpNotFound();
            }
            return View(hocVien);
        }

        // POST: HocViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HocVien hocVien = db.HocViens.Find(id);
            db.HocViens.Remove(hocVien);
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

        // GET: HocVien/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: HocVien/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(HocVien model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra nếu tài khoản đã tồn tại
                var existingAccount = db.HocViens.SingleOrDefault(hv => hv.TaiKhoan == model.TaiKhoan);
                if (existingAccount != null)
                {
                    ViewBag.ErrorMessage = "Tài khoản đã tồn tại!";
                    return View(model);
                }

                // Thêm học viên vào cơ sở dữ liệu
                db.HocViens.Add(model);
                db.SaveChanges();

                // Sau khi đăng ký thành công, chuyển đến trang đăng nhập
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }
    }
}
