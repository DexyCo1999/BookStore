using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models.Data
{
    public class Db : DbContext //Uvodim entity framework i ovo Db se nalazi u Web.configu (veza sa bazom)
    {
        //kako pistupam tabelama kroz entity framework
        public DbSet<PageDTO> Pages { get; set; }
        public DbSet<SidebarDTO> Sidebar { get; set; }
        public DbSet<CategoryDTO> Categories { get; set; }
        public DbSet<AuthorDTO> Authors { get; set; }
        public DbSet<PubHouseDTO> PubHouses { get; set; }     
        public DbSet<ProductDTO> Products { get; set; }
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<RoleDTO> Roles { get; set; }
        public DbSet<UserRoleDTO> UserRoles { get; set; }
    }
}