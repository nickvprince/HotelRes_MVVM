using HotelRes_MVVM.Exceptions;
using HotelRes_MVVM.Models;
using HotelRes_MVVM.Stores;
using HotelRes_MVVM.ViewModels;
using HotelRes_MVVM.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using HotelRes_MVVM.DbContexts;

namespace HotelRes_MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=HotelRes.db";
        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;
         
        public App()
        {
            _hotel = new Hotel("Prince Resorts");
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            using (HotelResDbContext dbContext = new HotelResDbContext(options))
            {
                dbContext.Database.Migrate();
            }

            _navigationStore.CurrentViewModel = CreateReservationViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private MakeReservationViewModel CreateMakeReservationViewModel()
        {
            return new MakeReservationViewModel(_hotel, new NavigationService( _navigationStore, CreateReservationViewModel));
        }

        private ReservationListingViewModel CreateReservationViewModel()
        {
            return new ReservationListingViewModel(_hotel, new NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }
}
