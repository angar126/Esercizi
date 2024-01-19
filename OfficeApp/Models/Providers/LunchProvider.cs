using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models.Providers
{
    public class LunchProvider : FoodProvider
    {
        public override TimeSpan OpenTime => new(11, 00, 00);
        public override TimeSpan CloseTime => new(14, 00, 00);

        public LunchProvider()
        {
            ListOfItems = new List<Food>{
             new Food("Cotoletta", TimeSpan.FromSeconds(4)){ Price = 1},
             new Food("Riso", TimeSpan.FromSeconds(8)){ Price = 2},
             new Food("Tiramisu", TimeSpan.FromSeconds(2)){ Price = 3},
            };
        }
    }
}
