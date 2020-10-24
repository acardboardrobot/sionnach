using System;
using System.Collections.Generic;
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
    public class Checkbox : Button
    {
        Texture2D checkboxTexture, selectedTexture, unselectedTexture;
        bool isChecked = false;
        public Checkbox(SpriteBatch SpriteBatch, string Text, Point Position, Point Size, bool isCheck)
        {
            rectangle = new Rectangle(Position.X - (Size.X / 2), Position.Y - (Size.Y / 2), Size.X + 24 + size.Y, Size.Y);
            position = Position;
            size = Size;
            text = new Text(SpriteBatch, Text, new Vector2(0, 0));
            CenterText();
            drawColor = upColor;
            selectedColor = downColor;
            //soundManager = stateManager.game.soundManager;
            spriteBatch = SpriteBatch;

            isChecked = isCheck;

            selectedTexture = TextureManager.checkboxTextureSelected;
            unselectedTexture = TextureManager.checkboxTextureUnselected;
        }

        public override void Draw()
        {
            int leftElementOffset = position.X - (size.X / 2);
            int rightElementOffset = position.X + (size.X / 2) - 20;
            int topElementOffset = position.Y - (size.Y / 2);
            int bottomElementOffset = position.Y + (size.Y / 2) - 20;

            if (isChecked)
            {
                checkboxTexture = selectedTexture;
            }
            else
            {
                checkboxTexture = unselectedTexture;
            }

            spriteBatch.Draw(checkboxTexture, new Vector2(leftElementOffset, topElementOffset), new Rectangle(0, 0, 20, 20), Color.White);
            spriteBatch.Draw(checkboxTexture, new Vector2(rightElementOffset, topElementOffset), new Rectangle(40, 0, 20, 20), Color.White);
            spriteBatch.Draw(checkboxTexture, new Vector2(leftElementOffset, bottomElementOffset), new Rectangle(0, 40, 20, 20), Color.White);
            spriteBatch.Draw(checkboxTexture, new Vector2(rightElementOffset, bottomElementOffset), new Rectangle(40, 40, 20, 20), Color.White);

            //Fill sides
            spriteBatch.Draw(checkboxTexture, new Rectangle(leftElementOffset + 20, topElementOffset, size.X - 40, 20), new Rectangle(20, 0, 20, 20), Color.White);
            spriteBatch.Draw(checkboxTexture, new Rectangle(leftElementOffset + 20, bottomElementOffset, size.X - 40, 20), new Rectangle(20, 40, 20, 20), Color.White);
            spriteBatch.Draw(checkboxTexture, new Rectangle(leftElementOffset, topElementOffset + 20, 20, size.Y - 40), new Rectangle(0, 20, 20, 20), Color.White);
            spriteBatch.Draw(checkboxTexture, new Rectangle(rightElementOffset, topElementOffset + 20, 20, size.Y - 40), new Rectangle(40, 20, 20, 20), Color.White);

            //Fill Centre
            spriteBatch.Draw(checkboxTexture, new Rectangle(leftElementOffset + 20, topElementOffset + 20, size.X - 40, size.Y - 40), new Rectangle(20, 20, 20, 20), Color.White);

            spriteBatch.Draw(checkboxTexture, new Rectangle(rightElementOffset + 24, topElementOffset, size.Y, size.Y), new Rectangle(60, 0, 60, 60), Color.White);

            text.Draw();

            //Make mouse over false as it is checked every frame.
            over = false;
        }

        public override void Click()
        {
            Clicked.Invoke(this, EventArgs.Empty);
            isChecked = !isChecked;
        }

        public bool isThisChecked()
        {
            return isChecked;
        }
    }
}
