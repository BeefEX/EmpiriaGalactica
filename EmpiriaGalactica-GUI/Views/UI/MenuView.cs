using System.Numerics;
using EmpiriaGalactica.Commands;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models.UI;
using ImGuiNET;

namespace EmpiriaGalactica_GUI.Views.UI {
    
    [Implements(typeof(global::EmpiriaGalactica.Views.UI.MenuView))]
    public class MenuView : global::EmpiriaGalactica.Views.UI.MenuView {

        #region Methods

        public MenuView(IController controller, Menu model) : base(controller, model) { }
        
        public override void Update() {
            var sizeTmp = EmpiriaGalactica.Window.Size;
            var halfSize = new Vector2(sizeTmp.X / 2f, sizeTmp.Y / 2f);
            var windowSize = new Vector2(sizeTmp.X / 5f, sizeTmp.Y / 5f);
            
            ImGui.SetNextWindowPos(
                halfSize - windowSize / 2f,
                Condition.Always,
                Vector2.Zero);
            
            ImGui.SetNextWindowSize(windowSize, Condition.Appearing);
            
            ImGui.BeginWindow("menu",
                WindowFlags.NoCollapse |
                WindowFlags.NoMove |
                WindowFlags.NoResize |
                WindowFlags.NoTitleBar |
                WindowFlags.NoScrollbar |
                WindowFlags.AlwaysAutoResize);

            for (var i = 0; i < Model.Buttons.Count; i++) {
                var button = Model.Buttons[i];
                
                if (ImGui.Button($"{button.Title}##{i}", new Vector2(ImGui.GetContentRegionAvailableWidth(), 50)))
                    Controller.OnCommand(new Command("Click", button));
            }
            
            ImGui.EndWindow();
        }

        public override void Dispose() {
            
        }
        
        #endregion
    }
}