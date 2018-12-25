using System.Collections;
using System.Collections.Generic;

namespace BT
{
	public abstract class BaseNode
	{
		private List<BaseNode> childList;
		private BaseNode activatedNode;

		public abstract bool Check();
		public abstract bool Execute();

		public BaseNode()
		{
			childList = new List<BaseNode>();
		}

		public void AddChildNode(BaseNode node, int priority = -1)
		{
			if(childList.Count < priority || priority < 0)
			{
				priority = childList.Count;
			}
			childList.Insert(priority, node);
		}

		public void ClearActivateFlag()
		{
			activatedNode.ClearActivateFlag();
			activatedNode = null;
		}
	}
}
