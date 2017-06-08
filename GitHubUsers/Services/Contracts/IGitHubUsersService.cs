using System.Collections.Generic;
using System.Threading.Tasks;

using GitHubUsers.Models.Presentation;

namespace GitHubUsers.Services.Contracts
{
    public interface IGitHubUsersService
    {
        Task<List<GitHubUserPresentationModel>> GetUsers(bool withRepos = true);
    }
}
