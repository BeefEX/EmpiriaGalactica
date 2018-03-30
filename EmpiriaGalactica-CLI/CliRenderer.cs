using System;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica_CLI {
    public class CliRenderer : IRenderer {

        /// <summary>
        /// Converts an vector to it's on-screen equivalent. 
        /// </summary>
        /// <param name="original">The vector to convert.</param>
        /// <returns>The converted vector.</returns>
        private Vector ToScreenPosition(Vector original) {
            return new Vector((int) Math.Floor(original.X / 100f * Console.WindowWidth), (int) Math.Floor(original.Y / 100f * Console.WindowHeight));
        }

        /// <inheritdoc cref="IRenderer.Clear"/>
        public void Clear(Color color) {
            Console.BackgroundColor = color.ToConsoleColor();
            Console.Clear();
        }

        /// <inheritdoc cref="IRenderer.GetGridSize"/>
        public Vector GetGridSize() {
            return new Vector(Console.WindowWidth, Console.WindowHeight);
        }

        /// <inheritdoc cref="IRenderer.DrawRect"/>
        public void DrawRect(Vector top, Vector bottom, bool filled, Color color, Color backgroundColor) {
            var size = bottom - top;

            Console.ForegroundColor = color.ToConsoleColor();
            Console.BackgroundColor = backgroundColor.ToConsoleColor();

            for (int y = top.Y; y < top.Y + size.Y; y++) {
                Console.SetCursorPosition(top.X, y);
                if (!filled && y > top.Y && y + 1 < bottom.Y) {
                    Console.Write(' ');
                    Console.SetCursorPosition(top.X + size.X - 1, y);
                    Console.Write(' ');
                    continue;
                }
                
                Console.Write(new string(' ', size.X));
            }
            
            Console.SetCursorPosition(0, Console.WindowHeight);
        }

        /// <inheritdoc cref="IRenderer.PrintText"/>
        public void PrintText(string text, Vector at, HorizontalAlign align, Color color, Color backgroundColor) {
            var startPos = at;

            switch (align) {
                case HorizontalAlign.Center:
                    startPos.X -= text.Length / 2;
                    break;
                case HorizontalAlign.Right:
                    startPos.X -= text.Length;
                    break;
            }
            
            Console.ForegroundColor = color.ToConsoleColor();
            Console.BackgroundColor = backgroundColor.ToConsoleColor();
            
            Console.SetCursorPosition(startPos.X, startPos.Y);
            Console.Write(text);
            Console.SetCursorPosition(0, Console.WindowHeight);
        }
    }
}