import java.util.Scanner;
import java.util.Arrays;

public class Solution {
	
	public static void main(String args[]) {
		Scanner sc = new Scanner(System.in);
		String[] entry = sc.nextLine().split(" ");
		
		int[] elements = new int[entry.length];
		
		for (int i = 0; i < entry.length; i++)
			elements[i] = new Integer(entry[i]);
		
		BinaryHeap heap = new BinaryHeap(elements);
		System.out.println(heap.toString());
	}
}

class BinaryHeap
{
    private int[] elements;
    private int size;
	
    public BinaryHeap()
    {
        elements = new int[8];
        size = 0;
    }
    public BinaryHeap(int[] elements)
    {
        this.elements = elements;
        size = elements.length;

        for (int i = getParentIndex(size - 1); i >= 0; i--)
            heapify(i);
    }
	
    private int getLeftChildIndex(int elementIndex)
	{
		return 2 * elementIndex + 1;
	}
    private int getRightChildIndex(int elementIndex)
	{
		return 2 * elementIndex + 2;
	}
    private int getParentIndex(int elementIndex)
	{
		return (elementIndex - 1) / 2;
	}
	
    public void add(int element)
    {
        if (elements.length == size - 1)
            increaseHeapSize();

        elements[size++] = element;
        
        int index = size - 1;
        while (index != 0 && elements[index] > elements[getParentIndex(index)])
        {
            int parentIndex = getParentIndex(index);
            swap(parentIndex, index);
            index = parentIndex;
        }
    }

    public int pop()
    {
        if (size != 0){
            int result = elements[0];
            elements[0] = elements[--size];

            heapify(0);

            return result;
        }
        return 0;
    }

    private void heapify(int index)
    {
		int biggerIndex = getLeftChildIndex(index);
		
        if (biggerIndex >=0 && biggerIndex < size)
        {
            int rightChildIndex = getRightChildIndex(index);			
            if (rightChildIndex >= 0 && rightChildIndex < size && elements[rightChildIndex] > elements[biggerIndex])
                biggerIndex = rightChildIndex;
            
            if (elements[biggerIndex] >= elements[index])
            {
                swap(biggerIndex, index);
                heapify(biggerIndex);
            }
        }
    }
	
    @Override
    public String toString()
    {
        return Arrays.toString(elements);
    }
	
    private void increaseHeapSize()
    {
        int[] array = new int[elements.length * 2];
        for (int i = 0; i < elements.length; i++)
            array[i] = elements[i];
        elements = array;
    }
	
    private void swap(int i, int j)
    {
        int temp = elements[i];
        elements[i] = elements[j];
        elements[j] = temp;
    }
}