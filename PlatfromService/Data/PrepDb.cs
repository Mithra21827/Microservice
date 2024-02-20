using PlatfromService.Models;
namespace PlatfromService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceapp = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceapp.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {

            if (!context.platforms.Any())
            {

                Console.WriteLine("--> Seeding data");

                context.platforms.AddRange(
                        new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                        new Platform() { Name = "Sql Server Express", Publisher = "Microsoft", Cost = "Free" }
                    );
                context.SaveChanges();
            }
            else {
                Console.WriteLine("--> we already have data"); 
            }
        }
    }
}