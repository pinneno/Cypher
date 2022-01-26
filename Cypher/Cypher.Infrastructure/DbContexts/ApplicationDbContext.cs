﻿using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Abstractions.Domain;
using AspNetCoreHero.EntityFrameworkCore.AuditTrail;
using Cypher.Application.Interfaces.Contexts;
using Cypher.Application.Interfaces.Shared;
using Cypher.Domain.Entities.Cypher;
using Microsoft.EntityFrameworkCore;

namespace Cypher.Infrastructure.DbContexts {
    public class ApplicationDbContext : AuditableContext, IApplicationDbContext {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base (options) {
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Lobby> Lobbies { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Puzzle> Puzzles { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }
        public DbSet<Question> Questons { get; set; }

        public IDbConnection Connection => Database.GetDbConnection ();

        public bool HasChanges => ChangeTracker.HasChanges ();

        public override async Task<int> SaveChangesAsync (CancellationToken cancellationToken = new CancellationToken ()) {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity> ().ToList ()) {
                switch (entry.State) {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUser.UserId;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                        break;
                }
            }
            if (_authenticatedUser.UserId == null) {
                return await base.SaveChangesAsync (cancellationToken);
            } else {
                return await base.SaveChangesAsync (_authenticatedUser.UserId);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MessagePlayer>().HasKey(mp => new { mp.MessageId, mp.PlayerId });

            builder.Entity<Lobby>()
                .HasOne<Player>(l => l.LobbyAdmin)
                .WithMany(p => p.LobbiesAdmin);

            foreach (var property in builder.Model.GetEntityTypes ()
                    .SelectMany (t => t.GetProperties ())
                    .Where (p => p.ClrType == typeof (decimal) || p.ClrType == typeof (decimal?))) {
                property.SetColumnType ("decimal(18,2)");
            }
            base.OnModelCreating (builder);
        }
    }
}