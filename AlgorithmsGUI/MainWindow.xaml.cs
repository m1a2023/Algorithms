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

		private void OnSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) { PlotBuilding(); }

		private String? GetSelectedAlgorithm() { 
			return (_PlotSelection.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString(); 
		}
		
		private (int, int, int) GetInputValues()
		{
			int _size = 0, _maxValue = 0, _cycles = 0;

			if (int.TryParse(_CollectionSize.Text, out _size) && 
				int.TryParse(_MaxValue.Text, out _maxValue) &&
				int.TryParse(_Cycles.Text, out _cycles))
			{
				///zero value cycle break system.
				_maxValue = _maxValue <= 0 ? 1 : _maxValue;
				_cycles = _cycles <= 0 ? 1 : _cycles;
				
				return (_size, _maxValue, _cycles);
			}
			
			MessageBox_ValueIsNotOk(_size, _maxValue, _cycles);

			///get default value
			(_size, _maxValue, _cycles) = (100, 100, 3);	
			
			TextBox_SetValues(_size, _maxValue, _cycles);

			return (_size, _maxValue, _cycles);
		}

		private void ShowAlgorithmPlot(String? algorithm, int size, int max, int cycles)
		{
			viewModel.SwitchAlgorithm(
				algorithm, size, max, cycles
			);
		}
		private void PlotBuilding()
		{
			string? selectedAlgorithm = GetSelectedAlgorithm();
			
			///TODO write a new function for checking is value null 
			if (_CollectionSize == null || _MaxValue == null || _Cycles == null) return;
	
			if (selectedAlgorithm == null) return;

			(int size, int max, int cycles) = GetInputValues();

			///messaging user
			MessageBox_IfSizeIsNotWell(selectedAlgorithm, size);
		
			///draw plot 
			ShowAlgorithmPlot(
					selectedAlgorithm, size, max, cycles
				);
		}
		private void TextBox_IsChanged() { PlotBuilding(); }
		private void TextBox_SizeChanged(object sender, TextChangedEventArgs e) { TextBox_IsChanged(); }
		
		private bool MessageBox_IfSizeIsNotWell(string? selectedAlgorithm, int size)
		{
			if (SizeForEachAlgorithm[selectedAlgorithm] < size)
			{
				MessageBox.Show(
					"Chosen size of collection is too large - there is a high risk of long computations. We recommend reducing the values.",
					"Warning",
					MessageBoxButton.OK,
					MessageBoxImage.Warning
				);
				return true;
			}
			return false;
		}
			
		private int MessageBox_ValueIsNotOk(params int[] values)
		{
			foreach (var value in values)
			{
				if (value >= int.MaxValue)
				{
					MessageBox.Show(
						$"Chosen value ({value}) is too large - set less.",
						"Error",
						MessageBoxButton.OK,
						MessageBoxImage.Error
					);
					return value;
				}
				else if (value <= 0)
				{
					MessageBox.Show(
						$"Stack overflow or chosen value ({value}) is too small - set different.",
						"Error",
						MessageBoxButton.OK,
						MessageBoxImage.Error
					);
					return value;
				}
			}
			return -1;
		}
	
		private void TextBox_SetValues(int a, int b, int c)
		{
			_CollectionSize.Text = Convert.ToString(a);
			_MaxValue.Text = Convert.ToString(b);
			_Cycles.Text = Convert.ToString(c);
		}
		private void TextBox_MaxValueChanged(object sender, TextChangedEventArgs e) { TextBox_IsChanged(); }
		private void TextBox_CyclesChanged(object sender, TextChangedEventArgs e) { TextBox_IsChanged(); }

		private readonly Dictionary<String?, int> SizeForEachAlgorithm = new Dictionary<string?, int>
		{
			{ "Addition", 125000 },
			{ "Bubble sort", 4000 },
			{ "Bucket sort", 50000 },
			{ "Constant", 125000 },
			{ "Insertion sort", 6000 },
			{ "Multiplication", 125000 },
			{ "Polynomial naive", 75000 },
			{ "Polynomial horner", 110000 },
			{ "Pow simple", 100000 },
			{ "Pow recursive", 100000 },
			{ "Pow quick", 100000 },
			{ "Pow classic quick", 100000 },
			{ "Quick sort", 50000 },
			{ "Stooge sort", 1200 },
			{ "Tim sort", 50000 },
			{ "Matrix multiplication", 650 }
		};
	}
}
