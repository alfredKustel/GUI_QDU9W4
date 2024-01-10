using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDU9W4_GUI_2023241.Models
{
    public class Restaurant
    {

        //This class represents the restaurants where my staff works
        //Every individual restaurant has an ID, representing themself in the database
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //They have their names, staff and menu stored in the database
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Chef> WorkingChefs { get; set; }

        [NotMapped]
        public virtual ICollection<Receipt> Menu { get; set; }
        public Restaurant()
        {
            WorkingChefs = new HashSet<Chef>();
            Menu = new HashSet<Receipt>();
        }
    }
}
