using EmpiriaGalactica.Commands;
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
            _planet.Buildings.ForEach(instance => instance.SourceBuilding.Update.Invoke(_planet, instance));
        }

        /// <inheritdoc />
        public void Dispose() { }

        /// <inheritdoc />
        public void OnCommand(Command command) {
            switch (command.Label) {
                case "BuildBuilding":
                    var building = (Building) command.Parameters[0];

                    if (building == null)
                        return;
                    
                    var canBuild = true;
                    
                    building.BaseCost.ForEach(instance => {
                        if (!canBuild)
                            return;

                        canBuild = _planet.Owner.Resources[instance.SourceResource].Amount >= instance.Amount;
                    });
                    
                    if (!canBuild)
                        return;
                    
                    _planet.Buildings.Add(new BuildingInstance {
                        SourceBuilding = building,
                        Level = 1
                    });
                    
                    break;
                case "DestroyBuilding":
                    var buildingInstance = (BuildingInstance) command.Parameters[0];
                    
                    if (!_planet.Buildings.Contains(buildingInstance))
                        return;
                    
                    buildingInstance.SourceBuilding.BaseCost.ForEach(resource => {
                        _planet.Owner.Resources[resource.SourceResource].Amount +=
                            resource.Amount / 2 * buildingInstance.Level;
                    });

                    _planet.Buildings.Remove(buildingInstance);
                    
                    break;
            }
        }

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