using System;
using System.Collections;
using System.Collections.Generic;

namespace BT
{
	public class SequnceNode : BaseNode
	{
		public SequnceNode(Func<bool> _evalFunc) : base(_evalFunc)
		{

		}

		// priority 순으로 evaluate 후 execute
		public override bool Execute()
		{
			foreach (BaseNode node in childList)
			{
				// 조건 검사 실패 또는 실행 실패 시 실패.
				if (!node.Evaluate() || !node.Execute())
				{
					return false;
				}
			}
			return true;
		}
	}
}
