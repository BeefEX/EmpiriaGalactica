using System;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica_CLI {
    public static class Extensions {

        public static ConsoleColor ToConsoleColor(this Color color) {
            if (color == Color.Black)
                return ConsoleColor.Black;
            if (color == Color.White)
                return ConsoleColor.White;
            if (color == Color.Red)
                return ConsoleColor.Red;
            if (color == Color.Green)
                return ConsoleColor.Green;
            if (color == Color.Blue)
                return ConsoleColor.Blue;
            if (color == Color.Yellow)
                return ConsoleColor.Yellow;
            if (color == Color.Grey)
                return ConsoleColor.DarkGray;
            
            return ConsoleColor.Black;
        }
    }
}