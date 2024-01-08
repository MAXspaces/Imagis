using Imagist_Backend;

var builder = WebApplication.CreateBuilder(args);
//设置配置项
builder.ConfigServer();
builder.RegisterComponents();
builder.RegisterServices();

var app = builder.Build();

//open swagger if in dev env
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();