using System;
using System.Collections.Generic;
using System.Text;
using Chess.Util;

namespace DAGridPuzzleSolver
{
    public class LightGrid
    {
        private ushort size;

        public List<List<LightNode>> Grid { get; set; } = new List<List<LightNode>>();

        public LightGrid(ushort size)
        {
            this.size = size;
            
            initializeAllLightNodes();
            initializeAllLightNodeNeighbors();
        }
        
        public override String ToString()
        {
            var builder = new StringBuilder();
            
            for (ushort y = 0; y < Grid[0].Count; y++)
            {
                for (ushort x = 0; x < Grid.Count; x++)
                {
                    builder.Append(Grid[x][y]);
                }

                builder.Append('\n');
            }

            return builder.ToString();
        }

        private void initializeAllLightNodes()
        {
            for (ushort x = 0; x < size; x++)
            {
                Grid.Add(new List<LightNode>());
                
                List<LightNode> column = Grid[x];
                    
                for (ushort y = 0; y < size; y++)
                {
                    var position = new Vec2<ushort>(x, y);
                    column.Add(new LightNode(position));
                }
            }
        }

        private void initializeAllLightNodeNeighbors()
        {
            for (var i = 0; i < Grid.Count; i++)
            {
                
                List<LightNode> column = Grid[i];
                
                for (var j = 0; j < column.Count; j++)
                {
                    
                    LightNode node = column[j];

                    initializeLightNodeNeighbors(node);
                    
                }
                
            }
            
        }

        private void initializeLightNodeNeighbors(LightNode node)
        {
            for (short xOffset = -1; xOffset <= 1; xOffset++)
            {
                for (short yOffset = -1; yOffset <= 1; yOffset++)
                {
                    if (xOffset == yOffset)
                    {
                        continue;
                    }
                    
                    Vec2<short> offset = new Vec2<short>(xOffset, yOffset);
                    Vec2<short> position = node.position.ConvertMemberType<short>();
                    
                    Optional<LightNode> possibleNeighbor = getNodeAt(position - offset);

                    if (possibleNeighbor.HasValue)
                    {
                        node.LateralNeighbors.Add(possibleNeighbor.Value);
                    }
                }
            }
        }
        
        

        private Optional<LightNode> getNodeAt(Vec2<short> position)
        {
            if ((position.x >= 0) && (position.x < Grid.Count))
            {
                if ((position.y >= 0) && (position.y < Grid[position.x].Count))
                {
                    return Grid[position.x][position.y];
                }
            }

            return Optional<LightNode>.CreateEmpty();
        }
        
        
        
    }
}