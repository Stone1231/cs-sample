using System;
using System.Diagnostics;

namespace tutorialspoint.State
{
    public interface State
    {
        void doAction(Context context);
    }

    public class StartState : State
    {
        public void doAction(Context context)
        {
            Debug.WriteLine("Player is in start state");
            context.setState(this);
        }

        public String toString()
        {
            return "Start State";
        }
    }

    public class StopState : State
    {

        public void doAction(Context context)
        {
            Debug.WriteLine("Player is in stop state");
            context.setState(this);
        }

        public String toString()
        {
            return "Stop State";
        }
    }

    public class Context
    {
        private State state;

        public Context()
        {
            state = null;
        }

        public void setState(State state)
        {
            this.state = state;
        }

        public State getState()
        {
            return state;
        }
    }

}