﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DesfacaFacil.Models
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class Entidades : DbContext
{
    public Entidades()
        : base("name=Entidades")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<ANUNCIO> ANUNCIOs { get; set; }

    public virtual DbSet<CANDIDATO> CANDIDATOS { get; set; }

    public virtual DbSet<CATEGORIA> CATEGORIAS { get; set; }

    public virtual DbSet<ENDERECO> ENDERECOes { get; set; }

    public virtual DbSet<MENSAGEN> MENSAGENS { get; set; }

    public virtual DbSet<USUARIO> USUARIOS { get; set; }

}

}

