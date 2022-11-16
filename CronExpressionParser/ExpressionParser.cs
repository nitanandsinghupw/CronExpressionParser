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
            Console.WriteLine(String.Format("minute\t\t\t\t{0}", minutes));
            Console.WriteLine(String.Format("hours\t\t\t\t{0}", hours));
            Console.WriteLine(String.Format("day of month\t\t\t{0}", dayOfMonth));
            Console.WriteLine(String.Format("month\t\t\t\t{0}", month));
            Console.WriteLine(String.Format("day of week\t\t\t{0}", dayOfWeek));
            Console.WriteLine(String.Format("command\t\t\t\t{0}", command));
        }
    }
}
