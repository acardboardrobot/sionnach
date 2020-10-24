using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sionnach
{
    class UI
    {
        StateManager stateManager;
        public Button houseBuildButton, stoneCutterBuildButton, hearthStoneBuildButton, hunterBuildButton, woodCutterBuildButton, stockpileBuildButton, claypitBuildButton, granaryBuildButton, monumentBuildButton;
        public UIPanel panel;
        public Rectangle UIRectangle;
        List<Button> buttons = new List<Button>();
        List<PopUp> popups = new List<PopUp>();
        Tooltip toolTip;

        public UI(StateManager StateManager)
        {
            stateManager = StateManager;
            /*sampleButton = new Button(stateManager, "Test", new Point(36, Utilities.gameWindowHeight - 107), new Point(64, 64));
            sampleButton.Clicked += new EventHandler(tests);
            */

            //buttons.Add(sampleButton);
            
            panel = new UIPanel(stateManager, new Point(Utilities.gameWindowWidth/2, Utilities.gameWindowHeight - 72), new Point(Utilities.gameWindowWidth, 142));
            UIRectangle = panel.rectangle;

            toolTip = new Tooltip(stateManager, "Sample", new Point(0, 0), new Point(128, 28));
        }

        public void Draw()
        {
            panel.Draw();
            foreach(Button b in buttons)
            {
                b.Draw();
            }

            foreach (PopUp p in popups)
            {
                p.Draw();
            }

            if (toolTip.toDraw)
            {
                toolTip.Draw();
            }

        }

        public void HandleInput(InputHelper input, GameTime gameTime)
        {
            /*
             * if (sampleButton.rectangle.Contains(input.cursorPosition))
            {
                if (input.IsNewMouseButtonRelease(MouseButtons.LeftButton))
                {
                    sampleButton.Click();
                }
                else
                {
                    sampleButton.mouseOver();
                    toolTip.changeText(LanguageManager.samplebuttonstring);
                }
            }
            */

            toolTip.setPosition(input.cursorPosition);

            Update(gameTime);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = popups.Count - 1; i > -1; i--)
            {
                popups[i].Update(gameTime.ElapsedGameTime.Milliseconds);

                if (popups[i].dead)
                {
                    popups.RemoveAt(i);
                    foreach (PopUp p in popups)
                    {
                        p.setTargetPosition(p.position - new Point(0, p.size.Y + 6));
                    }
                }
            }
        }

        public void addPopup(string desText)
        {
            PopUp p = new PopUp(stateManager, desText, Utilities.UILocationAnchor.topRight, 2000, popups.Count);
            popups.Add(p);
        }

        public void tests(object sender, EventArgs e)
        {
            
        }
    }
}
