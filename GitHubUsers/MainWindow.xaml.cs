using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace GitHubUsers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //for TESTS
            //List<GitHubUser> users = Utilities.GetGitHubUsersList("https://api.github.com/users");
            List<GitHubUser> users = Utilities.GetGitHubUsersList("http://makz.freevar.com/users");

            this.DataContext = users;

            //rozwiazanie async, które chcialbym zeby działalo
            //List<GitHubUser> users = new List<GitHubUser>();

            //string jsonUsers;

            //var client = new RestClient("http://makz.freevar.com/users");
            //var request = new RestRequest(Method.GET);
            //var asyncHandler = client.ExecuteAsync(request, r =>
            //{
            //    if (r.ResponseStatus == ResponseStatus.Completed)
            //    {
            //        jsonUsers = r.Content;
            //        users = JsonConvert.DeserializeObject<List<GitHubUser>>(jsonUsers);
            //    }
            //});
        }
    }
}
