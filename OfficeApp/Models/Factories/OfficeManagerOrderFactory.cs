using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeApp.Models.Interfaces;

namespace OfficeApp.Models.Factories
{
    public class OfficeManagerOrderFactory : AbstractFactoryServices
    {
        //public IOffice Office { get; set; }
        
        public override DeliveryOffice CreateFoodOffice()
        {
            return DeliveryOffice.GetInstance();
        }

        public override TranslationOffice CreateTranslateOffice()
        {
            return TranslationOffice.GetInstance();
        }
    }
}
