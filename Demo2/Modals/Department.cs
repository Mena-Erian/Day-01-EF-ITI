using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2.Modals
{
    internal class Department // Many
    {

        //public int DepartmentId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Data Annotation
        public int Id { get; set; } // USing Convension
        [Required]
        [StringLength(20)]
        public string DeptName { get; set; }
        public int? Capacity { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();//Should Initil, to be able to Add() to this list
        public virtual List<Course> Courses { get; set; } = new List<Course>();

        public override string ToString()
            => $"Department Id: {Id}, Name: {DeptName}, Capacity: {(Capacity.HasValue ? Capacity.Value.ToString() : "N/A")}";

    }
}
