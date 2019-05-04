using System;

namespace SortingAlgorithms
{
    public class BinaryTree<T> where T : IComparable
    {
        private bool isNIL;
        private T data;
        private BinaryTree<T> leftNode;
        private BinaryTree<T> rightNode;

        private void SetAsNIL()
        {
            data = default(T);
            leftNode = null;
            rightNode = null;
            isNIL = true;
        }

        private void SetData(T data)
        {
            this.data = data;
            leftNode = new BinaryTree<T>();
            rightNode = new BinaryTree<T>();
            isNIL = false;
        }

        public BinaryTree()
        {
            SetAsNIL();
        }

        public BinaryTree(T data)
        {
            SetData(data);
        }

        public void Add(T data)
        {
            if (data != null)
            {
                if (isNIL)
                    SetData(data);
                else
                {
                    if (data.CompareTo(this.data) < 0)
                        leftNode.Add(data);
                    else
                        rightNode.Add(data);
                }
            }
        }

        public T Find(T data)
        {
            T returnValue = default(T);

            if (data != null && !isNIL)
            {
                if (this.data.Equals(data))
                    returnValue = this.data;
                else if (data.CompareTo(this.data) < 0)
                    leftNode.Find(data);
                else
                    rightNode.Find(data);
            }

            return returnValue;
        }

        // all wrong
        public void Remove(T data)
        {
            if (data != null && !isNIL)
            {
                if (this.data.Equals(data))
                {
                    if (leftNode.isNIL && rightNode.isNIL)
                    {
                        SetAsNIL();
                    }
                    else if (leftNode.isNIL && !rightNode.isNIL)
                    {
                        this.data = rightNode.data;
                        leftNode = rightNode.leftNode;
                        rightNode = rightNode.rightNode;
                    }
                    else if (!leftNode.isNIL && rightNode.isNIL)
                    {
                        this.data = leftNode.data;
                        rightNode = leftNode.rightNode;
                        leftNode = leftNode.leftNode;
                    }
                    else if (!leftNode.isNIL && !rightNode.isNIL)
                    {
                        Console.WriteLine("Error: unimplemented remove case");
                    }
                }
                else if (data.CompareTo(this.data) < 0)
                    leftNode.Remove(data);
                else
                    rightNode.Remove(data);
            }
        }

        public override string ToString()
        {
            return isNIL ? "" :
                (leftNode.isNIL ? "" : leftNode.ToString() + ", ") +
                data.ToString() +
                (rightNode.isNIL ? "" : ", " + rightNode.ToString());
        }
    }
}
