using DataLayer.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Translator:IProduct
    {
        public int Id { get; set; }
       
        public string Name { get; set ; }

        public string Language { get; set; }
        public decimal Price { get; set; }
        public bool IsPrepared { get; set; }
        public bool IsBeingPrepared { get; set; }
        public TimeSpan PreparationTime { get; set; }
       
    }
}
