using OfficeApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeApp.Models.Factories;

namespace OfficeApp.Models
{
    public class OfficeManager : IOrderManager
    {
        private AbstractFactoryServices _orderFactory;

        public OfficeManager(OfficeManagerOrderFactory orderFactory)
        {
            _orderFactory = orderFactory;
        }
        public FoodProvider ProcessFood()
        {
            var foodOffice = _orderFactory.CreateFoodOffice();
            var foodProvider = foodOffice.GetProvider();
            return foodProvider;
        }
        public void ProcessTranslate()
        {
            //var translationOrderFactory = _orderFactory.CreateTranslateOffice();
            //var translationOrder = translationOrderFactory.CreateTranslationOrder();
        }
    }
}
