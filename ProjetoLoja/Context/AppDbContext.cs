﻿using Microsoft.EntityFrameworkCore;
using ProjetoLoja.Models;

namespace ProjetoLoja.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    
    public DbSet<CarrinhoCompraItem> ItensCarrinho { get; set; }
}