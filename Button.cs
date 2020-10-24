using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Sionnach
{
    public class Button
    {
        StateManager stateManager;
        SoundManager soundManager;
        protected SpriteBatch spriteBatch;
        public Rectangle rectangle; //the buttons background rectangle
        public Text text;           //the buttons foreground text
        public string id;
        public Point position;
        public Point size;

        public Color upColor = new Color(44, 44, 44);
        public Color overColor = new Color(66, 66, 66);
        public Color downColor = new Color(100, 100, 100);
        public Color drawColor;     //points to one of the above colors
        public Color selectedColor; //points to one of the above colors
        public bool selected = false;
        public bool over = true;

        Texture2D buttonTexture, selectedTexture, normalTexture, imageTexture;

        Sprite imageSprite;

        public enum ButtonState { Up, Over, Down } //up = normal, over = mouse over, down = mouse click
        public ButtonState buttonState = ButtonState.Up;

        public Button()
        {

        }

        public Button(StateManager StateManager, string Text, Point Position, Point Size)
        {
            stateManager = StateManager;
            rectangle = new Rectangle(Position.X - (Size.X/2), Position.Y - (Size.Y / 2), Size.X, Size.Y);
            position = Position;
            size = Size;
            text = new Text(stateManager, Text, new Vector2(0, 0));
            CenterText();
            drawColor = upColor;
            selectedColor = downColor;
            soundManager = stateManager.game.soundManager;
            spriteBatch = stateManager.spriteBatch;

            LoadContent();
        }

        public Button(SpriteBatch SpriteBatch, string Text, Point Position, Point Size)
        {
            rectangle = new Rectangle(Position.X - (Size.X / 2), Position.Y - (Size.Y / 2), Size.X, Size.Y);
            position = Position;
            size = Size;
            text = new Text(SpriteBatch, Text, new Vector2(0, 0));
            CenterText();
            drawColor = upColor;
            selectedColor = downColor;
            soundManager = stateManager.game.soundManager;
            spriteBatch = SpriteBatch;

            LoadContent();
        }

        public void LoadContent()
        {
            Stream fileStream;
            normalTexture = TextureManager.buttonTexture;
            selectedTexture = TextureManager.buttonSelectedTexture;
            /*if (buildArguments != null)
            {
                fileStream = TitleContainer.OpenStream("Content/buildingIconSheet.png");
                imageTexture = Texture2D.FromStream(spriteBatch.GraphicsDevice, fileStream);
                fileStream.Close();
                if (buildArguments.Name == buildingType.house)
                {
                    imageSprite = new Sprite(stateManager, imageTexture, Utilities.PointToVector2(position), new Point(28, 28), new Point(0, 0));
                }
            }*/

            buttonTexture = normalTexture;
        }

        public void CenterText()
        {
            text.position.X = position.X - (text.MeasureString()/2);
            text.position.Y = position.Y;
        }

        public virtual void Draw()
        {
            int leftElementOffset = position.X - (size.X / 2);
            int rightElementOffset = position.X + (size.X / 2) - 20;
            int topElementOffset = position.Y - (size.Y / 2);
            int bottomElementOffset = position.Y + (size.Y / 2) - 20;

            if (selected)
            {
                buttonTexture = selectedTexture;
            }
            else if(over)
            {
                buttonTexture = selectedTexture;
            }
            else
            {
                buttonTexture = normalTexture;
            }

            spriteBatch.Draw(buttonTexture, new Vector2(leftElementOffset, topElementOffset), new Rectangle(0, 0, 20, 20), Color.White);
            spriteBatch.Draw(buttonTexture, new Vector2(rightElementOffset, topElementOffset), new Rectangle(40, 0, 20, 20), Color.White);
            spriteBatch.Draw(buttonTexture, new Vector2(leftElementOffset, bottomElementOffset), new Rectangle(0, 40, 20, 20), Color.White);
            spriteBatch.Draw(buttonTexture, new Vector2(rightElementOffset, bottomElementOffset), new Rectangle(40, 40, 20, 20), Color.White);

            //Fill sides
            spriteBatch.Draw(buttonTexture, new Rectangle(leftElementOffset + 20, topElementOffset, size.X - 40, 20), new Rectangle(20, 0, 20, 20), Color.White);
            spriteBatch.Draw(buttonTexture, new Rectangle(leftElementOffset + 20, bottomElementOffset, size.X - 40, 20), new Rectangle(20, 40, 20, 20), Color.White);
            spriteBatch.Draw(buttonTexture, new Rectangle(leftElementOffset, topElementOffset + 20, 20, size.Y - 40), new Rectangle(0, 20, 20, 20), Color.White);
            spriteBatch.Draw(buttonTexture, new Rectangle(rightElementOffset, topElementOffset + 20, 20, size.Y - 40), new Rectangle(40, 20, 20, 20), Color.White);

            //Fill Centre
            spriteBatch.Draw(buttonTexture, new Rectangle(leftElementOffset + 20, topElementOffset + 20, size.X - 40, size.Y - 40), new Rectangle(20, 20, 20, 20), Color.White);

            if (imageSprite != null)
            {
                imageSprite.Draw();
            }
            else
            {
                text.Draw();
            }

            //Make mouse over false as it is checked every frame.
            over = false;
        }

        public void changePosition(int xChange = 0, int yChange = 0)
        {
            position.X += xChange;
            position.Y += yChange;

            rectangle.X += xChange;
            rectangle.Y += yChange;

            CenterText();
        }

        public virtual void Click()
        {
            /*if (buildArguments != null)
            {
                Clicked.Invoke(this, buildArguments);
            }
            else
            {*/

            Clicked.Invoke(this, EventArgs.Empty);

            //}
        }

        public EventHandler Clicked;

        public void mouseOver()
        {
            over = true;
        }
    }
}
