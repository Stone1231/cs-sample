using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace openhome.Builder
{
    class Maze
    {
        private char[,] maze;

        public Maze(char[,] maze)
        {
            this.maze = maze;
        }

        public void paint()
        {
            for(int k=0;k < maze.GetLength(0);k++){
                for(int l=0;l < maze.GetLength(1);l++)
                    Debug.Write(maze[k,l]);                   
                Debug.WriteLine("");
            }
        }
    }

    interface MazeBuilder
    {
        void buildRoad(int i, int j);
        void buildWall(int i, int j);
        void buildTreasure(int i, int j);
        Maze getMaze();
    }

    class MazeDirector
    {
        private int[,] maze;
        public MazeBuilder Builder;

        public MazeDirector(int[,] maze, MazeBuilder builder)
        {
            this.maze = maze;
            this.Builder = builder;
        }

        public Maze build()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    switch (maze[i,j])
                    {
                        case 0:
                            Builder.buildRoad(i, j);
                            break;
                        case 1:
                            Builder.buildWall(i, j);
                            break;
                        case 2:
                            Builder.buildTreasure(i, j);
                            break;
                    }
                }
            }
            return Builder.getMaze();
        }
    }
}