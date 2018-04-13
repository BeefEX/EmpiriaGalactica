using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Views.UI.Overlay {
    public abstract class OverlayView : View<Game> {
        protected OverlayView(IController controller, Game model) : base(controller, model) { }
    }
}