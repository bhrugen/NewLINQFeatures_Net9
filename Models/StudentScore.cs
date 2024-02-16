using System.ComponentModel.DataAnnotations.Schema;

namespace NewLINQFeatures.Models
{
    public class StudentScore
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        //based off 100
        public int Score { get; set; }

        public string SubjectName { get; set; }
    }
}
