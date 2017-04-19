namespace _01.SoftuniCoffeeOrders
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class SoftuniCoffeeOrders
    {
        public static void Main()
        {
            var ordersCount = int.Parse(Console.ReadLine());
            decimal total = 0;
            var coffePrices = new List<decimal>();

            for (int i = 0; i < ordersCount; i++)
            {
                var pricePerCaplule = decimal.Parse(Console.ReadLine());
                var orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                var capluleCount = long.Parse(Console.ReadLine());

                var days = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);

                decimal currentCoffePrice = days * capluleCount * pricePerCaplule;
                coffePrices.Add(currentCoffePrice);

                total += currentCoffePrice;
            }

            foreach (var coffePrice in coffePrices)
            {
                Console.WriteLine($"The price for the coffee is: ${coffePrice:f2}");
            }

            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
