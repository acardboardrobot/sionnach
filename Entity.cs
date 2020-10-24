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
    public class Entity
    {
        public Rectangle collisionRectangle;
        public Sprite sprite;
        public Vector2 currentPosition;
        public Vector2 targetPosition;
        public Vector2 direction;
        public bool collidable;
        protected Vector2 origin;
        public bool disposed;

        public virtual void Draw() { }
        public virtual void Update() { }
        public virtual void Update(GameTime gameTime, List<Entity> collisionList) { }

        public virtual void Dispose()
        {
            sprite.texture.Dispose();
            disposed = true;
        }
    }
}
