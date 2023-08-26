using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestoAppWeb.Models;

namespace RestoAppWeb.Data;

public partial class RestoAppContext : DbContext
{
    public RestoAppContext()
    {
    }

    public RestoAppContext(DbContextOptions<RestoAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Commande> Commandes { get; set; }

    public virtual DbSet<CommandeDetail> CommandeDetails { get; set; }

    public virtual DbSet<Produit> Produits { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Commande>(entity =>
        {
            entity.HasIndex(e => e.ClientId, "IX_Commandes_ClientId");

            entity.HasOne(d => d.Client).WithMany(p => p.Commandes).HasForeignKey(d => d.ClientId);
        });

        modelBuilder.Entity<CommandeDetail>(entity =>
        {
            entity.HasIndex(e => e.CommandeId, "IX_CommandeDetails_CommandeId");

            entity.HasIndex(e => e.ProduitId, "IX_CommandeDetails_ProduitId");

            entity.HasOne(d => d.Commande).WithMany(p => p.CommandeDetails).HasForeignKey(d => d.CommandeId);

            entity.HasOne(d => d.Produit).WithMany(p => p.CommandeDetails).HasForeignKey(d => d.ProduitId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
