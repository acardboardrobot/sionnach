using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sionnach
{
    public static class Utilities
    {

        public static int gameWindowWidth { get; set; }
        public static int gameWindowHeight { get; set; }

        public static int scrollSpeed { get; set; }

        public static int monitorWidth { get; set; }
        public static int monitorHeight { get; set; }

        public static resolutions resolution = resolutions.w1080x728;

        public enum resolutions { w800x600, w1080x728, w1280x720, w1920x1080 }

        public enum UILocationAnchor { topRight, topLeft}

        public enum ItemAnchor { top, bottom, left, right}

        public static int battlesFought = 0;
        public static int player1BattlesWon = 0;
        public static int player2BattlesWon = 0;
        public static int wintersPassed = 0;

        public static bool PointRectangleIntersection(Point point, Rectangle rectangle)
        {
            if (point.X >= rectangle.X && point.X <= (rectangle.X + rectangle.Width))
            {
                if (point.Y >= rectangle.Y && point.Y <= (rectangle.Y + rectangle.Height))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public static bool PointRectangleIntersection(Vector2 point, Rectangle rectangle)
        {
            if (point.X >= rectangle.X && point.X <= (rectangle.X + rectangle.Width))
            {
                if (point.Y >= rectangle.Y && point.Y <= (rectangle.Y + rectangle.Height))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public static bool RectangleRectangleIntersection(Rectangle rect1, Rectangle rect2)
        {
            if ((rect2.X + rect2.Width) >= rect1.X && (rect2.X) <= (rect1.X + rect1.Width))
            {
                if (((rect2.Y + rect2.Height) >= rect1.Y && (rect2.Y) <= (rect1.Y + rect1.Height)))
                {
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        public static Point Vector2ToPoint(Vector2 inVec)
        {
            Point returnPoint = new Point((int)inVec.X, (int)inVec.Y);
            return returnPoint;
        }

        public static Vector2 PointToVector2(Point inPoint)
        {
            Vector2 returnVec = new Vector2(inPoint.X, inPoint.Y);
            return returnVec;
        }

        public static float Distance(Point firstPoint, Point secondPoint)
        {
            float xDistance = firstPoint.X - secondPoint.X;
            float yDistance = firstPoint.Y - secondPoint.Y;

            float hypotenuseDistance = (float)Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));

            return hypotenuseDistance;
        }

        public static float Distance(Point firstPoint, Vector2 secondPoint)
        {
            float xDistance = firstPoint.X - secondPoint.X;
            float yDistance = firstPoint.Y - secondPoint.Y;

            float hypotenuseDistance = (float)Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));

            return hypotenuseDistance;
        }

        public static float Distance(Vector2 firstPoint, Point secondPoint)
        {
            float xDistance = firstPoint.X - secondPoint.X;
            float yDistance = firstPoint.Y - secondPoint.Y;

            float hypotenuseDistance = (float)Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));

            return hypotenuseDistance;
        }

        public static float Distance(Vector2 firstPoint, Vector2 secondPoint)
        {
            float xDistance = firstPoint.X - secondPoint.X;
            float yDistance = firstPoint.Y - secondPoint.Y;

            float hypotenuseDistance = (float)Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));

            return hypotenuseDistance;
        }
    }
    
    public class Line
    {
        Point startPoint, endPoint;
        public Line(Point sP, Point eP)
        {
            startPoint = sP;
            endPoint = eP;
        }

        public Vector2 startPointAsVector2()
        {
            Vector2 output = new Vector2(startPoint.X, startPoint.Y);
            return output;
        }

        public Vector2 endPointAsVector2()
        {
            Vector2 output = new Vector2(endPoint.X, endPoint.Y);
            return output;
        }
    }

    public enum titleStateState { intro, wait, outro }

    public struct GraphNode
    {
        public int id;
        public List<GraphNode> edges;
    }

    public struct resourceSnapshot
    {
        public int foodCount;
        public int stoneCount;
        public int woodCount;
        public int manaCount;
        public int population;
    }

    public struct Edge
    {
        public int firstId;
        public int secondId;
    }
}
