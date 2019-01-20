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

		// 1. 순서대로 검사, 성공 시 활성화
		// 2. 이후 다시 검사, 우선순위가 상위 => 교체 / 본인 => 중단 / 여기서 active가 null이면 하위로 넘어가서 체크
		// return true if find new active child node
		public bool SearchTree()
		{
			foreach(BaseNode node in childList)
			{
				if (activatedNode != null && node == activatedNode)
				{
					// every time evaluate node if that already activated
					if (!node.Evaluate())
					{
						ClearActivateFlag();
						return SearchTree();
					}
					return false;
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
