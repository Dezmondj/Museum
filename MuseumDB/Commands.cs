using Microsoft.EntityFrameworkCore;
using MuseumData;
using MuseumDomain;

namespace MuseumDB
{
    static public class Commands
    {
        static public void Add(DbContextOptions options)
        {
            using (MuseumDBContext context = new MuseumDBContext(options))
            {
                Museum museum1 = new() { Name = "museum1", Count_of_employees = 0, Count_of_exhibit = 0, Count_of_hall = 0 };
                Museum museum2 = new() { Name = "museum2", Count_of_employees = 0, Count_of_exhibit = 0, Count_of_hall = 0 };
                Museum museum3 = new() { Name = "museum3", Count_of_employees = 0, Count_of_exhibit = 0, Count_of_hall = 0 };

                context.Museums.AddRange(museum1, museum2, museum3);

                Hall hall1 = new() { Museum = museum1, Type_of_hall = "Type1", Count_of_exhibit = 0 };
                Hall hall2 = new() { Museum = museum2, Type_of_hall = "Type2", Count_of_exhibit = 0 };
                Hall hall3 = new() { Museum = museum3, Type_of_hall = "Type3", Count_of_exhibit = 0 };

                context.Halls.AddRange(hall1, hall2, hall3);

                Exhibit exhibit1 = new() { Hall = hall1, Name = "exhibit1", Cost = 100, Storage_conditions = "Cond1" };
                Exhibit exhibit2 = new() { Hall = hall1, Name = "exhibit2", Cost = 100, Storage_conditions = "Cond2" };
                Exhibit exhibit3 = new() { Hall = hall1, Name = "exhibit3", Cost = 100, Storage_conditions = "Cond3" };

                context.Exhibits.AddRange(exhibit1, exhibit2, exhibit3);

                context.SaveChanges();
            }
        }

        static public void Update(DbContextOptions options)
        {
            using (MuseumDBContext context = new MuseumDBContext(options))
            {
                var museums = context.Museums;
                Museum? museum = museums.Where(x => x.Name == "museum1").FirstOrDefault();
                if (museum != null)
                {
                    museum.Count_of_employees++;
                }

                context.SaveChanges();
            }
        }

        static public void SelectFst(DbContextOptions options)
        {
            using (MuseumDBContext context = new MuseumDBContext(options))
            {
                var Distinct = context.Exhibits.Select(y => new
                {
                    Storage_conditions = y.Storage_conditions
                }).Distinct();

                foreach (var item in Distinct)
                {
                    Console.WriteLine(item.Storage_conditions);
                }

                Console.WriteLine(new String('-', 40));

                var Second = context.Museums.Skip(1).Take(1);
                foreach (var item in Second)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine(new String('-', 40));

                var third = context.Exhibits.Include(x => x.Hall).Where(x => x.Cost > 100).ToList();

                foreach (var item in third)
                {
                    Console.WriteLine(item.Hall.Type_of_hall);
                }

                Console.WriteLine(new String('-', 40));

                var frth = context.Exhibits.Join(context.Halls, x => x.HallID, y => y.HallID, (x, y) => new {ExName = x.Name, HallType = y.Type_of_hall});

                foreach (var item in frth)
                {
                    Console.WriteLine(item.ExName + " " + item.HallType);
                }

                Console.WriteLine(new String('-', 40));

                var fifth = context.Exhibits.Include(x => x.Hall).Where(x => EF.Functions.Like(x.Name, "exhibit%")).ToList();

                foreach (var item in fifth)
                {
                    Console.WriteLine(item.Hall.Type_of_hall);
                }
            }
        }

        static public void SelectSnd(DbContextOptions options)
        {
            using (MuseumDBContext context = new MuseumDBContext(options))
            {
                var Union = context.Clients.Select(x => new { FullName = x.FName + " " + x.LName }).Union(context.Workers.Select(x => new { FullName = x.FName + " " + x.LName }));
                foreach (var item in Union)
                {
                    Console.WriteLine(item.FullName);
                }

                var GroupBy = context.Halls.GroupBy(x => x.Type_of_hall);
                foreach (var item in GroupBy)
                {
                    Console.WriteLine(item.Key + " " + item.Count());
                }
            }
        }
        static public void SelectAgregate(DbContextOptions options)
        {
            using (MuseumDBContext context = new MuseumDBContext(options))
            {
                int AmountMuseums = context.Museums.Count();
                Console.WriteLine(AmountMuseums);
                Console.WriteLine(new String('-', 80));

                int MinPrice = (int)context.Exhibits.Min(x => x.Cost);
                int MaxPrice = (int)context.Exhibits.Max(x => x.Cost);
                int AvgPrice = (int)context.Exhibits.Average(x => x.Cost);
                int SumPrice = (int)context.Exhibits.Sum(x => x.Cost);
                Console.WriteLine("Min: " + MinPrice);
                Console.WriteLine("Max: " + MaxPrice);
                Console.WriteLine("Avg: " + AvgPrice);
                Console.WriteLine("Sum: " + SumPrice);
            }
        }

    }
}
