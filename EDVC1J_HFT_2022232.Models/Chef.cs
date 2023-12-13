using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EDVC1J_HFT_2022232.Models
{
    public class Chef
    {

        //This class is representing the chefs, whos working for my restaurants
        //All of them gets an ID, that represents them individuali in the system
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //We store their personal data(name, age, specialities)
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        [ForeignKey(nameof(Restaurant))]

        //And the restaurant where they work.
        public int RestaurantID { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Restaurant Restaurant { get; set; }
        [JsonIgnore]
        public virtual ICollection<Receipt> Specialities { get; set; }
        public Chef()
        {
            Specialities = new HashSet<Receipt>();
           
        }
        
    }
}
