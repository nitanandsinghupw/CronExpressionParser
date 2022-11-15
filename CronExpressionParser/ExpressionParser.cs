using System;

namespace CronExpressionParser
{
    /// <summary>
    /// Parse individual expressions
    /// </summary>
    public class ExpressionParser
    {
        // Input expression
        private string expression;
        public ExpressionParser(string expression)
        {
            this.expression = expression;
        }

        /// <summary>
        ///  Start parsing process.
        /// </summary>
        public void InitiateParsing()
        {
            string[] parsed = new string[5];

            if (string.IsNullOrEmpty(expression)) throw new MissingFieldException();

            if (!string.IsNullOrEmpty(expression))
            {
                //Split the cron expression to get seperate parts.
                parsed = expression.Split(' ');

                if (parsed.Length != 6) throw new FormatException(string.Format("Error: Expression has {0} parts.only 5 part are required.", parsed.Length));
            }

            // Extract the cron expression values.
            Process(parsed);
        } 
        
        public void Process(string[] parsed)
        {
            String minutes = new ParserHelper(parsed[0], CronField.Minutes).ToString();
            String hours = new ParserHelper(parsed[1], CronField.Hours).ToString();
            String dayOfMonth = new ParserHelper(parsed[2], CronField.DaysOfMonth).ToString();
            String month = new ParserHelper(parsed[3], CronField.Months).ToString();
            String dayOfWeek = new ParserHelper(parsed[4], CronField.DaysOfWeek).ToString();
            String command = parsed[5];
           
            //Print output to console.
            Console.WriteLine("{0,1}{1,30}", "minute", minutes);
            Console.WriteLine("{0,1}{1,30}", "hours", hours);
            Console.WriteLine("{0,1}{1,30}", "day of month", dayOfMonth);
            Console.WriteLine("{0,1}{1,30}", "month", month);
            Console.WriteLine("{0,1}{1,30}", "day of week", dayOfWeek);
            Console.WriteLine("{0,1}{1,30}", "command", command);
        }
    }
}
