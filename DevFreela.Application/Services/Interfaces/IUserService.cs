using DevFreela.Application.InputModel;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        int Create(NewUserInputModel inputModel);
        UserViewModel GetById(int id);
    }
}
