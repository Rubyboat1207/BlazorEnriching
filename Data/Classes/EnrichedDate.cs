using SOS.Data;


public class EnrichedDate {

    public DateTime date = new DateTime();

    public string getDate()
    {
        return this.date.Year + "-" + (this.date.ToUniversalTime().Month + 1) + "-" + this.date.ToUniversalTime().Day;
    }

    static List<string> days = new List<string>()
    {
        {"monday"},
        {"tuesday"},
        {"wensday"},
        {"thursday"},
        {"friday"}
    };

    public EnrichedDate(DateTime newDate)
    {

        date = newDate;

    }

    public static EnrichedDate CreateEnrichedDateFromString(string date2)
    {
        int Year = int.Parse(date2.Split("-")[0]);

        int Month = int.Parse(date2.Split("-")[1]) - 1;

        int Day = int.Parse(date2.Split("-")[2]);

        return new EnrichedDate(new DateTime(Year, Month, Day));

    }

    public static EnrichedDate getDate(string Date)
    {

        EnrichedDate en = new EnrichedDate(new DateTime());

        DateTime newDate = new DateTime(0,0,0);

        if (days.Contains(Date.ToLower()))
        {
            while (en.date.Day != days.IndexOf(Date.ToLower()) + 1)
            {
                newDate = new DateTime(en.date.Year, en.date.Month, en.date.Day + 1);
            }

        }

        return newDate.Day == 0? en : new EnrichedDate(newDate);

    }

}