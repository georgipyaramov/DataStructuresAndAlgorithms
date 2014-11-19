namespace _01.KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EntryPoint
    {
        static void Main()
        {
            var capacity = 10;

            var products = new List<Product>()
            {
                new Product("Beer", 2, 3),
                new Product("Vodka", 12, 8),
                new Product("Cheese", 5, 4),
                new Product("Nuts", 4, 1),
                new Product("Ham", 3, 2),
                new Product("Whiskey", 13, 8)
            };

            var valueMatrix = new int[products.Count, capacity + 1];
            var keepMatrix = new int[products.Count, capacity + 1];

            for (int row = 0; row < products.Count; row++)
            {
                for (int col = 1; col <= capacity; col++)
                {
                    if (products[row].Weight <= col)
                    {
                        var max = 0;
                        if (col - products[row].Weight > 0)
                        {
                            var remainder = col - products[row].Weight;
                            
                            for (int i = 0; i < row; i++)
                            {
                                if (valueMatrix[i, remainder] > max)
                                {
                                    max = valueMatrix[i, remainder];
                                    var shit = 1;
                                }
                            }
                        }

                        if (row > 0)
                        {
                            if (products[row].Cost + max > valueMatrix[row - 1, col])
                            {
                                valueMatrix[row, col] = products[row].Cost + max;
                                keepMatrix[row, col] = 1;
                            }
                            else
                            {
                                valueMatrix[row, col] = valueMatrix[row - 1, col];
                                keepMatrix[row, col] = 0;
                            }
                        }
                        else
                        {
                            valueMatrix[row, col] = products[row].Cost;
                            keepMatrix[row, col] = 1;
                        }
                    }
                }
            }

            var selectedProducts = new List<Product>();
                        
            for (int i = capacity; i >= 1; i--)
            {
                for (int j = products.Count - 1; j >= 0; j--)
                {
                    if (keepMatrix[j, i] == 1)
                    {
                        selectedProducts.Add(products[j]);
                        i -= (products[j].Weight);
                        break;
                    }
                }
            }

            //for (int i = 0; i < valueMatrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < valueMatrix.GetLength(1); j++)
            //    {
            //        Console.Write("{0,3}", valueMatrix[i, j]);
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine();
            //Console.WriteLine();

            //for (int i = 0; i < keepMatrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < keepMatrix.GetLength(1); j++)
            //    {
            //        Console.Write("{0,3}", keepMatrix[i, j]);
            //    }
            //    Console.WriteLine();
            //}

            Console.WriteLine(string.Join(", ", selectedProducts.Select(p => p.Name)));
        }
    }
}