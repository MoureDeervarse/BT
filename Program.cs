using System;

namespace BT
{
    class TestInstance
    {
        public string state = "idle";
        public BehaviorTree bt;

        private DateTime curTime;

        public TestInstance()
        {
            bt = new BehaviorTree()
                .AddChild(new StateNode("work", SetState, EvalToWork))
                .AddChild(new StateNode("rest", SetState, EvalToRest))
                .AddChild(new StateNode("idle", SetState, EvalToIdle)) as BehaviorTree;
            curTime = DateTime.Now;
            Console.WriteLine(curTime);
        }

        public void SetState(string _stateName)
        {
            state = _stateName;
            Console.WriteLine(state);
        }

        public bool EvalToWork() => state == "idle";
        public bool EvalToRest() => state == "work";
        public bool EvalToIdle() => state == "rest";

        public void Update()
        {
            long deltaTick = DateTime.Now.Ticks - curTime.Ticks;
            if (deltaTick > 10000000)
            {
                curTime = DateTime.Now;
                Console.WriteLine(curTime);
                if(bt.SearchTree())
                {
                    bt.Execute();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello BT!");
            TestInstance inst = new TestInstance();
            while(true)
            {
                inst.Update();
            }
        }
    }
}
