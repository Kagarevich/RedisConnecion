using StackExchange.Redis;

namespace Multiplication
{
    class Program
    {
        static void Main()
        {
            var options = new ConfigurationOptions();
            options.EndPoints.Add("localhost", 6379);

            var redis = ConnectionMultiplexer.Connect(options);
            var db = redis.GetDatabase();

            const string keyFirst = "testFirstKey";
            const string keySecond = "testSecondKey";

            while (true)
            {
                System.Console.WriteLine("Press F to get multiplication");
                if (System.Console.ReadKey().KeyChar == 70)
                {
                    try
                    {
                        var firstMultiplier = System.Convert.ToDouble(db.StringGet(keyFirst));
                        var secondMultiplier = System.Convert.ToDouble(db.StringGet(keySecond));
                        GetMultiplication(firstMultiplier, secondMultiplier);
                    }
                    catch
                    {
                        System.Console.WriteLine("\nThere are incorrect data in database" +
                                                 "\nTry do that after correct the error");
                    }
                }
            }
        }

        static void GetMultiplication(double firstMultiplier, double secondMultiplier)
        {
            System.Console.WriteLine($"\n{firstMultiplier} * {secondMultiplier} = {firstMultiplier * secondMultiplier}");
        }
    }
}