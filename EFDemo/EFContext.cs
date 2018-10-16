using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace EFDemo
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Server=(localdb)\\mssqllocaldb;Database=DemoDB;Trusted_Connection=true;AttachDbFilename=C:\\temp\\tempdb.mdf")
        {

        }

        public DbSet<Person> Person { get; set; }
    }
}
