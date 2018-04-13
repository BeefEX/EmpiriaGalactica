using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models.UI;

namespace EmpiriaGalactica.Views.UI {
    public abstract class MenuView : View<Menu> {
        protected MenuView(IController controller, Menu model) : base(controller, model) { }
    }
}