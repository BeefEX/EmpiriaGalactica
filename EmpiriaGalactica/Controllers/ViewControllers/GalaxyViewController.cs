using System;
using EmpiriaGalactica.Commands;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Views;
using EmpiriaGalactica.Views.UI;

namespace EmpiriaGalactica.Controllers.ViewControllers {
    
    public class GalaxyViewController : IViewController {
        
        #region Members

        private readonly GalaxyController _galaxyController;

        private readonly GalaxyView _view;

        private readonly StarSystemTooltipView _tooltip;

        private bool _showTooltip;
        
        #endregion
        
        #region Methods
        
        public GalaxyViewController(GalaxyController galaxyController) {
            _galaxyController = galaxyController;
            _view = DependecyManager.GetInstance<GalaxyView>(this, _galaxyController.Galaxy);
            _tooltip = DependecyManager.GetInstance<StarSystemTooltipView>(this, null);
            _showTooltip = false;
        }

        public void Init() { }


        public void Update() {
            _view.Update();
            
            if (_showTooltip)
                _tooltip.Update();
        }
        
        public void Dispose() {
            _view.Dispose();
            _tooltip.Dispose();
        }

        /// <inheritdoc />
        public void OnCommand(Command command) {
            switch (command.Label) {
                case "HoverStart":
                    _showTooltip = true;
                    _tooltip.Model = (StarSystem) command.Parameters[0];
                    break;
                case "HoverEnd":
                    _showTooltip = false;
                    break;
                case "Click":
                    var starSystem = (StarSystem) command.Parameters[0];
                    EmpiriaGalactica.GameController.CurrentController =
                        new OverlayViewController(EmpiriaGalactica.GameController.Game) {
                            ChildViewController = new StarSystemViewController(
                                starSystem,
                                _galaxyController.GetController(starSystem)
                            )
                        };
                    break;
            }
        }
        
        #endregion
        
        #region Properties

        public GalaxyView View => _view;

        public StarSystemTooltipView Tooltip => _tooltip;

        public bool HasParent => true;
        public IController Parent => _galaxyController;

        #endregion
    }
}