﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models
{
    public class BreakfastProvider : FoodProvider
    {
        public override TimeSpan OpenTime => new(07, 00, 00);
        public override TimeSpan CloseTime => new(07, 00, 00);

        public BreakfastProvider()
        {
            ListOfItems = new List<Food>{
             new Food("Caffee", TimeSpan.FromSeconds(3)){ Price = 1},
             new Food("Cappuccino", TimeSpan.FromSeconds(4)){ Price = 1},
             new Food("Brioches", TimeSpan.FromSeconds(2)){ Price = 1},
            };
        }
    }
}
