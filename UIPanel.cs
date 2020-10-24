using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Sionnach
{
    class UIPanel
    {
        StateManager stateManager;
        SoundManager soundManager;
        SpriteBatch spriteBatch;
        public Rectangle rectangle; //the buttons background rectangle
        public Point position;
        public Point size;

        int elementOffset = 14;

        Texture2D panelTexture;

        public UIPanel(StateManager StateManager, Point Position, Point Size)
        {
            stateManager = StateManager;
            rectangle = new Rectangle(Position.X - (Size.X / 2), Position.Y - (Size.Y / 2), Size.X, Size.Y);
            position = Position;
            size = Size;
            soundManager = stateManager.game.soundManager;
            spriteBatch = stateManager.spriteBatch;

            LoadContent();
        }

        public void LoadContent()
        {
            Stream fileStream = TitleContainer.OpenStream("Content/UIPanel9Slice.png");
            panelTexture = Texture2D.FromStream(spriteBatch.GraphicsDevice, fileStream);
            fileStream.Close();
        }

        public void Draw()
        {
            int leftElementOffset = position.X - (size.X / 2);
            int rightElementOffset = position.X + (size.X / 2) - elementOffset;
            int topElementOffset = position.Y - (size.Y / 2);
            int bottomElementOffset = position.Y + (size.Y / 2) - elementOffset;

            spriteBatch.Draw(panelTexture, new Vector2(leftElementOffset, topElementOffset), new Rectangle(0, 0, elementOffset, elementOffset), Color.White);
            spriteBatch.Draw(panelTexture, new Vector2(rightElementOffset, topElementOffset), new Rectangle(elementOffset * 2, 0, elementOffset, elementOffset), Color.White);
            spriteBatch.Draw(panelTexture, new Vector2(leftElementOffset, bottomElementOffset), new Rectangle(0, (elementOffset * 2), elementOffset, elementOffset), Color.White);
            spriteBatch.Draw(panelTexture, new Vector2(rightElementOffset, bottomElementOffset), new Rectangle((elementOffset * 2), (elementOffset * 2), elementOffset, elementOffset), Color.White);

            //Fill sides
            spriteBatch.Draw(panelTexture, new Rectangle(leftElementOffset + elementOffset, topElementOffset, size.X - elementOffset * 2, elementOffset), new Rectangle(elementOffset, 0, elementOffset, elementOffset), Color.White);
            spriteBatch.Draw(panelTexture, new Rectangle(leftElementOffset + elementOffset, bottomElementOffset, size.X - elementOffset * 2, elementOffset), new Rectangle(elementOffset, elementOffset * 2, elementOffset, elementOffset), Color.White);
            spriteBatch.Draw(panelTexture, new Rectangle(leftElementOffset, topElementOffset + elementOffset, elementOffset, size.Y - elementOffset * 2), new Rectangle(0, elementOffset, elementOffset, elementOffset), Color.White);
            spriteBatch.Draw(panelTexture, new Rectangle(rightElementOffset, topElementOffset + elementOffset, elementOffset, size.Y - elementOffset * 2), new Rectangle(elementOffset * 2, elementOffset, elementOffset, elementOffset), Color.White);

            //Fill Centre
            spriteBatch.Draw(panelTexture, new Rectangle(leftElementOffset + elementOffset, topElementOffset + elementOffset, size.X - (elementOffset * 2), size.Y - (elementOffset * 2)), new Rectangle(elementOffset, elementOffset, elementOffset, elementOffset), Color.White);
        }

        public void Click()
        {
            Clicked.Invoke(this, EventArgs.Empty);

            Console.WriteLine("Panel clicked");
        }

        public EventHandler Clicked;
    }
}
