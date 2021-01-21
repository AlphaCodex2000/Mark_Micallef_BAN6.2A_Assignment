using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Email { get; set; }

        [ForeignKey("Product")]
        public Guid ProductFK { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
