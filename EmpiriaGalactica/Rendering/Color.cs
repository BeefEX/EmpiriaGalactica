using System;

namespace EmpiriaGalactica.Rendering {
    
    /// <summary>
    /// An custom, portable, color class.
    /// </summary>
    public class Color {

        #region Static members

        /// <summary>
        /// Do I even have to document these ... ?
        /// </summary>
        public static readonly Color Black = new Color(0, 0, 0);
        public static readonly Color White = new Color(255, 255, 255);
        public static readonly Color Red = new Color(255, 0, 0);
        public static readonly Color Green = new Color(0, 255, 0);
        public static readonly Color Blue = new Color(0, 0, 255);

        #endregion

        #region Members
        
        /// <summary>
        /// The red component
        /// </summary>
        private int _red;
        
        /// <summary>
        /// The green component
        /// </summary>
        private int _green;
        
        /// <summary>
        /// The blue component
        /// </summary>
        private int _blue;
        
        #endregion
        
        #region Methods

        /// <summary>
        /// Used to clap an number between 0 and 255.
        /// </summary>
        /// <param name="number">The number to clamp.</param>
        /// <returns>The clamped number.</returns>
        private static int ClampNumber(int number) => Math.Max(0, Math.Min(number, 255));
        
        /// <summary>
        /// Creates an new color.
        /// </summary>
        /// <param name="red">The red component</param>
        /// <param name="green">The green component</param>
        /// <param name="blue">The blue component</param>
        public Color(int red, int green, int blue) {
            _red = ClampNumber(red);
            _green = ClampNumber(green);
            _blue = ClampNumber(blue);
        }

        #endregion
        
        #region Properties

        /// <summary>
        /// The hex value of this color.
        /// </summary>
        public string HexValue => "#" + _red.ToString("X") + _green.ToString("X") + _blue.ToString("X");

        /// <summary>
        /// The red component
        /// </summary>
        public int R {
            get => _red;
            set => _red = value;
        }

        /// <summary>
        /// The green component
        /// </summary>
        public int G {
            get => _green;
            set => _green = value;
        }

        /// <summary>
        /// The blue component
        /// </summary>
        public int B {
            get => _blue;
            set => _blue = value;
        }

        #endregion
    }
}