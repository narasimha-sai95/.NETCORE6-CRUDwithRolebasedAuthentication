using System.ComponentModel.DataAnnotations;

namespace Practice_CRUD.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }

        public string EName { get; set; }

        public string Gender { get; set; }

        public string EDesig { get; set; }

        public string joindate { get; set; }



        


    }
}
