using System;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Views {
    
    public abstract class StarSystemView : View<StarSystem> {
        protected StarSystemView(IController controller, StarSystem model) : base(controller, model) { }
    }
}