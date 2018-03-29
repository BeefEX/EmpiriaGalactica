using System.Collections.Generic;
using EmpiriaGalactica.Controllers.UI;
using EmpiriaGalactica.Models.UI;

namespace EmpiriaGalactica.Controllers {
    public class GameController : IController {

        private IController _currentController;
        
        public GameController() {
            _currentController = new MenuController(new Menu {
                Buttons = new List<Button>(new [] {
                    new Button {
                        Title = "test"
                    }
                })
            });
        }

        public void Update() {
            _currentController.Update();
        }
        
        public void Dispose() {
            _currentController.Dispose();
        }
    }
}