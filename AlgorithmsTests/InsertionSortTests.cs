using Algorithms.models.Algorithms.models;
using Algorithms.models.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests
{
    [TestClass]
    public class InsertionSortTests
    {
        InsertionSort<int> insertionSort = new InsertionSort<int>();
        StructGenerator generator = new StructGenerator();

        /// <summary>Test execution and output of the insertion sort</summary>
        [TestMethod]
        public void ExecutionTest()
        {
            // Generate a random array with 1,000 elements
            var _insertionSort = new InsertionSort<int>(generator.GenerateArray<int>(1_000, 0, 1000));

            // Execute sorting and display the result
            Console.WriteLine(_insertionSort.ToString());
        }

        /// <summary>Test sorting functionality for random unsorted array</summary>
        [TestMethod]
        public void SortsUnsortedListTest()
        {
            // Arrange
            var unsortedList = new List<int> { 5, 2, 9, 1, 5, 6 };
            var expectedSortedList = new List<int> { 1, 2, 5, 5, 6, 9 };

            var _insertionSort = new InsertionSort<int>(unsortedList);

            // Act
            _insertionSort.Execute(unsortedList);

            // Assert
            CollectionAssert.AreEqual(expectedSortedList, unsortedList);
        }

        /// <summary>Test sorting functionality for a list already sorted</summary>
        [TestMethod]
        public void SortsAlreadySortedListTest()
        {
            // Arrange
            var sortedList = new List<int> { 1, 2, 3, 4, 5 };
            var expectedSortedList = new List<int> { 1, 2, 3, 4, 5 };

            var _insertionSort = new InsertionSort<int>(sortedList);

            // Act
            _insertionSort.Execute(sortedList);

            // Assert
            CollectionAssert.AreEqual(expectedSortedList, sortedList);
        }

        /// <summary>Test sorting functionality for a list in reverse order</summary>
        [TestMethod]
        public void SortsReverseOrderListTest()
        {
            // Arrange
            var reverseList = new List<int> { 5, 4, 3, 2, 1 };
            var expectedSortedList = new List<int> { 1, 2, 3, 4, 5 };

            var _insertionSort = new InsertionSort<int>(reverseList);

            // Act
            _insertionSort.Execute(reverseList);

            // Assert
            CollectionAssert.AreEqual(expectedSortedList, reverseList);
        }

        /// <summary>Test sorting functionality for an empty list</summary>
        [TestMethod]
        public void HandlesEmptyListTest()
        {
            // Arrange
            var emptyList = new List<int>();

            var _insertionSort = new InsertionSort<int>(emptyList);

            // Act
            _insertionSort.Execute(emptyList);

            // Assert
            Assert.AreEqual(0, emptyList.Count);
        }

        /// <summary>Test sorting functionality for a list with a single element</summary>
        [TestMethod]
        public void HandlesSingleElementListTest()
        {
            // Arrange
            var singleElementList = new List<int> { 42 };
            var expectedSortedList = new List<int> { 42 };

            var _insertionSort = new InsertionSort<int>(singleElementList);

            // Act
            _insertionSort.Execute(singleElementList);

            // Assert
            CollectionAssert.AreEqual(expectedSortedList, singleElementList);
        }

        /// <summary>Test sorting functionality for a list with negative numbers</summary>
        [TestMethod]
        public void SortsListWithNegativeNumbersTest()
        {
            // Arrange
            var listWithNegatives = new List<int> { -3, -1, -7, 4, 2, 0 };
            var expectedSortedList = new List<int> { -7, -3, -1, 0, 2, 4 };

            var _insertionSort = new InsertionSort<int>(listWithNegatives);

            // Act
            _insertionSort.Execute(listWithNegatives);

            // Assert
            CollectionAssert.AreEqual(expectedSortedList, listWithNegatives);
        }

        /// <summary>Test sorting functionality for a list with duplicate values</summary>
        [TestMethod]
        public void SortsListWithDuplicatesTest()
        {
            // Arrange
            var listWithDuplicates = new List<int> { 5, 3, 5, 2, 1, 3 };
            var expectedSortedList = new List<int> { 1, 2, 3, 3, 5, 5 };

            var _insertionSort = new InsertionSort<int>(listWithDuplicates);

            // Act
            _insertionSort.Execute(listWithDuplicates);

            // Assert
            CollectionAssert.AreEqual(expectedSortedList, listWithDuplicates);
        }
    }
}
