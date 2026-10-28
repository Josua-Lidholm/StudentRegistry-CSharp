using System.Text.Json.Serialization;

namespace CSharp_jsonLinq;

public class ProgramInfo
{
    public string Name { get; set; }
    [JsonPropertyName("current_semester")]
    public int CurrentSemester { get; set; }
    [JsonPropertyName("total_semesters")]
    public int TotalSemesters { get; set; }
}