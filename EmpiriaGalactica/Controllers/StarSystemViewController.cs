using EmpiriaGalactica.Input;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Rendering;
using EmpiriaGalactica.Views;
using EmpiriaGalactica.Views.UI;

namespace EmpiriaGalactica.Controllers {
    public class StarSystemViewController : IController {
        
        #region Members

        private StarSystem _starSystem;
        
        private readonly StarSystemView _starSystemView;
        private readonly StarSystemInfoView _starSystemInfoView;
        private PlanetInfoView _planetInfoView;
        
        #endregion
        
        #region Methods

        public StarSystemViewController(StarSystem starSystem) {
            _starSystem = starSystem;
            
            _starSystemView = new StarSystemView(this, starSystem);
            _starSystemInfoView = new StarSystemInfoView(this, starSystem);
            _planetInfoView = new PlanetInfoView(this, _starSystem.Planets[_starSystemView.SelectedPlanet]);
            
            EmpiriaGalactica.Input.KeyDown += InputOnKeyDown;
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
        }

        private void InputOnKeyDown(object sender, KeyboardArgs e) {
            if (e.Key == "LeftArrow")
                _starSystemView.SelectedPlanet--;
            else if (e.Key == "RightArrow")
                _starSystemView.SelectedPlanet++;
            
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