using System;
using System.Collections.Generic;
using EmpiriaGalactica.Controllers.UI;

namespace EmpiriaGalactica.Models.UI.Menus {
    
    public class MainMenu : Menu {
        public MainMenu() {
            Buttons = new List<Button>(new [] {
                new Button {
                    Title = "Play",
                    OnClick = () =>
                        EmpiriaGalactica.GameController.CurrentController = new MenuController(new PlayMenu())
                },
                new Button {
                    Title = "Settings"
                },
                new Button {
                    Title = "Exit",
                    OnClick = () => Environment.Exit(0)
                }
            });
        }
    }
}