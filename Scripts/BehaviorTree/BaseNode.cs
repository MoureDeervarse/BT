using System;
using System.Collections;
using System.Collections.Generic;

namespace BT
{
	public abstract class BaseNode
	{
		protected List<BaseNode> childList;
		protected BaseNode activatedNode;
		protected readonly Func<bool> evalFunc;

		public abstract bool Execute();
		
		public BaseNode(Func<bool> _evalFunc=null)
		{
			childList = new List<BaseNode>();
			evalFunc = _evalFunc;
		}

		// if eval func is null, it is assumed to be right
        public bool Evaluate()
        {
            if (evalFunc == null)
            {
                return true;
            }
            return evalFunc();
        }

		public void AddChildNode(BaseNode node, int priority = -1)
		{
			if(priority < 0 || childList.Count < priority)
			{
				priority = childList.Count;
			}
			childList.Insert(priority, node);
		}

		public void ClearActivateFlag()
		{
			if (activatedNode != null)
			{
				activatedNode.ClearActivateFlag();
			}
			activatedNode = null;
		}
	}
}
