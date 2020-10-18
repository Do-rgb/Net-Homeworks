// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SampleSupport;
using Task;
using Task.Data;

// Version Mad01

namespace SampleQueries
{
    [Title("LINQ Module")]
    [Prefix("Linq")]
    public class LinqSamples : SampleHarness
    {
        private readonly DataSource dataSource = new DataSource();

        private bool ValidateZipCode(string val)
        {
            long number;
            return long.TryParse(val, out number);
        }

        private bool ValidatePhone(string phone)
        {
            var pattern = @"^(\([0-9]\))+?";
            return Regex.IsMatch(phone, pattern);
        }

        private List<GroupPriceEntity> SortProductsByPrice()
        {
            var sortedProducts = new List<GroupPriceEntity>();

            foreach (var prod in dataSource.Products)
                if (prod.UnitPrice <= 20M)
                    sortedProducts.Add(new GroupPriceEntity {product = prod, Group = 0});
                else if ((prod.UnitPrice > 20M) && (prod.UnitPrice <= 50M))
                    sortedProducts.Add(new GroupPriceEntity {product = prod, Group = 1});
                else
                    sortedProducts.Add(new GroupPriceEntity {product = prod, Group = 2});

            return sortedProducts;
        }


        [Category("Restriction Operators")]
        [Title("Task 1")]
        [Description("Описание задачи на русском языке")]
        public void LinqForExample()
        {
            var customers = dataSource
                .Customers
                .Select(c => c);

            //Он умеет выполнять запросы самостоятельно. Так же умеет делать foreach по коллекции. 
            //Проверьте это все запустив приложение и сделав запуск запроса
            ObjectDumper.Write(customers);
        }
    }
}