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
    public class Text
    {
        StateManager stateManager;
        SpriteBatch spriteBatch;
        public String text;             //the string of text to draw
        public Sprite font;
        public Vector2 position;        //the position of the text to draw
        public Color color;             //the color of the text to draw
        public float alpha = 1.0f;      //the opacity of the text
        public float rotation = 0.0f;
        public float scale = 2.0f;
        public float zDepth = 0.001f;   //the layer to draw the text to
        public Vector2 glyphDimensions;
        public int kerning = 1;

        public Text(StateManager StateManager, String Text, Vector2 Position)
        {
            stateManager = StateManager;
            position = Position;
            text = Text;
            color = Color.DarkSlateGray;
            spriteBatch = stateManager.spriteBatch;

            Stream fileStream = TitleContainer.OpenStream("Content/Typeface.png");
            Texture2D text2d = Texture2D.FromStream(stateManager.spriteBatch.GraphicsDevice, fileStream);
            fileStream.Close();
            loadFont(text2d, new Vector2(5, 5));
        }

        public Text(SpriteBatch SpriteBatch, String Text, Vector2 Position)
        {
            position = Position;
            text = Text;
            color = Color.DarkSlateGray;
            spriteBatch = SpriteBatch;

            Stream fileStream = TitleContainer.OpenStream("Content/Typeface.png");
            Texture2D text2d = Texture2D.FromStream(SpriteBatch.GraphicsDevice, fileStream);
            fileStream.Close();
            loadFont(text2d, new Vector2(5, 5));
        }

        public void loadFont(Texture2D fontTexture, Vector2 glyphSize)
        {
            glyphDimensions = glyphSize;
            font = new Sprite(spriteBatch, fontTexture, position, Utilities.Vector2ToPoint(glyphDimensions), new Point(0, 0));
            font.scale = scale;
            font.drawColour = color;
        }

        public void drawString(string textToDraw)
        {
            Vector2 currentPosition = position;
            text = textToDraw;

            for (int i = 0; i < text.Length; i++)
            {
                font.position = currentPosition;

                switch(text[i].ToString())
                {
                    case "a":
                        font.currentFrame = new Point(0, 0);
                        //font.Draw();
                        break;
                    case "A":
                        font.currentFrame = new Point(1, 0);
                        //font.Draw();
                        break;
                    case "b":
                        font.currentFrame = new Point(2, 0);
                        break;
                    case "B":
                        font.currentFrame = new Point(3, 0);
                        break;
                    case "c":
                        font.currentFrame = new Point(4, 0);
                        break;
                    case "C":
                        font.currentFrame = new Point(5, 0);
                        break;
                    case "d":
                        font.currentFrame = new Point(6, 0);
                        break;
                    case "D":
                        font.currentFrame = new Point(7, 0);
                        break;
                    case "e":
                        font.currentFrame = new Point(8, 0);
                        break;
                    case "E":
                        font.currentFrame = new Point(9, 0);
                        break;
                    case "f":
                        font.currentFrame = new Point(10, 0);
                        break;
                    case "F":
                        font.currentFrame = new Point(11, 0);
                        break;
                    case "g":
                        font.currentFrame = new Point(12, 0);
                        break;
                    case "G":
                        font.currentFrame = new Point(13, 0);
                        break;
                    case "h":
                        font.currentFrame = new Point(14, 0);
                        break;
                    case "H":
                        font.currentFrame = new Point(15, 0);
                        break;
                    case "i":
                        font.currentFrame = new Point(16, 0);
                        break;
                    case "I":
                        font.currentFrame = new Point(17, 0);
                        break;
                    case "j":
                        font.currentFrame = new Point(18, 0);
                        break;
                    case "J":
                        font.currentFrame = new Point(19, 0);
                        break;
                    case "k":
                        font.currentFrame = new Point(20, 0);
                        break;
                    case "K":
                        font.currentFrame = new Point(21, 0);
                        break;
                    case "l":
                        font.currentFrame = new Point(22, 0);
                        break;
                    case "L":
                        font.currentFrame = new Point(23, 0);
                        break;
                    case "m":
                        font.currentFrame = new Point(24, 0);
                        break;
                    case "M":
                        font.currentFrame = new Point(25, 0);
                        break;
                    case "n":
                        font.currentFrame = new Point(26, 0);
                        break;
                    case "N":
                        font.currentFrame = new Point(27, 0);
                        break;
                    case "o":
                        font.currentFrame = new Point(28, 0);
                        break;
                    case "O":
                        font.currentFrame = new Point(29, 0);
                        break;
                    case "p":
                        font.currentFrame = new Point(30, 0);
                        break;
                    case "P":
                        font.currentFrame = new Point(31, 0);
                        break;
                    case "q":
                        font.currentFrame = new Point(32, 0);
                        break;
                    case "Q":
                        font.currentFrame = new Point(33, 0);
                        break;
                    case "r":
                        font.currentFrame = new Point(34, 0);
                        break;
                    case "R":
                        font.currentFrame = new Point(35, 0);
                        break;
                    case "s":
                        font.currentFrame = new Point(36, 0);
                        break;
                    case "S":
                        font.currentFrame = new Point(37, 0);
                        break;
                    case "t":
                        font.currentFrame = new Point(38, 0);
                        break;
                    case "T":
                        font.currentFrame = new Point(39, 0);
                        break;
                    case "u":
                        font.currentFrame = new Point(40, 0);
                        break;
                    case "U":
                        font.currentFrame = new Point(41, 0);
                        break;
                    case "v":
                        font.currentFrame = new Point(42, 0);
                        break;
                    case "V":
                        font.currentFrame = new Point(43, 0);
                        break;
                    case "w":
                        font.currentFrame = new Point(44, 0);
                        break;
                    case "W":
                        font.currentFrame = new Point(45, 0);
                        break;
                    case "x":
                        font.currentFrame = new Point(46, 0);
                        break;
                    case "X":
                        font.currentFrame = new Point(47, 0);
                        break;
                    case "y":
                        font.currentFrame = new Point(48, 0);
                        break;
                    case "Y":
                        font.currentFrame = new Point(49, 0);
                        break;
                    case "z":
                        font.currentFrame = new Point(50, 0);
                        break;
                    case "Z":
                        font.currentFrame = new Point(51, 0);
                        break;
                    case " ":
                        font.currentFrame = new Point(0, 1);
                        break;
                    case ",":
                        font.currentFrame = new Point(1, 1);
                        break;
                    case ".":
                        font.currentFrame = new Point(2, 1);
                        break;
                    case ":":
                        font.currentFrame = new Point(3, 1);
                        break;
                    case "0":
                        font.currentFrame = new Point(0, 2);
                        break;
                    case "1":
                        font.currentFrame = new Point(1, 2);
                        break;
                    case "2":
                        font.currentFrame = new Point(2, 2);
                        break;
                    case "3":
                        font.currentFrame = new Point(3, 2);
                        break;
                    case "4":
                        font.currentFrame = new Point(4, 2);
                        break;
                    case "5":
                        font.currentFrame = new Point(5, 2);
                        break;
                    case "6":
                        font.currentFrame = new Point(6, 2);
                        break;
                    case "7":
                        font.currentFrame = new Point(7, 2);
                        break;
                    case "8":
                        font.currentFrame = new Point(8, 2);
                        break;
                    case "9":
                        font.currentFrame = new Point(9, 2);
                        break;
                    case "á":
                        font.currentFrame = new Point(0, 3);
                        break;
                    case "Á":
                        font.currentFrame = new Point(1, 3);
                        break;
                    case "é":
                        font.currentFrame = new Point(2, 3);
                        break;
                    case "É":
                        font.currentFrame = new Point(3, 3);
                        break;
                    case "í":
                        font.currentFrame = new Point(4, 3);
                        break;
                    case "Í":
                        font.currentFrame = new Point(5, 3);
                        break;
                    case "ó":
                        font.currentFrame = new Point(6, 3);
                        break;
                    case "Ó":
                        font.currentFrame = new Point(7, 3);
                        break;
                    case "ú":
                        font.currentFrame = new Point(8, 3);
                        break;
                    case "Ú":
                        font.currentFrame = new Point(9, 3);
                        break;
                }

                font.Draw();

                currentPosition.X += (glyphDimensions.X + kerning) * scale;
            }

            font.position = position;
        }

        public void Draw()
        {
            drawString(text);
        }
        public void Draw(string textToDraw)
        {
            drawString(textToDraw);
        }

        public int MeasureString()
        {
            return (int)((glyphDimensions.X * text.Length) + (kerning * text.Length-1)) * 2;
        }
    }
}
