using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoOutBurgas
{
    public class BinaryTree
    {
        private TreeNode root;

        private class TreeNode
        {
            public int data;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        }

        public BinaryTree()
        {
            root = null;
        }

        public void Insert(int data)
        {
            TreeNode newNode = new TreeNode(data);

            if (root == null)
            {
                root = newNode;
                return;
            }

            TreeNode current = root;
            TreeNode parent = null;

            while (true)
            {
                parent = current;

                if (data < current.data)
                {
                    current = current.left;

                    if (current == null)
                    {
                        parent.left = newNode;
                        return;
                    }
                }
                else
                {
                    current = current.right;

                    if (current == null)
                    {
                        parent.right = newNode;
                        return;
                    }
                }
            }
        }

    }

}
