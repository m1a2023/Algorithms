using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
    public class TimSort<T> : Algorithm<T>
    where T : INumber<T>, IComparable<T>
    {
        private const int MIN_MERGE = 32;

        public override void Execute(IList<T> data)
        {
            Timsort(data, data.Count);
        }

        private void Timsort(IList<T> arr, int n)
        {
            int minRun = GetMinRunLength(MIN_MERGE);

            // Sort individual subarrays of size MIN_MERGE
            for (int i = 0; i < n; i += minRun)
            {
                InsertionSort(arr, i, Math.Min((i + MIN_MERGE - 1), (n - 1)));
            }

            // Merge subarrays
            for (int size = minRun; size < n; size = 2 * size)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));

                    if (mid < right)
                    {
                        Merge(arr, left, mid, right);
                    }
                }
            }
        }

        private void InsertionSort(IList<T> arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                T temp = arr[i];
                int j = i - 1;
                while (j >= left && arr[j].CompareTo(temp) > 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }

        private void Merge(IList<T> arr, int left, int mid, int right)
        {
            int len1 = mid - left + 1, len2 = right - mid;
            List<T> leftArr = new List<T>(len1);
            List<T> rightArr = new List<T>(len2);

            for (int x = 0; x < len1; x++)
                leftArr.Add(arr[left + x]);
            for (int x = 0; x < len2; x++)
                rightArr.Add(arr[mid + 1 + x]);

            int i = 0, j = 0, k = left;

            while (i < len1 && j < len2)
            {
                if (leftArr[i].CompareTo(rightArr[j]) <= 0)
                {
                    arr[k] = leftArr[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArr[j];
                    j++;
                }
                k++;
            }

            while (i < len1)
            {
                arr[k] = leftArr[i];
                i++;
                k++;
            }

            while (j < len2)
            {
                arr[k] = rightArr[j];
                j++;
                k++;
            }
        }

        private int GetMinRunLength(int n)
        {
            int r = 0;
            while (n >= MIN_MERGE)
            {
                r |= (n & 1);
                n >>= 1;
            }
            return n + r;
        }
    }

}
