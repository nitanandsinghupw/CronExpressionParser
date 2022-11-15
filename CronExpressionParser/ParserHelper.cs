using System;
using System.Collections.Generic;

namespace CronExpressionParser
{
    public class ParserHelper
    {
        private string expression = string.Empty;
        private CronField cronField = null;

        List<int> output = new List<int>();
        public ParserHelper(string expression, CronField cronField)
        {
            this.expression = expression;
            this.cronField = cronField;

            ParseSeparatorValues();

            ParseRangeValues();

            ParseStepValues();

            if (output.Count == 0)
            {
                output.Add(int.Parse(expression));
            }
        }

        /// <summary>
        /// Parse range values.
        /// </summary>
        private void ParseRangeValues()
        {
            String[] range = expression.Split("-");
            if (range.Length == 2)
            {
                int start = ParseNumber(range[0]);
                int end = ParseNumber(range[1]);

                // Extarct range for expression.
                while(start<=end)
                {
                    output.Add(start);
                    start++;
                }                
            }
        }

        /// <summary>
        /// Parse step values of the expression.
        /// </summary>
        private void ParseStepValues()
        {
            if (expression.StartsWith("*"))
            {                
                String[] intervals = expression.Split("/");
                if (intervals.Length > 2)
                {
                    throw new FormatException(String.Format("Too many expressions"));
                }
                if (intervals.Length == 2)
                {
                    int interval = ParseNumber(intervals[1]);
                    // calculate intervals for step values.
                    for (int k = cronField.Start; k <= cronField.End; k += interval)
                    {
                        output.Add(k);
                    }
                }
                if(intervals.Length == 1)
                {
                    int start = cronField.Start;
                    while (start <= cronField.End)
                    {
                        output.Add(start);
                        start++;
                    }
                }
            }
        }

        /// <summary>
        /// Parse the separator expression.
        /// </summary>
        private void ParseSeparatorValues()
        {
            string[] unitValues = expression.Split(",");
            if (unitValues.Length > 1)
            {
                foreach (var value in unitValues)
                {
                    output.Add(ParseNumber(value));
                }
            }
        }

        /// <summary>
        /// Parse number and validate with value range.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int ParseNumber(string value)
        {
            var num = int.Parse(value);
            //check the range of the cron field.
            if (num == -1 || num < cronField.Start || num > cronField.End)
            {
                throw new FormatException(String.Format("Value must be a number between {0} and {1} for {3}.", cronField.Start, cronField.End, cronField));
            }

            return num;
        }

        public override string ToString()
        {
            return string.Join(" ", output);
        }
    }
}
