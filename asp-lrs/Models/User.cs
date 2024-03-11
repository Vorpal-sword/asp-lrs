using System.ComponentModel.DataAnnotations;

namespace asp_lrs.Models
{
    public class User
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
        public int Count { get; set; }
    }
}
