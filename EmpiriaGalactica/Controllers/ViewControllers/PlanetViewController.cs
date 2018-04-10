using EmpiriaGalactica.Input;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica.Controllers.ViewControllers {
    /*
    public class PlanetViewController : IController {

        private Planet _planet;

        private PlanetView _planetView;
        
        public PlanetViewController(Planet planet) {
            _planet = planet;
            
            _planetView = new PlanetView(this, _planet);
        }

        public void Init() {
            EmpiriaGalactica.Input.KeyDown += InputOnKeyDown;
        }

        public void Update() {
            EmpiriaGalactica.Renderer.Clear(Color.Black);
            var screenSize = EmpiriaGalactica.Renderer.GetGridSize();
            
            _planetView.Top = new Vector(0, 1);
            _planetView.Bottom = screenSize - new Vector(screenSize.X / 3, 0);
            
            _planetView.Update();
        }
        
        public void Dispose() {
            _planetView.Dispose();
            
            EmpiriaGalactica.Input.KeyDown -= InputOnKeyDown;
        }
        
        private void InputOnKeyDown(object sender, KeyboardArgs e) {
            if (e.Key == "UpArrow")
                _planetView.SelectedBuildingIndex--;
            else if (e.Key == "DownArrow")
                _planetView.SelectedBuildingIndex++;
            else if (e.Key == "Enter") {
                _planet.Buildings.Add(_planetView.SelectedBuilding);
            } else if (e.Key == "Escape") {
                EmpiriaGalactica.GameController.PopBack();
                return;
            }

            if (_planetView.SelectedBuildingIndex < 0)
                _planetView.SelectedBuildingIndex += EmpiriaGalactica.Buildings.RegisteredItems.Count;
            
            _planetView.SelectedBuildingIndex %= EmpiriaGalactica.Buildings.RegisteredItems.Count;

            //_planetInfoView.Model = _starSystem.Planets[_starSystemView.SelectedPlanet];
            
            //_planetInfoView.Update();
            Update();
        }
    }
    */
}