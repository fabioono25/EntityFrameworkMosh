using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pluto
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[Required]
        public string Description { get; set; }
        //public Category Category { get; set; }
        public DateTime? DatePublished { get; set; }
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }
        
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        
        public IList<Tag> Tags { get; set; }

        public Cover Cover { get; set; }
    }
}
