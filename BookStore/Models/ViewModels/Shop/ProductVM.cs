using BookStore.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Models.ViewModels.Shop
{
    public class ProductVM
    {
        public ProductVM()
        {

        }
        public ProductVM(ProductDTO row)
        {
            Id = row.Id;
            Name = row.Name;
            Slug = row.Slug;
            Description = row.Description;
            Price = row.Price;
            CategoryName = row.CategoryName;
            CategoryId = row.CategoryId;
            ImageName = row.ImageName;
            Quantity = row.Quantity;

            AuthorName = row.AuthorName;            
            AuthorId = row.AuthorId;

            PubHouseName = row.PubHouseName;
            PubHouseId = row.PubHouseId;


        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string ImageName { get; set; }

        public int Quantity { get; set; }

        public string AuthorName { get; set; }
        [Required]
        public int AuthorId { get; set; }

        public string PubHouseName { get; set; }
        [Required]
        public int PubHouseId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
        public IEnumerable<SelectListItem> PubHouses { get; set; }

        public IEnumerable<string> GalleryImages { get; set; }


    }
}