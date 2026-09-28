using Godot;
using System;

public partial class guy : CharacterBody2D
{
	public const float Speed = 400.0f;
	public const float JumpVelocity = -700.0f;
	
	[Export] 
	public AnimatedSprite2D Sprite;
	
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("move up") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("move left", "move right", "move up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("move left"))
		{
			Sprite.FlipH = true;
		}
		else if (Input.IsActionPressed("move right"))
		{
			Sprite.FlipH = false;
		}
	}
}
