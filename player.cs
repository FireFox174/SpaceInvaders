using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Sprites;
using System;
using System.Collections.Generic;

namespace SpaceInvaders
{
	
	class Player : Entity
	{
		public Player()
		{
			assets.Add("player");
			Type = "player";
            Vector2 = new Vector2(500, 625);
            Transform = new Transform2(Vector2);
            Images = new List<Texture2D>();
            Rect = GetRectangle;
            Circle = GetCircle;
        }


		public override void Update(GameTime gameTime, EntityGroup entities = null)
		{ 
			float[] movement = { 0, 0 };
			base.Update(gameTime);
			var Kstate = Keyboard.GetState();
			if (Kstate.IsKeyDown(Keys.Left) && Vector2.X >= 32) { movement[0] = 1; }
			else { movement[0] = 0; }
			if (Kstate.IsKeyDown(Keys.Right) && Vector2.X <= 868) { movement[1] = 1; }
			else { movement[1] = 0; }
			Velocity.X += ((movement[1] - movement[0]) * 17);
			if (entities != null && entities.List.Count <= 2 && Keyboard.HasBeenPressed(Keys.Space))
			{
				entities.Add(new Bullet(Type, Vector2.X + Images[0].Width / 2, Vector2.Y));
				Console.WriteLine("bzz");
			}
		}
	}
}