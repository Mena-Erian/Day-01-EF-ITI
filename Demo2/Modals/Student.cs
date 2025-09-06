using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2.Modals
{
    //[Table("")]
    internal class Student //1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StdId { get; set; }
        //[Column("New Name Of Column")]
        [StringLength(20)]
        [Required]
        public string Name { get; set; }
        public int? Age { get; set; }
        [ForeignKey(nameof(Std))]
        public int? SuperViser { get; set; }
        public virtual Student Std { get; set; }
        public string Email { get; set; }

        // to Act the foreignKey in Code
        [ForeignKey("Department")]
        public int DeptNum { get; set; } // if you don't make it nullable it will to be in deleted casced,
        //  
        //  [ForeignKey("DeptNum")]
        public virtual Department Department { get; set; } // one to manyn relation
        public virtual List<StudentCourse> StudentCourses { get; set; }

        public override string ToString() => $"{StdId}, {Name}, {Age}";
    }
}
