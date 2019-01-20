using System;
using System.Collections;
using System.Collections.Generic;

namespace BT
{
	public class ActionNode : BaseNode
	{
		private Action action;

		public ActionNode(Action _act, Func<bool> _evalFunc=null) : base(_evalFunc)
		{
			action = _act;
		}

		public override bool Execute()
		{
			if (action == null)
			{
				return false;
			}
			action();
			return true;
		}
	}
}
