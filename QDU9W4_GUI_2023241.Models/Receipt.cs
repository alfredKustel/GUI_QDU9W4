using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QDU9W4_GUI_2023241.Models
{
    public class Receipt
    {

        //This class represents the specialities of my chefs, as well as the recepies that are served in my restaurants
        //Every individual food has an ID, representing them on the menu
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        //As information we store their names, price, the restaurants id where we serve them and the shefs id who makes them
        //in the data
        [Required]
        public string Name { get; set; }
        public int Price { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public int RestaurantID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Restaurant Restaurant { get; set; }
        [ForeignKey(nameof(Chef))]
        public int ChefID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Chef Chef { get; set; }
        public Receipt()
        {

        }
    }
}
