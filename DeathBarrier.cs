using Godot;

public partial class DeathBarrier : Area2D
{
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is guy)
		{
			GetTree().ReloadCurrentScene();
		}
	}
}
