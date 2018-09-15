using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class ToDo
    {
        [Key]
        public int ToDoID { get; set; }
        public string Text { get; set; }
        [Required]
        public DateTime DatetimeCreate { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
        [Required]
        public byte IsClose { get; set; }

        public byte IsAccepted { get; set; }
        public byte IsRemind { get; set; }

        public int RemindTime { get; set; }

        public byte? IsDelete { get; set; }
        [Required]
        [ForeignKey("IdUser")]
        public string IdUser;//{ get; set; }
       
        public virtual ApplicationUser User { get; set; }
    }
    
}