using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class EntityGroup : Entity
    {
        public List<Entity> List;

        public EntityGroup()
        {
            List = new List<Entity>();
        }

        public virtual void Add(Entity entity)
        {
            List.Add(entity);
        }

        public virtual void Remove(Entity entity)
        {
            List.Remove(entity);
        }

        public virtual Entity Get(int id)
        {
            return List[id];
        }

        public virtual void LoadContent(ContentManager content)
        {
            foreach (Entity entity in List.ToList())
            {
                entity.LoadContent(content);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (Entity entity in List.ToList())
            {
                if (entity.Dead)
                {
                    List.Remove(entity);
                }
                entity.Update(gameTime, this);
                entity.Transform = Transform;
            }
        }

        public new void Draw(SpriteBatch surface)
        {
            foreach (Entity entity in List.ToList())
            {
                entity.Draw(surface);
            }
        }
    }


    public static class Keyboard
    {
        static KeyboardState currentKeyState;
        static KeyboardState previousKeyState;

        public static KeyboardState GetState()
        {
            previousKeyState = currentKeyState;
            currentKeyState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            return currentKeyState;
        }

        public static bool IsPressed(Keys key)
        {
            return currentKeyState.IsKeyDown(key);
        }

        public static bool HasBeenPressed(Keys key)
        {
            return currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key);
        }
    }
}

