using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class contextDBTriidy :  DbContext
    {
        public contextDBTriidy(DbContextOptions<contextDBTriidy> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer( "Data Source=.;Initial Catalog=PruebaTriidy;Integrated Security=true" );

        //    base.OnConfiguring(optionsBuilder);
        //    //Primer Migracion   Add-Migration InitialCreate
        //    //Despues de la primera migracion se utiliza  Update-Database
        //}
        public DbSet<Contry> Contries { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
