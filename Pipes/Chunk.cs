using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes
{
    public sealed class Chunk
    {
        public Block[][][] Blocks;

        public Chunk()
        {
            this.Blocks = new Block[Engine.ChunkSize][][];
            for(int x = 0;x<Engine.ChunkSize;x++)
            {
                this.Blocks[x] = new Block[Engine.ChunkSize][];
                for (int y = 0; y < Engine.ChunkSize; y++)
                {
                    this.Blocks[x][y] = new Block[Engine.ChunkSize];
                    for (int z = 0; z < Engine.ChunkSize; z++)
                    {
                        this.Blocks[x][y][z] = new Block();
                        this.Blocks[x][y][z].Exists = true;
                    }
                }
            }

        }
    }
}
