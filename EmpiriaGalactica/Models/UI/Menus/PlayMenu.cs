using System.Collections.Generic;
using EmpiriaGalactica.Controllers.ViewControllers;

namespace EmpiriaGalactica.Models.UI.Menus {
    public class PlayMenu : Menu {
        
        public PlayMenu() {
            Buttons = new List<Button>(new[] {
                new Button {
                    Title = "Singleplayer",
                    OnClick = () =>
                        EmpiriaGalactica.GameController.CurrentController = new MenuViewController(new SingleplayerMenu())
                },
                new Button {
                    Title = "Multiplayer"
                },
                new Button {
                    Title = "Back",
                    OnClick = () => EmpiriaGalactica.GameController.PopBack()
                }
            });
        }
    }
}