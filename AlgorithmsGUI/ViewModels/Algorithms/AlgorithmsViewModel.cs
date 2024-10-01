using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.models.Algorithms.models;
using Algorithms.models.Matrix;
using AlgorithmsGUI.ViewModels;

namespace AlgorithmsGUI.ViewModels.Algorithms
{
    public class AlgorithmsViewModel
    {
        public MainViewModel MainViewModel { get; set; }
        private MainViewModel _mainViewModel
        {
            get => MainViewModel;
            set => MainViewModel = value;
        }

    }
}
