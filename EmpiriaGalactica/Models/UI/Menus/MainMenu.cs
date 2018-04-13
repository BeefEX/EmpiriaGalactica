using System;
using System.Collections.Generic;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Controllers.ViewControllers;

namespace EmpiriaGalactica.Models.UI.Menus {
    
    public class MainMenu : Menu {
        public MainMenu() {
            Buttons = new List<Button>(new [] {
                new Button {
                    Title = "Play",
                    OnClick = () =>
                        EmpiriaGalactica.GameController.CurrentController = new MenuViewController(new PlayMenu())
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