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
    public class PopUp
    {
        StateManager stateManager;
        SoundManager soundManager;
        SpriteBatch spriteBatch;
        public Rectangle rectangle; //the background rectangle
        public Text text;           //the foreground text
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
        public bool dead = false;
        public int lifeTime;

        public Point targetPosition;
        public bool moving;

        Texture2D backgroundTexture, selectedTexture, normalTexture, imageTexture;

        Sprite imageSprite;

        public enum popUpState { In, Solid, Out } //up = normal, over = mouse over, down = mouse click
        public popUpState popupState = popUpState.Solid;

        public PopUp(StateManager StateManager, string Text, Utilities.UILocationAnchor anchorPoint, int desLife = 1000, int numberOfPopups = 0)
        {
            stateManager = StateManager;
            text = new Text(stateManager, Text, new Vector2(0, 0));
            int widthHolder = text.MeasureString();
            size.X = widthHolder + 24;
            size.Y = (int)text.glyphDimensions.Y + 24;
            if (anchorPoint == Utilities.UILocationAnchor.topLeft)
            {
                //rectangle = new Rectangle
            }
            else if (anchorPoint == Utilities.UILocationAnchor.topRight)
            {
                position = new Point(Utilities.gameWindowWidth - ((size.X / 2) + 6), (size.Y / 2) + (size.Y * numberOfPopups) + 6);
            }
            rectangle = new Rectangle(Utilities.gameWindowWidth - (size.X / 2), position.Y - (size.Y / 2), size.X, size.Y);
            //position = new Point(Utilities.gameWindowWidth - size.X, 100);
            text = new Text(stateManager, Text, new Vector2(0, 0));
            CenterText();
            drawColor = upColor;
            selectedColor = downColor;
            soundManager = stateManager.game.soundManager;
            spriteBatch = stateManager.spriteBatch;
            moving = false;

            lifeTime = desLife;

            LoadContent();
        }

        public void LoadContent()
        {
            Stream fileStream = TitleContainer.OpenStream("Content/UIPanel9Slice.png");
            normalTexture = Texture2D.FromStream(spriteBatch.GraphicsDevice, fileStream);
            fileStream.Close();

            backgroundTexture = normalTexture;
        }

        public void CenterText()
        {
            //float textWidth = stateManager.game.spriteFont.MeasureString(text.text).X; //measure string
            //float textHeight = stateManager.game.spriteFont.MeasureString(text.text).Y; //measure string
            //text.position.X = (rectangle.Location.X + rectangle.Width / 2) - (textWidth / 2); //center text to button
            //if the textWidth is odd, it blurs, so add 0.5f to any odd sized text
            //if (textWidth % 2 != 0) { text.position.X += 0.5f; } //if textWidth is odd offset by 1/2 pixel to keep it sharp/on whole number
            //text.position.Y = (rectangle.Location.Y) + (textHeight / 2); //center text vertically
            text.position.X = position.X - (size.X / 2) + 14;
            text.position.Y = position.Y - (text.glyphDimensions.Y / 2);
        }

        public void Draw()
        {
            int leftElementOffset = position.X - (size.X / 2);
            int rightElementOffset = position.X + (size.X / 2) - 20;
            int topElementOffset = position.Y - (size.Y / 2);
            int bottomElementOffset = position.Y + (size.Y / 2) - 20;
            int elementOffset = 14;

            spriteBatch.Draw(backgroundTexture, new Vector2(leftElementOffset, topElementOffset), new Rectangle(0, 0, elementOffset, elementOffset), Color.White);
            spriteBatch.Draw(backgroundTexture, new Vector2(rightElementOffset, topElementOffset), new Rectangle(elementOffset * 2, 0, elementOffset, elementOffset), Color.White);
            spriteBatch.Draw(backgroundTexture, new Vector2(leftElementOffset, bottomElementOffset), new Rectangle(0, (elementOffset * 2), elementOffset, elementOffset), Color.White);
            spriteBatch.Draw(backgroundTexture, new Vector2(rightElementOffset, bottomElementOffset), new Rectangle((elementOffset * 2), elementOffset * 2, elementOffset, elementOffset), Color.White);

            //Fill sides
            spriteBatch.Draw(backgroundTexture, new Rectangle(leftElementOffset + elementOffset, topElementOffset, size.X - elementOffset * 2, elementOffset), new Rectangle(elementOffset, 0, elementOffset, elementOffset), Color.White);
            spriteBatch.Draw(backgroundTexture, new Rectangle(leftElementOffset + elementOffset, bottomElementOffset, size.X - elementOffset * 2, elementOffset), new Rectangle(elementOffset, elementOffset * 2, elementOffset, elementOffset), Color.White);
            spriteBatch.Draw(backgroundTexture, new Rectangle(leftElementOffset, topElementOffset + elementOffset, elementOffset, size.Y - elementOffset * 2), new Rectangle(0, elementOffset, elementOffset, elementOffset), Color.White);
            spriteBatch.Draw(backgroundTexture, new Rectangle(rightElementOffset, topElementOffset + elementOffset, elementOffset, size.Y - elementOffset * 2), new Rectangle(elementOffset * 2, elementOffset, elementOffset, elementOffset), Color.White);

            //Fill Centre
            spriteBatch.Draw(backgroundTexture, new Rectangle(leftElementOffset + elementOffset, topElementOffset + elementOffset, size.X - (elementOffset * 2), size.Y - (elementOffset * 2)), new Rectangle(elementOffset, elementOffset, elementOffset, elementOffset), Color.White);
            

            if (imageSprite != null)
            {
                imageSprite.Draw();
            }

            text.Draw();

            //Make mouse over false as it is checked every frame.
            over = false;
        }

        public void Update(int timeStamp)
        {
            lifeTime -= timeStamp;

            if (lifeTime <= 0)
            {
                dead = true;
            }

            if (position != targetPosition && moving)
            {
                int xDelta = targetPosition.X - position.X;
                int yDelta = targetPosition.Y - position.Y;

                position.X += (int)(xDelta * 0.1);
                position.Y += (int)(yDelta * 0.1);
                CenterText();

                if (position == targetPosition)
                {
                    moving = false;
                }
            }
        }

        public void setTargetPosition(Point newPoint)
        {
            targetPosition = newPoint;
            moving = true;
        }

        public void Click()
        {

        }

        public EventHandler Clicked;

        public void mouseOver()
        {
            over = true;
        }
    }
}
