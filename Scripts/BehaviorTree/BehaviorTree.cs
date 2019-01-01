using System.Collections;
using System.Collections.Generic;

namespace BT
{
	public class BehaviorTree : BaseNode
	{
		private float cumulInterval;
		private float evalInterval;
		public float EvalInterval {get {return evalInterval;}}

		public BehaviorTree(float _evalInterval=0.1f) : base()
		{
			cumulInterval = 0.0f;
			evalInterval = _evalInterval;
		}

		public void Update(float _timeDelta)
		{
			cumulInterval += _timeDelta;
			if (EvalInterval >= cumulInterval)
			{
				if (SearchTree())
				{
					Execute();
				}
				cumulInterval -= EvalInterval;
			}
		}

		public override bool Execute()
		{
			return activatedNode.Execute();
		}

		// return true if find new active child node
		public bool SearchTree()
		{
			foreach(BaseNode node in childList)
			{
				if (node == activatedNode)
				{
					// return false;
					continue;
				}
				if (node.Evaluate())
				{
					ClearActivateFlag();
					activatedNode = node;
					return true;
				}
			}
			return false;
		}
	}
}
