﻿using System;
using BookReading.DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookReading.Infrastructure.Mappings
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    { 

        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(b => b.Author)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(b => b.Description)
                .IsRequired(false)
                .HasColumnType("varchar(350)");

            builder.Property(b => b.Value)
                .IsRequired();

            builder.Property(b => b.PublishDate)
                .IsRequired();

            builder.Property(b => b.CategoryId)
                .IsRequired();

            builder.ToTable("Books");
        }
    }
}

