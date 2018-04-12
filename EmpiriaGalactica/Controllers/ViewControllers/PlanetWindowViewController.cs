using EmpiriaGalactica.Commands;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Views.UI;

namespace EmpiriaGalactica.Controllers.ViewControllers {
    class PlanetWindowViewController : IController {

        #region Members

        private readonly Planet _planet;
        private readonly PlanetWindowView _planetWindowView;

        private readonly StarSystemViewController _parentViewController;
        
        #endregion
        
        #region Methods

        public PlanetWindowViewController(Planet planet, StarSystemViewController parent) {
            _planet = planet;
            _parentViewController = parent;

            _planetWindowView = DependecyManager.GetInstance<PlanetWindowView>(this, _planet);
        }

        /// <inheritdoc />
        public void Init() { }

        /// <inheritdoc />
        public void Update() {
            _planetWindowView.Update();
        }

        /// <inheritdoc />
        public void Dispose() {
            _planetWindowView.Dispose();
        }

        /// <inheritdoc />
        public void OnCommand(Command command) { }
        
        #endregion

        #region Properties

        public bool HasParent => true;
        public IController Parent => _parentViewController;

        #endregion

    }
}