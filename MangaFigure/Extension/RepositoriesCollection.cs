using MangaFigure.Models;
using MangaFigure.Repositories;

namespace MangaFigure.Extension;

public static class RepositoriesCollection
{
    public static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<AccountRepository, AccountRepository>();
        serviceCollection.AddScoped<NavbarRepository, NavbarRepository>();
        serviceCollection.AddScoped<SiteRepository, SiteRepository>();
        serviceCollection.AddScoped<CustomerRepository, CustomerRepository>();
        serviceCollection.AddScoped<CartRepository, CartRepository>();
        serviceCollection.AddScoped<AnnouncementRepository, AnnouncementRepository>();
        serviceCollection.AddScoped<EmployeeRepository, EmployeeRepository>();
        serviceCollection.AddScoped<ContactRepository, ContactRepository>();
        serviceCollection.AddScoped<ProductImageRepository, ProductImageRepository>();
        serviceCollection.AddScoped<ProductRepository, ProductRepository>();
        serviceCollection.AddScoped<ProductReviewRepository, ProductReviewRepository>();
        serviceCollection.AddScoped<TransactionRepository, TransactionRepository>();
        serviceCollection.AddScoped<TransactionDetailRepository, TransactionDetailRepository>();
        serviceCollection.AddScoped<TransactionStatusRepository, TransactionStatusRepository>();
        serviceCollection.AddScoped<VoucherRepository, VoucherRepository>();
        serviceCollection.AddScoped<FileRepository, FileRepository>();
        serviceCollection.AddScoped<CatalogRepository, CatalogRepository>();
        serviceCollection.AddScoped<TestRepository, TestRepository>();
    }
}