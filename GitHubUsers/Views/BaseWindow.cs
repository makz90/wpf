using System;
using System.Windows;

using GitHubUsers.ViewModels;

namespace GitHubUsers.Views
{
    public class BaseWindow<T> : Window where T : BaseViewModel
    {
        public T ViewModel => DataContext as T;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ViewModel?.OnInitialized();
        }
    }
}