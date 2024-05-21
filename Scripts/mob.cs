using Godot;
using System;

public partial class mob : CharacterBody2D
{
	private CharacterBody2D player;
	private AnimationPlayer mobAnimate;
	private PackedScene explosion;
	private int health = 3;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<CharacterBody2D>("/root/Game/Player/PlayerBody");
		mobAnimate = GetNode<AnimationPlayer>("Slime/AnimationPlayer");
		explosion = ResourceLoader.Load<PackedScene>("res://smoke_explosion/smoke_explosion.tscn");
		mobAnimate.Play("walk");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 playerPosition = player.GlobalPosition;
		Vector2 direction = GlobalPosition.DirectionTo(playerPosition);

		Velocity = direction * 300;
		MoveAndSlide();
	}

	public void TakeDamage() 
	{
		health -= 1;
		mobAnimate.Play("hurt");

		if (health == 0) {
			QueueFree();

			Node2D smoke = (Node2D)explosion.Instantiate();
			GetParent().AddChild(smoke);
			smoke.GlobalPosition = GlobalPosition;
		}
	}
}
