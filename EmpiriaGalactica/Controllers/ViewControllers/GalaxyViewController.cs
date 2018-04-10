using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Views;

namespace EmpiriaGalactica.Controllers.ViewControllers {
    
    public class GalaxyViewController : IController {
        
        #region Members

        private readonly GalaxyController _galaxyController;

        private readonly GalaxyView _view;
        
        #endregion
        
        #region Methods
        
        public GalaxyViewController(GalaxyController galaxyController) {
            _galaxyController = galaxyController;
            _view = DependecyManager.GetInstance<GalaxyView>(_galaxyController, _galaxyController.Galaxy);
        }

        public void Init() { }


        public void Update() {
            _view.Update();
        }
        
        public void Dispose() {
            _view.Dispose();
        }
        
        #endregion
        
        #region Properties

        public GalaxyView View => _view;

        public bool HasParent => true;
        public IController Parent => _galaxyController;

        #endregion
    }
}