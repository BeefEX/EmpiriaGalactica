using System.Collections.Generic;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Controllers {
    public class GalaxyController : IController {

        #region Members

        private readonly Galaxy _galaxy;

        private List<StarSystemController> _starSystemControllers;
        
        #endregion
        
        #region Methods

        public GalaxyController(Galaxy galaxy) {
            _galaxy = galaxy;
            
        }

        public void Init() {
            _starSystemControllers = new List<StarSystemController>();

            foreach (var starSystem in _galaxy.StarSystems) {
                _starSystemControllers.Add(new StarSystemController(starSystem));
            }
        }
        

        public void Update() {
            _starSystemControllers.ForEach(controller => controller.Update());
        }
        
        public void Dispose() {
            _starSystemControllers.ForEach(controller => controller.Dispose());
        }
        
        #endregion
        
        #region Properties
        
        public Galaxy Galaxy => _galaxy;
        
        #endregion
    }
}