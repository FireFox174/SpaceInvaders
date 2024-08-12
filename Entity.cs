using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SpaceInvaders
{

	public abstract class Entity
	{
		public List<Texture2D> Images;

		public List<SoundEffect> SoundEffects;

		public List<string> assets = new List<string>();

		public List<string> assetType;

		public Sprite sprite;

		public Transform2 Transform;

		public Vector2 Vector2;
        
		public Vector2 Velocity = new();

        public RectangleF Rect;

		public CircleF Circle;

		public Color color = Color.White;

		public ContentManager Content;

		public bool Dead = false;

		public string Type;

		public RectangleF GetRectangle
		{
			get { return new RectangleF(Vector2, Transform.Scale); }
		}

		public CircleF GetCircle
		{
			get { return new CircleF(Vector2, (Transform.Scale.X + Transform.Scale.Y) / 2); }
		}

		public void Kill(Entity entity)
		{
			entity.Dead = true;
			entity.Rect = Rectangle.Empty;
			entity.Circle = Rectangle.Empty;
		}

		public Entity()
		{
			Vector2 = new Vector2();
			Transform = new Transform2(Vector2);
			Images = new List<Texture2D>();
            Rect = GetRectangle;
			Circle = GetCircle;
		}


		public virtual void LoadContent(ContentManager content)
		{
			Content = content;
			if (Content != null)
			{
				foreach (string asset in assets)
				{
					try
					{
						Images.Add(Content.Load<Texture2D>(asset));
					}
					catch (Exception ex)
					{
						try
						{
							SoundEffects.Add(Content.Load<SoundEffect>(asset));
						}
						catch (Exception e) 
						{
							Debug.WriteLine(e);
						}

						Debug.WriteLine(ex);
					}

					if (Images != null && Images.Count > 0) sprite = new Sprite(Images[0]);
				}
			}
		}


		public virtual void Update(GameTime gameTime, EntityGroup entities = null)
		{
			int DeltaTime = gameTime.ElapsedGameTime.Milliseconds;
			Vector2.X += Velocity.X / 110 * DeltaTime;
			Vector2.Y += Velocity.Y / 110 * DeltaTime;
			Velocity.X /= 5;
			Velocity.Y /= 5;
		}

		public virtual void Draw(SpriteBatch Surface)
		{
			Surface.Begin();
			if (sprite != null) Surface.Draw(sprite, Vector2, 0.0f);
			Surface.End();
		}
	}
}