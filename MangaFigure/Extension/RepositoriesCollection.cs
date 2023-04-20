using MangaFigure.Models;
using MangaFigure.Repositories;

namespace MangaFigure.Extension;

public static class RepositoriesCollection
{
    public static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<AccountRepository, AccountRepository>();
        serviceCollection.AddTransient<NavbarRepository, NavbarRepository>();
        serviceCollection.AddTransient<SiteRepository, SiteRepository>();
        serviceCollection.AddTransient<CustomerRepository, CustomerRepository>();
        serviceCollection.AddTransient<CartRepository, CartRepository>();
        serviceCollection.AddTransient<AnnouncementRepository, AnnouncementRepository>();
        serviceCollection.AddTransient<EmployeeRepository, EmployeeRepository>();
        serviceCollection.AddTransient<ContactRepository, ContactRepository>();
        serviceCollection.AddTransient<ProductImageRepository, ProductImageRepository>();
        serviceCollection.AddTransient<ProductRepository, ProductRepository>();
        serviceCollection.AddTransient<ProductReviewRepository, ProductReviewRepository>();
        serviceCollection.AddTransient<TransactionRepository, TransactionRepository>();
        serviceCollection.AddTransient<TransactionDetailRepository, TransactionDetailRepository>();
        serviceCollection.AddTransient<TransactionStatusRepository, TransactionStatusRepository>();
        serviceCollection.AddTransient<VoucherRepository, VoucherRepository>();
        serviceCollection.AddTransient<FileRepository, FileRepository>();
        serviceCollection.AddTransient<TestRepository, TestRepository>();
    }
}