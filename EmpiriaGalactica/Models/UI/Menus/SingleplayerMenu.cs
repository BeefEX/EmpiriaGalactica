using System.Collections.Generic;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Controllers.UI;

namespace EmpiriaGalactica.Models.UI.Menus {
    public class SingleplayerMenu : Menu {
        public SingleplayerMenu() {
            Buttons = new List<Button>(new [] {
                new Button {
                    Title = "New game",
                    OnClick = () =>
                        EmpiriaGalactica.GameController.CurrentController = new GalaxyViewController(new Galaxy {
                            Name = "Test galaxy",
                            Empires = new List<Empire>(new [] {
                                new Empire {
                                    Name = "Test empire"
                                }
                            })
                        })
                },
                new Button {
                    Title = "Load game"
                },
                new Button {
                    Title = "Back",
                    OnClick = () =>
                        EmpiriaGalactica.GameController.CurrentController = new MenuController(new PlayMenu())
                }
            });
        }
    }
}