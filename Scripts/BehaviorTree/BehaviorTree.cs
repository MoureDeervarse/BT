using System.Collections;
using System.Collections.Generic;

namespace BT
{
	public class BehaviorTree : BaseNode
	{
		private float cumulInterval;
		private float checkInterval;
		public float CheckInterval {get {return checkInterval;}}

		public BehaviorTree(float _checkInterval=0.1f) : base()
		{
			cumulInterval = 0.0f;
			checkInterval = _checkInterval;
		}

		public void Update(float _timeDelta)
		{
			cumulInterval += _timeDelta;
			if (CheckInterval >= cumulInterval)
			{
				if (Check())
				{
					Execute();
				}
				cumulInterval -= CheckInterval;
			}
		}

		public override bool Execute()
		{
			activatedNode.Execute();
		}

		// return true if find new active child node
		public override bool Check()
		{
			foreach(BaseNode node in childList)
			{
				if (node == activatedNode)
				{
					continue;
				}
				if (node.Check())
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
