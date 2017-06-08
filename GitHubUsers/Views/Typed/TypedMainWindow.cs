using GitHubUsers.Services;
using GitHubUsers.ViewModels;

namespace GitHubUsers.Views.Typed
{
    public class TypedMainWindow : BaseWindow<MainViewModel>
    {
        public TypedMainWindow()
        {
            var gitHubRestService = new GitHubRestService();
            DataContext = new MainViewModel(gitHubRestService, gitHubRestService);
        }
    }
}