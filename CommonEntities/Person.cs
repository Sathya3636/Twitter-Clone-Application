using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonEntities
{
    [Table("Person")]
    public class Person
    {
        [Key, StringLength(25)]
        public string UserName { get; set; }

        [Required, StringLength(50)]
        public string Password { get; set; }

        [Required, StringLength(30)]
        public string FullName { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }

        [Required]
        public DateTime Joined { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}

