using System.Collections;
using System.Collections.Generic;

public abstract class BaseNode
{
	private List<BaseNode> nodeList;
	private BaseNode activatedNode;
	private string conditionID;
	private string activeID;

	// activeID에 해당하는 행동을 함
	public abstract void Activate();
	public abstract bool Check();
	// 하위의 노드들을 Activate 시킴
	public abstract bool Execute();

	public virtual void Initialize()
	{
		nodeList = new List<BaseNode>();
	}
	public void AddChildNode(BaseNode node, int priority = -1)
	{
		if(nodeList == null)
		{
			// Logger call error
		}

		if(nodeList.Count < priority || priority < 0)
		{
			priority = nodeList.Count;
		}

		nodeList.Insert(priority, node);
	}

	public void ClearActivateFlag()
	{
		activatedNode.ClearActivateFlag();
		activatedNode = null;
	}

}
