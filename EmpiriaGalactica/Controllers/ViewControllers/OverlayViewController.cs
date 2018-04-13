using EmpiriaGalactica.Commands;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Views.UI.Overlay;

namespace EmpiriaGalactica.Controllers.ViewControllers {
    public class OverlayViewController : IViewController {
        
        #region Members

        /// <summary>
        /// The view this controller is controlling.
        /// </summary>
        private readonly OverlayView _view;

        /// <summary>
        /// The controller that is rendered bellow the overlay.
        /// </summary>
        private IViewController _childViewController;
        
        #endregion
        
        #region Methods

        public OverlayViewController(Game game) {
            _view = DependecyManager.GetInstance<OverlayView>(this, game);
            _childViewController = null;
        }

        /// <inheritdoc />
        public void Init() { }

        /// <inheritdoc />
        public void Update() {
            _childViewController.Update();
            _view.Update();
        }

        /// <inheritdoc />
        public void Dispose() {
            _childViewController.Dispose();
            _view.Dispose();
        }

        /// <inheritdoc />
        public void OnCommand(Command command) {
            
        }
        
        #endregion
        
        #region Properties

        /// <summary>
        /// The view controller rendered bellow the overlay.
        /// </summary>
        public IViewController ChildViewController {
            get => _childViewController;
            set => _childViewController = value;
        }

        /// <inheritdoc />
        public bool HasParent => false;

        /// <inheritdoc />
        public IController Parent => null;

        #endregion
    }
}