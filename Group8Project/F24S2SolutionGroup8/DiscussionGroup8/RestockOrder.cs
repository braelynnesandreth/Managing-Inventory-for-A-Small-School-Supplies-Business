﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
   
        public class RestockOrder
        {

            [Key]
            public int RestockOrderId { get; set; }
            public DateTime Date { get; set; }
            public string Status { get; set; }

            public Product Product { get; set; }
            public Supplier Supplier { get; set; }
            public Manager Manager { get; set; }

            public RestockOrder() { }
            public RestockOrder(DateTime date, string status, Product product, Supplier supplier, Manager manager)
            {
                Date = date;
                Status = status;
                Product = product;
                Supplier = supplier;
                Manager = manager;
            }
        }
    }
