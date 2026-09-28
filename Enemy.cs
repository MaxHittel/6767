using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	[Export]
	public float Speed = 100.0f;

	[Export]
	public CharacterBody2D Player;

	public override void _PhysicsProcess(double delta)
	{
		if (Player == null)
		{
			GD.Print("Player is not assigned!");
			return;
		}

		Vector2 direction = GlobalPosition.DirectionTo(Player.GlobalPosition);

		Velocity = direction * Speed;
		MoveAndSlide();
	}
}
