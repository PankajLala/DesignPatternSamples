using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateSample
{
    /* Allows an object to alter its behaviour when its internal state changes
     * */
    class StatePtrn
    {
        static void Main(string[] args)
        {

            Context ctx = new Context();
            ctx.SetState(new StateA());

            ctx.Request();
            ctx.Request();
            ctx.Request();

            Console.ReadLine();
        }
    }

    class Context
    {
        private State _state;

        public void SetState(State state)
        {
            _state = state;
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }

    abstract class State
    {
        public abstract void  Handle(Context ctx);
    }

    class StateA: State
    {
        public override void  Handle(Context cts)
        {
            Console.WriteLine("Handled StateA");
            cts.SetState(new StateB());
        }
    }

    class StateB: State
    { 

        public override void Handle(Context ctx)
        {
            Console.WriteLine("Handled StateB");
            ctx.SetState(new StateC());
        }
    }

    class StateC : State
    {

        public override void Handle(Context ctx)
        {
            Console.WriteLine("Handled StateC");
            Console.WriteLine("Final State");
        }
    }
}
