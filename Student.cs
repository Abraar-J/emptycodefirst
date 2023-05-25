using System.ComponentModel.DataAnnotations;

namespace emptycodefirst
{
    public class Student
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public int age { get; set; }
    }
}
