using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class DbInitializer
    {
        public static void InitializeDb(IApplicationBuilder app)
        {
            SisDbContext context = app.ApplicationServices.GetRequiredService<SisDbContext>();

            context.Database.Migrate();
            if (context.Dersler.Any() == false)
            {
                var ders = new[]
                {
                     new Ders() { DersAdi = "Digital Image Processing", DersKodu="Cen401",Ogrt="Mustafa Oral",DersSaati="17.15",DersDay="Pazartesi" },
                     new Ders() { DersAdi = "Introduction to Data Mining",  DersKodu="Cen402",Ogrt="Selma Ayşe Özel ",DersSaati="20.15",DersDay="Pazartesi"  },
                    new Ders() { DersAdi = "Web Programing", DersKodu="Cen403",Ogrt="Serkan Kartal",DersSaati="17.15",DersDay="Salı"  },
                    new Ders() { DersAdi = "Introduction To Java Programming",  DersKodu="Cen404",Ogrt="Havva Esin Ünal",DersSaati="17.15",DersDay="Çarşamba"  },
                    new Ders() { DersAdi = "Algorithms",  DersKodu="Cen405",Ogrt="Buse Melis Özyıldırım",DersSaati="17.15",DersDay="Perşembe"  },
                    new Ders() { DersAdi = "Microprocessors",  DersKodu="Cen406",Ogrt="Mustafa Oral",DersSaati="17.15",DersDay="Cuma"  }
                    
                   
                };
                context.Dersler.AddRange(
                   ders
                 );
                var student = new[]
               {
                   new Student() { Name = "Mesut", Surname = "Gedik", StudentNumber = "2015556031",  Password = "12343" },
                   new Student() { Name = "Iremsu", Surname = "Savas", StudentNumber = "2015556058",  Password = "123456" },
                   new Student() { Name = "Berkay", Surname = "Ozcelik", StudentNumber = "2014556050",  Password = "12347" },
                   new Student() { Name = "Erdinc", Surname = "Ugur", StudentNumber = "2014556040",  Password = "12348" },
                   new Student() { Name = "Muhsin", Surname = "Gedik", StudentNumber = "2014556030",  Password = "12349" },
                   new Student() { Name = "Eren", Surname = "Cetin", StudentNumber = "2015556020",  Password = "12343" },
                   new Student() { Name = "Melike", Surname = "Subasi", StudentNumber = "2014556044",  Password = "12349" },
                   new Student() { Name = "Petek", Surname = "Yildiz", StudentNumber = "2015556051",  Password = "12343" }
                };
                context.Students.AddRange(

                   student

                );
                //var studentdders = new[]
                //{
                //    new StudentDers {Student=student[0],Ders=ders [0]},
                //    new StudentDers {Student=student[1],Ders=ders [1]},
                //    new StudentDers {Student=student[2],Ders=ders [2]},
                //    new StudentDers {Student=student[3], Ders=ders [3]},
                //    new StudentDers {Student=student[0],Ders=ders [1]},
                //    new StudentDers {Student=student[0],Ders=ders [2]},
                //    new StudentDers {Student=student[0],Ders=ders [3]},
                //    new StudentDers {Student=student[0],Ders=ders [4]},
                //    new StudentDers {Student=student[0],Ders=ders [5]}


                //};
                //context.StudentDersler.AddRange(studentdders);
             
                context.SaveChanges();

            }
        }
    
    }
}
