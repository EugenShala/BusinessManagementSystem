using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BMS.DataAccess.Models
{
    public class ProductService
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Name")]
        public string Name { get; set; }
        [Required, Display(Name = "Description")]

        public string Description { get; set; }
        [Required, Display(Name = "Price")]

        public decimal Price { get; set; }


        public ApplicationUser ApplicationUser { get; set; }
    }
}
