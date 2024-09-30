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

        public void SwitchAlgorithm(String algorithm, int size, int cycles, int maxValue)
        {
            switch (algorithm)
            {
                case "Addition":
                    MainViewModel.ChangeAlgorithm(new Addition<int> (), size, cycles, maxValue);             
                    break;
                case "Bubble sort":
                    MainViewModel.ChangeAlgorithm(new BubbleSort<int> (), size, cycles, maxValue);             
                    break;
                case "Bucket sort":
                    MainViewModel.ChangeAlgorithm(new BucketSort<int> (), size, cycles, maxValue);             
                    break;
                case "Constant":
                    MainViewModel.ChangeAlgorithm(new Constant<int> (), size, cycles, maxValue);             
                    break;
                case "Insertion sort":
                    MainViewModel.ChangeAlgorithm(new InsertionSort<int> (), size, cycles, maxValue);             
                    break;
                case "Multiplication":
                    MainViewModel.ChangeAlgorithm(new Multiplication<int> (), size, cycles, maxValue);             
                    break;
                case "Polynomial naive":
                    MainViewModel.ChangeAlgorithm(new PolynomialP.Naive<double> (), size, cycles, maxValue);             
                    break;
                case "Polynomial horner":
                    MainViewModel.ChangeAlgorithm(new PolynomialP.Horner<double> (), size, cycles, maxValue);             
                    break;
                case "Pow simple":
                    MainViewModel.ChangeAlgorithm(new Pow.Simple<int> (), size, cycles, maxValue);             
                    break;
                case "Pow recursive":
                    MainViewModel.ChangeAlgorithm(new Pow.Recursive<int> (), size, cycles, maxValue);             
                    break;
                case "Pow quick":
                    MainViewModel.ChangeAlgorithm(new Pow.Quick<int> (), size, cycles, maxValue);             
                    break;
                case "Pow classic quick":
                    MainViewModel.ChangeAlgorithm(new Pow.ClassicQuick<int> (), size, cycles, maxValue);             
                    break;
                case "Quick sort":
                    MainViewModel.ChangeAlgorithm(new QuickSort<int> (), size, cycles, maxValue);             
                    break;
                case "Tim sort":
                    MainViewModel.ChangeAlgorithm(new TimSort<int> (), size, cycles, maxValue);             
                    break;
                case "Matrix multiplication":
                    //MainViewModel.ChangeAlgorithm(new SquareMatrixMultiplication<int> (), size, cycles, maxValue);             
                    break;

                default:

                    break;
            }
        }
    }
}
