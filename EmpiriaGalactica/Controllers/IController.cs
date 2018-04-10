using System;

namespace EmpiriaGalactica.Controllers {
    public interface IController : IDisposable {

        /// <summary>
        /// Used to initialize the controller.
        /// </summary>
        void Init();
        
        /// <summary>
        /// Used to update the controller.
        /// </summary>
        void Update();

    }
}