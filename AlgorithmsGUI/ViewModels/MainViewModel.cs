using Algorithms.models.Algorithms;
using Algorithms.models.Algorithms.models;
using Algorithms.models.Generator;
using Algorithms.models.Matrix;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Numerics;
using System.Windows;

namespace AlgorithmsGUI
{
	public class MainViewModel
	{
		public PlotModel PlotModel { get; set; }
		private readonly StructGenerator StructGenerator = new StructGenerator();
		private readonly DataGenerator DataGenerator = new DataGenerator();
		private CancellationTokenSource _cts;

		public MainViewModel()
		{
			PlotModel = new PlotModel();
		}

		/// <summary>Switch algorithm plot, using ChangeAlgorithm</summary>
		/// <param name="algorithm"></param>
		/// <param name="size"></param>
		/// <param name="maxValue"></param>
		public void SwitchAlgorithm(String? algorithm, int size, int maxValue, int cycles)
		{
			_cts?.Cancel();
			_cts = new CancellationTokenSource();

			PlotModel.Subtitle = algorithm;

			switch (algorithm)
			{
				case "Addition":
					StateAlgorithmPlot(new Addition<long>(), size, maxValue, cycles, _cts);
					break;
				case "Bubble sort":
					StateAlgorithmPlot(new BubbleSort<long>(), size, maxValue, cycles, _cts);
					break;
				case "Bucket sort":
					StateAlgorithmPlot(new BucketSort<long>(), size, maxValue, cycles, _cts);
					break;
				case "Constant":
					StateAlgorithmPlot(new Constant<long>(), size, maxValue, cycles, _cts);
					break;
				case "Insertion sort":
					StateAlgorithmPlot(new InsertionSort<long>(), size, maxValue, cycles, _cts);
					break;
				case "Multiplication":
					StateAlgorithmPlot(new Multiplication<long>(), size, maxValue, cycles, _cts);
					break;
				case "Polynomial naive":
					StateAlgorithmPlot(new PolynomialP.Naive<double>(), size, maxValue, cycles, _cts);
					break;
				case "Polynomial horner":
					StateAlgorithmPlot(new PolynomialP.Horner<double>(), size, maxValue, cycles, _cts);
					break;
				case "Pow simple":
					StateAlgorithmPlot(new Pow.Simple<long>(), size, maxValue, cycles, _cts);
					break;
				case "Pow recursive":
					StateAlgorithmPlot(new Pow.Recursive<long>(), size, maxValue, cycles, _cts);
					break;
				case "Pow quick":
					StateAlgorithmPlot(new Pow.Quick<long>(), size, maxValue, cycles, _cts);
					break;
				case "Pow classic quick":
					StateAlgorithmPlot(new Pow.ClassicQuick<long>(), size, maxValue, cycles, _cts);
					break;
				case "Quick sort":
					StateAlgorithmPlot(new QuickSort<long>(), size, maxValue, cycles, _cts);
					break;
				case "Stooge sort":
					StateAlgorithmPlot(new StoogeSort<long>(), size, maxValue, cycles, _cts);
					break;
				case "Tim sort":
					StateAlgorithmPlot(new TimSort<long>(), size, maxValue, cycles, _cts);
					break;
				case "Matrix multiplication":
					StateAlgorithmPlot(new SquareMatrixMultiplication<int>(), size, maxValue, cycles, _cts);
					break;
			}
		}

		/// <summary></summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="algo"></param>
		/// <param name="n"></param>
		/// <param name="maxValue"></param>
		/// <param name="series"></param>
		public async void StateAlgorithmPlot<T>(AAlgorithm<T> algo, int size, int maxValue, int cycles, CancellationTokenSource token)
		where T : INumber<T>
		{
			if (token.IsCancellationRequested) return;

			PlotStart();

			LineSeries series = new LineSeries { MarkerType = MarkerType.None, Color = OxyColor.FromRgb(0, 0, 0) };
			LineSeries approximation = new LineSeries { MarkerType = MarkerType.None, Color = OxyColor.FromRgb(255, 0, 0) };

			(List<double> xApproxData, List<double> yApproxData) = (new List<double>(), new List<double>());

			for (int n = 1; n <= size; n++)
			{
				await AddPoint(algo, n, maxValue, cycles, series, approximation, xApproxData, yApproxData);
			}

			UpdatePlot(series, approximation);
		}

		public async Task AddPoint<T>(AAlgorithm<T> algo, int n, int maxValue, int cycles,
			LineSeries series, LineSeries approximation, List<double> xApproxData, List<double> yApproxData)
			where T : INumber<T>
		{
			double[] times = new double[cycles];

			await Task.Run(() =>
			{
				Parallel.For(0, cycles, i =>
				{
					if (algo is AProcessingAlgorithm<T> processingAlgorithm)
					{
						processingAlgorithm.SetData(StructGenerator.GenerateArray<T>(n, 1, maxValue));
						times[i] = processingAlgorithm.GetExecutionTime();
					}
					else if (algo is ASortingAlgorithm<T> sortingAlgorithm)
					{
						sortingAlgorithm.SetData(StructGenerator.GenerateArray<T>(n, 1, maxValue));
						times[i] = sortingAlgorithm.GetExecutionTime();
					}
				});
			});

			Array.Sort(times);

			Application.Current.Dispatcher.Invoke(() =>
			{
				series.Points.Add(new DataPoint(n, times[cycles / 2]));
			});

			xApproxData.Add(n);
			yApproxData.Add(times.Min());

			if (xApproxData.Count > 1)
			{
				(double a, double b) = CalculateLinearApproximation(xApproxData.ToArray(), yApproxData.ToArray());
				double approximatedY = a * n + b;

				Application.Current.Dispatcher.Invoke(() => approximation.Points.Add(new DataPoint(n, Math.Abs(approximatedY))));
			}
		}

		public (double a, double b) CalculateLinearApproximation(double[] xApproxData, double[] yApproxData)
		{
			int n = xApproxData.Length;
			double sumX = xApproxData.Sum();
			double sumY = yApproxData.Sum();
			double sumXY = xApproxData.Zip(yApproxData, (x, y) => x * y).Sum();
			double sumXSquare = xApproxData.Select(x => x * x).Sum();

			double a = (n * sumXY - sumX * sumY) / (n * sumXSquare - sumX * sumX);
			double b = (sumY - a * sumX) / n;

			return (a, b);
		}
		public (double a, double b) CalculateLogarithmicApproximation(double[] xApproxData, double[] yApproxData)
		{
			int n = xApproxData.Length;

			double[] logX = xApproxData.Select(x => Math.Log(x + 1)).ToArray();

			double sumLogX = logX.Sum();
			double sumY = yApproxData.Sum();
			double sumLogXY = logX.Zip(yApproxData, (logXVal, y) => logXVal * y).Sum();
			double sumLogXSquare = logX.Select(logXVal => logXVal * logXVal).Sum();

			double a = (n * sumLogXY - sumLogX * sumY) / (n * sumLogXSquare - sumLogX * sumLogX);
			double b = (sumY - a * sumLogX) / n;
			
			return (a, b);
		}

		/// <summary></summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="algo"></param>
		/// <param name="n"></param>
		/// <param name="maxValue"></param>
		/// <param name="series"></param>
		public async Task AddPoint<T>(APow<T> algo, long factor, long exponent,
			LineSeries series, LineSeries approximation, List<double> xApproxData, List<double> yApproxData)
			where T : INumber<T>
		{
			await Task.Run(() =>
			{
				algo.SetData(T.CreateChecked(factor), T.CreateChecked(exponent));
			});

			Application.Current.Dispatcher.Invoke(() =>
			{
				var steps = algo.GetSteps();

				series.Points.Add(new DataPoint(exponent, steps));

				xApproxData.Add(exponent);
				yApproxData.Add(steps);

				if (xApproxData.Count > 1)
				{
					var (a, b) = CalculateLogarithmicApproximation(xApproxData.ToArray(), yApproxData.ToArray());
					var approximatedY = a * exponent + b;

					approximation.Points.Add(new DataPoint(exponent, Math.Log2(approximatedY + 1)));
				}

			});

		}

		/// <summary></summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="algo"></param>
		/// <param name="size"></param>
		/// <param name="maxValue"></param>
		public async void StateAlgorithmPlot<T>(APow<T> algo, long factor, long exponent, int cycles, CancellationTokenSource token)
			where T : INumber<T>, IBinaryInteger<T>
		{
			if (token.IsCancellationRequested) return;
			PlotStart(xTitle: "Steps", yTitle: "Value");

			LineSeries series = new LineSeries { MarkerType = MarkerType.None, Color = OxyColor.FromRgb(0, 0, 0), };
			LineSeries approximation = new LineSeries { MarkerType = MarkerType.None, Color = OxyColor.FromRgb(255, 0, 0), };

			(List<double> xApproxData, List<double> yApproxData) = (new List<double>(), new List<double>());

			for (int n = 0; n <= exponent; n++)
			{
				await AddPoint(algo, factor, n, series, approximation, xApproxData, yApproxData);
			}

			if (algo is Pow.Simple<T>)
			{
				UpdatePlot(series);
				return;
			}

			UpdatePlot(series, approximation);
		}

		public async void StateAlgorithmPlot<T>(SquareMatrixMultiplication<T> mul, int size, int maxValue, int cycles, CancellationTokenSource token)
			where T : INumber<T>
		{
			if (token.IsCancellationRequested) return;
			PlotStart();

			LineSeries series = new LineSeries { MarkerType = MarkerType.None, Color = OxyColor.FromRgb(0, 0, 0) };
			LineSeries approximation = new LineSeries { MarkerType = MarkerType.None, Color = OxyColor.FromRgb(255, 0, 0) };

			(List<double> xApproxData, List<double> yApproxData) = (new List<double>(), new List<double>());

			for (int n = 0; n <= size; n++)
			{
				await AddPoint(mul, n, maxValue, cycles, series, approximation, xApproxData, yApproxData);
			}

			UpdatePlot(series, approximation);
		}

		/// <summary></summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="algo"></param>
		/// <param name="n"></param>
		/// <param name="maxValue"></param>
		/// <param name="series"></param>
		public async Task AddPoint<T>(SquareMatrixMultiplication<T> mul, int size, int maxValue, int cycles,
			LineSeries series, LineSeries approximation, List<double> xApproxData, List<double> yApproxData)
			where T : INumber<T>
		{
			double[] times = new double[cycles];

			await Task.Run(() =>
			{
				mul.SetMatrices(
					StructGenerator.GenerateMatrix<T>(size, 0, maxValue),
					StructGenerator.GenerateMatrix<T>(size, 0, maxValue)
				);

				for (int i = 0; i < cycles; i++)
					times[i] = mul.GetExecutionTime();
			});

			Array.Sort(times);

			Application.Current.Dispatcher.Invoke(() => series.Points.Add(new DataPoint(size, times[cycles / 2])));

			xApproxData.Add(size);
			yApproxData.Add(times.Max());

			if (xApproxData.Count > 1)
			{
				(double a, double b) = CalculateLinearApproximation(xApproxData.ToArray(), yApproxData.ToArray());
				double approximatedY = a * size + b;

				Application.Current.Dispatcher.Invoke(() => approximation.Points.Add(new DataPoint(size, Math.Abs(approximatedY))));
			}
		}

		private void UpdatePlot(params LineSeries[] Series)
		{
			Application.Current.Dispatcher.Invoke(() =>
			{
				ClearPlot();
				foreach (var series in Series)
					PlotModel.Series.Add(series);

				PlotDataChangedNotification();
			});
		}
		private void PlotStart(String? xTitle = "Time in ms", String? yTitle = "Elements")
		{
			ClearAxes();
			PlotModel.Axes.Add(new LinearAxis() { Title = xTitle, Position = AxisPosition.Left });
			PlotModel.Axes.Add(new LinearAxis() { Title = yTitle, Position = AxisPosition.Bottom });
		}
		private void ClearPlot() { this.PlotModel.Series.Clear(); }
		private void PlotDataChangedNotification() { this.PlotModel.InvalidatePlot(true); }
		private void ClearAxes() { PlotModel.Axes.Clear(); }
	}
}
