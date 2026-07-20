using FullStack_BrianBuenJA.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGreetingService, GreetingService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.Use(async(context,next)=>
{
    var start = DateTime.UtcNow;
    await next();
    var elapsed = DateTime.UtcNow - start;
    Console.Write($"{context.Request.Method}{context.Request.Path}=>{elapsed.TotalMilliseconds:F1}s");
});
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
