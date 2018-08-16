using System;
using System.Collections.Generic;
using System.ComponentModel;
using Chess.Util;

namespace DAGridPuzzleSolver
{
    public class LightNode
    {
        public enum State
        {
            On = 1,
            Off = 0
        }

        private State state;
        
        public State CurrentState { get { return state; } }

        public Vec2<ushort> position { get; }

        public List<LightNode> LateralNeighbors { get; } = new List<LightNode>();

        public LightNode(Vec2<ushort> position)
        {
            state = State.Off;
            this.position = position;
        }

        public void Toggle()
        {
            if (CurrentState == State.Off)
            {
                state = State.On;
            }
            else if (CurrentState == State.On)
            {
                state = State.Off;
            }

            foreach (var neighbor in LateralNeighbors)
            {
                neighbor.Toggle();
            }
        }

        public override String ToString()
        {
            switch (state)
            {
                case State.On:
                    return "⬜";
                case State.Off:
                    return "⬛️";
            }
            
            throw new InvalidEnumArgumentException("Unhandled Node State enum value");
        }
        
        
    }
}