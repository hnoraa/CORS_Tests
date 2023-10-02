var AllowSpecificOrigins = "_corsPolicy";

var builder = Host.CreateDefaultBuilder()
    .ConfigureWebHostDefaults(webBuilder => 
    {
        webBuilder.ConfigureServices((ctx, svc) => 
        {
            svc.AddControllers();

            svc.AddCors(options => {
                options.AddPolicy(name: AllowSpecificOrigins,
                    policy => {
                        policy.WithOrigins("http://localhost:3000", "http://localhost:81");
                    });
            });
        });

        webBuilder.Configure((ctx, app) =>
        {
            if(ctx.HostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/home/error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(AllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapGet("hello", async () => 
                {
                    return Results.Ok(new Payload("hello", "THis is a test route"));
                });
            });
        });
    });

builder.Build().Run();

internal record Payload(string route, string message);