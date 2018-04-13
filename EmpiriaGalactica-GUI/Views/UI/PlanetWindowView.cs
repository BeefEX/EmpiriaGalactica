using System;
using System.Collections.Generic;
using System.Numerics;
using EmpiriaGalactica.Commands;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using ImGuiNET;

namespace EmpiriaGalactica_GUI.Views.UI {
    
    [Implements(typeof(global::EmpiriaGalactica.Views.UI.PlanetWindowView))]
    public class PlanetWindowView : global::EmpiriaGalactica.Views.UI.PlanetWindowView {

        private bool _opened;

        public PlanetWindowView(IController controller, Planet model) : base(controller, model) {
            _opened = true;
        }
        
        public override void Update() {
            ImGui.BeginWindow($"Planet - {Model.Name}",
                ref _opened,
                WindowFlags.AlwaysAutoResize |
                WindowFlags.NoSavedSettings);
            
            ImGui.Text($"Planet name: {Model.Name}");
            ImGui.Text($"Planet biome: {Model.Biome}");
            ImGui.Separator();
            ImGui.Text($"Planet population: {Model.Pupulation}");
            ImGui.Text($"Planet emperor: {Model.Owner.Name}");
            
            ImGui.Separator();
            
            ImGui.Text("Buildings:");
            
            ImGui.PopStyleColor();

            if (ImGui.CollapsingHeader("Built", TreeNodeFlags.CollapsingHeader)) {
                for (var i = 0; i < Model.Buildings.Count; i++) {
                    var buildingInstance = Model.Buildings[i];
                    ImGui.Text(buildingInstance.SourceBuilding.Name);

                    ImGui.SameLine(ImGui.GetWindowWidth() - 120);

                    if (ImGui.Button($"Destroy##d{i}", new Vector2(100, 10))) {
                        Controller.OnCommand(new Command("DestroyBuilding", buildingInstance));
                    }
                }
            }

            if (ImGui.CollapsingHeader("Avaliable", TreeNodeFlags.CollapsingHeader)) {
                var buildings = new List<Building>(global::EmpiriaGalactica.EmpiriaGalactica.Buildings.RegisteredItems);

                buildings.RemoveAll(building => {
                    var remove = false;

                    Model.Buildings.ForEach(instance => {
                        if (remove)
                            return;
                        
                        remove = instance.SourceBuilding == building;
                    });

                    return remove;
                });

                for (var i = 0; i < buildings.Count; i++) {
                    var buildingInstance = buildings[i];
                    ImGui.Text(buildingInstance.Name);

                    ImGui.SameLine(ImGui.GetWindowWidth() - 120);

                    if (ImGui.Button($"Build##b{i}", new Vector2(100, 10))) {
                        Controller.OnCommand(new Command("BuildBuilding", buildingInstance));
                    }
                }
            }
            
            ImGui.EndWindow();
        }

        public override void Dispose() { }

        #region Properties

        public override bool Opened => _opened;

        #endregion
    }
}