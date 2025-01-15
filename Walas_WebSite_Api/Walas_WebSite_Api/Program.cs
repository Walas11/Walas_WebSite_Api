var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Personaliza la información del documento
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Walas WebSite Api 👽⚡",
        Version = "v1",
        Description = "Descripción de la API de Walas WebSite\r\n\r\n" +
        "La API de Walas WebSite permite interactuar con los servicios y datos del sitio de forma segura y eficiente. Proporciona funcionalidades clave como:\r\n\r\n" +
        "Gestión de usuarios: Creación, actualización y administración.\r\n\r\n" +
        "Acceso a contenido: Consulta de publicaciones y recursos multimedia.\r\n\r\n" +
        "Autenticación: Uso de tokens para operaciones seguras.\r\n\r\n" +
        "Consultas avanzadas: Filtros, ordenamiento y paginación.\r\n\r\n" +
        "Esta API está diseñada para facilitar la integración con aplicaciones externas, automatizar tareas y extender la funcionalidad del sitio web.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Sebastián Acero León",
            Email = "sebastianaceroleon@outlook.com",
            Url = new Uri("https://walaswebsite-mvc-ajd6dmh5g5csd6bb.brazilsouth-01.azurewebsites.net/#hero")
        }
    });

    // Habilita anotaciones en Swagger
    options.EnableAnnotations();
});

var app = builder.Build();

// Configura el middleware de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // Personaliza la interfaz de SwaggerUI
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        options.DocumentTitle = "Documentación de Mi API";
    });
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
