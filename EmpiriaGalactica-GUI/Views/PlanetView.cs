using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica_GUI.GlUtils;
using ImGuiNET;
using OpenTK.Graphics.OpenGL4;

namespace EmpiriaGalactica_GUI.Views {
    
    [Implements(typeof(global::EmpiriaGalactica.Views.PlanetView))]
    public class PlanetView : global::EmpiriaGalactica.Views.PlanetView {

        public PlanetView(IController controller, Planet model) : base(controller, model) {
            
        }
        
        public override void Update() {
            
        }

        public override void Dispose() {
            
        }
    }
}