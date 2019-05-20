import java.util.Scanner;
import java.util.ArrayList;
import java.util.HashSet;

public class Solution {
	public static ArrayList<ArrayList<Integer>> adjacencies; 
	
	public static void main(String args[]) {
		Scanner sc = new Scanner(System.in);
		String[] initEntry = sc.nextLine().split(" ");
		
		int nodeCount = new Integer(initEntry[0]);
		int edgeCount = new Integer(initEntry[1]);
		
		adjacencies = new ArrayList<ArrayList<Integer>>();
		
		for (int i = 0; i < nodeCount; i++)
			adjacencies.add(new ArrayList<Integer>());
		
		for (int i = 0; i < edgeCount; i++)
		{
			String[] cEntry = sc.nextLine().split(" ");
			
			int node0 = new Integer(cEntry[0]);
			int node1 = new Integer(cEntry[1]);
		
			adjacencies.get(node0).add(node1);
			adjacencies.get(node1).add(node0);
		}
		
		boolean visited[] = new boolean[nodeCount];
		for (int i = 0; i < nodeCount; i++) 
			visited[i] = false; 
		
		for (int i = 0; i < nodeCount; i++)
			if (!visited[i] && hasCycle(i, visited, -1))
			{
				System.out.println("False");
				return;
			}
		
		System.out.println("True");
	}
	
	public static boolean hasCycle(int currentNode, boolean visited[], int parent) 
	{ 
		visited[currentNode] = true;
		
		for (Integer i : adjacencies.get(currentNode))
		{
			if (!visited[i])
			{
				if (hasCycle(i, visited, currentNode))
					return true;
			}
			else if (i != parent)
				return true;
		}
		return false;
	}
}