using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica.Views {
    public abstract class GalaxyView : View<Galaxy> {
        protected GalaxyView(IController controller, Galaxy model) : base(controller, model) { }
    }
}