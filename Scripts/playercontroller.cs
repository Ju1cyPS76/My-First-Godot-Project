using Godot;
using System;
using System.IO;

public partial class playercontroller : CharacterBody2D
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		PlayerMovement();
	}

	private void PlayerMovement() 
	{
		Node happyBoo = GetNode("HappyBoo");

		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		this.Velocity = direction * 600; // Adding the += operation will make the player slippery
		MoveAndSlide(); // Useful because it deals with collisions

		if (Velocity.Length() > 0) 
		{
			happyBoo.GetNode<AnimationPlayer>("AnimationPlayer").Play("walk");

		} else 
		{
			happyBoo.GetNode<AnimationPlayer>("AnimationPlayer").Play("idle");	
		}
	}
}
