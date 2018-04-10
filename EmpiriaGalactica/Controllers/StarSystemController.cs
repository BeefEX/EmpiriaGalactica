using System.Collections.Generic;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Controllers {
    public class StarSystemController : IController {
        
        #region Members

        private readonly StarSystem _starSystem;

        private List<PlanetController> _planetControllers;
        
        #endregion
        
        #region Methods

        public StarSystemController(StarSystem starSystem) {
            _starSystem = starSystem;
        }

        public void Init() {
            _planetControllers = new List<PlanetController>();

            foreach (var planet in _starSystem.Planets) {
                _planetControllers.Add(new PlanetController(planet));
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

        #endregion
    }
}