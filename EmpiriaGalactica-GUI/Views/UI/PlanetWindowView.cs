using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using ImGuiNET;

namespace EmpiriaGalactica_GUI.Views.UI {
    
    [Implements(typeof(global::EmpiriaGalactica.Views.UI.PlanetWindowView))]
    public class PlanetWindowView : global::EmpiriaGalactica.Views.UI.PlanetWindowView {
        
        public PlanetWindowView(IController controller, Planet model) : base(controller, model) { }
        
        public override void Update() {

            var io = ImGui.GetIO();
            
            if (io.KeysDown[io.KeyMap[GuiKey.Escape]])
                return;
            
            ImGui.BeginWindow($"Planet - {Model.Name}");

            ImGui.Text($"Planet name: {Model.Name}");
            ImGui.Text($"Planet biome: {Model.Biome}");
            ImGui.Separator();
            ImGui.Text($"Planet population: {Model.Pupulation}");
            ImGui.Text($"Planet emperor: {Model.Owner.Name}");
            
            ImGui.Separator();
            
            //ImGui
            ImGui.BeginChild("scroll");

            foreach (var buildingInstance in Model.Buildings) {
                ImGui.Text(buildingInstance.SourceBuilding.Name);
            }
            
            ImGui.EndChild();
            
            ImGui.EndWindow();
        }

        public override void Dispose() {
            
        }
    }
}