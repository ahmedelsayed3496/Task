namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chargeForSmall = 25;
            int chargeForLarge = 35;
            

            Console.Write("Number of small carpets: ");
            int numberForSmall = int.Parse(Console.ReadLine());
            Console.Write("Number of large carpets: ");
            int numberForLarge = int.Parse(Console.ReadLine());

            Console.WriteLine($"Price per small room: ${chargeForSmall}");
            Console.WriteLine($"Price per large room: ${chargeForLarge}");

            int cost = (chargeForSmall * numberForSmall) + (chargeForLarge * numberForLarge);
            double tax = cost * 0.06;

            Console.WriteLine($"Cost: ${cost}");
            Console.WriteLine($"Tax: ${tax}");

            double totalEstimate = cost+tax;

            Console.WriteLine($"===============================");
            Console.WriteLine($"Total estimate: ${totalEstimate}");
            Console.WriteLine("This estimate is valid for 30 days");
        }
    }
}
