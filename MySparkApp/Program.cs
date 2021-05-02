using Microsoft.Spark.Sql;
using static Microsoft.Spark.Sql.Functions;

namespace MySparkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Spark Session
            SparkSession spark = 
                SparkSession
                    .Builder()
                    .AppName("word_count_sample")
                    .GetOrCreate();
            
            // Create initial DataFrame
            string filePath = args[0];
            DataFrame dataFrame = spark.Read().Text(filePath);

            // Count words
            DataFrame words = 
                dataFrame
                    .Select(Split(Col("Value"), " ").Alias("words"))
                    .Select(Explode(Col("words")).Alias("word"))
                    .GroupBy("word")
                    .Count()
                    .OrderBy(Col("count").Desc());

            // Display results
            words.Show();

            // Stop Spark Session
            spark.Stop();
        }
    }
}
