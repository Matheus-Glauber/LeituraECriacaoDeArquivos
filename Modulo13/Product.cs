using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Modulo13
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Qtd { get; set; }

        public Product(string name, double price, int qtd)
        {
            Name = name;
            Price = price;
            Qtd = qtd;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: ");
            sb.Append(Name);
            sb.Append(", Price: ");
            sb.Append(Price.ToString("F2", CultureInfo.InvariantCulture));
            sb.Append(", Quantity: ");
            sb.Append(Qtd);

            return sb.ToString();
        }

        public double ValorTotal()
        {
            return Price * Qtd;
        }
    }
}
