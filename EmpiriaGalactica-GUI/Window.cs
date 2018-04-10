using System;
using System.Collections.Generic;
using System.IO;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica_GUI.GlUtils;
using EmpiriaGalactica_GUI.Views;
using ImGuiNET;
using ImGuiOpenTK;
using Bitmap = System.Drawing.Bitmap;
using Vector2 = System.Numerics.Vector2;
using Vector4 = System.Numerics.Vector4;

namespace EmpiriaGalactica_GUI {
    
    public class Window : ImGuiOpenTKWindow {

        public Window() : base("EmpiriaGalactica") {
            GalaxyView.InitTextures();
            StarSystemView.InitTextures();
        }

        public override void ImGuiLayout() {
            global::EmpiriaGalactica.EmpiriaGalactica.GameController.Update();
        }
    }
}