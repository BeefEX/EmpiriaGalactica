using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Controllers {
    public class PlanetController : IController {
        
        #region Members

        /// <summary>
        /// The planet thic controller is controlling.
        /// </summary>
        private readonly Planet _planet;

        /// <summary>
        /// The parent controller.
        /// </summary>
        private readonly StarSystemController _parentStarSystemController;
        
        #endregion
        
        #region Methods

        /// <inheritdoc />
        public PlanetController(Planet planet, StarSystemController starSystemController) {
            _planet = planet;
            _parentStarSystemController = starSystemController;
            
            Init();
        }

        /// <inheritdoc />
        public void Init() { }

        /// <inheritdoc />
        public void Update() {
            _planet.Buildings[0].SourceBuilding.Update.Invoke(_planet);
        }

        /// <inheritdoc />
        public void Dispose() { }

        #endregion
        
        #region Properties

        /// <inheritdoc />
        public bool HasParent => true;

        /// <inheritdoc />
        /// <summary>
        /// Controller of the Star System this planet is in. 
        /// </summary>
        public IController Parent => _parentStarSystemController;

        #endregion
    }
}