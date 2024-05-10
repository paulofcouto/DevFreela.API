using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbcontext;
        public ProjectService(DevFreelaDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdCliente, inputModel.IdFreelancer, inputModel.TotalCost);

            _dbcontext.Projects.Add(project);

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);

            _dbcontext.Comments.Add(comment);
        }

        public void Delete(int id)
        {
            var project = _dbcontext.Projects.SingleOrDefault(p => p.Id == id);

            project.Cancel();
        }

        public void Finish(int id)
        {
            var project = _dbcontext.Projects.SingleOrDefault(p => p.Id == id);

            project.Finish();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbcontext.Projects;

            var projectsViewModel = projects.Select(t => new ProjectViewModel(t.Id, t.Title, t.CreatedAt)).ToList();

            return projectsViewModel;
        }

        public ProjectDetailsViewModel? GetById(int id)
        {
            var project = _dbcontext.Projects.SingleOrDefault(p => p.Id == id);
            
            if(project == null)
            {
                return null;
            }

            var projectDetailViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartAt,
                project.FinishedAt  
                );

            return projectDetailViewModel;
        }

        public void Start(int id)
        {
            var project = _dbcontext.Projects.SingleOrDefault(p => p.Id == id);

            project.Start();
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbcontext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
        }
    }
}
