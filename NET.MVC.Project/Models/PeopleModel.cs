using System.Collections.Generic;

namespace NET.MVC.Project.Models
{

    public class PeopleModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Height { get; set; }

        public List<string> Likes { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Gender}-{Age}-{Height}";
        }
    }
}
