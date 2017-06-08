using GitHubUsers.Models.Presentation;

namespace GitHubUsers.Models.Rest
{
    public class GitHubRepoRestModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public static explicit operator GitHubRepoPresentationModel(GitHubRepoRestModel restModel)
        {
            return new GitHubRepoPresentationModel
            {
                Id = restModel.id,
                Name = restModel.name,
                Description = restModel.description
            };
        }
    }
}
