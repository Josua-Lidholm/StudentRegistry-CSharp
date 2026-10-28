namespace CSharp_jsonLinq;

public class StudentUtilities
{
    private readonly List<Student> _students;

    public StudentUtilities(List<Student> students)
    {
        _students = students;
    }
/*
1. Filtrering – hitta duktiga studenter
Hämta alla studenter som har ett betyg över 80.
*/
    public List<Student> GetTopStudents()
    {
        var topStudents = _students
            .Where(s => s.Grade > 80)
            .ToList();
        return topStudents;
    }
    

// 2. Sortering – ordna efter högsta betyg
// Sortera studenterna i fallande ordning efter Grade och returnera namn + betyg.
// Exempel: "Adam - 95"
// */
     public List<string> GetStudentsSortedByGrade()
     {
         var gradeDescendingStudents = _students
             .OrderByDescending(s => s.Grade)
             .Select(s =>  $"{s.Name} - {s.Grade}")
             .ToList();
         return gradeDescendingStudents;
     }


// /*
// 3. Projektion – skapa en enklare lista
// Returnera varje students namn + programnamn.
// Exempel: "Adam - Undersköterska"
// */
     public List<string> GetStudentProgramList()
     {
         var studentProgramList = _students
             .Select(s => $"{s.Name} - {s.Program.Name}")
             .ToList();
         return studentProgramList;
     }

// /*
// 4. Gruppering – gruppera efter program
// Returnera hur många som går varje program.
// Exempel: "Undersköterska - 24 studenter"
// */
     public Dictionary<string, int> GetStudentCountByProgram()
     {
         var studentCountByProgram = _students
             .GroupBy(s => s.Program.Name)
             .ToDictionary(group => group.Key, group => group.Count());
         
         return studentCountByProgram;
     }


// /*
// 5. Aggerering – medelbetyg per program
// Beräkna medelbetyg per program.
// Exempel: "Undersköterska - snitt 72.5"
// */
    // public Dictionary<string, double> GetAverageGradeByProgram()
    // {
    //     var averageGradeByProgram = _students
    //         .GroupBy(s => s.Program.Name, s => s.Grade.)
    //         .
    //
    //     return averageGradeByProgram;
    //
    // }
// /*
// 6. Villkorskontroll – kontrollera betyg
// Kontrollera om alla i "Undersköterska" har godkänt (>= 50).
// Returnera true eller false.
// */
     public bool AllNursesStudentsArePassing()
     {
         var totalNurses = _students
             .Where(s => s.Program.Name == "Undersköterska");
         
         var nursesPassing = _students
             .Where(s => s.Program.Name == "Undersköterska" && s.Grade >= 50);

         if (totalNurses.Count() > nursesPassing.Count())
         {
             return false;
         }
         else
         {
             return true;
         }
     }


// /*
// 7. Åldersberäkning – äldsta studenten
// Returnera den student som är äldst.
// */
//     public Student GetOldestStudent()
//     {
//         // TODO: Implementera med LINQ
//     }
//
//
// /*
// 8. Urval – top 5
// Returnera de 5 studenter med högst betyg.
// */
//     public List<Student> GetTop5Students()
//     {
//         // TODO: Implementera med LINQ
//     }
//
//
// /*
// 9. Transformation – andel avklarade terminer
// Returnera namn + procent avklarade terminer.
// Exempel: "Adam - 70%"
// */
//     public List<string> GetCompletionPercentage()
//     {
//         // TODO: Implementera med LINQ
//     }
//
//
// /*
// 10. Gruppfiltrering – program med snitt > 70
// Returnera programnamn där medelbetyget överstiger 70.
// Exempel: "Sjuksköterska"
// */
//     public List<string> GetProgramsWithHighAverage()
//     {
//         // TODO: Implementera med LINQ
//     }

    }