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
		public PlotModel PlotModel { get; private set; }

		public MainViewModel()
		{
			PlotModel = new PlotModel ();
			
			ChangeAlgorithm<int> (new Addition<int>(), 1000, 5, 10000);
		}
		
        public void SwitchAlgorithm(String algorithm, int size, int cycles, int maxValue)
        {
            switch (algorithm)
            {
                case "Addition":
                    ChangeAlgorithm(new Addition<int> (), size, cycles, maxValue);             
                    break;
                case "Bubble sort":
                    ChangeAlgorithm(new BubbleSort<int> (), size, cycles, maxValue);             
                    break;
                case "Bucket sort":
                    ChangeAlgorithm(new BucketSort<int> (), size, cycles, maxValue);             
                    break;
                case "Constant":
                    ChangeAlgorithm(new Constant<int> (), size, cycles, maxValue);             
                    break;
                case "Insertion sort":
                    ChangeAlgorithm(new InsertionSort<int> (), size, cycles, maxValue);             
                    break;
                case "Multiplication":
                    ChangeAlgorithm(new Multiplication<int> (), size, cycles, maxValue);             
                    break;
                case "Polynomial naive":
                    ChangeAlgorithm(new PolynomialP.Naive<double> (), size, cycles, maxValue);             
                    break;
                case "Polynomial horner":
                    ChangeAlgorithm(new PolynomialP.Horner<double> (), size, cycles, maxValue);             
                    break;
                case "Pow simple":
                    ChangeAlgorithm(new Pow.Simple<int> (), size, cycles, maxValue);             
                    break;
                case "Pow recursive":
                    ChangeAlgorithm(new Pow.Recursive<int> (), size, cycles, maxValue);             
                    break;
                case "Pow quick":
                    ChangeAlgorithm(new Pow.Quick<int> (), size, cycles, maxValue);             
                    break;
                case "Pow classic quick":
                    ChangeAlgorithm(new Pow.ClassicQuick<int> (), size, cycles, maxValue);             
                    break;
                case "Quick sort":
                    ChangeAlgorithm(new QuickSort<int> (), size, cycles, maxValue);             
                    break;
                case "Tim sort":
                    ChangeAlgorithm(new TimSort<int> (), size, cycles, maxValue);             
                    break;
                case "Matrix multiplication":
                    //MainViewModel.ChangeAlgorithm(new SquareMatrixMultiplication<int> (), size, cycles, maxValue);             
                    break;

                default:

                    break;
            }
        }
		public void ChangeAlgorithm<T>(AAlgorithm<T> algo, int size, int cycles, int maxValue)
			where T : INumber<T>
		{
			var series = new LineSeries {	MarkerType = MarkerType.None, Color = OxyColor.FromRgb(0, 0, 0), };
			var appro = new LineSeries { MarkerType = MarkerType.None, Color = OxyColor.FromRgb(255, 0, 0) };

			for (int n = 0; n < size; n++)
			{
				double avg = 0;
				var tmpPoints = new DataPoint[cycles];

				for (int i = 0; i < cycles; i++)
				{
					var time = algo.GetExecutionTime(new StructGenerator().GenerateArray<T>(n, 0, maxValue));
					avg += time;
					series.Points.Add(new DataPoint(n, time));
				}
				
				avg /= cycles;
				appro.Points.Add (new DataPoint(n, avg));
			}

			PlotModel.Series.Add(series);
			PlotModel.Series.Add(appro);
		}
	}
}
