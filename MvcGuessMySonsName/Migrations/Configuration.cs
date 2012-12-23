namespace MvcGuessMySonsName.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcGuessMySonsName.Models.DbGuesss>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcGuessMySonsName.Models.DbGuesss context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            foreach (var guess in context.Guesses)
            {
                if (guess.Name.Contains("Gr�mur"))
                {
                    guess.Correct = true;
                }
            }
            //var guesses = context.Guesses.ToList();

            //for (int i = guesses.Count - 1; i >= 0; i--)
            //{
            //    var guess = guesses[i];

            //    if (string.IsNullOrEmpty(guess.Username) || guess.Username == "��ekkt")
            //    {
            //        context.Guesses.Remove(guess);
            //    }
            //}
        }
    }
}
