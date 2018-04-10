using System.Collections.Generic;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Controllers {
    public class StarSystemController : IController {
        
        #region Members

        private readonly StarSystem _starSystem;

        private List<PlanetController> _planetControllers;

        private readonly GalaxyController _parentGalaxyController;
        
        #endregion
        
        #region Methods

        public StarSystemController(StarSystem starSystem, GalaxyController galaxyController) {
            _starSystem = starSystem;
            _parentGalaxyController = galaxyController;

            Init();
        }

        public void Init() {
            _planetControllers = new List<PlanetController>();

            foreach (var planet in _starSystem.Planets) {
                _planetControllers.Add(new PlanetController(planet, this));
            }
        }

        public void Update() {
            _planetControllers.ForEach(controller => controller.Update());
        }
        
        public void Dispose() {
            _planetControllers.ForEach(controller => controller.Dispose());
        }
        
        #endregion
        
        #region Properties

        public StarSystem StarSystem => _starSystem;

        public bool HasParent => true;

        public IController Parent => _parentGalaxyController;

        #endregion
    }
}