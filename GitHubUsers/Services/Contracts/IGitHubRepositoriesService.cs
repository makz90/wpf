using System.Collections.Generic;
using System.Threading.Tasks;

using GitHubUsers.Models.Presentation;

namespace GitHubUsers.Services.Contracts
{
    public interface IGitHubRepositoriesService
    {
        Task<List<GitHubRepoPresentationModel>> GetRepositories(string repositoryUrl);
    }
}
