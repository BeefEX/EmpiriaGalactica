using EmpiriaGalactica.Models.UI;
using EmpiriaGalactica.Views.UI;

namespace EmpiriaGalactica.Controllers.UI {
    public class MenuController : IController {
        
        #region Members

        private readonly MenuView _view;
        
        #endregion
        
        #region Methods

        public MenuController(Menu menu) {
            _view = new MenuView(this, menu);
        }

        public void Update() {
            _view.Update();
        }
        
        public void Dispose() {
            _view.Dispose();
        }

        #endregion
    }
}