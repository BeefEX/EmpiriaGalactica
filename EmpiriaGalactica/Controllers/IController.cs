using System;

namespace EmpiriaGalactica.Controllers {
    
    /// <summary>
    /// The controller part of MVC.
    /// </summary>
    /// <inheritdoc />
    public interface IController : IDisposable {

        #region Methods
        
        /// <summary>
        /// Used to initialize the controller.
        /// </summary>
        void Init();
        
        /// <summary>
        /// Used to update the controller.
        /// </summary>
        void Update();
        
        #endregion

        #region Properties
        
        /// <summary>
        /// Used to determine if this controller has a parent one.
        /// </summary>
        /// <returns>Wherever this controller has a parent controller.</returns>
        bool HasParent { get; }

        /// <summary>
        /// The parent controller of this controller. Null if it doesn't have one.
        /// </summary>
        IController Parent { get; }
        
        #endregion
    }
}