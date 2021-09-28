using MealTracker.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MealTracker.ViewModels
{
    public class MealViewModel : ViewModelBase
    {
        public ObservableCollection<Meal> Meals { get; }

        public AsyncCommand RefreshCommand;

        public MealViewModel()
        {
            Meals = new ObservableCollection<Meal>
            {
                new Meal { Name = "Broccoli, Bloemkool, Tofu", LastEaten = DateTime.Now },
                new Meal { Name = "Spaghetti met Rode Saus", LastEaten = DateTime.Now.AddDays(-1) },
                new Meal { Name = "Dahl", LastEaten = DateTime.Now.AddDays(-2) }
            };

            RefreshCommand = new AsyncCommand(Refresh);
        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            IsBusy = false;
        }
    }
}
