using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class Product
    {
        [Key] //Primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Auto Generation
        public Guid Id { get; set; }    

        [Required] //Mandatory
        public string Name { get; set; }
        public string Description { get; set; }

        [Required] //Mandatory
        public double Price { get; set; }
        public int Stock{ get; set; }

        [Required] //Mandatory
        public virtual Category Category { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public string ImageURL { get; set; }

        public bool Disabled { get; set; }
    }
}
