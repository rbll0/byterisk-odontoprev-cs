using byterisk_odontoprev_cs.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o ApplicationDbContext com a configuração de conexão com Oracle
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona os serviços necessários para controladores e visualizações
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuração do pipeline de requisição HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Redirecionamento para a página de erro em produção
    app.UseHsts(); // Ativa o HSTS para segurança adicional
}

// Redireciona para HTTPS automaticamente
app.UseHttpsRedirection();

// Serve arquivos estáticos, como CSS e JavaScript
app.UseStaticFiles();

// Configura o roteamento da aplicação
app.UseRouting();

// Configura a autorização, caso você tenha alguma implementação de autenticação/autorizações
app.UseAuthorization();

// Configura a rota padrão para a aplicação
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}"); // Define que a página de login é a padrão

app.Run();
