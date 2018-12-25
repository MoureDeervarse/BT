using System;
using System.Collections;
using System.Collections.Generic;

namespace BT
{
	public class ActionNode : BaseNode
	{
		private Action act;

		public ActionNode(Action _act)
		{
			act = _act;
		}

		public override bool Check()
		{
			return true;
		}

		public override bool Execute()
		{
			if (act == null)
			{
				return false;
			}
			act.Call();
			return true;
		}
	}
}
