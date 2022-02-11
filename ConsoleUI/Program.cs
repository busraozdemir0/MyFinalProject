using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemory çalışacak
            //ProductTest();
            //CategoryTest();

            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetProductDetails();

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    //iki tabloda dataları join ettik ve yan yana listeledik
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                }
            }
            else
                Console.WriteLine(result.Message);

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {


            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
            Console.WriteLine("*****Fiyatı 50 ile 100 arasında olanlar*****");
            var result = productManager.GetByUnitPrice(50, 100);
            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
            else Console.WriteLine(result.Message);

            Console.WriteLine("*****Category Id'si 2 olanlar******");
            var result1 = productManager.GetAllByCategoryId(2);
            if (result1.Success == true)
            {
                foreach (var product in result1.Data)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
            else Console.WriteLine(result1.Message);

        }
    }
}
