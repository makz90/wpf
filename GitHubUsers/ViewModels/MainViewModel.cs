using System.Collections.ObjectModel;
using System.Collections.Specialized;

using GitHubUsers.Extensions;
using GitHubUsers.Models.Presentation;
using GitHubUsers.Services.Contracts;

namespace GitHubUsers.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IGitHubUsersService _gitHubUsersService;
        private readonly IGitHubRepositoriesService _gitHubRepositoriesService;

        public MainViewModel(IGitHubUsersService gitHubUsersService, IGitHubRepositoriesService gitHubRepositoriesService)
        {
            _gitHubUsersService = gitHubUsersService;
            _gitHubRepositoriesService = gitHubRepositoriesService;
            Users = new ObservableCollection<GitHubUserPresentationModel>();
            Users.CollectionChanged += UsersOnCollectionChanged;
        }

        private async void UsersOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            foreach (var newItem in notifyCollectionChangedEventArgs.NewItems)
            {
                var user = newItem as GitHubUserPresentationModel;
                user.ReposLoading = true;
                var repos = await _gitHubRepositoriesService.GetRepositories(user.ReposUrl);
                user.Repos.AddRange(repos);
                user.ReposLoading = false;
            }
        }

        public ObservableCollection<GitHubUserPresentationModel> Users { get; }

        public override async void OnInitialized()
        {
            var users = await _gitHubUsersService.GetUsers();
            Users.AddRange(users);
        }
    }
}