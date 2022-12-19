using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_9_Task2
{
    public delegate T GetPivotLogic<T>(T[] arr, int left, int right) where T : IComparable<T>;

    public class HoareQuickSort<T> where T : IComparable<T>
    {
        public int PartOfSortHoara(T[] arr, int left, int right, GetPivotLogic<T> pivotLogic)
        {
            T pivot = pivotLogic(arr, left, right);

            while (left <= right)
            {
                while (arr[left].CompareTo(pivot) < 0) left++;
                while (arr[right].CompareTo(pivot) > 0) right--;

                if (left < right)
                {
                    T temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    left++;
                    right--;
                    continue;
                }

                right--;
            }

            return left;
        }

        public void QuickSortHoara(T[] arr, int start, int end, GetPivotLogic<T> pivotLogic)
        {
            if (start >= end) return;
            int rightStart = PartOfSortHoara(arr, start, end, pivotLogic);
            QuickSortHoara(arr, start, rightStart-1, pivotLogic);
            QuickSortHoara(arr, rightStart, end, pivotLogic);
        }

        public void QuickSortHoara(T[] arr, GetPivotLogic<T> pivotLogic) => 
            QuickSortHoara(arr, 0, arr.Length-1, pivotLogic);

        public virtual T GetPivotMiddle(T[] arr, int left, int right) =>
             arr[(left + right) / 2];
    }
}
