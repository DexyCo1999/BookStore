using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookStore.Models.Data
{
    [Table("tblProducts")]
    public class ProductDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
     
        public int CategoryId { get; set; }

        public string AuthorName { get; set; }

        public int AuthorId { get; set; }

        public string PubHouseName { get; set; }

        public int PubHouseId { get; set; }
        public string ImageName { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CategoryDTO Category { get; set; }

        [ForeignKey("AuthorId")]
        public virtual AuthorDTO Author { get; set; }

        [ForeignKey("PubHouseId")]
        public virtual PubHouseDTO PubHouse { get; set; }

    }
}