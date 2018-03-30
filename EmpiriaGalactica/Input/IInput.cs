using System;

namespace EmpiriaGalactica.Input {
    
    /// <summary>
    /// Custom event args for keyboard events.
    /// </summary>
    public class KeyboardArgs : EventArgs {
        
        #region Members
        
        /// <summary>
        /// The key related to this event.
        /// </summary>
        private readonly string _key;
        
        #endregion
        
        #region Methods
        
        /// <summary>
        /// Creates new event args.
        /// </summary>
        /// <param name="key">The key related to this event.</param>
        public KeyboardArgs(string key) {
            _key = key;
        }
        
        #endregion
        
        #region Properties
        
        /// <summary>
        /// The key related to this event.
        /// </summary>
        public string Key => _key;
        
        #endregion
    }  
    
    /// <summary>
    /// Used to get user input.
    /// </summary>
    public interface IInput {

        /// <summary>
        /// Fires when an key is pressed.
        /// </summary>
        event EventHandler<KeyboardArgs> KeyDown;
    }
}