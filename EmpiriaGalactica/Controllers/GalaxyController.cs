using System.Collections.Generic;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Controllers {
    public class GalaxyController : IController {

        #region Members

        private readonly Galaxy _galaxy;

        private List<StarSystemController> _starSystemControllers;
        
        #endregion
        
        #region Methods

        /// <summary>
        /// Creates a new controller.
        /// </summary>
        /// <param name="galaxy">The galaxy this controller will controll.</param>
        public GalaxyController(Galaxy galaxy) {
            _galaxy = galaxy;
            Init();
        }

        /// <inheritdoc />
        public void Init() {
            _starSystemControllers = new List<StarSystemController>();

            foreach (var starSystem in _galaxy.StarSystems) {
                _starSystemControllers.Add(new StarSystemController(starSystem, this));
            }
        }
        

        /// <inheritdoc />
        public void Update() {
            _starSystemControllers.ForEach(controller => controller.Update());
        }
        
        /// <inheritdoc />
        public void Dispose() {
            _starSystemControllers.ForEach(controller => controller.Dispose());
        }
        
        #endregion
        
        #region Properties
        
        /// <summary>
        /// The galaxy this controller is controlling.
        /// </summary>
        public Galaxy Galaxy => _galaxy;

        /// <inheritdoc />
        public bool HasParent => false;
        
        /// <inheritdoc />
        public IController Parent => null;

        #endregion
    }
}