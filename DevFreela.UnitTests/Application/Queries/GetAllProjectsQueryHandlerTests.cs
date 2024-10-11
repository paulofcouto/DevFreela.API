using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            //Arange
            var projects = new List<Project>
            {
                new Project("Nome do teste 1", "Descrição 1", 1, 2, 10000),
                new Project("Nome do teste 2", "Descrição 2", 1, 2, 10000),
                new Project("Nome do teste 3", "Descrição 3", 1, 2, 10000),
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(t => t.GetAllAsync().Result).Returns(projects);

            var getAllProjectQuery = new GetAllProjectsQuery("");
            var getAllProjectQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectViewModelList = await getAllProjectQueryHandler.Handle(getAllProjectQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            projectRepositoryMock.Verify(t => t.GetAllAsync().Result, Times.Once);
        }
    }
}
