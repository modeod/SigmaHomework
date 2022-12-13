using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_9_Task1.Services
{
    public class MergeSortingService
    {
        public void MergeSort(int[] mainArray)
        {
            if(mainArray.Length <= 1)
                return;

            int mid = mainArray.Length / 2;
            int[] leftArray = new int[mid];
            int[] rightArray = new int[mainArray.Length - mid];

            for (int i = 0; i < mid; i++)
                leftArray[i] = mainArray[i];

            for (int i = mid; i < mainArray.Length; i++)
                rightArray[i - mid] = mainArray[i];

            MergeSort(leftArray);
            MergeSort(rightArray);

            MergeSortedArrays(mainArray, leftArray, rightArray);
        }

        public void MergeSortedArrays(int[] targerArray, int[] leftArray, int[] rightArray)
        {
            int arrayLeftMinIndex = 0;
            int arrayRightMinIndex = 0;
            int targetArrayMinIndex = 0;

            while(arrayLeftMinIndex < leftArray.Length &&
                  arrayRightMinIndex < rightArray.Length)
            {
                if (leftArray[arrayLeftMinIndex] <= rightArray[arrayRightMinIndex])
                {
                    targerArray[targetArrayMinIndex] = leftArray[arrayLeftMinIndex];
                    arrayLeftMinIndex++;
                }
                else
                {
                    targerArray[targetArrayMinIndex] = rightArray[arrayRightMinIndex];
                    arrayRightMinIndex++;
                }

                targetArrayMinIndex++;
            }
            
            while(arrayLeftMinIndex < leftArray.Length)
            {
                targerArray[targetArrayMinIndex] = leftArray[arrayLeftMinIndex];
                arrayLeftMinIndex++;
                targetArrayMinIndex++;
            }

            while (arrayRightMinIndex < rightArray.Length)
            {
                targerArray[targetArrayMinIndex] = rightArray[arrayRightMinIndex];
                arrayRightMinIndex++;
                targetArrayMinIndex++;
            }
        }
    }
}
