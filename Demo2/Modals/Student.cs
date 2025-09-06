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
    internal class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StdId { get; set; }
        //[Column("New Name Of Column")]
        [StringLength(20)]
        [Required]
        public string Name { get; set; }
        public int? Age { get; set; }
        public override string ToString() => $"{StdId}, {Name}, {Age}";
    }
}
