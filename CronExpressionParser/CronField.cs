namespace CronExpressionParser
{
    /// <summary>
    /// CronField class to represent cron expression types.
    /// </summary>
    public class CronField
    {        
        public static readonly CronField DaysOfWeek = new CronField(1, 7);
        public static readonly CronField Months = new CronField(1, 12);
        public static readonly CronField DaysOfMonth = new CronField(1, 31);
        public static readonly CronField Hours = new CronField( 0, 23);
        public static readonly CronField Minutes = new CronField(0, 59);        
        
        public readonly int Start;
        public readonly int End;            
        private CronField(int start, int end)
        {            
            Start = start;
            End = end;                             
        }
    }
}
