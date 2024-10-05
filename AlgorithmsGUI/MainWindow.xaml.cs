using AlgorithmsGUI;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using Algorithms.models.Algorithms.models;
using Algorithms.models.Generator;
using AlgorithmsGUI.ViewModels.Algorithms;
using OxyPlot.Axes;

namespace AlgorithmsGUI
{
	public partial class MainWindow : Window
	{
		MainViewModel viewModel = new MainViewModel();
		public MainWindow()
		{
			InitializeComponent();
			DataContext = viewModel;
		}

		private void OnSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			var SelectedAlgorithm = (plotSelection.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString();
			int size = 10000,  maxValue = 10000;
			
			viewModel.SwitchAlgorithm(
				SelectedAlgorithm, size, maxValue, 3
			);
		}	
	}
}
