using System;
using ImGuiNET;
using ImGuiOpenTK;
using OpenTK.Graphics.OpenGL4;

namespace EmpiriaGalactica_GUI {
    
    public class Window : ImGuiOpenTKWindow {
        
        public Window() : base("EmpiriaGalactica") {
            
        }

        public override void ImGuiLayout() {
            ImGui.BeginWindow("test");
            ImGui.Text("this is a text");
            ImGui.EndWindow();
        }
    }
}