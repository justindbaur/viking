using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using Viking.Entities;

namespace Viking.Contexts
{
    public static class Helpers
    {
        public static EntityTypeBuilder<T> DefaultConfigure<T>(this EntityTypeBuilder<T> builder, Expression<Func<T, object>> keyExpression)
            where T : AuditableEntity
        {
            // Rename table to the types name
            builder.ToTable(typeof(T).Name.ToLower());

            // Configure the keys they passed in
            builder.HasKey(keyExpression);

            // Configure the default alternate key
            builder.HasAlternateKey(i => new { i.RowId });

            // Give the builder back
            return builder;
        }

        public static EntityTypeBuilder<T> DefaultConfigure<T>(this EntityTypeBuilder<T> builder)
            where T : EntityBase
        {
            // Rename table to the types name
            builder.ToTable(typeof(T).Name);

            // Configure the default primary key
            builder.HasKey(i => new { i.RowId });

            // Give the builder back
            return builder;
        }
    }
}
