﻿using Mango.Services.CartApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CartApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<CartHeader> CartHeaders { get; set; }
    public DbSet<CartDetails> CartDetails { get; set; }




}
