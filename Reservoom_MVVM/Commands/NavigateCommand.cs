using HotelRes_MVVM.Services;
using HotelRes_MVVM.Stores;
using HotelRes_MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelRes_MVVM.Commands
{
    public class NavigateCommand : CommandBase
    {

        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
