import java.util.Scanner;

public class Solution {
	public static void main(String args[]) {
		Scanner sc = new Scanner(System.in);
		String[] entry = sc.nextLine().split(" ");
		
		int value = sc.nextInt();
		sc.nextLine();
		
		int rootVal = new Integer(entry[0]);
		
		BinaryTree root = new BinaryTree(null, rootVal);
		
		for (int i = 1; i < entry.length; i++)
			root.add(new Integer(entry[i]));
		
		System.out.print("[");
		root.searchNode(value).predecessor();
		System.out.println();
	}
}

class BinaryTree
{
	private int data;
	private BinaryTree parent;
	private BinaryTree leftNode;
	private BinaryTree rightNode;
	
	public BinaryTree(BinaryTree parent, int data)
	{
		this.parent = parent;
		this.data = data;
	}
	
	public int getData()
	{
		return data;
	}
	
	public void add(int data)
	{
		if (data < this.data)
		{
			if (leftNode == null)
				leftNode = new BinaryTree(this, data);
			else
				leftNode.add(data);
		}
		else if (data > this.data)
		{
			if (rightNode == null)
				rightNode = new BinaryTree(this, data);
			else
				rightNode.add(data);
		}
	}

	public int search(int data)
	{
		if (this.data == data)
			return this.data;
		else if (data < this.data && leftNode != null)
			return leftNode.search(data);
		else if (rightNode != null)
			return rightNode.search(data);
		
		return 0;
	}
	
	public BinaryTree searchNode(int data)
	{
		if (this.data == data)
			return this;
		else if (data < this.data && leftNode != null)
			return leftNode.searchNode(data);
		else if (rightNode != null)
			return rightNode.searchNode(data);
		
		return null;
	}
	
	public void remove(int data)
	{
		if (this.data == data)
		{
			if (leftNode == null && rightNode == null)
			{
				if (parent.leftNode == this)
					parent.leftNode = null;
				else
					parent.rightNode = null;
			}
			else if (leftNode != null && rightNode == null)
			{
				if (parent.leftNode == this)
					this.parent.leftNode = leftNode;
				else
					this.parent.rightNode = leftNode;
				
				leftNode.parent = this.parent;
			}
			else if (leftNode == null && rightNode != null)
			{
				if (parent.rightNode == this)
					this.parent.rightNode = rightNode;
				else
					this.parent.leftNode = rightNode;
				
				rightNode.parent = this.parent;
			}
			else
			{
				this.data = successor();
				rightNode.remove(this.data);
			}
		}
		else if (data < this.data && leftNode != null)
			leftNode.remove(data);
		else if (rightNode != null)
			rightNode.remove(data);
	}

	public int lowerBound()
	{
		if (leftNode == null)
			return data;
		
		return leftNode.lowerBound();
	}

	public int upperBound()
	{
		if (rightNode == null)
			return data;
		
		return rightNode.upperBound();
	}
	
	public int predecessor()
	{
		if (leftNode != null)
			return leftNode.upperBound();
		
		BinaryTree parent = this.parent;
		BinaryTree node = this;
		
		while (parent != null && node == parent.leftNode)
		{
			node = parent;
			parent = parent.parent;
		}

		if (parent != null)
			return parent.data;
		
		return 0;
	}
	
	public int successor()
	{
		if (rightNode != null)
			return rightNode.lowerBound();
		
		BinaryTree parent = this.parent;
		BinaryTree node = this;
		
		while (parent != null && node == parent.rightNode)
		{
			node = parent;
			parent = parent.parent;
		}

		if (parent != null)
			return parent.data;
		
		return 0;
	}
	
	public int height()
	{
		int rightHeight = rightNode == null ? 0 : rightNode.height();
		int leftHeight = leftNode == null ? 0 : leftNode.height();
		
		return (parent == null ? 0 : 1) + Math.max(rightHeight, leftHeight);
	}
	
	public int contaInternos()
	{
		int returnValue = 0;
		
		if (leftNode != null || rightNode != null)
			returnValue = 1;
		
		if (leftNode != null)
			returnValue += leftNode.contaInternos();
		if (rightNode != null)
			returnValue += rightNode.contaInternos();
		
		return returnValue;
	}
	
	@Override
	public String toString()
	{
		return
			(leftNode == null ? "" : leftNode.toString() + " ") +
			data +
			(rightNode== null ? "" : " " + rightNode.toString());
	}
}