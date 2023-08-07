using System.ComponentModel.DataAnnotations.Schema;

namespace TRYING.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string description { get; set; }

    }
}
