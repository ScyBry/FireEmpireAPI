﻿using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<IProjectRepository> _projectRepository;

    private readonly RepositoryContext _repositoryContext;


    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _projectRepository = new Lazy<IProjectRepository>(() => new ProjectRepository(_repositoryContext));
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_repositoryContext));
    }


    public IProjectRepository Project => _projectRepository.Value;
    public IProductRepository Product => _productRepository.Value;

    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }


    public void Save()
    {
        _repositoryContext.SaveChanges();
    }
}