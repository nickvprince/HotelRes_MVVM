using Reservoom_MVVM.Stores;
using Reservoom_MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom_MVVM.Commands
{
    public class NavigateCommand : CommandBase
    {

        private readonly NavigationStore _navigationStore;
        public NavigateCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new MakeReservationViewModel(new Models.Hotel(""));
        }
    }
}
