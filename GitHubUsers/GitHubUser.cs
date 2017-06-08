using System.Collections.Generic;

namespace GitHubUsers
{
    public class GitHubUser
    {
        public int id { get; set; }
        public string login { get; set; }
        public string avatar_url { get; set; }
        public string repos_url { get; set; }
        public List<GitHubRepo> repos { get; set; }
        public string reposCountString
        {
            get
            {
                string reposString;
                if (repos == null) return $"{0} REPOS";

                if (repos.Count == 1)
                {
                    reposString = "REPO";
                }
                else
                {
                    reposString = "REPOS";
                }

                return $"{repos.Count} {reposString}";
            }
            set
            {
                reposCountString = value;
            }
        }
    }
}