using System.Diagnostics;
using System;

namespace wiki.State
{
    interface Statelike
    {
        void writeName(StateContext context, String name);
    }

    class StateLowerCase : Statelike
    {
        public void writeName(StateContext context, String name)
        {
            Debug.WriteLine(name.ToLower());
            context.setState(new StateMultipleUpperCase());
        }
    }

    class StateMultipleUpperCase : Statelike
    {
        /** Counter local to this state */
        private int count = 0;

        public void writeName(StateContext context, String name)
        {
            Debug.WriteLine(name.ToUpper());
            /* Change state after StateMultipleUpperCase's writeName() gets invoked twice */
            if (++count > 1)
            {
                context.setState(new StateLowerCase());
            }
        }
    }

    class StateContext
    {
        private Statelike myState;
        public StateContext()
        {
            setState(new StateLowerCase());
        }

        /**
         * Setter method for the state.
         * Normally only called by classes implementing the State interface.
         * @param newState the new state of this context
         */
        public void setState(Statelike newState)
        {
            myState = newState;
        }

        public void writeName(String name)
        {
            myState.writeName(this, name);
        }
    }
}