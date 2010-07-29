using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acme.Data;
using Acme.Model;
using ACME.Repository;


namespace Acme.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting...");
            SampleMethod(new ProductRepository());
            System.Console.WriteLine("FIDAD!");
            System.Console.ReadKey();
        }

        private static void SampleMethod(IRepository<Product,int?> productRepository)
        {
            SessionProvider.RebuildSchema();
            
            //Create a Product
            var pNew = new Product { ProductName = "Canned Salmon" };
            productRepository.Save(pNew);

            //Get a Product
            var pGet = productRepository.GetById(pNew.ProductId);

            //Update a Product
            pGet.ProductName = "Canned Tuna";
            productRepository.Save(pGet);

            //Delete a Product
            productRepository.Delete(pNew);
        }
    }
}
