using System.Collections.Generic;
using EmpiriaGalactica.Controllers.UI;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Models.UI.Menus;

namespace EmpiriaGalactica.Controllers {
    public class GameController : IController {

        private IController _currentController;
        
        public GameController() {
            _currentController = new MenuController(new MainMenu());
        }

        public void Update() {
            _currentController.Update();
        }
        
        public void Dispose() {
            _currentController.Dispose();
        }

        public IController CurrentController {
            get => _currentController;
            set {
                _currentController.Dispose();
                _currentController = value;
                Update();
            }
        }
    }
}