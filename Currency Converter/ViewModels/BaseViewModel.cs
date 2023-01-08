using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter.ViewModels
{
    public class BaseViewModel: Conductor<object>
    {
        private HomeViewModel _homeViewModel;
        public BaseViewModel(HomeViewModel homeViewModel) {
            _homeViewModel = homeViewModel;
            ActivateItemAsync(_homeViewModel);
        }
    }
}
