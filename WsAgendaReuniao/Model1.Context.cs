﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WsAgendaReuniao
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SalaReuniaoEntities : DbContext
    {
        public SalaReuniaoEntities()
            : base("name=SalaReuniaoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<Periodos> Periodos { get; set; }
        public virtual DbSet<Reservas> Reservas { get; set; }
        public virtual DbSet<Salas> Salas { get; set; }
    }
}
