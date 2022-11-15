using System;

namespace CronExpressionParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length!=1)
            {
                Console.Write("Please provide valid cron expression.");
            }

            try
            {
                ExpressionParser cronExpressionParser = new ExpressionParser(args[0]);                
                cronExpressionParser.InitiateParsing();               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
