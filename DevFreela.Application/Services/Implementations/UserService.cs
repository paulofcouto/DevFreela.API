using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext devFreelaDbContext) 
        {
            _dbContext = devFreelaDbContext;
        }
        public int Create(NewUserInputModel inputModel)
        {
            var project = new User(inputModel.Username, inputModel.Email, inputModel.BirthDate);

            _dbContext.Users.Add(project);

            return project.Id;
        }

        public UserViewModel? GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return new UserViewModel(user.FullName, user.Email);
        }
    }
}
