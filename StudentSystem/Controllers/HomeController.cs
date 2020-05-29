using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using StudentSystem.Models;

namespace StudentSystem.Controllers
{

    public class HomeController : Controller
    {
        Student m;
        public static Student active_student = new Student();

       SisDbContext context;
        public HomeController(SisDbContext c)
        {
            context = c;
        }

        public IActionResult Index()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Sis(Student student)
        {
            m = context.Students.FirstOrDefault(i => i.StudentNumber == student.StudentNumber);
            
            foreach(var item in context.Students)
            {
                if(item.StudentNumber==student.StudentNumber && item.Password == student.Password)
                {
                    active_student = item;
                    return View(active_student);
                }
            }
            ViewBag.Message = "Kullanici adi veya sifrenizi kontrol ediniz!";
             return View("Index");
            
        }

        public IActionResult DersEkleme()
        {

            return View(context.Dersler.ToList());
        }
        [HttpPost]
        public IActionResult DersEkleme(List <Ders> ders)
        {

            return View(context.Dersler.ToList());
        }

        public IActionResult DersProgrami()
        {
          
            return View(context.Dersler.ToList());
        }

        public IActionResult DersSilme(int cid)
        {
            StudentDers ders = context.StudentDersler.FirstOrDefault(i => i.DersId == cid && i.StudentId == active_student.StudentId);
            context.Remove(ders);
            context.SaveChanges();
            var dersler = from n in context.Dersler
                          join mc in context.StudentDersler
                          on n.DersId equals mc.DersId
                          where mc.StudentId == active_student.StudentId
                          select n;
            return View("SecilenDersler",dersler.ToList());
        }
        [HttpPost]
        public IActionResult SecilenDersler(List<Ders> ders)
        {
            int x = 4;
            for(int i=0; i < ders.Count(); i++)
            {
                if(ders[i].chechboxAnswer == true)
                {
                    context.StudentDersler.Add(new StudentDers {StudentId=active_student.StudentId ,DersId=ders[i].DersId });
                    context.SaveChanges();
                }

            }
            
            var dersler = from n in context.Dersler
                          join mc in context.StudentDersler
                          on n.DersId equals mc.DersId
                          where mc.StudentId == active_student.StudentId
                          select n;

            return View(dersler.ToList());
        }
            public IActionResult SecilenDersler()
        {

            var dersler = from n in context.Dersler
                          join mc in context.StudentDersler
                          on n.DersId equals mc.DersId
                          where mc.StudentId == active_student.StudentId
                          select n;
            return View(dersler.ToList());
        }
    }
}