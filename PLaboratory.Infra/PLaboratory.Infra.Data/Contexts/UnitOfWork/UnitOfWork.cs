﻿using Microsoft.EntityFrameworkCore;
using PLaboratory.Core.Domain.DbContexts.UnitOfWork;

namespace PLaboratory.Infra.Data.Contexts.UnitOfWork;

public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
{
    private readonly TDbContext _context;

    public UnitOfWork(TDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task RollbackAsync()
    {
        await _context.DisposeAsync();
    }
}

public class UnitOfWork<TDbContext, TDbContext2> : IUnitOfWork where TDbContext : DbContext where TDbContext2 : DbContext
{
    private readonly TDbContext _context1;
    private readonly TDbContext2 _context2;

    public UnitOfWork(TDbContext context1,
        TDbContext2 context2)
    {
        _context1 = context1;
        _context2 = context2;
    }

    public async Task CommitAsync()
    {
        await _context1.SaveChangesAsync();
        await _context2.SaveChangesAsync();
    }

    public async Task RollbackAsync()
    {
        await _context2.DisposeAsync();
        await _context2.DisposeAsync();
    }
}

public class UnitOfWork<TDbContext, TDbContext2, TDbContext3> : IUnitOfWork where TDbContext : DbContext where TDbContext2 : DbContext where TDbContext3 : DbContext
{
    private readonly TDbContext _context1;
    private readonly TDbContext2 _context2;
    private readonly TDbContext3 _context3;

    public UnitOfWork(TDbContext context1,
        TDbContext2 context2,
        TDbContext3 context3)
    {
        _context1 = context1;
        _context2 = context2;
        _context3 = context3;
    }

    public async Task CommitAsync()
    {
        await _context1.SaveChangesAsync();
        await _context2.SaveChangesAsync();
        await _context3.SaveChangesAsync();
    }

    public async Task RollbackAsync()
    {
        await _context1.DisposeAsync();
        await _context2.DisposeAsync();
        await _context3.DisposeAsync();
    }
}