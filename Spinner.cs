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
    public class Spinner
    {
        StateManager stateManager;
        SoundManager soundManager;
        SpriteBatch spriteBatch;
        public Rectangle rectangle, rightArea, leftArea; //the buttons background rectangle
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

        Texture2D spinnerTexture;

        public int value = 0;


        public Spinner(StateManager StateManager, string Text, Point Position, Point Size)
        {
            stateManager = StateManager;
            rectangle = new Rectangle(Position.X - (Size.X / 2), Position.Y - (Size.Y / 2), Size.X, Size.Y);
            position = Position;
            size = Size;
            text = new Text(stateManager, Text, new Vector2(0, 0));
            drawColor = upColor;
            selectedColor = downColor;
            soundManager = stateManager.game.soundManager;
            spriteBatch = stateManager.spriteBatch;

            rightArea = new Rectangle(position.X + (size.X / 4), position.Y - (size.Y / 2), size.X / 4, size.Y);
            leftArea = new Rectangle(position.X - (size.X / 2), position.Y - (size.Y / 2), size.X / 4, size.Y);

            value = 0;

            updateText();

            LoadContent();
        }

        public void LoadContent()
        {
            spinnerTexture = TextureManager.spinnerTexture;
        }

        public void updateText()
        {
            if (value == 0)
            {
                
            }
            else if (value == 1)
            {
                
            }
        }

        public void changePosition(int deltaX = 0, int deltaY = 0)
        {
            position.X += deltaX;
            position.Y += deltaY;

            rectangle.X += deltaX;
            rectangle.Y += deltaY;

            rightArea.X += deltaX;
            rightArea.Y += deltaY;

            leftArea.X += deltaX;
            leftArea.Y += deltaY;

            CenterText();
        }

        public void CenterText()
        {
            text.position.X = position.X - (text.MeasureString() / 2);
            text.position.Y = position.Y;
        }

        public void Draw()
        {
            int leftElementOffset = position.X - (size.X / 2);
            int rightElementOffset = position.X + (size.X / 2) - 20;
            int topElementOffset = position.Y - (size.Y / 2);
            int bottomElementOffset = position.Y + (size.Y / 2) - 20;

            spriteBatch.Draw(spinnerTexture, new Vector2(leftElementOffset, topElementOffset), new Rectangle(0, 0, 20, 20), Color.White);
            spriteBatch.Draw(spinnerTexture, new Vector2(rightElementOffset, topElementOffset), new Rectangle(40, 0, 20, 20), Color.White);
            spriteBatch.Draw(spinnerTexture, new Vector2(leftElementOffset, bottomElementOffset), new Rectangle(0, 40, 20, 20), Color.White);
            spriteBatch.Draw(spinnerTexture, new Vector2(rightElementOffset, bottomElementOffset), new Rectangle(40, 40, 20, 20), Color.White);

            //Fill sides
            spriteBatch.Draw(spinnerTexture, new Rectangle(leftElementOffset + 20, topElementOffset, size.X - 40, 20), new Rectangle(20, 0, 20, 20), Color.White);
            spriteBatch.Draw(spinnerTexture, new Rectangle(leftElementOffset + 20, bottomElementOffset, size.X - 40, 20), new Rectangle(20, 40, 20, 20), Color.White);
            spriteBatch.Draw(spinnerTexture, new Rectangle(leftElementOffset, topElementOffset + 20, 20, size.Y - 40), new Rectangle(0, 20, 20, 20), Color.White);
            spriteBatch.Draw(spinnerTexture, new Rectangle(rightElementOffset, topElementOffset + 20, 20, size.Y - 40), new Rectangle(40, 20, 20, 20), Color.White);

            //Fill Centre
            spriteBatch.Draw(spinnerTexture, new Rectangle(leftElementOffset + 20, topElementOffset + 20, size.X - 40, size.Y - 40), new Rectangle(20, 20, 20, 20), Color.White);

            text.Draw();

        }

        public void Click(Point clickPoint)
        {
            if (rightArea.Contains(clickPoint))
            {
                value++;
            }
            else if (leftArea.Contains(clickPoint))
            {
                value--;
            }

            if (value > 3)
            {
                value = 0;
            }
            else if (value < 0)
            {
                value = 3;
            }

            updateText();
        }

        public EventHandler Clicked;
    }
}
