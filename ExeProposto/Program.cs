using ExeProposto.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExeProposto
{
    class Program
    {
        static void Main(string[] args)
        {
            //instancia uma lista de PRODUCT vazia
            List<Product> listaProdutos = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Commom, used or imported (c/u/i)? ");
                char resposta = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string nome = Console.ReadLine();
                Console.Write("Price: ");
                double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (resposta == 'c')
                {
                    listaProdutos.Add(new Product(nome, preco));
                }
                else if (resposta == 'i')
                {
                    Console.Write("Customs fee: ");
                    double taxaAlfandega = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    listaProdutos.Add(new ImportedProduct(nome, preco, taxaAlfandega));
                }
                else
                {
                    Console.Write("Manufacture date (dd/mm/yyyy): ");
                    DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());
                    listaProdutos.Add(new UsedProduct(nome, preco, dataFabricacao));
                }                
            }
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS");
            foreach (Product item in listaProdutos)
            {
                Console.WriteLine(item.PriceTag());
            }
        }
    }
}
