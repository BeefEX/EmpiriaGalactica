using System.Collections.Generic;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica.Views.UI {
    public class PlanetView : Panel<Planet> {

        private Building _selectedBuilding;
        
        public PlanetView(IController controller, Planet model) : base(controller, model) {
            
        }
        
        public override void Update() {
            var renderer = EmpiriaGalactica.Renderer;

            var size = Bottom - Top;
            
            var buildings = new List<Building>(EmpiriaGalactica.Buildings.RegisteredItems);

            buildings.RemoveAll(Model.Buildings.Contains);

            var i = 0;
            
            foreach (var building in Model.Buildings) {
                renderer.PrintText(building.Name, Top + new Vector(size.X / 2, 10 + i * 2), HorizontalAlign.Center,
                    Color.Grey, i == SelectedBuildingIndex ? Color.White : Color.Black);

                if (i == SelectedBuildingIndex)
                    _selectedBuilding = building;
                
                i++;
            }
            
            foreach (var building in buildings) {
                renderer.PrintText(building.Name, Top + new Vector(size.X / 2, 10 + i * 2), HorizontalAlign.Center,
                    i == SelectedBuildingIndex ? Color.Black : Color.White, i == SelectedBuildingIndex ? Color.White : Color.Black);
                
                if (i == SelectedBuildingIndex)
                    _selectedBuilding = building;
                
                i++;
            }
        }

        public override void Dispose() {
            
        }
        
        public int SelectedBuildingIndex { get; set; }

        public Building SelectedBuilding => _selectedBuilding;
    }
}