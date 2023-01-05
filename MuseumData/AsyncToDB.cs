using Microsoft.EntityFrameworkCore;
using MuseumDomain;

namespace MuseumData
{
    public class AsyncToDB
    {
        private DbContextOptions options;
        public AsyncToDB(DbContextOptions options)
        {
            this.options = options;
        }
        public async Task AsyncAdd()
        {
            using (MuseumDBContext context = new MuseumDBContext(options))
            {
                for (int i = 0; i < 50; i++)
                {
                    await context.Clients.AddAsync(new Client { LName = "Client " + i });
                }
                await context.SaveChangesAsync();
            }
        }

        public async Task AsyncRead()
        {
            using (MuseumDBContext context = new MuseumDBContext(options))
            {
                var list = await context.Clients.ToListAsync();
                foreach (var item in list)
                {
                    Console.WriteLine(item.LName);
                }
            }
        }
    }
}
