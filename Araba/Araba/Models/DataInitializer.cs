using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Araba.Models
{
    public class DataInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var sehirler = new List<Sehir>()
            {
                new Sehir() {SehirAd="İSTANBUL"},
                new Sehir() {SehirAd="ANKARA"},
                new Sehir() {SehirAd="İZMİR"}
            };
            foreach (var item in sehirler)
            {
                context.Sehirs.Add(item);
            }
            context.SaveChanges();
            var durum = new List<Durum>()
            {
                new Durum() {DurumAd="KİRALIK"},
                new Durum() {DurumAd="SATILIK"}
            };
            foreach (var item in durum)
            {
                context.Durums.Add(item);
            }
            context.SaveChanges();
            var marka = new List<Marka>()
            {
                  new Marka() {MarkaAd="BMW"},
                  new Marka() {MarkaAd="MERCEDES"},
                  new Marka() {MarkaAd="AUDİ"}
            };
            foreach (var item in marka)
            {
                context.Markas.Add(item);
            }
            context.SaveChanges();
            var model = new List<Model>()
            {
                new Model() {ModelAd="520",MarkaId=1},
                new Model() {ModelAd="X5",MarkaId=1},
                new Model() {ModelAd="A180",MarkaId=2},
                new Model() {ModelAd="Q7",MarkaId=3}
            };
            foreach (var item in model)
            {
                context.Models.Add(item);
            }
            context.SaveChanges();
            var ilan = new List<Ilan>()
            {
                new Ilan() {MarkaId=1, Aciklama="Araba Temiz",IlanNo="A125",Fiyat=3000,Tarih="24/01/2022",Kilometre=10000,ModelYili=2012,YakitTuru="Benzin",VitesTuru="Düz Vites",DurumId=1,ModelId=1,Username="yaso",SehirId=1,Telefon="123123"},
                new Ilan() {MarkaId=3, Aciklama="Araba Temizdir, sıkıntısız",IlanNo="A150",Fiyat=7000,Tarih="21/01/2022",Kilometre=10000,ModelYili=2017,YakitTuru="LPG",VitesTuru="Düz Vites",DurumId=2,ModelId=4,Username="taso",SehirId=1,Telefon="666554"}

            };
            foreach (var item in ilan)
            {
                context.Ilans.Add(item);
            }
            context.SaveChanges();
            var resim = new List<Resim>()
            {
                new Resim() {ResimAd="a1.jpg",IlanId=1},
                new Resim() {ResimAd="q2.jpg",IlanId=1},
                new Resim() {ResimAd="q2.jpg",IlanId=2}
            };
            foreach (var item in resim)
            {
                context.Resims.Add(item);
            }
            context.SaveChanges();


            base.Seed(context);
        }
    }
}