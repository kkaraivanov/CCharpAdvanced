namespace DateModifier
{
    using System;

    public class DateModifier
    {
        public int Calculate(string ferstDate, string secondDate)
        {
            var parsedDate1 = ferstDate.Split();
            var dateFirst = DateTime.Parse($"{parsedDate1[1]}/{parsedDate1[0]}/{parsedDate1[2]}");
            var parsedDate2 = secondDate.Split();
            var dateSecond = DateTime.Parse($"{parsedDate2[1]}/{parsedDate2[0]}/{parsedDate2[2]}");
            var diff = dateSecond.Subtract(dateFirst).Days;
            
            return diff < 0 ? diff * -1 : diff;
        }
    }
}
