// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        [Category("MISC")]
        [Title("Task 1")]
        [Description("Выдайте список всех клиентов, чей суммарный оборот (сумма всех заказов) превосходит некоторую величину X. Продемонстрируйте выполнение запроса с различными X (подумайте, можно ли обойтись без копирования запроса несколько раз)")]
        public void Linq1()
        {
            var minOrdersSum = 40000;

            var result = dataSource.Customers
                .Where(c => c.Orders.Sum(o => o.Total) >= minOrdersSum)
                .Select(c=> new { c.CompanyName, OrdersSum = c.Orders.Sum(o => o.Total) });

            ObjectDumper.Write($"Сумма больше {minOrdersSum}");
            ObjectDumper.Write(result);

            minOrdersSum = 50000;
            ObjectDumper.Write($"Сумма больше {minOrdersSum}");
            ObjectDumper.Write(result);
        }

        [Category("MISC")]
        [Title("Task 2")]
        [Description("Для каждого клиента составьте список поставщиков, находящихся в той же стране и том же городе. Сделайте задания с использованием группировки и без.")]
        public void Linq2()
        {
            var result = dataSource.Customers
                .GroupJoin(
                dataSource.Suppliers,
                c => new { c.Country,c.City},
                s => new {s.Country,s.City},
                (c,s)=>new {
                    Customer = c,
                    Suppliers = s
                });

            ObjectDumper.Write("С группировкой:");
            foreach (var c in result)
            {
                ObjectDumper.Write($"CustomerId: {c.Customer.CustomerID} " +
                    $"Поставщики: {string.Join(", ", c.Suppliers.Select(s => s.SupplierName))}");
            }

            var resultWithOutGroup = dataSource.Customers
                .Select(c => new { 
                Customer = c,
                Suppliers = dataSource.Suppliers
                .Where(s=>s.City.Equals(c.City) && s.Country.Equals(c.Country))
                });

            foreach (var customer in resultWithOutGroup)
            {
                ObjectDumper.Write($"CustomerId: {customer.Customer.CustomerID} " +
                    $"Поставщики: {string.Join(", ", customer.Suppliers.Select(s => s.SupplierName))}");
            }
        }

        [Category("MISC")]
        [Title("Task 3")]
        [Description("Найдите всех клиентов, у которых были заказы, превосходящие по сумме величину X")]
        public void Linq3()
        {
            var minOrderTotal = 5000;

            var result = dataSource.Customers
                .Where(c => c.Orders.Any(o => o.Total >= minOrderTotal))
                .Select(c=>c.CompanyName);
            ObjectDumper.Write(result);
        }

        [Category("MISC")]
        [Title("Task 4")]
        [Description("Выдайте список клиентов с указанием, начиная с какого месяца какого года они стали клиентами (принять за таковые месяц и год самого первого заказа)")]
        public void Linq4()
        {
            var result = dataSource.Customers
                .Where(c=>c.Orders.Any())
                .Select(c=>new { 
                    c.CompanyName,
                    FirstMonth = c.Orders.Min(o=>o.OrderDate).Month,
                    FirstYear = c.Orders.Min(o=>o.OrderDate).Year,
                });

            ObjectDumper.Write(result);
        }

        [Category("MISC")]
        [Title("Task 5")]
        [Description("Сделайте предыдущее задание, но выдайте список отсортированным по году, месяцу, оборотам клиента (от максимального к минимальному) и имени клиента")]
        public void Linq5()
        {
            var result = dataSource.Customers
                .Where(c => c.Orders.Any())
                .Select(c => new {
                    c.CompanyName,
                    FirstMonth = c.Orders.Min(o => o.OrderDate).Month,
                    FirstYear = c.Orders.Min(o => o.OrderDate).Year,
                    OrdersSum = c.Orders.Sum(o=>o.Total),
                })
                .OrderByDescending(c=>c.FirstYear)
                .ThenByDescending(c=>c.FirstMonth)
                .ThenByDescending(c=>c.OrdersSum)
                .ThenByDescending(c=>c.CompanyName);

            ObjectDumper.Write(result);
        }

        [Category("MISC")]
        [Title("Task 6")]
        [Description("Укажите всех клиентов, у которых указан нецифровой код или не заполнен регион или в телефоне не указан код оператора (для простоты считаем, что это равнозначно «нет круглых скобочек в начале»).")]
        public void Linq6()
        {
            var result = dataSource.Customers
                .Where(c=> string.IsNullOrWhiteSpace(c.Phone)
                || (c.PostalCode != null && c.PostalCode.Any(char.IsLetter))
                || !c.Phone.StartsWith("("))
                .Select(c=>new { c.CompanyName,c.PostalCode,c.Region,c.Phone});

            ObjectDumper.Write(result);
        }


        [Category("MISC")]
        [Title("Task 7")]
        [Description("Сгруппируйте все продукты по категориям, внутри – по наличию на складе, внутри последней группы отсортируйте по стоимости")]
        public void Linq7()
        {
            var result = dataSource.Products
                .GroupBy(p => p.Category)
                .Select(
                g=> new
                {
                    Category = g.Key,
                    Stocks = g.GroupBy(t => t.UnitsInStock)
                    .Select(h => new { 
                        InStock = h.Key,
                        Products = h.OrderBy(o => o.UnitPrice) 
                    })
                });

            foreach (var category in result)
            {
                ObjectDumper.Write($"{category.Category}");
                foreach (var strock in category.Stocks)
                {
                    ObjectDumper.Write($"\tНаличие: {strock.InStock}");
                    foreach (var product in strock.Products)
                    {
                        ObjectDumper.Write($"\t\t{product.ProductName} \t{product.UnitPrice}");
                    }
                }
            }
        }

        [Category("MISC")]
        [Title("Task 8")]
        [Description("Сгруппируйте товары по группам «дешевые», «средняя цена», «дорогие». Границы каждой группы задайте сами")]
        public void Linq8()
        {
            var max = dataSource.Products.Max(p=>p.UnitPrice);
            var min = dataSource.Products.Min(p=>p.UnitPrice);
            var diff = max - min;

            var middlePriceLowerBorder = max - diff / 3;
            var middlePriceUpperBorder = min + diff / 3;

            var result = dataSource.Products
                .GroupBy(p => p.UnitPrice < middlePriceLowerBorder ? "Cheap"
                : p.UnitPrice > middlePriceUpperBorder ? "High" : "Middle");

            //var result = new { 
            //    Cheap = dataSource.Products.Where(p=>p.UnitPrice < middlePriceLowerBorder), 
            //    High = dataSource.Products.Where(p=>p.UnitPrice > middlePriceUpperBorder),
            //    Middle = dataSource.Products.Where(p=>p.UnitPrice <= middlePriceUpperBorder && p.UnitPrice >= middlePriceLowerBorder)
            //};

            foreach (var item in result)
            {
                ObjectDumper.Write($"{item.Key}:");
                foreach (var product in item)
                {
                    ObjectDumper.Write($"\tПродукт: {product.ProductName} Цена: {product.UnitPrice}\n");
                }
            }
        }

        [Category("MISC")]
        [Title("Task 9")]
        [Description("Рассчитайте среднюю прибыльность каждого города (среднюю сумму заказа по всем клиентам из данного города) и среднюю интенсивность (среднее количество заказов, приходящееся на клиента из каждого города)")]
        public void Linq9()
        {
            var result = dataSource.Customers
                .GroupBy(c => c.City)
                .Select(c => new{
                    City = c.Key,
                    Avg = c.Average(g =>g.Orders.Average(t => t?.Total)),
                    Intens = c.Average(g=>g.Orders.Length)
                });

            ObjectDumper.Write(result);
        }

        [Category("MISC")]
        [Title("Task 10")]
        [Description("Сделайте среднегодовую статистику активности клиентов по месяцам (без учета года), статистику по годам, по годам и месяцам (т.е. когда один месяц в разные годы имеет своё значение).")]
        public void Linq10()
        {
            var result = dataSource.Customers
                 .Select(c => new
                 {
                     c.CustomerID,
                     Month = c.Orders.GroupBy(o => o.OrderDate.Month)
                                         .Select(g => new { Month = g.Key, OrdersCount = g.Count() }),
                     Year = c.Orders.GroupBy(o => o.OrderDate.Year)
                                         .Select(g => new { Year = g.Key, OrdersCount = g.Count() }),
                     YearAndMonth = c.Orders
                                         .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                                         .Select(g => new { g.Key.Year, g.Key.Month, OrdersCount = g.Count() })
                 });

            foreach (var record in result)
            {
                ObjectDumper.Write($"CustomerId: {record.CustomerID}");
                ObjectDumper.Write("\tMonths:\n");
                foreach (var ms in record.Month)
                {
                    ObjectDumper.Write($"\t\tMonth: {ms.Month} Orders count: {ms.OrdersCount}");
                }
                ObjectDumper.Write("\tYears:\n");
                foreach (var ys in record.Year)
                {
                    ObjectDumper.Write($"\t\tYear: {ys.Year} Orders count: {ys.OrdersCount}");
                }
                ObjectDumper.Write("\tYearAndMonth:\n");
                foreach (var ym in record.YearAndMonth)
                {
                    ObjectDumper.Write($"\t\tYear: {ym.Year} Month: {ym.Month} Orders count: {ym.OrdersCount}");
                }
            }
        }
    }
}