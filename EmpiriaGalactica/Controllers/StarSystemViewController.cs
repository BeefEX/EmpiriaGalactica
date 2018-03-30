using EmpiriaGalactica.Input;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Rendering;
using EmpiriaGalactica.Views;
using EmpiriaGalactica.Views.UI;

namespace EmpiriaGalactica.Controllers {
    public class StarSystemViewController : IController {
        
        #region Members

        private readonly StarSystem _starSystem;
        
        private readonly StarSystemView _starSystemView;
        private readonly StarSystemInfoView _starSystemInfoView;
        private readonly PlanetInfoView _planetInfoView;
        
        #endregion
        
        #region Methods

        public StarSystemViewController(StarSystem starSystem) {
            _starSystem = starSystem;
            _starSystemView = new StarSystemView(this, _starSystem);
            _starSystemInfoView = new StarSystemInfoView(this, _starSystem);
            _planetInfoView = new PlanetInfoView(this, _starSystem.Planets[_starSystemView.SelectedPlanet]);
        }

        public void Init() {
            EmpiriaGalactica.Input.KeyDown += InputOnKeyDown;

            _starSystemView.ForcedUpdate = true;
        }

        public void Update() {
            EmpiriaGalactica.Renderer.Clear(Color.Black);
            var screenSize = EmpiriaGalactica.Renderer.GetGridSize();
            
            _starSystemView.Top = new Vector(0, 1);
            _starSystemView.Bottom = screenSize - new Vector(screenSize.X / 3, 0);
            
            _starSystemInfoView.Top = new Vector(screenSize.X - screenSize.X / 3, 0);
            _starSystemInfoView.Bottom = new Vector(screenSize.X, screenSize.Y / 4);
            
            _planetInfoView.Top = new Vector(screenSize.X - screenSize.X / 3, screenSize.Y / 4);
            _planetInfoView.Bottom = new Vector(screenSize.X, screenSize.Y);
            
            _starSystemView.Update();
            _planetInfoView.Update();
            _starSystemInfoView.Update();
        }
        
        public void Dispose() {
            _starSystemView.Dispose();
            _starSystemInfoView.Dispose();

            EmpiriaGalactica.Input.KeyDown -= InputOnKeyDown;
        }

        private void InputOnKeyDown(object sender, KeyboardArgs e) {
            if (e.Key == "LeftArrow")
                _starSystemView.SelectedPlanet--;
            else if (e.Key == "RightArrow")
                _starSystemView.SelectedPlanet++;
            else if (e.Key == "Enter") {
                EmpiriaGalactica.GameController.CurrentController = new PlanetViewController(_starSystem.Planets[_starSystemView.SelectedPlanet]);
                return;
            } else if (e.Key == "Escape") {
                EmpiriaGalactica.GameController.PopBack();
                return;
            }

            if (_starSystemView.SelectedPlanet < 0)
                _starSystemView.SelectedPlanet += _starSystemView.Model.Planets.Count;
            
            _starSystemView.SelectedPlanet %= _starSystemView.Model.Planets.Count;

            _planetInfoView.Model = _starSystem.Planets[_starSystemView.SelectedPlanet];
            
            _planetInfoView.Update();
            _starSystemView.Update();
        }
        
        #endregion
        
        #region Properties
        
        #endregion
    }
}