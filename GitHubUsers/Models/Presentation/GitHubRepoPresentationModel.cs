using System.ComponentModel;
using System.Runtime.CompilerServices;

using GitHubUsers.Annotations;

namespace GitHubUsers.Models.Presentation
{
    public class GitHubRepoPresentationModel : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _description;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value; 
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value; 
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value; 
                OnPropertyChanged(nameof(Description));
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