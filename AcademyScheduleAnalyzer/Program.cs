using System.Collections.Immutable;
using System.Text;
using AcademyScheduleAnalyzer.Benchmarks;
using BenchmarkDotNet.Running;
using Iced.Intel;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace AcademyScheduleAnalyzer;

internal class Program
{    
static void Main(string[] args)
    {
        while (true)
        {
            string input;
            MenuItems();
            MenuInput(out input);
            
            if (input == "0")
                break;
           
            switch (input)
            {
                case "1":
                    DisplayAllSessions();
                    break;
                
                case "2":
                    Console.WriteLine(FindSession());
                    break;


                case "3":
                    SortSessionNames();
                    break;


                case "4":
                    ReverseSessionNames();
                    break;

                case "5":
                    FindSessionIndex();
                    break;

                case "6":
                    CheckSessionExists();
                    break;


                case "7":
                    DurationAnalysis();
                    break;


                case "8":
                    SessionDateDetails();
                    break;


                case "9":
                    StatusOfSession();
                    break;


                case "10":
                    FindTheNextSession();
                    break;
                


                case "11":
                    DateDifference();
                    break;


                case "12":
                    ReadAndValidDate();
                    break;

                case "13":
                    AccessSessionIndex();
                    break;


                case "14":
                    ValidateSessionDuration();
                    break;


                case "15":
                    Console.WriteLine(ScheduleReportUsingString());
                    break;


                case "16":
                    Console.WriteLine(ScheduleReportUsingStringBuilder());
                    break;

            }

            
        }
    
    
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

#region Array Method Practice
    public static void SortSessionNames()
    {
        string[] copiedArray = new string[sessionNames.Length];
        Array.Copy(sessionNames , copiedArray , sessionNames.Length);
        Array.Sort(copiedArray);

        Console.WriteLine($"Non-Sorted Session Names: {string.Join(", ",sessionNames)}");
        Console.WriteLine($"Sorted Session Names: {string.Join(", ",copiedArray)}");

    }


    public static void ReverseSessionNames()
    {
        string[] copiedArray = new string[sessionNames.Length];
        Array.Copy(sessionNames , copiedArray , sessionNames.Length);
        Array.Reverse(copiedArray);

        Console.WriteLine($"Non-Reversed Session Names: {string.Join(", " , sessionNames)}");
        Console.WriteLine($"Reversed Session Names: {string.Join(", " , copiedArray)}");

    }


    public static void FindSessionIndex()
    {
        int sessionIndex = Array.IndexOf(sessionNames , FindSession());
        Console.WriteLine($"Index: {sessionIndex}");
    }


    public static void CheckSessionExists()
    {
        string sessionName = FindSession();
        if (!Array.Exists(sessionNames, s => s == sessionName))
        {
            Console.WriteLine("Session not found");
            return;
        }

        Console.WriteLine("Session found");
    }


    public static string FindSession()
    {   
        Console.Write("Enter The Name Of The Session: ") ;
        string searchName = Console.ReadLine();
        string? foundSession = Array.Find(sessionNames ,  s => string.Equals(s , searchName ,StringComparison.OrdinalIgnoreCase));
    
        return foundSession ?? "Invalid Session";
    }


    public static int FindSessionWithCondition()
    {

        int indexSearched = Array.IndexOf(sessionNames , FindSession());
        return indexSearched;
    }


    public static void CopyArray()
    {
        string[] copiedArray = new string[sessionNames.Length];
        Array.Copy(sessionNames , copiedArray , sessionNames.Length);

        copiedArray[0] = "Git & Github";

        Console.WriteLine($"Original Array: {string.Join(", ", sessionNames)}");
        Console.WriteLine($"Copiec Array: {string.Join(", ", copiedArray)}");


    }
#endregion

#region Duration Analysis
    public static void DurationAnalysis()
    {
        int totalDuration = sessionDurations.Sum();
        double avgDuration = sessionDurations.Average();
        int shortestDuration = sessionDurations.Min();
        int longestDuration = sessionDurations.Max();

        Console.WriteLine($"Total Duration: {totalDuration} minutes");
        Console.WriteLine($"Average Duration: {avgDuration} minutes");
        Console.WriteLine($"Shortest Duration: {shortestDuration} minutes");
        Console.WriteLine($"Longest Duration: {longestDuration} minutes");
  
    }


    public static void SortDurations()
    {
        int[] copiedArr = new int[sessionDurations.Length];
        Array.Copy(sessionDurations , copiedArr , sessionDurations.Length);
        Array.Sort(copiedArr);

        Console.WriteLine($"Sorted Durations: {string.Join(", " , copiedArr)}");
    }
#endregion

#region Functions
    public static int GetTotalDuration()
        => sessionDurations.Sum();
    
    public static double GetAverageDuration()
        => sessionDurations.Average();
    
    public static int GetShortestDuration()
        => sessionDurations.Min();
    
    public static int GetLongestDuration()
        => sessionDurations.Max();

    public static DateTime GetSessionEndTime(string sessionName)
    {
        int sessionIndex = Array.IndexOf(sessionNames , sessionName);
        DateTime endTime = sessionDates[sessionIndex].AddMinutes(sessionDurations[sessionIndex]);

        return endTime;
    }
        
    public static DateTime ReadSessionDate(string sessionName)
    {
        int sessionIndex = Array.IndexOf(sessionNames , sessionName);
        return sessionDates[sessionIndex];
    }
#endregion

#region ref, out, and Reference-Type Parameters
    public static int beforeRef = 10;
    public static void ChangeByRef(ref int changingVariable)
    {
        Console.WriteLine($"Integer before changing: {beforeRef}");

        changingVariable = changingVariable + 5;

        Console.WriteLine($"Integer after changing: {beforeRef}");
    }

    public static int sessionIndex;
    public static int sessionDuration;
    public static void ChangeByOut(string sessionName , out int sessionIndex2 , out int sessionDuration2)
    {
        sessionIndex2 = Array.IndexOf(sessionNames , sessionName);
        sessionDuration2 = sessionDurations[sessionIndex2];   

        Console.WriteLine($"Index: {sessionIndex}");
        Console.WriteLine($"Duration: {sessionDuration}"); 
    }


    public static string[] mentors = new string[] {"Ahmed Anwer" , "Fady Walid"};
    public static void ChangeArr(string[] changedArr)
    {
        Console.WriteLine($"Old Mentors: {string.Join(", " , mentors)}");
        changedArr[1] = "Ibrahim Abd ElRahman";
    
        Console.WriteLine($"New Mentors: {string.Join(", " , mentors)}");
    }
#endregion
 
#region Date Parts
    public static void SessionDateDetails()
    {
        int sessionIndex = Array.IndexOf(sessionNames, FindSession());
        
        Console.WriteLine($"Date: {sessionDates[sessionIndex].ToString("dd MMMM yyyy")}");
        Console.WriteLine($"Day: {sessionDates[sessionIndex].DayOfWeek}");
        Console.WriteLine($"Year: {sessionDates[sessionIndex].Year}");
        Console.WriteLine($"Month: {sessionDates[sessionIndex].Month}");
        Console.WriteLine($"Day Number: {sessionDates[sessionIndex].Day}");
        Console.WriteLine($"Start Time: {sessionDates[sessionIndex].ToString("hh:mm tt")}");
        Console.WriteLine($"Duration: {sessionDurations[sessionIndex]}");
        Console.WriteLine($"End Time: {sessionDates[sessionIndex].AddMinutes(sessionDurations[sessionIndex]).ToString("hh:mm tt")}");
    }

    public static void DateDifference()
    {
        Console.Write("Enter The First Session: ");
        string firstSession = Console.ReadLine();

        Console.Write("Enter The Second Session: ");
        string secondSession = Console.ReadLine();
        
        int firstIndex = Array.IndexOf(sessionNames , firstSession);
        int secondIndex = Array.IndexOf(sessionNames , secondSession);


        TimeSpan difference = sessionDates[firstIndex] - sessionDates[secondIndex];
        if (difference.Days < 0)
        {
            difference = sessionDates[secondIndex] - sessionDates[firstIndex];
        }
        
        Console.WriteLine($"Days: {difference.Days}");
        Console.WriteLine($"Hours: {difference.TotalHours}"); 



    }

    public static void StatusOfSession()
    {
        
        DateTime currentTime = DateTime.Now;
        for(int i = 0 ; i < sessionNames.Length ; i++)
        {
            if (sessionDates[i] > currentTime)
            {
                Console.WriteLine($"{sessionNames[i]} Up Coming");
            }
            else
            {
            Console.WriteLine($"{sessionNames[i]} Past");
            }
        }
    }

    public static void FindTheNextSession()
    {
        int sessionIndex = Array.IndexOf(sessionNames , FindSession());
        DateTime sessionCurrentTime = sessionDates[sessionIndex];

        bool checker = false;
        for(int i = 0 ; i < sessionNames.Length ; i++)
        {
            if (sessionDates[i] > sessionCurrentTime && sessionDates[i] > DateTime.Now)
            {
                checker = true;

                Console.WriteLine("Next Session:");
                Console.WriteLine(sessionNames[i]);
                Console.WriteLine(sessionDates[i].ToString("dd MMMM yyyy"));
                Console.WriteLine(sessionDates[i].ToString("hh:mm tt"));

                Console.WriteLine("Time Remaining:");
                Console.WriteLine($"{(sessionDates[i]-DateTime.Now).Days} Days");
                Console.WriteLine($"{(sessionDates[i]-DateTime.Now).Hours} Hours");
                break;
            }
            
        }
        if (checker == false)
        {
            Console.WriteLine("There is no next session");
        }
    }

    public static void DateFormating()
    {
        Console.WriteLine(sessionDates[0].ToString("yyyy-MM-dd"));
        Console.WriteLine(sessionDates[0].ToString("dd/MM/yyyy"));
        Console.WriteLine(sessionDates[0].ToString("dd MMMM yyyy"));
        Console.WriteLine(sessionDates[0].DayOfWeek+", "+sessionDates[0].ToString("yyyy-MM-dd"));
        Console.WriteLine(sessionDates[0].ToString("hh:mm tt"));
    }

    public static void ReadAndValidDate()
    {
        while (true)
        {
            Console.Write("Enter The Date: ");
            string reader = Console.ReadLine()!;
            bool checker = DateTime.TryParseExact(
                reader,
                "yyyy-MM-dd hh:mm",
                null,
                System.Globalization.DateTimeStyles.None,
                out DateTime parsedDate);

            if (checker)
            {
                Console.WriteLine($"{parsedDate.ToString("yyyy-MM-dd hh:mm")} is a valid Date");
                break;
            }
            Console.WriteLine($"{reader} is not a valid Date, Please try again");

        }

    }
#endregion

#region Handling Exception Part
    public static void MenuInput(out string? input)
        {
            while(true)
            {
        
                Console.Write("\nChoose an option: ");
                input = Console.ReadLine();
                try
                {
                    int? option = int.Parse(input);
                    if (option < 0 || option > 16)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid menu option. Enter a number.");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Your Option Invalid, Please Try Again");

                }
                
            
            }
        }

    public static void AccessSessionIndex()
    {
        try
        {
            Console.Write("Enter Session Index: ");
            int sessionIndex = int.Parse(Console.ReadLine());

            Console.WriteLine($"Session: {sessionNames[sessionIndex]}");  
        }
        catch (IndexOutOfRangeException)
        {
           Console.WriteLine("The selected session index is out of range.");
            
        }
    }

    public static void ValidateSessionDuration()
    {
        try
        {
            Console.Write("Enter Session Duration: ");
            int sessionDuration = int.Parse(Console.ReadLine());

            if (sessionDuration <= 0)
            {
                throw new ArgumentException();
            }
            Console.WriteLine("Duration Accepted");
        }
        catch(ArgumentException)
        {
            Console.WriteLine("Duration must be greater than zero.");
        }
        finally
        {
            Console.WriteLine("Input operation finished.");
        } 
    }
#endregion

#region Reports
    public static string ScheduleReportUsingString()
    {
        string result = "";
        for(int i = 0 ; i < sessionNames.Length ; i++)
        {
            result += $"{sessionNames[i]} - {sessionDates[i].ToString("dd/MM/yyyy hh:mm tt")} - {sessionDurations[i]} minutes\n";
            
        }
        
        return result;
    }

    public static string ScheduleReportUsingStringBuilder()
    {
        StringBuilder sb = new StringBuilder();
        for(int i = 0 ; i < sessionNames.Length ; i++)
        {
            sb.Append($"{sessionNames[i]} - {sessionDates[i].ToString("dd/MM/yyyy hh:mm tt")} - {sessionDurations[i]} minutes\n");
        }

        string? result = Convert.ToString(sb) ;
        return result;
    }
#endregion

    public static void MenuItems()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Academy Schedule Analyzer");
            Console.WriteLine("===================================");
            
            Console.WriteLine("1. Display all sessions");
            Console.WriteLine("2. Search for a session");
            Console.WriteLine("3. Sort session names");
            Console.WriteLine("4. Reverse session names");
            Console.WriteLine("5. Find session index");
            Console.WriteLine("6. Check if session exists");
            Console.WriteLine("7. Show duration statistics");
            Console.WriteLine("8. Show session date details");
            Console.WriteLine("9. Show past and upcoming sessions");
            Console.WriteLine("10. Find next session");
            Console.WriteLine("11. Compare two session dates");
            Console.WriteLine("12. Read and validate a custom date");
            Console.WriteLine("13. Select session by index");
            Console.WriteLine("14. Validate session duration");
            Console.WriteLine("15. Generate report using string");
            Console.WriteLine("16. Generate report using StringBuilder");
            Console.WriteLine("0. Exit");
        }

    public static int Calculate(params int[] durations)
        {
            int sum = 0;
        foreach(int num in durations)
        {
            sum += num;
        }
        return sum;
        }        

    public static void DisplayAllSessions()
    {
        for (int i = 0; i < sessionDurations.Length; i++)
        {
            Console.WriteLine($"{i+1}. {sessionNames[i]}");
            Console.WriteLine($"Date is: {sessionDates[i].ToString("dd MMMM yyyy")}");
            Console.WriteLine($"Start Time is: {sessionDates[i].ToString("hh:mm tt")}");
            Console.WriteLine($"Duration is: {sessionDurations[i]} minutes");
        }
    }

    public static void DisplaySessionDetails(string sessionName)
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



    

