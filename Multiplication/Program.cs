using StackExchange.Redis;

namespace Multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new ConfigurationOptions();
            options.EndPoints.Add("localhost", 6379);

            var redis = ConnectionMultiplexer.Connect(options);
            var db = redis.GetDatabase();

            const string keyFrist = "testFirstKey";
            const string keySecond = "testSecondKey";

            var firstMultiplier = System.Convert.ToDouble(db.StringGet(keyFrist));
            var secondMultiplier = System.Convert.ToDouble(db.StringGet(keySecond));
            
            
            System.Console.WriteLine("Press F to get multiplication");
            if (System.Console.ReadKey().KeyChar == 70)
            {
                GetMultiplication(firstMultiplier, secondMultiplier);
            }
        }

        static void GetMultiplication(double firstMultiplier, double secondMultiplier)
        {
            System.Console.WriteLine($"\n{firstMultiplier} * {secondMultiplier} = {firstMultiplier * secondMultiplier}");
        }
    }
}