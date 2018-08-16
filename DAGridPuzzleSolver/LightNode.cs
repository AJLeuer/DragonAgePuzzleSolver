using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Chess.Util;

namespace DAGridPuzzleSolver
{
    public class LightNode
    {
        public enum State
        {
            on = 1,
            off = 0
        }

        private State state;
        
        public State CurrentState { get { return state; } }

        public Vec2<ushort> position { get; }

        public List<LightNode> LateralNeighbors { get; } = new List<LightNode>();

        public LightNode(Vec2<ushort> position)
        {
            state = State.off;
            this.position = position;
        }

        public void Toggle()
        {
            if (CurrentState == State.off)
            {
                state = State.on;
            }
            else if (CurrentState == State.on)
            {
                state = State.off;
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
                case State.on:
                    return "⬜";
                case State.off:
                    return "⬛️";
            }
            
            throw new InvalidEnumArgumentException("Unhandled Node State enum value");
        }
        
        
    }
}