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
    public static class TextureManager
    {
        public static Texture2D checkboxTextureUnselected, checkboxTextureSelected;
        public static Texture2D buttonTexture, buttonSelectedTexture;
        public static Texture2D spinnerTexture;
        public static Texture2D resourceSheetTexture;
        public static void LoadContent(SpriteBatch spriteBatch)
        {
            Stream fileStream = TitleContainer.OpenStream("Content/Checkbox9Slice.png");
            checkboxTextureUnselected = Texture2D.FromStream(spriteBatch.GraphicsDevice, fileStream);
            fileStream.Close();
            fileStream = TitleContainer.OpenStream("Content/Checkbox9SliceSelected.png");
            checkboxTextureSelected = Texture2D.FromStream(spriteBatch.GraphicsDevice, fileStream);
            fileStream.Close();

            fileStream = TitleContainer.OpenStream("Content/Button9Slice.png");
            buttonTexture = Texture2D.FromStream(spriteBatch.GraphicsDevice, fileStream);
            fileStream.Close();
            fileStream = TitleContainer.OpenStream("Content/Button9SliceSelected.png");
            buttonSelectedTexture = Texture2D.FromStream(spriteBatch.GraphicsDevice, fileStream);
            fileStream.Close();

            fileStream = TitleContainer.OpenStream("Content/Spinner9Slice.png");
            spinnerTexture = Texture2D.FromStream(spriteBatch.GraphicsDevice, fileStream);
            fileStream.Close();

            fileStream = TitleContainer.OpenStream("Content/ResourceSheet.png");
            resourceSheetTexture = Texture2D.FromStream(spriteBatch.GraphicsDevice, fileStream);
            fileStream.Close();
        }
    }
}
