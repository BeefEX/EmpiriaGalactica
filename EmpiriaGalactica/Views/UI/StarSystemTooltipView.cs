using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Views.UI {
    public abstract class StarSystemTooltipView : View<StarSystem> {
        protected StarSystemTooltipView(IController controller, StarSystem model) : base(controller, model) { }
    }
}