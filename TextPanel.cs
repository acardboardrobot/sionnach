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
using LineBatch;

namespace Sionnach
{
    class TextPanel
    {
        StateManager stateManager;
        SoundManager soundManager;
        SpriteBatch spriteBatch;
        public Rectangle rectangle; //the buttons background rectangle
        public Text text;           //the buttons foreground text
        public string id;
        public Point position;
        public Point size;

        int padding = 2;

        public Color upColor = new Color(44, 44, 44);
        public Color overColor = new Color(66, 66, 66);
        public Color downColor = new Color(100, 100, 100);
        public Color drawColor;     //points to one of the above colors
        public Color selectedColor; //points to one of the above colors
        public bool selected = false;
        public bool over = true;

        List<Text> lines;

        Texture2D buttonTexture, selectedTexture, normalTexture, imageTexture;

        public TextPanel()
        {

        }

        public TextPanel(StateManager stateMan, Rectangle elementToAnchorTo, Utilities.ItemAnchor anchorPoint, Point Size, string stringToShow, int Padding = 6)
        {
            stateManager = stateMan;
            spriteBatch = stateManager.spriteBatch;

            size = Size;
            padding = Padding;

            position = elementToAnchorTo.Center;
            position.X -= (elementToAnchorTo.Width / 2);

            if (anchorPoint == Utilities.ItemAnchor.bottom)
            {
                position.Y += ((elementToAnchorTo.Height / 2) + padding);
            }
            else if (anchorPoint == Utilities.ItemAnchor.top)
            {
                position.Y -= ((elementToAnchorTo.Height / 2) + padding);
            }
            else if (anchorPoint == Utilities.ItemAnchor.left)
            {
                position.X -= ((elementToAnchorTo.Width / 2) + padding);
            }
            else if (anchorPoint == Utilities.ItemAnchor.right)
            {
                position.X += ((elementToAnchorTo.Width / 2) + padding);
            }

            rectangle = new Rectangle(position.X, position.Y, size.X, size.Y);

            createLines(stringToShow);

            layoutLines();
        }

        public void Draw()
        {
            SpriteBatchEx.DrawFilledRectangle(spriteBatch, rectangle, Color.White, Color.Gray);

            foreach (Text line in lines)
            {
                line.Draw();
            }
        }

        public void createLines(string input)
        {
            lines = new List<Text>();

            Text helperText = new Text(stateManager, "A", new Vector2(-500, -500));

            int widthInPixels = rectangle.Width - (padding * 5);
            int glyphWidth = helperText.MeasureString() + 1;
            int widthInGlyphs = (widthInPixels / glyphWidth) - 4;

            Console.WriteLine("width: {0}, {1}, {2}", widthInPixels, glyphWidth, widthInGlyphs);

            Console.WriteLine(input.Length);

            int lineStart = 0;
            int startOfWord = 0;

            string[] words = input.Split(' ');

            int currentLineLength = 0;
            string currentLine = "";

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                if (currentLineLength + word.Length > widthInGlyphs)
                {
                    currentLine = currentLine.TrimStart();
                    Text textToAdd = new Text(stateManager, currentLine, new Vector2(0, 0));
                    lines.Add(textToAdd);

                    currentLine = word;
                    currentLineLength = word.Length;
                    Console.WriteLine(currentLineLength);
                }
                else
                {
                    currentLine += " " + word;
                    currentLineLength += word.Length;
                }

                if (i == words.Length -1)
                {
                    currentLine = currentLine.TrimStart();
                    Text textToAdd = new Text(stateManager, currentLine, new Vector2(0, 0));
                    lines.Add(textToAdd);
                }
            }
        }

        public void createLines(List<string> strings)
        {
            lines = new List<Text>();

            Text helperText = new Text(stateManager, "A", new Vector2(-500, -500));

            int widthInPixels = rectangle.Width - (padding * 5);
            int glyphWidth = helperText.MeasureString() + 1;
            int widthInGlyphs = (widthInPixels / glyphWidth) - 4;

            Console.WriteLine("width: {0}, {1}, {2}", widthInPixels, glyphWidth, widthInGlyphs);

            int lineStart = 0;
            int startOfWord = 0;

            foreach (string s in strings)
            {
                string[] words = s.Split(' ');

                int currentLineLength = 0;
                string currentLine = "";

                for (int i = 0; i < words.Length; i++)
                {
                    string word = words[i];

                    if (currentLineLength + word.Length > widthInGlyphs)
                    {
                        currentLine = currentLine.TrimStart();
                        Text textToAdd = new Text(stateManager, currentLine, new Vector2(0, 0));
                        lines.Add(textToAdd);

                        currentLine = word;
                        currentLineLength = word.Length;
                        Console.WriteLine(currentLineLength);
                    }
                    else
                    {
                        currentLine += " " + word;
                        currentLineLength += word.Length;
                    }

                    if (i == words.Length - 1)
                    {
                        currentLine = currentLine.TrimStart();
                        Text textToAdd = new Text(stateManager, currentLine, new Vector2(0, 0));
                        lines.Add(textToAdd);
                    }
                }
            }

            
        }

        public void layoutLines()
        {
            Point textOffset = new Point(padding * 2, padding * 2);
            Point startPoint = position + textOffset;
            Console.WriteLine("{0} : {1}", startPoint, position);

            foreach (Text line in lines)
            {
                line.position = new Vector2(startPoint.X, startPoint.Y);
                startPoint.Y += (int)(line.glyphDimensions.Y * 2) + padding;
            }
        }

        public void changeText(string newText)
        {
            createLines(newText);
            layoutLines();
        }

        public void changeText(List<TrackingEvent> objectives)
        {
            string finalText = "";
            List<string> objectiveStrings = new List<string>();

            foreach (TrackingEvent e in objectives)
            {
                objectiveStrings.Add(e.unfinishedString);
            }

            createLines(objectiveStrings);
            layoutLines();
        }
    }
}
