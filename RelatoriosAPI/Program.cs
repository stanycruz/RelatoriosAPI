using System.Reflection;
using System.Runtime.InteropServices;
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

// Determinar a biblioteca nativa correta
string libraryFileName;
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    libraryFileName = "libwkhtmltox.dll";
else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
    libraryFileName = "libwkhtmltox.so";
else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
    libraryFileName = "libwkhtmltox.dylib";
else
    throw new PlatformNotSupportedException("Unsupported OS platform");

// Configurar o diretório base entre ambiente de publicação ou desenvolvimento
var environment = builder.Environment;
var baseDirectory = environment.IsDevelopment()
    ? Directory.GetCurrentDirectory()
    : AppContext.BaseDirectory;

var nativeLibraryPath = Path.Combine(
    baseDirectory,
    "lib",
    RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
        ? "windows"
        : (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "linux" : "macos"),
    libraryFileName
);

var context = new CustomAssemblyLoadContext();
context.LoadUnmanagedLibrary(nativeLibraryPath);

// Registrar o serviço de conversão de PDF
builder.Services.AddSingleton<IConverter, SynchronizedConverter>(
    provider => new SynchronizedConverter(new PdfTools())
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o uso das portas apenas em ambiente de publicação
if (!app.Environment.IsDevelopment())
{
    app.Urls.Add("http://*:5000");
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

// Classe CustomAssemblyLoadContext para carregar a biblioteca nativa
public class CustomAssemblyLoadContext : AssemblyLoadContext
{
    public CustomAssemblyLoadContext()
        : base(true) { }

    public IntPtr LoadUnmanagedLibrary(string absolutePath)
    {
        return LoadUnmanagedDllFromPath(absolutePath);
    }

    protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
    {
        return LoadUnmanagedDllFromPath(unmanagedDllName);
    }

    protected override Assembly? Load(AssemblyName assemblyName)
    {
        return null;
    }
}
