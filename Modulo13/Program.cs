using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Modulo13
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = @"G:\Curso de C#\Projetos\Modulo13\source\products.csv";
            List<Product> ListProducts = new List<Product>();

            FileStream fs = null;
            StreamReader sr = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(source, FileMode.Open);
                sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    //Lendo Cada linha do arquivo
                    string line = sr.ReadLine();
                    //Separando os valores por ","
                    string[] listLine = line.Split(",");

                    string name = listLine[0];
                    double price = double.Parse(listLine[1]);
                    int quantity = int.Parse(listLine[2]);

                    ListProducts.Add(new Product(name, price, quantity));                    
                }                
            }
            catch (IOException e)
            {
                Console.Write("An error ocurred: ");
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
                sr.Close();
            }

            Directory.CreateDirectory(@"G:\Curso de C#\Projetos\Modulo13\out");
            string outPath = @"G:\Curso de C#\Projetos\Modulo13\out\";
            
            try
            {
                sw = File.AppendText(outPath + "summary.csv");
                foreach (var product in ListProducts)
                {                    
                    sw.WriteLineAsync(product.Name + "," + product.ValorTotal().ToString("F2", CultureInfo.InvariantCulture));
                }
            }
            catch (IOException e)
            {
                Console.Write("An error ocurred: ");
                Console.WriteLine(e.Message);
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
