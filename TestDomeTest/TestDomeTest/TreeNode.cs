using System;

namespace TestDomeTest
{
	public class TreeNode
	{
		public TreeNode LeftNode { get; set; }
		public TreeNode RightNode { get; set; }

		private static int CountTreeDepth(TreeNode node)
		{
			if (node == null) return 0;

			int leftHeight = CountTreeDepth(node.LeftNode);
			int rightHeight = CountTreeDepth(node.RightNode);

			return (leftHeight > rightHeight) ? leftHeight + 1 : rightHeight + 1;
		}

		private static void Main(string[] args)
		{
			TreeNode root = new TreeNode
			{
//				LeftNode = new TreeNode
//				{
////					LeftNode = new TreeNode
////					{
//////						RightNode = new TreeNode()
////					}
//				},
				RightNode = new TreeNode
				{
//					LeftNode = new TreeNode()
				}
			};

			Console.WriteLine(CountTreeDepth(root));
			Console.ReadKey();
		}
	}
}