using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SamuraApp.Data;
using SamuraiApp.Domain;


namespace ConsoleApp
{
    public class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        static void Main(string[] args)
        {
            //InsertNewSamuraiWithManyQuotes();
            // InsertQuoteToExistingSamuraiWhileTracked();
            // AddQuoteToExisitingSamuraiNotTracked(2);
            EagerLoadSamuraiWithQuotes();
        }
        
        private static void InsertNewSamuraiWithManyQuotes()
        {
            var samurai = new Samurai
            {
                Name = "Kambei Shimada",
                Quotes = new List<Quote>()
                {
                    new Quote { Text = "I've come to save you" },
                    new Quote { Text = "I've come to kill you" }
                }
            };

            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        private static void InsertQuoteToExistingSamuraiWhileTracked()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Quotes.Add(new Quote
            {
                Text = "I bet you're happy that I've saved you!"
            });
            _context.SaveChanges();
        }

        private static void AddQuoteToExisitingSamuraiNotTracked(int samuraiId)
        {
            var samurai = _context.Samurais.Find(samuraiId);
            samurai.Quotes.Add(new Quote
            {
                Text = "Now that I saved you, will you feed me dinner again?"
            });
            using (var newContext = new SamuraiContext())
            {
                // newContext.Samurais.Update(samurai);
                newContext.Samurais.Attach(samurai);
                newContext.SaveChanges();
            }
        }
        private static void EagerLoadSamuraiWithQuotes()
        {
            var samuraiWithQuotes = _context.Samurais
                .Where(s => s.Name.Contains("juan"))
                .Include(s => s.Quotes);

            samuraiWithQuotes.ToList();
        }

        private static void ProjectSomeProperties()
        {
            var someProperties = _context.Samurais.Select(s => new { s.Id, s.Name }).ToList();
            var idsAndNames = _context.Samurais.Select(s => new IdAndName(s.Id, s.Name)).ToList();
        }
        public struct IdAndName
        {
            public IdAndName(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public int Id { get; set; }
            public string Name { get; set; }
        }
    }


}