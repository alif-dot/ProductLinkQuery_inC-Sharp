﻿namespace ProductLinkQ
{
    class Program
    {
        static void Main(String[] args)
        {
            var Categories = new Category[]
            {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Shirt"
                },

                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Pant"
                }
            };

            var Models = new ProductModel[]
            {
                new ProductModel
                {
                    ModelID = 1,
                    ModelName = "Man's Shirt",
                },

                new ProductModel
                {
                    ModelID = 2,
                    ModelName = "Man's Pant",
                },

                new ProductModel
                {
                    ModelID = 3,
                    ModelName = "Woman's Shirt",
                },

                new ProductModel
                {
                    ModelID = 4,
                    ModelName = "Woman's Pant",
                },
            };

            var Products = new Product[]
            {
                new Product
                {
                    ProductId = 1,
                    ProductName = "Polo Shirt",
                    ProductNumber = 1213,
                    Color = "Blue",
                    FixedPrice = 700,
                    CategoryID = 1,
                    ModelID = 1
                },

                new Product
                {
                    ProductId = 2,
                    ProductName = "Casual Pant",
                    ProductNumber = 1214,
                    Color = "Gray",
                    FixedPrice = 800,
                    CategoryID = 2,
                    ModelID = 2
                },

                new Product {
                    ProductId = 3,
                    ProductName = "Formal Shirt",
                    ProductNumber = 1222,
                    Color = "White",
                    FixedPrice = 500,
                    CategoryID = 1,
                    ModelID = 1
                },

                new Product
                {
                    ProductId = 4,
                    ProductName = "Formal Pant",
                    ProductNumber = 1223,
                    Color = "Black",
                    FixedPrice = 600,
                    CategoryID = 2,
                    ModelID = 2
                },

                new Product
                {
                    ProductId = 5,
                    ProductName = "Polo Shirt",
                    ProductNumber = 1231,
                    Color = "Orange",
                    FixedPrice = 700,
                    CategoryID = 1,
                    ModelID = 3
                },

                new Product
                {
                    ProductId = 6,
                    ProductName = "Casual Pant",
                    ProductNumber = 1232,
                    Color = "Red",
                    FixedPrice = 800,
                    CategoryID = 2,
                    ModelID = 4
                },

                new Product
                {
                    ProductId = 7,
                    ProductName = "Formal Shirt",
                    ProductNumber = 1241,
                    Color = "White",
                    FixedPrice = 500,
                    CategoryID = 1,
                    ModelID = 3
                },

                new Product
                {
                    ProductId = 8,
                    ProductName = "Formal Pant",
                    ProductNumber = 1242,
                    Color = "Black",
                    FixedPrice = 600,
                    CategoryID = 2,
                    ModelID = 4}
            };

            /*============JoiningTable=============*/
            Console.WriteLine("--------------Joining Three Table-----------");
            var Garments = from p in Products
                           join c in Categories
                           on p.CategoryID equals c.CategoryID
                           join m in Models
                           on p.ModelID equals m.ModelID
                           select new { Product = p.ProductId, Category = c.CategoryName, Model = m.ModelName, p.ProductName, p.Color, p.FixedPrice };

            foreach (var x in Garments)
            {
                Console.WriteLine($"{x.ProductName}\t{x.Model}\t{x.Color}\t{x.FixedPrice}");
            }

            /*============Select,where=============*/
            Console.WriteLine("\n--------Select,where ProductName= Polo Shirt--------");
            var pInfo = Products
            .Where(sg => String.Equals(sg.ProductName, "Polo Shirt"))

            .Select(pd => new {
                pd.ProductId,
                pd.ProductName,
                pd.ProductNumber,
                pd.Color,
                pd.FixedPrice,
                pd.ModelID
            });
            foreach (var info in pInfo)
            {
                Console.WriteLine(info);
            }

            /*==========Group By============*/
            Console.WriteLine("\n--------Group By--------");
            var groupPD = from pd in Products
                          group pd by pd.ProductName;

            foreach (var g in groupPD)
            {
                Console.WriteLine(g.Key + " = " + g.Count());
            }

            /*======Order By======*/

            Console.WriteLine("\n--------OrderBy with descending--------");
            var orderByProduct = from pd in Products
                                 orderby pd.ProductName descending
                                 select pd;

            foreach (var pds in orderByProduct)
            {
                Console.WriteLine(pds.ProductName);
            }

            Console.WriteLine("\n--------ThenBy with Descending--------");

            var product = Products
                .OrderBy(s => s.ProductName)
                .ThenByDescending(s => s.Color);

            foreach (var pd in product)
            {
                Console.WriteLine("ProductName: {0}, Color:{1} \n", pd.ProductName, pd.Color);
            }

            /*==========Aggregate Function =============*/
            Console.WriteLine("--------------Use of Aggregate-----------");
           
            //Count
            var totalProducts = Products.Count();

            Console.WriteLine("\nNumber of Total Products: {0} \n", totalProducts);


            /*========== This Program done by =============*/
            Console.WriteLine("\n========== This Program done by =============");
            Console.WriteLine("\nMD. Easin Alif, Software Engineer from IsDB-BISEW IT Scholarship Program");

            Console.ReadKey();
        }
    }
}