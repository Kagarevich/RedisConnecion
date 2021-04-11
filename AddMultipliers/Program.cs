using StackExchange.Redis;

namespace RedisConnecion
{
    class Program
    {
        static void Main()
        {
            var options = new ConfigurationOptions();
            options.EndPoints.Add("localhost", 6379);

            var redis = ConnectionMultiplexer.Connect(options);
            //Таблица по умолчанию
            var db = redis.GetDatabase();
            
            
            //ключи для двух значений
            const string keyFirst = "testFirstKey";
            const string keySecond = "testSecondKey";
            
            //Ввод значений множителей и их последующая записаь в бд
            System.Console.WriteLine("Enter the first multiplier:");
            db.StringSet(keyFirst, System.Convert.ToDouble(System.Console.ReadLine()));
            System.Console.WriteLine("Enter the second multiplier:");
            db.StringSet(keySecond, System.Convert.ToDouble(System.Console.ReadLine()));
        }
    }
}