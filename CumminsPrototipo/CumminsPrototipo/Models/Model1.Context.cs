﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CumminsPrototipo.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SPI_DB_PROTOTIPOSEntities : DbContext
    {
        public SPI_DB_PROTOTIPOSEntities()
            : base("name=SPI_DB_PROTOTIPOSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EMAIL> EMAIL { get; set; }
        public virtual DbSet<GRUPO_EMAIL> GRUPO_EMAIL { get; set; }
        public virtual DbSet<PROTOTIPO> PROTOTIPO { get; set; }
        public virtual DbSet<PROTOTIPO_GRUPO_EMAIL> PROTOTIPO_GRUPO_EMAIL { get; set; }
    }
}