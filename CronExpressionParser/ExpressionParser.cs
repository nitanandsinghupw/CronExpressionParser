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
            string minutes = new ParserHelper(parsed[0], CronField.Minutes).ToString();
            string hours = new ParserHelper(parsed[1], CronField.Hours).ToString();
            string dayOfMonth = new ParserHelper(parsed[2], CronField.DaysOfMonth).ToString();
            string month = new ParserHelper(parsed[3], CronField.Months).ToString();
            string dayOfWeek = new ParserHelper(parsed[4], CronField.DaysOfWeek).ToString();
            string command = parsed[5];
           
            //Print output to console.
            Console.WriteLine(string.Format("minute\t\t\t\t{0}", minutes));
            Console.WriteLine(string.Format("hours\t\t\t\t{0}", hours));
            Console.WriteLine(string.Format("day of month\t\t\t{0}", dayOfMonth));
            Console.WriteLine(string.Format("month\t\t\t\t{0}", month));
            Console.WriteLine(string.Format("day of week\t\t\t{0}", dayOfWeek));
            Console.WriteLine(string.Format("command\t\t\t\t{0}", command));
        }
    }
}
