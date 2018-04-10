using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Controllers {
    public class PlanetController : IController {
        
        #region Members

        private readonly Planet _planet;
        
        #endregion
        
        #region Methods

        public PlanetController(Planet planet) {
            _planet = planet;
        }

        public void Init() { }

        public void Update() {
            _planet.Buildings[0].SourceBuilding.Update.Invoke(_planet);
        }
        
        public void Dispose() { }

        #endregion
        
        #region Properties
        
        #endregion
        
        #region Operators
        
        #endregion
    }
}