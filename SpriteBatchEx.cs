using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LineBatch
{
    /// <summary>
    /// Contains extension methods of the spritebatch class to draw lines.
    /// </summary>
    static class SpriteBatchEx
    {
        /// <summary>
        /// Draws a single line. 
        /// Require SpriteBatch.Begin() and SpriteBatch.End()
        /// </summary>
        /// <param name="begin">Begin point.</param>
        /// <param name="end">End point.</param>
        /// <param name="color">The color.</param>
        /// <param name="width">The width.</param>
        public static void DrawLine(this SpriteBatch spriteBatch, Vector2 begin, Vector2 end, Color color, int width = 1)
        {
            Rectangle r = new Rectangle((int)begin.X, (int)begin.Y, (int)(end - begin).Length() + width, width);
            Vector2 v = Vector2.Normalize(begin - end);
            float angle = (float)Math.Acos(Vector2.Dot(v, -Vector2.UnitX));
            if (begin.Y > end.Y) angle = MathHelper.TwoPi - angle;
            spriteBatch.Draw(TexGen.White, r, null, color, angle, Vector2.Zero, SpriteEffects.None, 0);
        }

        /// <summary>
        /// Draws a single line. 
        /// Doesn't require SpriteBatch.Begin() or SpriteBatch.End()
        /// </summary>
        /// <param name="begin">Begin point.</param>
        /// <param name="end">End point.</param>
        /// <param name="color">The color.</param>
        /// <param name="width">The width.</param>
        public static void DrawSingleLine(this SpriteBatch spriteBatch, Vector2 begin, Vector2 end, Color color, int width = 1)
        {
            //spriteBatch.Begin();
            spriteBatch.DrawLine(begin, end, color, width);
            //spriteBatch.End();
        }

        public static void DrawRectangle(this SpriteBatch spriteBatch, Vector2 begin, int rectWidth, int rectHeight, Color color, int width = 1)
        {
            //spriteBatch.Begin();
            Vector2 topRight = begin;
            topRight.X += rectWidth;
            Vector2 bottomRight = topRight;
            bottomRight.Y += rectHeight;
            Vector2 bottomLeft = begin;
            bottomLeft.Y += rectHeight;
            spriteBatch.DrawLine(begin, topRight - new Vector2(width, 0), color, width);
            spriteBatch.DrawLine(topRight, bottomRight - new Vector2(0, width), color, width);
            spriteBatch.DrawLine(bottomRight, bottomLeft + new Vector2(width, 0), color, width);
            spriteBatch.DrawLine(bottomLeft, begin + new Vector2(0, width), color, width);
            //spriteBatch.End();
        }

        public static void DrawRectangle(this SpriteBatch spriteBatch, Point begin, int rectWidth, int rectHeight, Color color, int width = 1)
        {
            DrawRectangle(spriteBatch, new Vector2(begin.X, begin.Y), rectWidth, rectHeight, color, width);
        }

        public static void DrawRectangle(this SpriteBatch spriteBatch, Rectangle rectangle, Color color, int width = 1)
        {
            spriteBatch.DrawLine(new Vector2(rectangle.Left, rectangle.Top), new Vector2(rectangle.Right, rectangle.Top), color, width);
            spriteBatch.DrawLine(new Vector2(rectangle.Right, rectangle.Top), new Vector2(rectangle.Right, rectangle.Bottom), color, width);
            spriteBatch.DrawLine(new Vector2(rectangle.Left, rectangle.Bottom), new Vector2(rectangle.Right, rectangle.Bottom), color, width);
            spriteBatch.DrawLine(new Vector2(rectangle.Left, rectangle.Top), new Vector2(rectangle.Left, rectangle.Bottom), color, width);
        }

        public static void DrawRectangleOutOfDraw(this SpriteBatch spriteBatch, Rectangle rectangle, Color color, int width = 1)
        {
            spriteBatch.Begin();
            spriteBatch.DrawLine(new Vector2(rectangle.Left, rectangle.Top), new Vector2(rectangle.Right, rectangle.Top), color, width);
            spriteBatch.DrawLine(new Vector2(rectangle.Right, rectangle.Top), new Vector2(rectangle.Right, rectangle.Bottom), color, width);
            spriteBatch.DrawLine(new Vector2(rectangle.Left, rectangle.Bottom), new Vector2(rectangle.Right, rectangle.Bottom), color, width);
            spriteBatch.DrawLine(new Vector2(rectangle.Left, rectangle.Top), new Vector2(rectangle.Left, rectangle.Bottom), color, width);
            spriteBatch.End();
        }

        public static void DrawFilledRectangle(this SpriteBatch spriteBatch, Vector2 begin, int rectWidth, int rectHeight, Color borderColour, Color fillColour, int width = 1)
        {
            Rectangle rect = new Rectangle((int)begin.X, (int)begin.Y, rectWidth, rectHeight);
            spriteBatch.Draw(TexGen.White, rect, fillColour);
            DrawRectangle(spriteBatch, begin, rectWidth, rectHeight, borderColour, width);
        }

        public static void DrawFilledRectangle(this SpriteBatch spriteBatch, Rectangle rect, Color borderColour, Color fillColour, int width = 1)
        {
            spriteBatch.Draw(TexGen.White, rect, fillColour);
            Vector2 point = new Vector2(rect.X, rect.Y);
            DrawRectangle(spriteBatch, point, rect.Width, rect.Height, borderColour, width);
        }

        public static void DrawFilledRectangleFromCentre(this SpriteBatch spriteBatch, Vector2 centrePoint, int rectWidth, int rectHeight, Color borderColour, Color fillColour, int width = 1)
        {
            Rectangle rect = new Rectangle((int)centrePoint.X - (rectWidth/2), (int)centrePoint.Y - (rectHeight / 2), rectWidth, rectHeight);
            spriteBatch.Draw(TexGen.White, rect, fillColour);
            DrawRectangle(spriteBatch, rect.Location, rectWidth, rectHeight, borderColour, width);
        }

        /// <summary>
        /// Draws a poly line.
        /// Doesn't require SpriteBatch.Begin() or SpriteBatch.End()
        /// <param name="points">The points.</param>
        /// <param name="color">The color.</param>
        /// <param name="width">The width.</param>
        /// <param name="closed">Whether the shape should be closed.</param>
        public static void DrawPolyLine(this SpriteBatch spriteBatch, Vector2[] points, Color color, int width = 1, bool closed = false)
        {
            //spriteBatch.Begin();
            for (int i = 0; i < points.Length - 1; i++)
                spriteBatch.DrawLine(points[i], points[i + 1], color, width);
            if (closed)
                spriteBatch.DrawLine(points[points.Length - 1], points[0], color, width);
            //spriteBatch.End();
        }


        public static void DrawCircle(this SpriteBatch spriteBatch, Vector2 centre, float radius, Color color, int width = 1, int segments = 32)
        {
            Vector2[] vertex = new Vector2[segments];

            double increment = Math.PI * 2.0 / segments;
            double theta = 0.0;

            for (int i = 0; i < segments; i++)
            {
                vertex[i] = centre + radius * new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                theta += increment;
            }

            DrawPolyLine(spriteBatch, vertex, color, width, true);
        }

        /// <summary>
        /// The graphics device, set this before drawing lines
        /// </summary>
        public static GraphicsDevice GraphicsDevice;

        /// <summary>
        /// Generates a 1 pixel white texture used to draw lines.
        /// </summary>
        static class TexGen
        {
            static Texture2D white = null;
            /// <summary>
            /// Returns a single pixel white texture, if it doesn't exist, it creates one
            /// </summary>
            /// <exception cref="System.Exception">Please set the SpriteBatchEx.GraphicsDevice to your graphicsdevice before drawing lines.</exception>
            public static Texture2D White
            {
                get
                {
                    if (white == null)
                    {
                        if (SpriteBatchEx.GraphicsDevice == null)
                            throw new Exception("Please set the SpriteBatchEx.GraphicsDevice to your GraphicsDevice before drawing lines.");
                        white = new Texture2D(SpriteBatchEx.GraphicsDevice, 1, 1);
                        Color[] color = new Color[1];
                        color[0] = Color.White;
                        white.SetData<Color>(color);
                    }
                    return white;
                }
            }
        }
    }
}
