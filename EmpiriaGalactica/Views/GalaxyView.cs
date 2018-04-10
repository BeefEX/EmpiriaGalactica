using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Views {
    public abstract class GalaxyView : View<Galaxy> {
        protected GalaxyView(IController controller, Galaxy model) : base(controller, model) { }
    }
}