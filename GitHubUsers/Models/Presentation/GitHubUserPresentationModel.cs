using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using GitHubUsers.Annotations;

namespace GitHubUsers.Models.Presentation
{
    public class GitHubUserPresentationModel : INotifyPropertyChanged
    {
        private int _id;
        private string _login;
        private string _avatarUrl;
        private string _reposUrl;
        private bool _reposLoading;

        public GitHubUserPresentationModel()
        {
            Repos = new ObservableCollection<GitHubRepoPresentationModel>();
            Repos.CollectionChanged += (sender, args) =>
            {
                OnPropertyChanged(nameof(ReposCountString));
            };
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value; 
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value; 
                OnPropertyChanged(nameof(Login));
            }
        }

        public string AvatarUrl
        {
            get { return _avatarUrl; }
            set
            {
                _avatarUrl = value; 
                OnPropertyChanged(nameof(AvatarUrl));
            }
        }

        public string ReposUrl
        {
            get { return _reposUrl; }
            set
            {
                _reposUrl = value; 
                OnPropertyChanged(nameof(ReposUrl));
            }
        }

        public bool ReposLoading
        {
            get { return _reposLoading; }
            set
            {
                _reposLoading = value; 
                OnPropertyChanged(nameof(ReposLoading));
            }
        }

        public ObservableCollection<GitHubRepoPresentationModel> Repos { get; }

        public string ReposCountString
        {
            get
            {
                if (Repos == null) return $"{0} REPOS";
                var reposString = Repos.Count == 1 ? "REPO" : "REPOS";
                return $"{Repos.Count} {reposString}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}