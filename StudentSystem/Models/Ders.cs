using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class Ders
    {
        public int DersId { get; set; }
        public string DersAdi{ get; set; }
        public string Ogrt { get; set; }
        public string DersKodu { get; set; }
        public string DersSaati { get; set; }
        public string DersDay { get; set; }
        public bool chechboxAnswer { get; set; }
        public List<StudentDers> StudentDersler { get; set; }

    }
}
