using System.ComponentModel;
using System.Runtime.CompilerServices;

using GitHubUsers.Annotations;

namespace GitHubUsers.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public virtual void OnInitialized() { }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}