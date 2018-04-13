using EmpiriaGalactica.Commands;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models.UI;
using EmpiriaGalactica.Views.UI;

namespace EmpiriaGalactica.Controllers.ViewControllers {
    public class MenuViewController : IViewController {

        #region Members

        private readonly Menu _menu;
        private readonly MenuView _view;

        #endregion
        
        #region Methods

        public MenuViewController(Menu menu) {
            _menu = menu;
            _view = DependecyManager.GetInstance<MenuView>(this, _menu);
        }

        public void Init() { }

        public void Update() {
            _view.Update();
        }
        
        public void Dispose() {
            _view.Dispose();
        }

        public void OnCommand(Command command) {
            if (command.Label != "Click") return;
            
            var button = (Button) command.Parameters[0];
            button.OnClick();
        }
        
        #endregion
        
        #region Properties

        public bool HasParent => false;
        public IController Parent => null;

        #endregion
    }
}