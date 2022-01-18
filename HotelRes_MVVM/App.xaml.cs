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
using HotelRes_MVVM.Services.ReservationProviders;
using HotelRes_MVVM.Services.ReservationCreators;
using HotelRes_MVVM.Services.ReservationConflictCheckers;

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
        private readonly HotelResDbContextFactory _hotelResDbContextFactory;
         
        public App()
        {
            _hotelResDbContextFactory = new HotelResDbContextFactory(CONNECTION_STRING);

            IReservationProvider reservationProvider = new DatabaseReservationProvider(_hotelResDbContextFactory);
            IReservationCreator reservationCreator = new DatabaseReservationCreator(_hotelResDbContextFactory);
            IReservationConflictChecker reservationConflictChecker = new DatabaseReservationConflictChecker(_hotelResDbContextFactory);

            ReservationBook reservationBook = new ReservationBook(reservationProvider, reservationCreator, reservationConflictChecker);

            _hotel = new Hotel("Prince Resorts", reservationBook);
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            
            using (HotelResDbContext dbContext = _hotelResDbContextFactory.CreateDbContext())
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
            return ReservationListingViewModel.LoadViewModel(_hotel, new NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }
}
