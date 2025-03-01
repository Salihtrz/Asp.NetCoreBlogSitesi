#define salihveritabani
#undef iremveritabani

using System;
using System.Collections.Generic;
using DataAccess.Context;   
using EFLayer.Class;

using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;



public partial class IKBlokContex : DbContext
{
    public IKBlokContex()
    {
    }

    public IKBlokContex(DbContextOptions<IKBlokContex> options)
       : base(options)
    {
    }

    public virtual DbSet<Gonderiler> Gonderis { get; set; }
    public virtual DbSet<Kategories> Kategories { get; set; }
    public virtual DbSet<Iletisim> Iletisims { get; set; }
    public virtual DbSet<Hakkimda> Hakkimdas { get; set; }
    public virtual DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlServer("Data Source=SALIH\\SQLEXPRESS;Initial Catalog=IKBlok;Integrated Security=True;TrustServerCertificate=True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gonderiler>(entity =>
        {
            entity.ToTable("Gonderiler");

            entity.Property(e => e.GonderiId);
            entity.Property(e => e.GonderiName);
			entity.Property(e => e.GonderiBaslik);
			entity.Property(e => e.GonderiIcerik);
			entity.Property(e => e.GonderiResim);

			entity.HasOne(e => e.Kategories)
            .WithMany(e => e.Gonderiler)
            .HasForeignKey(e => e.kategoriId);

        });
        


        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId);
			entity.Property(e => e.Name);
			entity.Property(e => e.SurName);
			entity.Property(e => e.UserAdi);
		    entity.Property(e => e.Password);
		    entity.Property(e => e.RoleId);
	
});

        modelBuilder.Entity<Kategories>(entity =>
        {
            entity.ToTable("Kategories");

            entity.Property(e => e.kategoriId);
            entity.Property(e => e.kategoryName);

        });

        modelBuilder.Entity<Iletisim>(entity =>
        {
            entity.ToTable("Iletisim");

            entity.Property(e => e.IletisimId);
            entity.Property(e => e.Adres);
            entity.Property(e => e.Mail);
            entity.Property(e => e.Telefon);



        });

        modelBuilder.Entity<Hakkimda>(entity =>
        {
            entity.ToTable("Hakkimda");

            entity.Property(e => e.hakkimdaId);
            entity.Property(e => e.baslik);
            entity.Property(e => e.icerik);
            entity.Property(e => e.resimLinki);


        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
