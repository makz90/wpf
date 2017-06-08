using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GitHubUsers.Models.Presentation;
using GitHubUsers.Models.Rest;
using GitHubUsers.Services.Contracts;

namespace GitHubUsers.Services
{
    public class GitHubRestService : IGitHubRepositoriesService, IGitHubUsersService
    {
        private const string GitHubUsersApiUrl = "https://api.github.com/users";
        private const string ApiToken = "f7158772d7aa97ebfc440c7939ff16603e501da5";

        private readonly Utilities _utilities;
        private bool _authenticated;
        
        public GitHubRestService()
        {
            _utilities = new Utilities();
        }

        public async Task<List<GitHubUserPresentationModel>> GetUsers(bool withRepos = true)
        {
            if (!_authenticated)
            {
                _utilities.Client.DefaultRequestHeaders.Add("Authorization", $"token {ApiToken}");
                _authenticated = true;
            }

            var users = await _utilities.GetListOfType<GitHubUserRestModel>(GitHubUsersApiUrl);
            var returnUsers = users?.Select(u => (GitHubUserPresentationModel) u).ToList();
            return returnUsers;
        }

        public async Task<List<GitHubRepoPresentationModel>> GetRepositories(string repositoryUrl)
        {
            var repos = await _utilities.GetListOfType<GitHubRepoRestModel>(repositoryUrl);
            return repos.Select(u => (GitHubRepoPresentationModel)u).ToList();
        }
    }
}
