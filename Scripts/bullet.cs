using Godot;
using System;

public partial class bullet : Area2D
{
	double traveledDistance;
	
	public override void _PhysicsProcess(double delta)
	{
		const float SPEED = 1000;
		const float RANGE = 1200;

		Vector2 direction = Vector2.Right.Rotated(Rotation);
		Position += direction * SPEED * (float)delta;

		traveledDistance += SPEED * (float)delta;
		if(traveledDistance > RANGE) 
		{
			QueueFree();
		}
	}

	private void _on_body_entered(Node2D body)
	{
		QueueFree(); // Waits one frame before deletion

		if(body.HasMethod("TakeDamage")) 
		{
			mob mob = (mob)body;
			mob.TakeDamage();
		}
	}
}
