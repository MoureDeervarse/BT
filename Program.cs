using System;

namespace BT
{
    class TestInstance
    {
        public string state = "idle";
        public float curTime = 0;
        public BehaviorTree bt;

        public void SetState(string _stateName)
        {
            state = _stateName;
            Console.WriteLine(state);
        }

        public bool EvalToWork() => state == "idle";
        public bool EvalToRest() => state == "work";
        public bool EvalToIdle() => state == "rest";

        public TestInstance()
        {
            bt = new BehaviorTree(1.0f);
            bt.AddChildNode(new StateNode("work", SetState, EvalToWork));
            bt.AddChildNode(new StateNode("rest", SetState, EvalToRest));
            bt.AddChildNode(new StateNode("idle", SetState, EvalToIdle));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello BT!");
            DateTime curTime = DateTime.Now;
            Console.WriteLine(curTime);
            TestInstance inst = new TestInstance();

            while(true)
            {
                long delta = DateTime.Now.Ticks - curTime.Ticks;
                if (delta > 10000000)
                {
                    curTime = DateTime.Now;
                    Console.WriteLine(curTime);
                    if(inst.bt.SearchTree())
                    {
                        inst.bt.Execute();
                    }
                }
            }
        }
    }
}
