using System.Collections;
using System.Collections.Generic;

namespace BT
{
	public class BehaviorTree : BaseNode
	{
		public BehaviorTree() : base()
		{
		}

		public override bool Execute()
		{
			if (activatedNode == null)
			{
				return false;
			}
			return activatedNode.Execute();
		}

		// return true if find new active child node
		public bool SearchTree()
		{
			foreach(BaseNode node in childList)
			{
				if (node.Evaluate())
				{
					// pass evaluated node if that already activated
					if (node == activatedNode)
					{
						return false;
					}
					ClearActivateFlag();
					activatedNode = node;
					return true;
				}
			}
			return false;
		}
	}
}
