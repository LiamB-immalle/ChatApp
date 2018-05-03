using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class Bericht
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime Datum = DateTime.Now;
        public DateTime _Datum
        {
            get
            {
                return (Datum == DateTime.MinValue) ? DateTime.Now : Datum;
            }
            set
            {
                Datum = value;
            }
        }
    }
}