using System.Collections.Generic;
using EmpiriaGalactica.Commands;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Controllers {
    public class StarSystemController : IController {
        
        #region Members

        private readonly StarSystem _starSystem;

        private Dictionary<Planet, PlanetController> _planetControllers;

        private readonly GalaxyController _parentGalaxyController;
        
        #endregion
        
        #region Methods

        public StarSystemController(StarSystem starSystem, GalaxyController galaxyController) {
            _starSystem = starSystem;
            _parentGalaxyController = galaxyController;

            Init();
        }

        public void Init() {
            _planetControllers = new Dictionary<Planet, PlanetController>();

            foreach (var planet in _starSystem.Planets) {
                _planetControllers.Add(planet, new PlanetController(planet, this));
            }
        }

        public void Update() {
            foreach (var controller in _planetControllers.Values) {
                controller.Update();
            }
        }
        
        public void Dispose() {
            foreach (var controller in _planetControllers.Values) {
                controller.Dispose();
            }
        }
        
        /// <summary>
        /// Used to retrieve the controller for a planet.
        /// </summary>
        /// <param name="planet">The planet to get a controller for.</param>
        /// <returns>The controller.</returns>
        public PlanetController GetController(Planet planet) {
            return _planetControllers[planet];
        }
        
        /// <inheritdoc />
        public void OnCommand(Command command) { }
        
        #endregion
        
        #region Properties

        public StarSystem StarSystem => _starSystem;

        public bool HasParent => true;

        public IController Parent => _parentGalaxyController;

        #endregion
    }
}