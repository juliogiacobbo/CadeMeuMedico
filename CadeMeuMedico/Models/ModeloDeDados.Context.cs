﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CadeMeuMedico.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EntidadesCadeMeuMedicoBD2 : DbContext
    {
        public EntidadesCadeMeuMedicoBD2()
            : base("name=EntidadesCadeMeuMedicoBD2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
