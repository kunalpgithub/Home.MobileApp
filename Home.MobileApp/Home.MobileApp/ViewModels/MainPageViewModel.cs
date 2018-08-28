using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home.MobileApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public DelegateCommand NavigateToAttendanceView { get; set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Dashboard View";
            _navigationService = navigationService;
            NavigateToAttendanceView = new DelegateCommand(NavigateToAttendance);
            //_navigationService.NavigateAsync("Attendance");
        }

        private void NavigateToAttendance() {
            _navigationService.NavigateAsync("Attendance");
        }
    }
}
