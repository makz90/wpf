using System.Linq;
using System.Windows;

namespace GitHubUsers
{
    public partial class MainWindow : Window
    {
        private readonly Utilities _utilities = new Utilities();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            var users = await _utilities.GetListOfType<GitHubUser>("https://api.github.com/users");
            users.AsParallel().ForAll(
                async user => user.repos = await _utilities.GetListOfType<GitHubRepo>(user.repos_url));
            this.DataContext = users;
        }
    }
}