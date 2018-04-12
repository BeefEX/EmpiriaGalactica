using System.Collections.Generic;
using EmpiriaGalactica.Commands;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Controllers {
    public class GalaxyController : IController {

        #region Members

        private readonly Galaxy _galaxy;

        private Dictionary<string, StarSystemController> _starSystemControllers;
        
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
            _starSystemControllers = new Dictionary<string, StarSystemController>();

            foreach (var starSystem in _galaxy.StarSystems) {
                _starSystemControllers.Add(starSystem.Position.ToString(), new StarSystemController(starSystem, this));
            }
        }
        

        /// <inheritdoc />
        public void Update() {
            foreach (var starSystemController in _starSystemControllers.Values) {
                starSystemController.Update();
            }
        }
        
        /// <inheritdoc />
        public void Dispose() {
            foreach (var starSystemController in _starSystemControllers.Values) {
                starSystemController.Dispose();
            }
        }

        /// <summary>
        /// Used to retrieve the controller for a star system.
        /// </summary>
        /// <param name="starSystem">Thew star system to get a controller for.</param>
        /// <returns>The controller.</returns>
        public StarSystemController GetController(StarSystem starSystem) {
            return _starSystemControllers[starSystem.Position.ToString()];
        }
        
        /// <inheritdoc />
        public void OnCommand(Command command) { }
        
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