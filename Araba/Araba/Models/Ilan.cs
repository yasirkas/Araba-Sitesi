using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Araba.Models
{
    public class Ilan
    {
        public string IlanNo { get; set; }
        public string Aciklama { get; set; }
        public double Fiyat { get; set; }
        public string Tarih { get; set; }
        public int Kilometre { get; set; }
        public int ModelYili { get; set; }
        public string YakitTuru { get; set; }
        public string VitesTuru { get; set; }
        public string Username { get; set; }
        public string Telefon { get; set; }
        public int DurumId { get; set; }
        public Durum Durum { get; set; }

        public int MarkaId { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int SehirId { get; set; }
        public Sehir Sehir { get; set; }
        public List<Resim> Resims { get; set; }
    }
}