using System;

namespace SortingAlgorithms
{
    public class BinaryTree<T> where T : IComparable
    {
        private bool isNIL;
        private T data;
        private BinaryTree<T> parent;
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
            leftNode = new BinaryTree<T>(this);
            rightNode = new BinaryTree<T>(this);
            isNIL = false;
        }

        public BinaryTree(BinaryTree<T> parent)
        {
            this.parent = parent;
            SetAsNIL();
        }

        public BinaryTree(BinaryTree<T> parent, T data)
        {
            this.parent = parent;
            SetData(data);
        }

        public T Data => data;

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
                    // Caso onde so tem o leftNode e o rightNode e NIL
                    // Tambem poderia ser o contrario aqui e no else trocar pelo predecessor
                    else if (!leftNode.isNIL && rightNode.isNIL)
                    {
                        if (parent.leftNode == this)
                            parent.leftNode = leftNode;
                        else
                            parent.rightNode = leftNode;

                        leftNode.parent = parent;
                    }
                    else
                    {
                        this.data = Successor();
                        rightNode.Remove(this.data);
                    }
                }
                else if (data.CompareTo(this.data) < 0)
                    leftNode.Remove(data);
                else
                    rightNode.Remove(data);
            }
        }

        public T LowerBound()
        {
            T returnValue = default(T);

            if (!isNIL)
            {
                if (leftNode.isNIL)
                    returnValue = data;
                else
                    returnValue = leftNode.LowerBound();
            }

            return returnValue;
        }

        public T UpperBound()
        {
            T returnValue = default(T);

            if (!isNIL)
            {
                if (rightNode.isNIL)
                    returnValue = data;
                else
                    returnValue = rightNode.UpperBound();
            }

            return returnValue;
        }

        public T Predecessor()
        {
            T returnValue = default(T);

            if (!isNIL)
            {
                if (!leftNode.isNIL)
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

        public T Successor()
        {
            T returnValue = default(T);

            if (!isNIL)
            {
                if (!rightNode.isNIL)
                    returnValue = rightNode.LowerBound();
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
                    // else, nao tem sucessor
                }
            }

            return returnValue;
        }

        public int Height()
        {
            int returnValue = 0;

            if (!isNIL)
                returnValue = 1 + Math.Max(leftNode.Height(), rightNode.Height());
            
            return returnValue;
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
