using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
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
		private Logger Logger { get; set; }
		private StructGenerator StructGenerator { get; set; }

		public MainViewModel()
		{
			PlotModel = new PlotModel { Title = "Graphic algorithms" };
			
			AddPerformanceData<long> (new Multiplication<long> ());
		}

		//u can use extended or empty constructor
		public void AddPerformanceData<T>(AProcessingAlgorithm<T> algorithm) 
			where T : INumber<T>
		{
			var series = new LineSeries
			{
				Title = "Time (ms)",
				MarkerType = MarkerType.None
			};
			
			for (int n = 0; n < 2000; n++)
			{
				series.Points.Add(
					new DataPoint(n, algorithm.GetExecutionTime())
					);
			}
				
			//Logger.Write(algorithm.ToString());
			
			PlotModel.Series.Add(series);
		}
		
		protected DataPoint[] GeneratePoints(int size)
		{
			var dp = new DataPoint[size];
		
			for (int n = 0; n < size; n++)
			{
				dp[n] = new DataPoint();
			}

			return dp;
		}
    }

}
