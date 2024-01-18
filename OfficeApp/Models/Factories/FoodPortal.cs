﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeApp.Models.Events;
using OfficeApp.Models.Interfaces;
using static OfficeApp.Models.FoodProvider;

namespace OfficeApp.Models.Factories
{
    public class FoodPortal : IPortal
    {
        List<FoodProvider> _foodProviders;
        private static FoodPortal _instance;
        
        private FoodProvider? _currentProvider;
        private FoodPortal()
        {
            _foodProviders = new List<FoodProvider>()
            {
                new BreakfastProvider(){Name = "Caffe del corso"},
                new BreakfastProvider(){Name = "StarCaffe"},
                new LunchProvider(){Name = "Da Mauro"},
                new LunchProvider(){Name = "Da Stefano"},
                new DinnerProvider(){Name = "Ristorante la sera"},
                new DinnerProvider(){Name = "Ristorante le stelle"}

            };
        }
        public static FoodPortal GetInstance()
        {
            if (_instance is null)
            {
                _instance = new FoodPortal();
            }
            return _instance;
        }
        public FoodProvider GetProvider()
        {
            TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
            Random random = new Random();
            var provider = _foodProviders
                .Where(provider => provider.OpenTime <= timeOfDay && provider.CloseTime >= timeOfDay)
                .OrderBy(_ => random.Next())
                .FirstOrDefault();
            //provider.OrderReady += OrderIsFinish;
            _currentProvider = provider;
            if (_currentProvider != null)
            {
                provider.OrderReady -= OrderIsFinish;
                provider.OrderReady += OrderIsFinish;
            }
            return provider;
        }
        public event EventHandler<OrderEventArgs<Food>> OrderOnWay;

        public void SendOrder(Order<Food> order)
        {
           // OrderOnWay.Invoke(this, new OrderEventArgs<Food>(order));
        }

        public async void OrderIsFinish(object sender, OrderEventArgs<Food> e) {
            //Dispose();
            //_currentProvider.Next();
            Console.WriteLine($"FoodPortal handling OrderReady event for order {e.Order.Id}");
            //SendOrder(e.Order);
            
        }

        public async Task<bool> Dispose()
        {
            if (_currentProvider != null)
            {
                _currentProvider.OrderReady -= OrderIsFinish;
                _currentProvider = null;
            }
            return true;
        }
    }
}
