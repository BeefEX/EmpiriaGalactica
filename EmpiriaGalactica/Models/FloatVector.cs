using Newtonsoft.Json;

namespace EmpiriaGalactica.Models {
    
    /// <summary>
    /// A class representing a 2D vector using floats.
    /// </summary>
    public class FloatVector {

        #region Members
        
        /// <summary>
        /// The X coordinate of the vector.
        /// </summary>
        private float _x;
        
        /// <summary>
        /// The Y coordinate of the vector.
        /// </summary>
        private float _y;

        #endregion
        
        #region Methods

        /// <summary>
        /// Creates a new empty vector (0,0).
        /// </summary>
        public FloatVector() {
            _x = 0;
            _y = 0;
        }
        
        /// <summary>
        /// Creates a new vector and set the provided values.
        /// </summary>
        /// <param name="x">The X coordinate to set.</param>
        /// <param name="y">The Y coordinate to set.</param>
        public FloatVector(float x, float y) {
            _x = x;
            _y = y;
        }
        
        #endregion
        
        #region Operators

        /// <summary>
        /// Used to add two vectors.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns>The resulting vector.</returns>
        public static FloatVector operator +(FloatVector a, FloatVector b) {
            return new FloatVector(a.X + b.X, a.Y + b.Y);
        }
        
        /// <summary>
        /// Used to subtract two vectors.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns>The resulting vector.</returns>
        public static FloatVector operator -(FloatVector a, FloatVector b) {
            return new FloatVector(a.X - b.X, a.Y - b.Y);
        }
        
        #endregion

        #region Properies

        /// <summary>
        /// The X coordinate of the vector.
        /// </summary>
        [JsonProperty]
        public float X {
            get => _x;
            set => _x = value;
        }

        /// <summary>
        /// The Y coordinate of the vector.
        /// </summary>
        [JsonProperty]
        public float Y {
            get => _y;
            set => _y = value;
        }

        #endregion
    }
}