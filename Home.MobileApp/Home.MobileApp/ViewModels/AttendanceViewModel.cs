using Home.MobileApp.Models;
using Home.MobileApp.Repository;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Home.MobileApp.ViewModels
{
	public class AttendanceViewModel : BindableBase
	{
        private INavigationService _navigationService;
        public DelegateCommand GoBack { get; set; }
        public DelegateCommand<IWorker> ItemTappedCommand { get; set; }
        public string Title { get; set; }

        public AttendanceViewModel(INavigationService navigationService)
        {
            Title = "Attendance";
            _navigationService = navigationService;
            GoBack = new DelegateCommand(GoBackNavigation);
            ItemTappedCommand = new DelegateCommand<IWorker>(OnItemTapped);
            LoadAllWorkingEmployee();
        }

        private void GoBackNavigation() {
            _navigationService.GoBackAsync();
        }

        private EmployeeRepository _empRepo;
        public ICollection<IWorker> EmployeeList { get; set; }

        public void DidWork(IWorker emp)
        {
            emp.DidWork(true);
        }

        public void DidNotWork(IWorker emp)
        {
            emp.DidWork(false);
        }

        public void LoadAllWorkingEmployee()
        {
            
            _empRepo = new EmployeeRepository();
            EmployeeList = _empRepo.GetAllEmployee();
            SelectedDate = DateTime.Now;
        }

        private void OnItemTapped(IWorker worker) {
            worker.DidWork(true);
        }

        private DateTime _selectedDate;

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set { SetProperty(ref _selectedDate,value); }
        }
    }
}
