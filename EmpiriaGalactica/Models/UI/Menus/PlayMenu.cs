using System.Collections.Generic;
using EmpiriaGalactica.Controllers.UI;

namespace EmpiriaGalactica.Models.UI.Menus {
    public class PlayMenu : Menu {
        
        public PlayMenu() {
            Buttons = new List<Button>(new[] {
                new Button {
                    Title = "Singleplayer"
                },
                new Button {
                    Title = "Multiplayer"
                },
                new Button {
                    Title = "Back",
                    OnClick = () =>
                        EmpiriaGalactica.GameController.CurrentController = new MenuController(new MainMenu())
                }
            });
        }
    }
}