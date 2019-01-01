using System;
using System.Collections;
using System.Collections.Generic;

namespace BT
{
    public class StateNode : BaseNode
    {
        private string stateName;
        public string StateName { get{ return stateName;}}

        private readonly Action<string> stateFunc;

        public StateNode(string _stateName, Action<string> _stateFunc, Func<bool> _evalFunc=null)
         : base(_evalFunc)
        {
            stateName = _stateName;
            stateFunc = _stateFunc;
        }

        // if state func is null, it can not be executed so return false
        public override bool Execute()
        {
            if (stateFunc == null)
			{
				return false;
			}
            stateFunc(StateName);
            return true;
        }
    }
}
