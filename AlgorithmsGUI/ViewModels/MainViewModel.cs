using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Algorithms.models.Algorithms;
using Algorithms.models.Algorithms.models;
using Algorithms.models.Generator;
using Algorithms.models.Matrix;
using Algorithms.models.Measurer;
using OxyPlot;
using OxyPlot.Series;

namespace AlgorithmsGUI
{
	public class MainViewModel
	{
		public PlotModel PlotModel { get; set; }
		private readonly StructGenerator StructGenerator = new StructGenerator();
		private readonly DataGenerator DataGenerator = new DataGenerator();
		private LineSeries series = new LineSeries { MarkerType = MarkerType.None, Color = OxyColor.FromRgb(0, 0, 0), };
		private LineSeries appro = new LineSeries { MarkerType = MarkerType.None, Color = OxyColor.FromRgb(255, 0, 0) };

		public MainViewModel()
		{
			PlotModel = new PlotModel();

			ChangeAlgorithm<int>(new Addition<int>(), 1000, 5, 1000);
		}

		/// <summary>Switch algorithm plot, using ChangeAlgorithm</summary>
		/// <param name="algorithm"></param>
		/// <param name="size"></param>
		/// <param name="maxValue"></param>
		public void SwitchAlgorithm(String? algorithm, int size, int maxValue)
		{
			switch (algorithm)
			{
				case "Addition":
					StateAlgorithmPlot(new Addition<long>(), size, maxValue);
					break;
				case "Bubble sort":
					StateAlgorithmPlot(new BubbleSort<long>(), size, maxValue);
					break;
				case "Bucket sort":
					StateAlgorithmPlot(new BucketSort<long>(), size, maxValue);
					break;
				case "Constant":
					StateAlgorithmPlot(new Constant<long>(), size, maxValue);
					break;
				case "Insertion sort":
					StateAlgorithmPlot(new InsertionSort<long>(), size, maxValue);
					break;
				case "Multiplication":
					StateAlgorithmPlot(new Multiplication<long>(), size, maxValue);
					break;
				case "Polynomial naive":
					StateAlgorithmPlot(new PolynomialP.Naive<double>(), size, maxValue);
					break;
				case "Polynomial horner":
					StateAlgorithmPlot(new PolynomialP.Horner<double>(), size, maxValue);
					break;
				case "Pow simple":
					StateAlgorithmPlot(new Pow.Simple<long>(), size, maxValue);
					break;
				case "Pow recursive":
					StateAlgorithmPlot(new Pow.Recursive<long>(), size, maxValue);
					break;
				case "Pow quick":
					StateAlgorithmPlot(new Pow.Quick<long>(), size, maxValue);
					break;
				case "Pow classic quick":
					StateAlgorithmPlot(new Pow.ClassicQuick<long>(), size, maxValue);
					break;
				case "Quick sort":
					StateAlgorithmPlot(new QuickSort<long>(), size, maxValue);
					break;
				case "Tim sort":
					StateAlgorithmPlot(new TimSort<long>(), size, maxValue);
					break;
				case "Matrix multiplication":
					// StateAlgorithm(new SquareMatrixMultiplication<int>(), size, maxValue);             
					break;

				default:
					break;
			}
		}

		/// <summary>Changes algorithm and updates plot for choosen algorithm</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="algo"></param>
		/// <param name="size"></param>
		/// <param name="cycles"></param>
		/// <param name="maxValue"></param>
		public void ChangeAlgorithm<T>(AAlgorithm<T> algo, int size, int cycles, int maxValue)
			where T : INumber<T>
		{

			for (int n = 0; n < size; n++)
			{
				var time = algo.GetExecutionTime(StructGenerator.GenerateArray<T>(n, 0, maxValue));
				series.Points.Add(new DataPoint(n, time));
			}

			ClearPlot();
			PlotModel.Series.Add(series);
			PlotModel.Series.Add(appro);
			PlotDataChangedNotification();
		}

		/// <summary></summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="algo"></param>
		/// <param name="n"></param>
		/// <param name="maxValue"></param>
		/// <param name="series"></param>
		public void AddPointsAlgorithmPlot<T>(AAlgorithm<T> algo, int n /*, int cycles*/ , int maxValue, LineSeries series)
			where T : INumber<T>
		{

			if (algo is AProcessingAlgorithm<T> processingAlgorithm)
			{
				processingAlgorithm.SetData(
						StructGenerator.GenerateArray<T>(n, 1, maxValue)
					);

				series.Points.Add(new DataPoint(n, processingAlgorithm.GetExecutionTime()));
			}

			else if (algo is ASortingAlgorithm<T> sortingAlgorithm)
			{
				sortingAlgorithm.SetData(
						StructGenerator.GenerateArray<T>(n, 1, maxValue)
					);
				
				series.Points.Add(new DataPoint(n, sortingAlgorithm.GetExecutionTime()));
			}
		}
		
		/// <summary></summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="algo"></param>
		/// <param name="n"></param>
		/// <param name="maxValue"></param>
		/// <param name="series"></param>
		public void AddPointsAlgorithmPlot<T>(APow<T> algo, long factor, long exponent  /*, int cycles*/, LineSeries series)
			where T : INumber<T>
		{
			if (algo is APow<T>  powAlgorithm)
			{
				powAlgorithm.SetData(
						T.CreateChecked(factor),	
						T.CreateChecked(exponent)
					);
				powAlgorithm.Execute();
				var steps = powAlgorithm.GetSteps();
				
				series.Points.Add(new DataPoint(exponent, steps));
			}
		} 
			
		/// <summary></summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="algo"></param>
		/// <param name="size"></param>
		/// <param name="maxValue"></param>
		public void StateAlgorithmPlot<T>(AAlgorithm<T> algo, int size /*, int cycles */ , int maxValue)
			where T : INumber<T>
		{
			var series = new LineSeries { MarkerType = MarkerType.None, Color = OxyColor.FromRgb(0, 0, 0), };

			int n = algo is PolynomialP.Naive<double> || 
					algo is PolynomialP.Horner<double> 
						? 1 : 0;


			for (; n < size; n++)
			{
				AddPointsAlgorithmPlot<T>(algo, n, maxValue, series);
			}
			
			ClearPlot();
			PlotModel.Series.Add(series);
			PlotDataChangedNotification();
		}
		
		/// <summary></summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="algo"></param>
		/// <param name="size"></param>
		/// <param name="maxValue"></param>
		public void StateAlgorithmPlot<T>(APow<T> algo, long factor, long exponent)
			where T : INumber<T>
		{
			var series = new LineSeries { MarkerType = MarkerType.Circle, Color = OxyColor.FromRgb(0, 0, 0), };

			for (int n = 0; n <= exponent; n++)
			{
				AddPointsAlgorithmPlot<T>(algo, factor, n, series);
			}

			ClearPlot();
			PlotModel.Series.Add(series);
			PlotDataChangedNotification();
		}

		private void ClearPlot() { this.PlotModel.Series.Clear(); }
		private void PlotDataChangedNotification() { this.PlotModel.InvalidatePlot(true); }
	}
} 
