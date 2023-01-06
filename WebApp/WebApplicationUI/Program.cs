var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
//app.UseStatusCodePages(); //404 sayfa y�nlendirmesi
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error","?code={0}"); //Y�nlendirilecek error sayfas�n�n belirlenmesi

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}");

app.Run();
