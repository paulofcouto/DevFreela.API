using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Minha descrição do projeto 1", 1, 1, 10000),
                new Project("Meu projeto ASPNET Core 1", "Minha descrição do projeto 1", 1, 1, 20000),
                new Project("Meu projeto ASPNET Core 1", "Minha descrição do projeto 1", 1, 1, null)
            };

            Users = new List<User>
            {
                new User("Luis Felipen", "luis@dev.com.br", new DateTime(1992,1,1)),
                new User("Paulo Couto", "paulocouto@gmail.com", new DateTime(1987,12,12)),
                new User("Alessandra Rosa", "rosa@gmail.com", new DateTime(1990,10,10))
            };


            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
