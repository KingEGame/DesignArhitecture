using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Design.objects;

namespace Design.services
{
    class DatabaseContext : DbContext
    {
        public DbSet<Order> orders { get; set; }
        public DbSet<TypeOfItem> typeOfItems { get; set; }
        public DbSet<TypeOfService> typeOfServices { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Tariff> tariffs { get; set; }
        public DbSet<Employer> employers { get; set; }

        //public DatabaseContext()
        //{
        //    Database.EnsureDeleted();   // удаляем бд со старой схемой
        //    Database.EnsureCreated();   // создаем бд с новой схемой
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=KINGWARPC;Database=Atelier;Trusted_Connection=True;");
        }
    }
}
