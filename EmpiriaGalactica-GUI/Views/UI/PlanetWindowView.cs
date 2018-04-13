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

        #region Methods
        
        private bool _opened;

        public PlanetWindowView(IController controller, Planet model) : base(controller, model) {
            _opened = true;
        }
        
        public override void Update() {
            
            ImGui.PushStyleVar(StyleVar.WindowMinSize, new Vector2(450, 220));
            
            // Create a window
            ImGui.BeginWindow($"Planet - {Model.Name}", ref _opened, WindowFlags.NoSavedSettings);
            
            ImGui.PopStyleVar();
            
            // Create columns
            ImGui.Columns(3, "windowCols", true);

            // Column labels
            ImGui.Text("Planet information:");
            ImGui.NextColumn();
            
            ImGui.Text("Buildings:");
            ImGui.NextColumn();
            
            ImGui.Text("Units:");
            ImGui.NextColumn();
            ImGui.Separator();
            
            
            // First column
            ImGui.BeginChild("##info");
            
            ImGui.Text("Planet name:");
            ImGui.Text(Model.Name);
            ImGui.Separator();
            
            ImGui.Text("Planet biome:");
            ImGui.Text(Model.Biome.ToString());
            ImGui.Separator();
            
            ImGui.Text("Planet population:");
            ImGui.Text(Model.Pupulation.ToString());
            ImGui.Separator();
            
            ImGui.Text("Planet emperor:");
            ImGui.Text(Model.Owner.Name);
            
            ImGui.EndChild();
            ImGui.NextColumn();

            
            // Second column
            ImGui.BeginChild("##buildings");

            if (ImGui.CollapsingHeader("Built", "bui", true, true)) {
                for (var i = 0; i < Model.Buildings.Count; i++) {
                    var buildingInstance = Model.Buildings[i];
                    ImGui.Text(buildingInstance.SourceBuilding.Name);

                    if (ImGui.Button($"Destroy##d{i}", new Vector2(ImGui.GetContentRegionAvailableWidth(), 20)))
                        Controller.OnCommand(new Command("DestroyBuilding", buildingInstance));
                    
                    if (ImGui.IsItemHovered(HoveredFlags.Default))
                        ShowDestroyToolTip(buildingInstance.SourceBuilding);
                }
            }

            if (ImGui.CollapsingHeader("Avaliable", "ava", true, true)) {
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

                    var canBuild = Model.Owner.Resources.HasAllResources(buildingInstance.BaseCost);

                    if (!canBuild) {
                        ImGui.PushStyleColor(ColorTarget.Button, new Vector4(0.7f, 0.7f, 0.7f, 1f));
                        ImGui.PushStyleColor(ColorTarget.ButtonActive, new Vector4(0.7f, 0.7f, 0.7f, 1f));
                        ImGui.PushStyleColor(ColorTarget.ButtonHovered, new Vector4(0.7f, 0.7f, 0.7f, 1f));
                    }


                    if (ImGui.Button($"Build##b{i}", new Vector2(ImGui.GetContentRegionAvailableWidth(), 20)) &&
                        canBuild)
                        Controller.OnCommand(new Command("BuildBuilding", buildingInstance));
                    
                    if (!canBuild)
                        ImGui.PopStyleColor(3);
                    
                    if (ImGui.IsItemHovered(HoveredFlags.Default))
                        ShowBuildToolTip(buildingInstance);
                }
            }
            
            ImGui.EndChild();
            
            ImGui.NextColumn();
            
            
            
            // Third column
            ImGui.BeginChild("##units");
            
            ImGui.EndChild();
            
            ImGui.EndWindow();
            
            ImGui.PopStyleVar();
        }

        private void ShowBuildToolTip(Building building) {
            var mousePos = ImGui.GetIO().MousePosition;

            ImGui.SetNextWindowPos(mousePos + new Vector2(10, 0), Condition.Always, Vector2.Zero);
            
            ImGui.PushStyleVar(StyleVar.WindowPadding, new Vector2(20, 10));

            bool tmp = true;
            
            ImGui.BeginWindow(
                "BuildTooltip",
                ref tmp,
                1.0f,
                WindowFlags.NoCollapse |
                WindowFlags.NoMove |
                WindowFlags.NoTitleBar |
                WindowFlags.NoInputs |
                WindowFlags.NoSavedSettings |
                WindowFlags.AlwaysAutoResize);
            
            ImGui.Text("Required resources:");

            foreach (var instance in building.BaseCost) {
                ImGui.PushStyleColor(ColorTarget.Text, new Vector4(0.5f, 0.5f, 0.5f, 1.0f));
                ImGui.Text($"{instance.SourceResource.Name}: ");

                
                ImGui.PopStyleColor();
                ImGui.SameLine();
                
                var notEnough = Model.Owner.Resources[instance.SourceResource.InternalName].Amount < instance.Amount;
                
                if (notEnough)
                    ImGui.PushStyleColor(ColorTarget.Text, new Vector4(0.9f, 0f, 0f, 1f));
                
                ImGui.Text(instance.Amount.ToString());
                
                if (notEnough)
                    ImGui.PopStyleColor();
            }
            
            ImGui.EndWindow();
            
            ImGui.PopStyleVar();
        }
        
        private void ShowDestroyToolTip(Building building) {
            var mousePos = ImGui.GetIO().MousePosition;

            ImGui.SetNextWindowPos(mousePos + new Vector2(10, 0), Condition.Always, Vector2.Zero);
            
            ImGui.PushStyleVar(StyleVar.WindowPadding, new Vector2(20, 10));

            bool tmp = true;
            
            ImGui.BeginWindow(
                "BuildTooltip",
                ref tmp,
                1.0f,
                WindowFlags.NoCollapse |
                WindowFlags.NoMove |
                WindowFlags.NoTitleBar |
                WindowFlags.NoInputs |
                WindowFlags.NoSavedSettings |
                WindowFlags.AlwaysAutoResize);
            
            ImGui.Text("Will yield:");

            foreach (var instance in building.BaseCost) {
                ImGui.PushStyleColor(ColorTarget.Text, new Vector4(0.5f, 0.5f, 0.5f, 1.0f));
                ImGui.Text($"{instance.SourceResource.Name}: ");
                ImGui.PopStyleColor();
                
                ImGui.SameLine();
                ImGui.Text(instance.Amount.ToString());
            }
            
            ImGui.EndWindow();
            
            ImGui.PopStyleVar();
        }
        
        public override void Dispose() { }
        
        #endregion
        
        #region Properties

        public override bool Opened => _opened;

        #endregion
    }
}