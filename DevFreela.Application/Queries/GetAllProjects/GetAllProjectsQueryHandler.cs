﻿using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetAllProjectsQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = await projects
                .Select(t => new ProjectViewModel(t.Id, t.Title, t.CreatedAt))
                .ToListAsync();

            return projectsViewModel.ToList();
        }
    }
}
