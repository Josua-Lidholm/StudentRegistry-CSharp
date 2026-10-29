namespace CSharp_jsonLinq;

public class StudentUtilities
{
    private readonly List<Student> _students;

    public StudentUtilities(List<Student> students)
    {
        _students = students;
    }

    #region 1
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
    #endregion


    #region 2

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

    #endregion
    
    #region 3

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

    #endregion

    #region 4
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
    

    #endregion

    #region 5

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

    #endregion

    #region 6

    // 6. Villkorskontroll – kontrollera betyg
    // Kontrollera om alla i "Undersköterska" har godkänt (>= 50).
    // Returnera true eller false.
    // */
        public bool AllNursesStudentsArePassing()
        {
            var allNursesPass = _students
                .Where(s => s.Program.Name == "Undersköterska")
                .All(s => s.Grade >= 50);

            return allNursesPass;
        }


    #endregion

    #region 7

    // /*
// 7. Åldersberäkning – äldsta studenten
// Returnera den student som är äldst.
// */
    public List<Student> GetOldestStudent()
    {
        var oldestStudent = _students
            .OrderBy(s => s.Birthdate)
            .Take(1)
            .ToList();

        return oldestStudent;
    }

    #endregion
    
    #region 8

    
// /*
// 8. Urval – top 5
// Returnera de 5 studenter med högst betyg.
// */
    public List<Student> GetTop5Students()
    {
        var top5Students = _students
            .OrderByDescending(s => s.Grade)
            .Take(5)
            .ToList();

        return top5Students;
    }
    #endregion

    #region 9

    
// /*
// 9. Transformation – andel avklarade terminer
// Returnera namn + procent avklarade terminer.
// Exempel: "Adam - 70%"
// */
    public Dictionary<string, double> GetCompletionPercentage()
    {
         
        // Returnera namn och procent "Adam - 70%". Detta innebär en string, men jag tror det bara är dåligt
        // formulerat. Detta handlar om att få ut en För att få fram dessa värden
        // så behöver vi peka ut en student, och få dess namn, deras CurrentSemester och TotalSemesters.
        // Oklart om detta ska skriva ut en elev eller flera, men förmodar flera.
         
        // Kolla i _students, välj ut studenters namn, och semestervärden. Hur?
        // Jag kan göra detta, men inte med LINQ.

        Dictionary<string, double> completionPercentage = new Dictionary<string, double>();
         
        foreach (var s in _students) 
        {
            double currentSemester = Convert.ToDouble(s.Program.CurrentSemester);
            double totalSemesters = Convert.ToDouble(s.Program.TotalSemesters);
            completionPercentage.Add(s.Name, currentSemester / totalSemesters * 100);
        }
         
        return completionPercentage;
    }
    #endregion
    
    #region 10

    // /*
    // 10. Gruppfiltrering – program med snitt > 70
    // Returnera programnamn där medelbetyget överstiger 70.
    // Exempel: "Sjuksköterska"
    // */
    public List<string> GetProgramsWithHighAverage()
    {
        var programs = _students
            .GroupBy(s => s.Program.Name);

        List<string> nerdyProgram = new List<string>();
         
        foreach (var program in programs)
        {
            double average = program.Average(s => s.Grade);

            if (average > 70)
            {
                nerdyProgram.Add(program.Key);
            }
        }
         

        return nerdyProgram;
    }

    #endregion
    
    }