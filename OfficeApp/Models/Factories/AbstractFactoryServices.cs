using OfficeApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models.Factories
{
    public abstract class AbstractFactoryServices
    {
        public abstract DeliveryOffice CreateFoodOffice();
        public abstract TranslationOffice CreateTranslateOffice();
    }
}
