using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class Bullet : Entity
    {
        public string owner; 

        public Bullet(string a, float x, float y)
        {
            assets.Add("bullet");
            Type = "bullet";
            Vector2 = new Vector2(x, y);
            Transform = new Transform2(Vector2);
            Images = new List<Texture2D>();
            Rect = GetRectangle;
            Circle = GetCircle;
        }

        public override void Update(GameTime gameTime, EntityGroup entities = null)
        {
            base.Update(gameTime, entities);
            if (owner == "player")
            {
                Velocity.Y -= 2;
            }

            if (entities != null)
            {
                foreach (Entity entity in entities.List)
                {
                    if (Rect.Intersects(entity.Circle) || Rect.Intersects(entity.Circle) && entity.Type != owner)
                    {
                        Kill(this);
                        Kill(entity);
                    }
                }
            }
        }
    }
}
