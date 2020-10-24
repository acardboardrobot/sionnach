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
    public class Sprite
    {
        public StateManager stateManager;
        public SpriteBatch spriteBatch;
        public Texture2D texture;
        public Point frameSize;
        public Point currentFrame;

        public Vector2 position;
        public bool shouldDraw = true;
        public float alpha = 1.0f;
        public SpriteEffects spriteEffect = SpriteEffects.None;
        public Rectangle drawRectangle = new Rectangle(0, 0, 0, 0);
        public Color drawColour = Color.White;
        public float scale = 1.0f;
        public float rotation = 0.0f;
        public Vector2 origin = new Vector2(0, 0);
        public float zDepth = 0.0f;
        public Point frameOffset = new Point(0, 0);

        public Sprite(StateManager StateManager, Texture2D Texture, Vector2 Position, Point FrameSize, Point CurrentFrame)
        {
            stateManager = StateManager;
            texture = Texture;
            position = Position;
            frameSize = FrameSize;
            currentFrame = CurrentFrame;

            spriteBatch = stateManager.spriteBatch;
            centreOrigin();
        }

        public Sprite(SpriteBatch SpriteBatch, Texture2D Texture, Vector2 Position, Point FrameSize, Point CurrentFrame)
        {
            texture = Texture;
            position = Position;
            frameSize = FrameSize;
            currentFrame = CurrentFrame;

            spriteBatch = SpriteBatch;
            centreOrigin();
        }

        public void centreOrigin()
        {
            origin.X = frameSize.X / 2;
            origin.Y = frameSize.Y / 2;
        }

        public virtual void Draw()
        {
            if (shouldDraw)
            {
                drawRectangle.Width = frameSize.X;
                drawRectangle.Height = frameSize.Y;
                drawRectangle.X = (frameSize.X * currentFrame.X) + frameOffset.X;
                drawRectangle.Y = (frameSize.Y * currentFrame.Y) + frameOffset.Y;
                spriteBatch.Draw(texture, position, drawRectangle, drawColour * alpha, rotation, origin, scale, spriteEffect, zDepth);
            }
        }
    }
}
