using AutoMapper;
using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository;
using Fiap.Web.AspNet3.Repository.Interface;
using Fiap.Web.AspNet3.ViewModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*Inserindo DB*/
var connectionString = builder.Configuration.GetConnectionString("databaseUrl");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging(true));



#region IoC
builder.Services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFornecedorRepository, FornecedoresRepository>();
builder.Services.AddScoped<IGerenteRepository, GerenteRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
#endregion


var mapperConfig = new AutoMapper.MapperConfiguration(c =>
{
    c.AllowNullCollections = true;

    c.CreateMap<UsuarioModel, LoginViewModel>();
    c.CreateMap<LoginViewModel, UsuarioModel>();

    //Representante
    //c.CreateMap<IList<RepresentanteModel>, IList<RepresentanteViewModel>>();
    c.CreateMap<RepresentanteViewModel, RepresentanteModel>();
    c.CreateMap<RepresentanteModel, RepresentanteViewModel>();


    //Cliente
    //c.CreateMap<IList<ClientModel>, IList<ClienteViewModel>>();
    c.CreateMap<ClienteViewModel, ClientModel>();
    c.CreateMap<ClientModel, ClienteViewModel>();

    //For Member Ignore

    //c.CreateMap<RepresentanteModel, RepresentanteViewModel>().
    //ForMember(vm => vm.RepresentanteId, m => m.MapFrom(d => d.RepresentanteId)).
    //ForMember(vm => vm.RepresentanteId, m => m.MapFrom(d => d.RepresentanteId);
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
