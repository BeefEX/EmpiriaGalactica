using EmpiriaGalactica.Commands;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Views;

namespace EmpiriaGalactica.Controllers.ViewControllers {
    
    public class StarSystemViewController : IController {
        
        #region Members

        private readonly StarSystem _starSystem;
        
        private readonly StarSystemView _starSystemView;

        private readonly StarSystemController _parentStarSystemController;

        private PlanetWindowViewController _planetWindowViewController;
        
        #endregion
        
        #region Methods

        public StarSystemViewController(StarSystem starSystem, StarSystemController parent) {
            _starSystem = starSystem;
            _starSystemView = DependecyManager.GetInstance<StarSystemView>(this, starSystem);

            _parentStarSystemController = parent;

            _planetWindowViewController = null;
        }

        /// <inheritdoc />
        public void Init() {
        }

        /// <inheritdoc />
        public void Update() {
            _starSystemView.Update();
            
            
            _planetWindowViewController?.Update();
        }

        /// <inheritdoc />
        public void Dispose() {
            _starSystemView.Dispose();
            
            _planetWindowViewController?.Dispose();
        }

        /// <inheritdoc />
        public void OnCommand(Command command) {
            switch (command.Label) {
                case "Click":
                    _planetWindowViewController?.Dispose();
            
                    _planetWindowViewController = new PlanetWindowViewController((Planet) command.Parameters[0], this);        
                    break;
                case "WindowClosed":
                    _planetWindowViewController?.Dispose();
                    _planetWindowViewController = null;
                    break;
            }
        }
        
        #endregion
        
        #region Properties

        public bool HasParent => true;
        public IController Parent => _parentStarSystemController;

        #endregion
    }
}