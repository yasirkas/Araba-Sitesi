using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Araba.Models
{
    public class Model
    {
        public int ModelId { get; set; }
        public string ModelAd { get; set; }
        public int MarkaId { get; set; }
        public virtual Marka Marka { get; set; }
    }
}