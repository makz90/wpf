using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GitHubUsers
{
    public class GitHubUser
    {
        public int id { get; set; }
        public string login { get; set; }
        public string avatar_url { get; set; }
        public string repos_url { get; set; }
        public List<GitHubRepo> repos
        {
            get
            {
                //for TESTS
                //return Utilities.GetReposList(repos_url);
                return Utilities.GetReposList("http://makz.freevar.com/repos");
            }
            set
            {
                repos = value;
            }
        }
        public string reposCountString
        {
            get
            {
                string reposString;

                if(repos.Count  == 1)
                {
                    reposString = "REPO";
                } else
                {
                    reposString = "REPOS";
                }

                return string.Format("{0} {1}", repos.Count, reposString);
            }
            set
            {
                reposCountString = value;
            }
        }
    }
}
