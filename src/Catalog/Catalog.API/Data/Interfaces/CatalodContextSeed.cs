using System;
using System.Collections.Generic;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data.Interfaces
{
    public class CatalodContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection){
            bool existsProduct = productCollection.Find(p => true).Any();

            if (!existsProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>(){
                new Product{
                    Name = "Iphone X",
                    Summary = "abc",
                    Description = "abc",
                    ImageFile = "product-1.png",
                    Price = 950.000M,
                    Category = "Smart Phone"
                },
                new Product{
                    Name = "Sansung 10",
                    Summary = "abc",
                    Description = "abc",
                    ImageFile = "product-1.png",
                    Price = 840.000M,
                    Category = "Smart Phone"
                }
            };
        }
    }
}