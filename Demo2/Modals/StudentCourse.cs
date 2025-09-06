using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2.Modals
{
    //1 to many
    internal class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int? Degree { get; set; }
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }
    }
}
