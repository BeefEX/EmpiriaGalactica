using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Views.UI {
    public abstract class PlanetWindowView : View<Planet> {
        protected PlanetWindowView(IController controller, Planet model) : base(controller, model) { }
    }
}