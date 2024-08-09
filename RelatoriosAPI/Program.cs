using System.Reflection;
using System.Runtime.Loader;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.EntityFrameworkCore;
using RelatoriosAPI.Application.Services;
using RelatoriosAPI.Domain.Interfaces;
using RelatoriosAPI.Domain.Services;
using RelatoriosAPI.Infrastructure.Data;
using RelatoriosAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Registrar repositórios e serviços
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Registrar serviços para geração de relatórios
builder.Services.AddScoped<IPdfReportService, PdfReportService>();
builder.Services.AddScoped<IExcelReportService, ExcelReportService>();
builder.Services.AddScoped<ICsvReportService, CsvReportService>();

// Registrar o serviço de conversão de PDF
builder.Services.AddSingleton<IConverter, SynchronizedConverter>(
    provider => new SynchronizedConverter(new PdfTools())
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o uso da porta 8080 apenas no ambiente de publicação
if (!app.Environment.IsDevelopment())
{
    app.Urls.Add("http://*:8080");
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

// Classe CustomAssemblyLoadContext para carregar a biblioteca nativa
public class CustomAssemblyLoadContext : AssemblyLoadContext
{
    public CustomAssemblyLoadContext()
        : base(true) { }

    protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
    {
        string filePath = Path.Combine(Environment.CurrentDirectory, $"{unmanagedDllName}.dll");
        if (!File.Exists(filePath))
        {
            throw new DllNotFoundException(
                $"Unable to find library '{filePath}'. Ensure the library is present in the application directory."
            );
        }
        return LoadUnmanagedDllFromPath(filePath);
    }

    protected override Assembly? Load(AssemblyName assemblyName)
    {
        return null;
    }
}
