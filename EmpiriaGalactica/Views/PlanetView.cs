using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Views {
    public abstract class PlanetView : View<Planet> {
        protected PlanetView(IController controller, Planet model) : base(controller, model) { }
    }
}