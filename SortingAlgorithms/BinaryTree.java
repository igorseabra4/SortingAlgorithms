public class MyClass {
	public static void main(String args[]) {
		int x=10;
		int y=25;
		int z=x+y;

		System.out.println("Sum of x+y = " + z);
	}
}

public class BinaryTree<T>
{
	private T data;
	private BinaryTree<T> leftNode;
	private BinaryTree<T> rightNode;
	
	public BinaryTree()
	{
		setAsNIL();
	}
	
	public BinaryTree(T data)
	{
		setData(data);
	}
	
	public boolean isNIL()
	{
		return data == null;
	}
	
	private void setAsNIL()
	{
		data = null;
		leftNode = null;
		rightNode = null;
	}
	
	private void setData(T data)
	{
		this.data = data;
		leftNode = new BinaryTree<T>();
		rightNode = new BinaryTree<T>();
	}
	
	public T getData()
	{
		return data;
	}
	
	public void add(T data)
	{
		if (data != null)
		{
			if (isNIL())
				setData(data);
			else
			{
				if (data.compareTo(this.data) < 0)
					leftNode.add(data);
				else if (data.compareTo(this.data) > 0)
					rightNode.add(data);
			}
		}
	}

	public T search(T data)
	{
		T returnValue = null;

		if (data != null && !isNIL())
		{
			if (this.data.equals(data))
				returnValue = this.data;
			else if (data.compareTo(this.data) < 0)
				returnValue = leftNode.search(data);
			else
				returnValue = rightNode.search(data);
		}
		
		return returnValue;
	}

	public void remove(T data)
	{
		if (data != null && !isNIL())
		{
			if (this.data.equals(data))
			{
				if (leftNode.isNIL() && rightNode.isNIL())
				{
					setAsNIL();
				}
				// Caso onde so tem o leftNode e o rightNode e NIL
				// Tambem poderia ser o contrario aqui e no else trocar pelo predecessor
				else if (!leftNode.isNIL() && rightNode.isNIL())
				{
					this.data = leftNode.data;
					rightNode = leftNode.rightNode;
					leftNode = leftNode.leftNode;
				}
				else
				{
					this.data = successor();
					rightNode.remove(this.data);
				}
			}
			else if (data.compareTo(this.data) < 0)
				leftNode.remove(data);
			else
				rightNode.remove(data);
		}
	}

	public T lowerBound()
	{
		T returnValue = null;

		if (!isNIL())
		{
			if (leftNode.isNIL())
				returnValue = data;
			else
				returnValue = leftNode.lowerBound();
		}

		return returnValue;
	}

	public T upperBound()
	{
		T returnValue = null;

		if (!isNIL())
		{
			if (rightNode.isNIL())
				returnValue = data;
			else
				returnValue = rightNode.upperBound();
		}

		return returnValue;
	}
	
	public T predecessor()
	{
		T returnValue = null;

		if (!isNIL())
		{
			if (!leftNode.isNIL())
				returnValue = leftNode.UpperBound();
			else
			{
				BinaryTree<T> parent = this.parent;
				BinaryTree<T> node = this;

				while (parent != null && node == parent.leftNode)
				{
					node = parent;
					parent = parent.parent;
				}

				if (parent != null)
					returnValue = parent.data;
				// else, nao tem predecessor
			}
		}
		
		return returnValue;
	}
	
	public T successor()
	{
		T returnValue = null;

		if (!isNIL())
		{
			if (!rightNode.isNIL())
				returnValue = rightNode.lowerBound();
			else
			{
				BinaryTree<T> parent = this.parent;
				BinaryTree<T> node = this;

				while (parent != null && node == parent.rightNode)
				{
					node = parent;
					parent = parent.parent;
				}

				if (parent != null)
					returnValue = parent.data;
				// else, nao tem predecessor
			}
		}
		
		return returnValue;
	}
	
	public int height()
	{
		int returnValue = 0;

		if (!isNIL)
			returnValue = 1 + Math.max(leftNode.height(), rightNode.height());
			
		return returnValue;
	}
	
	@Override
	public String toString()
	{
		return isNIL() ? "" :
			(leftNode.isNIL() ? "" : leftNode.toString() + ", ") +
			data.toString() +
			(rightNode.isNIL() ? "" : ", " + rightNode.toString());
	}
}