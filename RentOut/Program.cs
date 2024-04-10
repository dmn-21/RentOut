using RentOut.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentOut.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAplicationDbContext(builder.Configuration);
builder.Services.AddAplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddAplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Car Details",
        pattern: "/Car/Details/{id}/{information}",
        defaults: new { Controller = "Car", Action = "Details" }
    );
    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

await app.CreateAdminRoleAsync();
await app.RunAsync();