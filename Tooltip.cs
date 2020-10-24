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
    public class Tooltip
    {
        StateManager stateManager;
        SpriteBatch spriteBatch;
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

        public bool toDraw = false;

        Texture2D tooltipTexture;

        public Tooltip(StateManager StateManager, string Text, Point Position, Point Size)
        {
            stateManager = StateManager;
            rectangle = new Rectangle(Position.X - (Size.X / 2), Position.Y - (Size.Y / 2), Size.X, Size.Y);
            position = Position;
            size = Size;
            text = new Text(stateManager, Text, new Vector2(0, 0));
            CenterText();
            drawColor = upColor;
            selectedColor = downColor;
            spriteBatch = stateManager.spriteBatch;

            LoadContent();
        }

        public void LoadContent()
        {
            Stream fileStream = TitleContainer.OpenStream("Content/Button9Slice.png");
            tooltipTexture = Texture2D.FromStream(spriteBatch.GraphicsDevice, fileStream);
            fileStream.Close();
        }

        public void changeText(string desText)
        {
            text.text = desText;
            size.X = text.MeasureString() + 28;
            CenterText();
            toDraw = true;
        }

        public void setPosition(Point desPoint)
        {
            position = desPoint;
            position.Y -= 14;
            position.X += 100;
            rectangle.Location = position;
            rectangle.X -= rectangle.Width / 2;
        }

        public void CenterText()
        {
            float textWidth = text.MeasureString(); //measure string
            float textHeight = text.glyphDimensions.Y; //measure string
            text.position.X = (position.X) - (textWidth / 2); //center text to button
            //if the textWidth is odd, it blurs, so add 0.5f to any odd sized text
            if (textWidth % 2 != 0) { text.position.X += 0.5f; } //if textWidth is odd offset by 1/2 pixel to keep it sharp/on whole number
            text.position.Y = (rectangle.Location.Y) + (textHeight / 2); //center text vertically
        }

        public void Draw()
        {
            int leftElementOffset = position.X - (size.X / 2);
            int rightElementOffset = position.X + (size.X / 2) - 20;
            int topElementOffset = position.Y - (size.Y / 2);
            int bottomElementOffset = position.Y + (size.Y / 2) - 20;

            spriteBatch.Draw(tooltipTexture, new Vector2(leftElementOffset, topElementOffset), new Rectangle(0, 0, 20, 20), Color.White);
            spriteBatch.Draw(tooltipTexture, new Vector2(rightElementOffset, topElementOffset), new Rectangle(40, 0, 20, 20), Color.White);
            spriteBatch.Draw(tooltipTexture, new Vector2(leftElementOffset, bottomElementOffset), new Rectangle(0, 40, 20, 20), Color.White);
            spriteBatch.Draw(tooltipTexture, new Vector2(rightElementOffset, bottomElementOffset), new Rectangle(40, 40, 20, 20), Color.White);

            //Fill sides
            spriteBatch.Draw(tooltipTexture, new Rectangle(leftElementOffset + 20, topElementOffset, size.X - 40, 20), new Rectangle(20, 0, 20, 20), Color.White);
            spriteBatch.Draw(tooltipTexture, new Rectangle(leftElementOffset + 20, bottomElementOffset, size.X - 40, 20), new Rectangle(20, 40, 20, 20), Color.White);
            spriteBatch.Draw(tooltipTexture, new Rectangle(leftElementOffset, topElementOffset + 20, 20, size.Y - 40), new Rectangle(0, 20, 20, 20), Color.White);
            spriteBatch.Draw(tooltipTexture, new Rectangle(rightElementOffset, topElementOffset + 20, 20, size.Y - 40), new Rectangle(40, 20, 20, 20), Color.White);

            //Fill Centre
            spriteBatch.Draw(tooltipTexture, new Rectangle(leftElementOffset + 20, topElementOffset + 20, size.X - 40, size.Y - 40), new Rectangle(20, 20, 20, 20), Color.White);

            text.Draw();

            toDraw = false;
        }

        public void Click()
        {

        }

        public EventHandler Clicked;
    }
}
