using LevelUp.CSharpJuniors.Project.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace LevelUp.CSharpJuniors.Project.DAL
{
    public sealed class ProductsDbContext : DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<ProductEntity>? Products { get; set; }
    }
}