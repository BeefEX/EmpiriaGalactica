using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Rendering {
    
    public enum HorizontalAlign {
        Right,
        Center,
        Left
    }
    
    public interface IRenderer {

        /// <summary>
        /// Used to clear the screen.
        /// </summary>
        /// <param name="color">The color to clear the screen with.</param>
        void Clear(Color color);
        
        /// <summary>
        /// Used to retrieve the size of the rendering grid.
        /// </summary>
        /// <returns>Size of the rendering grid.</returns>
        Vector GetGridSize();

        /// <summary>
        /// Prints an rectange on the screen.
        /// </summary>
        /// <param name="top">Top-right of the rectangle.</param>
        /// <param name="bottom">Bottom-left of the rectangle.</param>
        /// <param name="filled">If the rectange should be filled.</param>
        /// <param name="color">The color to print with.</param>
        /// <param name="backgroundColor">The background color to use.</param>
        void DrawRect(Vector top, Vector bottom, bool filled, Color color, Color backgroundColor);

        /// <summary>
        /// Prints an text on the screen.
        /// </summary>
        /// <param name="text"> The text to print.</param>
        /// <param name="at">Where to print it.</param>
        /// <param name="align">The alignment of the text.</param>
        /// <param name="color">The text to print in.</param>
        /// <param name="backgroundColor">The background color to use.</param>
        void PrintText(string text, Vector at, HorizontalAlign align, Color color, Color backgroundColor);
    }
}