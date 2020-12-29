using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo.Areas.Identity;
using ToDo.Areas.Identity.Models;

namespace ToDo.Areas.Identity
{
    public class ToDoAppContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ToDoAppContext(DbContextOptions<ToDoAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ToDoList> ToDoLists { get; set; }
    


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoList>(entity =>
            {
                entity.ToTable("ToDoList");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContentToDo)
                    .HasMaxLength(200)
                    .HasColumnName("contentToDo")
                    .IsFixedLength(true);

                entity.Property(e => e.Date)
                    .HasMaxLength(10)
                    .HasColumnName("date");

                entity.Property(e => e.Hour)
                    .HasMaxLength(8)
                    .HasColumnName("hour")
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("title")
                    .IsFixedLength(true);

            });

        }

    }
}
