﻿public class Program
{ 
	public static void Main(string[] args)
	{
		using var game = new SpaceInvaders.Game1();
		game.Run();
	}
}