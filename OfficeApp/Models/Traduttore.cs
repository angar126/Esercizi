using OfficeApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models
{
    public class Traduttore
    {
        public string Name {  get; set; }
        public string Lingua {  get; set; }

        public Traduttore(string Name,string Lingua) 
        {
            this.Name = Name;
            this.Lingua = Lingua;
        }

        public string Translate(string text)
        {
            return $"[{Lingua}] {text}";
        }

    }
}
