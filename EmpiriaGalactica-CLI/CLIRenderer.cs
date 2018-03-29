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
            return new Vector((int) Math.Floor(original.X / 100f * Console.BufferWidth), (int) Math.Floor(original.Y / 100f * Console.BufferHeight));
        }
        
        /// <inheritdoc cref="IRenderer.DrawRect"/>
        public void DrawRect(Vector top, Vector bottom, bool filled, Color color, Color backgroundColor) {
            var convertedTop = ToScreenPosition(top);
            var convertedBottom = ToScreenPosition(bottom);

            var size = convertedBottom - convertedTop;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            for (int y = convertedTop.Y; y < convertedBottom.Y - convertedTop.Y; y++) {
                if (!filled && y > convertedTop.Y && y - size.Y < convertedBottom.Y) {
                    Console.Write('#');
                    Console.SetCursorPosition(convertedTop.X + size.X, y);
                    Console.Write('#');
                    continue;
                }
                
                Console.Write(new string('#', size.X));
            }
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
            
            Console.SetCursorPosition(startPos.X, startPos.Y);
            Console.Write(text);
        }
    }
}