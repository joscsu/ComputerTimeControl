using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WpfClient
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ClientDbContext context;

        public ObservableCollection<ComputerTimeViewModel> ComputerTimeViewModels { get; set; }

        public MainViewModel(ClientDbContext context)
        {
            this.context = context;
            ComputerTimeViewModels = new ObservableCollection<ComputerTimeViewModel>();
            SearchCommand = new RelayCommand(() => Search(StartDate, EndDate));
            Search(null, null);
            StartDate = DateTime.Today.AddMonths(-1);
            EndDate = DateTime.Today;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public RelayCommand SearchCommand { get; }
        public void Search(DateTime? start, DateTime? end)
        {
            var computerTimes = context.ComputerTimes.AsQueryable();
            if (start.HasValue)
            {
                computerTimes = computerTimes.Where(x => x.Start > start);
            }
            if (end.HasValue)
            {
                computerTimes = computerTimes.Where(x => x.Stop < end.Value.AddDays(1));
            }

            ComputerTimeViewModels.Clear();
            if (!computerTimes.Any())
                return;
            DateTime minDate = start.HasValue ? start.Value : computerTimes.Select(x => x.Start).Min();
            DateTime? maxDate = end.HasValue ? end.Value : computerTimes.Select(x => x.Stop).Max();

            var actualDate = minDate.Date;
            while (actualDate <= maxDate)
            {
                var viewModel = new ComputerTimeViewModel()
                {
                    Date = actualDate,
                    ComputerTimes = computerTimes.Where(x => x.Start > actualDate && x.Start <= actualDate.AddDays(1)).ToList()
                };

                ComputerTimeViewModels.Add(viewModel);

                actualDate = actualDate.AddDays(1);
            }
        }
    }
}
