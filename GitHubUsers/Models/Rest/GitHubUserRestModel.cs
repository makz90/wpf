using System.Collections.Generic;
using System.Linq;

using GitHubUsers.Extensions;
using GitHubUsers.Models.Presentation;

namespace GitHubUsers.Models.Rest
{
    public class GitHubUserRestModel
    {
        public int id { get; set; }

        public string login { get; set; }

        public string avatar_url { get; set; }

        public string repos_url { get; set; }

        public List<GitHubRepoRestModel> repos { get; set; }

        public static explicit operator GitHubUserPresentationModel(GitHubUserRestModel restModel)
        {
            var returnModel = new GitHubUserPresentationModel
            {
                Id = restModel.id,
                AvatarUrl = restModel.avatar_url,
                ReposUrl = restModel.repos_url,
                Login = restModel.login,
            };

            returnModel.Repos.AddRange(restModel.repos?.Select(r => (GitHubRepoPresentationModel)r));

            return returnModel;
        }
    }
}