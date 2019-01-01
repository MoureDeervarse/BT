using System;
using System.Collections;
using System.Collections.Generic;

namespace BT
{
    public class SelectNode : BaseNode
    {
        public SelectNode(Func<bool> _evalFunc) : base(_evalFunc)
        {

        }

        // evaluate 성공한 node를 찾은 후 execute
        public override bool Execute()
		{
			foreach (BaseNode node in childList)
			{
                if (node.Evaluate() && node.Execute())
                {
					return true;
				}
			}
			return false;
		}
    }
}
