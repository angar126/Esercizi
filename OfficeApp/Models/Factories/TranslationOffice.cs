using OfficeApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models.Factories
{
    public class TranslationOffice : IOffice
    {
        private static TranslationOffice _instance;
        private TranslationOffice() { }
        //public IPortal CreateFoodOrder()
        //{
        //    return new TranslationPortal();
        //}
        public static TranslationOffice GetInstance()
        {
            if (_instance is null)
            {
                _instance = new TranslationOffice();
            }
            return _instance;
        }
    }
}
