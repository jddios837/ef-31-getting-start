using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SamuraApp.Data;
using SamuraiApp.Domain;

namespace ConsoleApp
{
    class ProgramOld
    {
        private static SamuraiContext _context = new SamuraiContext();
        
        static void MainOld(string[] args)
        {
            _context.Database.EnsureCreated();
            //GetSamurais("Before Add:");
            //AddSamurai();
            AddMultipleSamurais();
            //InsertVariousTypes();
            //GetSamurais("After Add:");
            //GetSimpleSamurais();
            // QueryFilters();
            // RetrieveAndUpdateSamurai();
            // RetrieveAndUpdateMultipleSamurais();
            DeleteSamurai();
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void AddMultipleSamurais()
        {
            var samurai = new Samurai { Name = "Steven" };
            var samurai2 = new Samurai { Name = "Calos" };
            var samurai3 = new Samurai { Name = "Juan Manuel" };
            var samurai4 = new Samurai { Name = "Luis" };

            _context.Samurais.AddRange(samurai, samurai2, samurai3, samurai4);
            _context.SaveChanges();
        }

        private static void InsertVariousTypes()
        {
            var samurai = new Samurai { Name = "Test10" };
            var clan = new Clan { ClanName = "Gomera", ClanDescription = "Gomera Famili" };
            _context.AddRange(samurai, clan);
            _context.SaveChanges();
        }
        

        private static void AddSamurai()
        {
            var samurai = new Samurai {Name = "Sampson"};
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void GetSimpleSamurais()
        {
            var samurais = _context.Samurais.ToList();
            foreach (var samurai in samurais)
            {
                Console.WriteLine($"Samurai Name: {samurai.Name}");
            }
        }

        private static void GetSamurais(string beforeAdd)
        {
            var samurais = _context.Samurais.ToList();
            Console.WriteLine($"{beforeAdd}: Samurai count is {samurais.Count}");
            //foreach (var samurai in samurais)
            //{
            //    Console.WriteLine(samurai.Name);
            //}
        }

        private static void QueryFilters()
        {
            //var name = "Sampson";
            var name = "%amp%";
            //var samurais = _context.Samurais.Where(s => s.Name == name).ToList();
            //var samurais = _context.Samurais.Where(s => s.Name.Contains(name)).ToList();
            var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, name)).ToList();
            
           
            foreach (var s in samurais)
            {
                Console.WriteLine($"Samurai Name: {s.Name} - {s.Id}");
            }
            
            var name2 = "Sampson";
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == name2);
            Console.WriteLine($"Samurai Name: {samurai.Name} - {samurai.Id}");

            var samuraiByKey = _context.Samurais.Find(2);
            Console.WriteLine($"Samurai Name by Key: {samuraiByKey.Name}");

            var last = _context.Samurais.OrderBy(s => s.Id).LastOrDefault(s => s.Name == name2);
            if (last != null)
            {
                Console.WriteLine($"Samurai Name Last: {last.Name}");
            }

        }

        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            if (samurai == null) return;
            
            samurai.Name += "SanT";
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateMultipleSamurais()
        {
            var samurais = _context.Samurais.Skip(1).Take(3).ToList();
            samurais.ForEach(s => s.Name += "San");
            _context.SaveChanges();
        }

        private static void DeleteSamurai()
        {
            var samurai = _context.Samurais.Find(1);
            _context.Samurais.Remove(samurai);
            _context.SaveChanges();
        }
    }
}