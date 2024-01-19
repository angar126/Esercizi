using OfficeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp
{
    public class FirstTranslationProvider : TranslationProvider
    {
        public FirstTranslationProvider()
        {
            ListOfItems = new List<Translation>{
             new Translation("English", TimeSpan.FromSeconds(5)){ Price = 1},
             new Translation("Spanish", TimeSpan.FromSeconds(5)){ Price = 1},
             new Translation("French", TimeSpan.FromSeconds(2)){ Price = 1}
            };
        }
    }
}
