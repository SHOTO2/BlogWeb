using System;
using System.Collections.Generic;
using BlogWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogWeb;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comments>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comments__C3B4DFAAD4693F46");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.Contant).HasMaxLength(50);
            entity.Property(e => e.PostsId).HasColumnName("PostsID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Posts).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__PostsI__4AB81AF0");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__UserID__49C3F6B7");
        });

        modelBuilder.Entity<Posts>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Posts__AA126038EE6D6FDE");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Posts__UserID__398D8EEE");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC4A45038F");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserRole).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
