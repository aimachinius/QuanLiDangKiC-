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
    public class DangKyKhoaHocsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DangKyKhoaHocs
        public ActionResult Index()
        {
            if (Session["TenDangNhap"] == null)
            {
                return RedirectToAction("DangNhap", "User");
            }
            var dangKyKhoaHocs = db.DangKyKhoaHocs.Include(d => d.HocVien).Include(d => d.KhoaHoc);
            return View(dangKyKhoaHocs.ToList());
        }

        // GET: DangKyKhoaHocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangKyKhoaHoc dangKyKhoaHoc = db.DangKyKhoaHocs.Find(id);
            if (dangKyKhoaHoc == null)
            {
                return HttpNotFound();
            }
            return View(dangKyKhoaHoc);
        }

        // GET: DangKyKhoaHocs/Create
        public ActionResult Create()
        {
            
            ViewBag.MaHocVien = new SelectList(db.HocViens, "MaHocVien", "HoTen");
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHocs, "MaKhoaHoc", "TenKhoaHoc");
            return View();
        }

        // POST: DangKyKhoaHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDangKy,MaHocVien,MaKhoaHoc,NgayDangKy")] DangKyKhoaHoc dangKyKhoaHoc)
        {
            if (ModelState.IsValid)
            {
                db.DangKyKhoaHocs.Add(dangKyKhoaHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHocVien = new SelectList(db.HocViens, "MaHocVien", "HoTen", dangKyKhoaHoc.MaHocVien);
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHocs, "MaKhoaHoc", "TenKhoaHoc", dangKyKhoaHoc.MaKhoaHoc);
            return View(dangKyKhoaHoc);
        }

        // GET: DangKyKhoaHocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangKyKhoaHoc dangKyKhoaHoc = db.DangKyKhoaHocs.Find(id);
            if (dangKyKhoaHoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHocVien = new SelectList(db.HocViens, "MaHocVien", "HoTen", dangKyKhoaHoc.MaHocVien);
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHocs, "MaKhoaHoc", "TenKhoaHoc", dangKyKhoaHoc.MaKhoaHoc);
            return View(dangKyKhoaHoc);
        }

        // POST: DangKyKhoaHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDangKy,MaHocVien,MaKhoaHoc,NgayDangKy")] DangKyKhoaHoc dangKyKhoaHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dangKyKhoaHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHocVien = new SelectList(db.HocViens, "MaHocVien", "HoTen", dangKyKhoaHoc.MaHocVien);
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHocs, "MaKhoaHoc", "TenKhoaHoc", dangKyKhoaHoc.MaKhoaHoc);
            return View(dangKyKhoaHoc);
        }

        // GET: DangKyKhoaHocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangKyKhoaHoc dangKyKhoaHoc = db.DangKyKhoaHocs.Find(id);
            if (dangKyKhoaHoc == null)
            {
                return HttpNotFound();
            }
            return View(dangKyKhoaHoc);
        }

        // POST: DangKyKhoaHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DangKyKhoaHoc dangKyKhoaHoc = db.DangKyKhoaHocs.Find(id);
            db.DangKyKhoaHocs.Remove(dangKyKhoaHoc);
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
    }
}
