﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //poi dto

        public Product(Product product)
        {
            Id = product.Id;
            Name = product.Name;
        }
        public Product() { }
    }
}
