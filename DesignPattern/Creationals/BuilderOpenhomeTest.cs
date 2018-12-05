using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace openhome.Builder
{
    class PlainBuilder : MazeBuilder
    {
        private char[,] maze;

        public PlainBuilder(int i, int j)
        {
            this.maze = new char[i, j];
        }
        public void buildRoad(int i, int j)
        {
            maze[i, j] = ' ';
        }
        public void buildWall(int i, int j)
        {
            maze[i, j] = '□';
        }
        public void buildTreasure(int i, int j)
        {
            maze[i, j] = '★';
        }

        public Maze getMaze()
        {
            return new Maze(maze);
        }
    }

    class PlainBuilder2 : MazeBuilder
    {
        private char[,] maze;

        public PlainBuilder2(int i, int j)
        {
            this.maze = new char[i, j];
        }
        public void buildRoad(int i, int j)
        {
            maze[i, j] = 'x';
        }
        public void buildWall(int i, int j)
        {
            maze[i, j] = 'o';
        }
        public void buildTreasure(int i, int j)
        {
            maze[i, j] = 'v';
        }

        public Maze getMaze()
        {
            return new Maze(maze);
        }
    }


    [TestClass]
    public class BuilderOpenhomeTest
    {
        [TestMethod]
        public void BuilderTest()
        {
            int[,] material = new int[,]{
                {1, 1, 1, 1, 1, 1, 1},
                {1, 0, 0, 0, 0, 2, 1},
                {1, 0, 1, 0, 1, 0, 1},
                {1, 0, 2, 1, 0, 1, 1},
                {1, 1, 0, 1, 0, 1, 1},
                {1, 0, 0, 2, 0, 0, 1},
                {1, 1, 1, 1, 1, 1, 1}};

            MazeDirector director = new MazeDirector(
                material,
                new PlainBuilder(
                    material.GetLength(0), 
                    material.GetLength(1)));

            var maze = director.build();
            maze.paint();        

            director.Builder = new PlainBuilder2(
                    material.GetLength(0), 
                    material.GetLength(1));                 

            maze = director.build();
            maze.paint(); 
        }
    }
}