// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using CSharp_jsonLinq;

// Läs in json-data.

string import = File.ReadAllText("students.json");
List<Student> students = JsonSerializer.Deserialize<List<Student>>(import, JsonSerializerOptions.Web) ?? new List<Student>();

var studentUtils = new StudentUtilities(students);

bool running = true;

while (running == true)
{
    Console.Clear();

    Console.WriteLine("Välkommen till elevregistret!");
    Console.WriteLine("Vad vill du göra?");
    Console.WriteLine();
    Console.WriteLine("1. Visa alla toppstudenter (betyg över 80).");
    Console.WriteLine("2. Visa alla elever och deras betyg, sorterat i fallande betygsordning.");
    Console.WriteLine("3. Visa alla elever och deras program.");
    Console.WriteLine("4. Visa antal elever per program.");
    Console.WriteLine("5. På väg...");
    Console.WriteLine("6. Kolla om alla undersköterskor har fått godkänt.");
    Console.WriteLine("7. Visa äldsta studenten.");
    Console.WriteLine("8. Visa top 5 i betyg");
    Console.WriteLine("9. Visa elever och hur långt de har kommit i utbildningen.");
    Console.WriteLine("Fler alternativ kommer...");

    var input = Console.ReadKey(true);

    switch (input.Key)
    {
        case ConsoleKey.D1:
            Console.Clear();
            List<Student> topStudents = studentUtils.GetTopStudents();
            foreach (var s in topStudents)
            {
                Console.WriteLine(s.Name);
            }

            Console.WriteLine(1);
            Console.WriteLine("Tryck när du är klar.");
            Console.ReadKey();
            break;
        
        case ConsoleKey.D2:
            Console.Clear();
            List<String> descGradeStudents = studentUtils.GetStudentsSortedByGrade();
            foreach (var s in descGradeStudents)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
            
            break;
        case ConsoleKey.D3:
            Console.Clear();
            List<String> studentProgram = studentUtils.GetStudentProgramList();
            foreach (var s in studentProgram)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
            
            break;
        case ConsoleKey.D4:
            Console.Clear();
            var studentCountByProgram = studentUtils.GetStudentCountByProgram();
            
            foreach (var s in studentCountByProgram)
            {
                Console.WriteLine($"{s.Key} - {s.Value} studenter");
            }
            
            Console.ReadKey();
            
            break;
        case ConsoleKey.D5:
            Console.Clear();
            
            
            Console.ReadKey();
            
            break;
        case ConsoleKey.D6:
            Console.Clear();

            Console.WriteLine(studentUtils.AllNursesStudentsArePassing());
            
            Console.ReadKey();
            
            break;
        case ConsoleKey.D7:
            Console.Clear();

            var oldestStudent = studentUtils.GetOldestStudent();

            Console.WriteLine($"{oldestStudent[0].Name}: {oldestStudent[0].Birthdate}");
            
            Console.ReadKey();
            
            break;
        
        case ConsoleKey.D8:
            Console.Clear();

            var top5Students = studentUtils.GetTop5Students();

            foreach (var student in top5Students)
            {
                Console.WriteLine($"{student.Name}: {student.Grade}");
            }
            
            Console.ReadKey();
            
            break;
            
        case ConsoleKey.D9:
            Console.Clear();

            var completionPercentage = studentUtils.GetCompletionPercentage();

            foreach (var s in completionPercentage)
            {
                Console.WriteLine($"{s.Key} - {s.Value}%");
            }
            
            Console.ReadKey();
            
            break;
        
        case ConsoleKey.D0:
            Console.Clear();

            var nerdyProgram = studentUtils.GetProgramsWithHighAverage();
            
            foreach (var s in nerdyProgram)
            {
                Console.WriteLine($"{s}");
            }
            
            Console.ReadKey();
            
            break;
        
        default:
            Console.WriteLine("Okänt kommando. Försök igen.");
            Console.ReadKey();
            break;
    }
}







Console.WriteLine();