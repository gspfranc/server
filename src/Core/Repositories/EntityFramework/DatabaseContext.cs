﻿using System;
using Bit.Core.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Bit.Core.Repositories.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        public DbSet<Cipher> Ciphers { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionCipher> CollectionCiphers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<EmergencyAccess> EmergencyAccesses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Grant> Grants { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Installation> Installations { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationUser> OrganizationUsers { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Send> Sends { get; set; }
        public DbSet<SsoConfig> SsoConfigs { get; set; }
        public DbSet<SsoUser> SsoUsers { get; set; }
        public DbSet<TaxRate> TaxRates { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<U2f> U2fs { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cipher>().Ignore(e => e.Data);
            builder.Entity<Cipher>().Property(e => e.DataJson).HasColumnName("Data");
            builder.Entity<Cipher>().Ignore(e => e.Attachments);
            builder.Entity<Cipher>().Property(e => e.AttachmentsJson).HasColumnName("Attachments");
            builder.Entity<Cipher>().Ignore(e => e.Favorites);
            builder.Entity<Cipher>().Property(e => e.FavoritesJson).HasColumnName("Favorites");
            builder.Entity<Cipher>().Ignore(e => e.Folders);
            builder.Entity<Cipher>().Property(e => e.FoldersJson).HasColumnName("Folders");

            builder.Entity<User>().Ignore(e => e.TwoFactorProviders);
            builder.Entity<User>().Property(e => e.TwoFactorProvidersJson).HasColumnName("TwoFactorProviders");

            builder.Entity<Organization>().Ignore(e => e.TwoFactorProviders);
            builder.Entity<Organization>().Property(e => e.TwoFactorProvidersJson).HasColumnName("TwoFactorProviders");

            builder.Entity<User>().ToTable(nameof(User));
            builder.Entity<Cipher>().ToTable(nameof(Cipher));
            builder.Entity<Organization>().ToTable(nameof(Organization));
        }
    }
}
