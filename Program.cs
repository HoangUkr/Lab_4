using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        public class Product
        {
            public int id;
            public string name;
            public float price;
            public int count;
            public string date;
            public int id_company;
            public int id_category;
            public Product(int _id, string _name, float _price, int _count, string _date, int _id_company, int _id_category)
            {
                this.id = _id;
                this.name = _name;
                this.price = _price;
                this.date = _date;
                this.count = _count;
                this.id_company = _id_company;
                this.id_category = _id_category;
            }
            public override string ToString()
            {
                return "id = " + this.id.ToString() + "; name = " + this.name + "; price = " + this.price.ToString() + "; count = " + this.count.ToString() + "; company id= " + this.id_company.ToString() + "; category id = " + this.id_category.ToString();
            }
        }
        public class Company
        {
            public int id;
            public string name_company;
            public Company(int _id, string _name_company)
            {
                this.id = _id;
                this.name_company = _name_company;
            }
            public override string ToString()
            {
                return "id = " + this.id + "; company name = " + this.name_company + " ;";
            }
        }
        public class Category
        {
            public int id;
            public string name;
            public Category(int _id, string _name)
            {
                this.id = _id;
                this.name = _name;
            }
        }
        static List<Product> d1 = new List<Product>()
        {
            new Product(1, "Bottle", 5, 10, "20/10/2010", 2, 2),
            new Product(2, "Bottle", 5, 20, "14/11/2011", 1, 2),
            new Product(3, "Ball", 100, 5, "15/06/2017", 3, 2),
            new Product(4, "Ball", 100, 10, "12/05/2012", 1, 2),
            new Product(5, "Coca Cola", 25, 18, "11/09/2015", 2, 1),
            new Product(6, "Sprite", 24, 16, "05/08/2012", 3, 1),
            new Product(7, "Fanta", 24, 16, "17/02/2013", 1, 1),
            new Product(8, "Microwave", 1500, 10, "06/09/2017", 2, 3),
            new Product(9, "Coca Cola", 25, 16, "21/11/2013", 3, 1),
            new Product(10, "Sprite", 24, 30, "28/12/2010", 2, 1),
            new Product(11, "Blender", 800, 24, "27/08/2011", 3, 3)
        };
        static List<Company> d2 = new List<Company>()
        {
            new Company(1, "IMEX_RGT"),
            new Company(2, "Vingroup Coorp."),
            new Company(3, "Tengu Coorp.")
        };
        static List<Category> d3 = new List<Category>()
        {
            new Category(1, "Drink"),
            new Category(2, "Plastic"),
            new Category(3, "Electronic")
        };
        static void Main(string[] args)
        {
            Console.WriteLine("LabWork #4: LINQ");
            Console.WriteLine("Student: Pham Xuan Hoang");
            Console.WriteLine("Group: IS-63");
            Console.WriteLine("First Query: ");
            var query1 = from x1 in d1
                         select x1;
            foreach (var x1 in query1)
                Console.WriteLine(x1);
            Console.WriteLine("________________________________________________________________________________________________");
            Console.WriteLine("Second Query: ");
            var query2 = from x2 in d2
                         select x2;
            foreach (var x2 in query2)
                Console.WriteLine(x2);
            Console.WriteLine("________________________________________________________________________________________________");
            Console.WriteLine("Third Query: ");
            var query3 = from x3 in d1
                         where x3.price >= 100
                         select x3;
            foreach (var x3 in query3)
                Console.WriteLine(x3);
            Console.WriteLine("________________________________________________________________________________________________");
            Console.WriteLine("Fourth Query: ");
            var query4 = from x4 in d1
                         orderby x4.price
                         select x4;
            foreach (var x4 in query4)
                Console.WriteLine(x4);
            Console.WriteLine("________________________________________________________________________________________________");
            Console.WriteLine("Fifth Query: ");
            var query5 = from x5 in d1
                         join y5 in d2 on x5.id_company equals y5.id
                         select new { v1 = x5.name, v2 = y5.name_company };
            foreach (var x5 in query5)
                Console.WriteLine(x5);
            Console.WriteLine("________________________________________________________________________________________________");
            Console.WriteLine("Sixth Query: ");
            var query6 = (from x6 in d1 select x6.name).Distinct();
            foreach (var x6 in query6)
                Console.WriteLine(x6);
            Console.WriteLine("________________________________________________________________________________________________");
            Console.WriteLine("Seventh Query: ");
            var query7 = from x7 in d1
                         join y7 in d3 on x7.id_category equals y7.id
                         select new { v1 = x7.name, v2 = y7.name };
            foreach (var x7 in query7)
                Console.WriteLine(x7);
            Console.WriteLine("________________________________________________________________________________________________");
            Console.WriteLine("Eighth Query: ");
            var query8 = from x8 in d1
                         group x8 by x8.id_category into g
                         orderby g.Key
                         select g;
            foreach (var category in query8)
            {
                foreach (var x8 in category)
                    Console.WriteLine(x8);
            }
            Console.WriteLine("________________________________________________________________________________________________");
            Console.WriteLine("Nineth Query: ");
            var query9 = from x7 in d1
                         join y7 in d3 on x7.id_category equals y7.id
                         where y7.name == "Plastic"
                         select new { Product = x7.name, Category = y7.name };
            foreach (var x7 in query9)
                Console.WriteLine(x7);
            Console.ReadKey();
        }
    }
}
