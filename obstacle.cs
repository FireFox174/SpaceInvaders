using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SpaceInvaders
{
    class Obstacle
    {
        public List<Barrier> barriers;
        public bool Dead;

        int[] makeRow01 = { 0, 00, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 00, 00 };
        int[] makeRow02 = { 0, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 00 };
        int[] makeRow03 = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80 };
        int[] makeRow04 = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80 };
        int[] makeRow05 = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80 };
        int[] makeRow06 = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80 };
        int[] makeRow07 = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80 };
        int[] makeRow08 = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80 };
        int[] makeRow09 = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80 };
        int[] makeRow10 = { 5, 10, 15, 20, 00, 00, 00, 00, 00, 00, 00, 00, 65, 70, 75, 80 };
        int[] makeRow11 = { 5, 10, 15, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 70, 75, 80 };

        List<int[]> barrierCreator;

        public Obstacle(ContentManager Content, int x, int y)
        {
            barriers = new List<Barrier>();
            barrierCreator = new List<int[]>();
            barrierCreator.Add(makeRow01);
            barrierCreator.Add(makeRow02);
            barrierCreator.Add(makeRow03);
            barrierCreator.Add(makeRow04);
            barrierCreator.Add(makeRow05);
            barrierCreator.Add(makeRow06);
            barrierCreator.Add(makeRow07);
            barrierCreator.Add(makeRow08);
            barrierCreator.Add(makeRow09);
            barrierCreator.Add(makeRow10);
            barrierCreator.Add(makeRow11);

            int rowNumber = 0;

            foreach (int[] row in barrierCreator)
            {
                rowNumber++;

                foreach (int item in row)
                {
                    if (item != 0)
                    {
                        barriers.Add(new Barrier(Content, x, y, item, (rowNumber * 5)));
                    }
                }
            }
        }

        public void LoadContent(ContentManager content)
        {
            foreach (Barrier item in barriers)
            {
                item.LoadContent(content);
            }
        }

        public void Update(GameTime gameTime, Entity[] entities)
        {
            foreach (Barrier barrier in barriers.ToList())
            {
                if (barrier.Dead) barriers.Remove(barrier);
                else barrier.Update(gameTime);
                if (barriers.Count == 0) Dead = true;

                foreach (Entity entity in entities.ToList())
                {
                    if (barrier.Rect.Intersects(entity.Rect) && entity.Type == "bullet_player")
                    {
                        barrier.Kill(barrier);
                        entity.Dead = true;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Barrier barrier in barriers.ToList())
            {
                barrier.Draw(spriteBatch);
            }
        }
    }
}
