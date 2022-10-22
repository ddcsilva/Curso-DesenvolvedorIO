// Builder que será o meio de acesso de todos os recursos
// Tudo inicia a partir do builder
var builder = WebApplication.CreateBuilder(args);

// Adicionando o MVC ao container
builder.Services.AddControllersWithViews();

// Construção da APP
// Realizando o buid das configurações que resultará na App
var app = builder.Build();

// Ativando a pagina de erros caso seja ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Adicionando Rota padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Rodando a APP
app.Run();