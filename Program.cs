using LevelUp.CSharpJuniors.Project.DAL;
using LevelUp.CSharpJuniors.Project.Services;

var builder = WebApplication.CreateBuilder(args); // коробочка дл€ деталей лего

// Add services to the container.

builder.Services.AddControllers(); // добавл€ет механизм рутировани€
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // дл€ сваггера
builder.Services.AddSwaggerGen(); 

// Dependencies - инъекции зависимостей
builder.Services.AddDbContext<ProductsDbContext>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>(); // когда в конструкторе будет прокидыватьс€ интерфейс - создай экземпл€р класса
// addscope - будем создаватьс€ экземпл€р класса на каждый запрос, если синглтон - все будут работать с 1 экземпл€ром
builder.Services.AddScoped<IProductsService, ProductsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // включаем сваггер, выставл€етс€ в переменных окружени€
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // кубик прокси

app.UseAuthorization();

app.MapControllers(); // создание таблицы рутировани€, карта контроллеров с методами

app.Run(); // запуск приложени€