using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvaders
{
    public class Barrier : Entity
    {

        public Barrier(ContentManager content, int x, int y, int a, int b)
        {
            Content = content;
            Vector2 = new Microsoft.Xna.Framework.Vector2((x + a), (y + b));
            assets.Add("barrier");
            Type = "barrier";
            Dead = false;
            color = Color.Cyan;
        }
    }
}
