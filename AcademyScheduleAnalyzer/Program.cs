namespace AcademyScheduleAnalyzer;

internal class Program
{
    static void Main(string[] args)
    {
        // DisplayAllSessions(sessionNames , sessionDates , sessionDurations);
        SearchForSession("c# Basics");
    }
#region StarterData
    public static string[] sessionNames =
        {
            "C# Basics",
            "Arrays",
            "Functions",
            "Date and Time",
            "Exception Handling"
        };

    public static DateTime[] sessionDates =
        {
            new DateTime(2026, 9, 10, 18, 0, 0),
            new DateTime(2026, 9, 13, 18, 0, 0),
            new DateTime(2026, 9, 17, 18, 0, 0),
            new DateTime(2026, 9, 20, 18, 0, 0),
            new DateTime(2026, 9, 24, 18, 0, 0)
        };

    public static int[] sessionDurations =
        {
            180,
            240,
            180,
            240,
            180
        };
#endregion


    public static void DisplayAllSessions(string[] sessionName , DateTime[] sessionDate , int[] sessionDuration)
    {
        for (int i = 0; i < sessionDuration.Length; i++)
        {
            Console.WriteLine($"{i+1}. {sessionName[i]}");
            Console.WriteLine($"Date is: {sessionDate[i].ToString("dd MMMM yyyy")}");
            Console.WriteLine($"Start Time is: {sessionDate[i].ToString("hh:mm tt")}");
            Console.WriteLine($"Duration is: {sessionDuration[i]} minutes");
        }
    }


    public static void SearchForSession(string sessionName)
    {
       
        if (!sessionNames.Contains(sessionName , StringComparer.OrdinalIgnoreCase))
        {
            Console.WriteLine("Session not found");
            return;
        } 
        
        if (String.IsNullOrWhiteSpace(sessionName))
        {
            Console.WriteLine("Invalid Session Name");
        }

        int sessionIndex = Array.FindIndex(sessionNames , s => string.Equals(s , sessionName , StringComparison.OrdinalIgnoreCase));  

        Console.WriteLine($"{sessionName}");
        Console.WriteLine($"Date: {sessionDates[sessionIndex].ToString("dd MM yyyy")}");
        Console.WriteLine($"Start Time: {sessionDates[sessionIndex].ToString("hh:mm tt")}");
        Console.WriteLine($"Duration: {sessionDurations[sessionIndex]}");

    }


}




    

