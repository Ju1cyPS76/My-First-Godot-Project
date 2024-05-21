using Godot;
using System;

public partial class playerreceiver : Node2D
{
	[Signal]
	public delegate void HealthDepletedEventHandler();

	private float health = 100.0f;
	private Area2D playerHurtbox;
	private ProgressBar healthBar;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		playerHurtbox = GetNode<Area2D>("PlayerBody/Hurtbox");
		healthBar = GetNode<ProgressBar>("PlayerBody/ProgressBar");

		healthBar.Value = health;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		PlayerDamage(delta);
	}

	public void PlayerDamage(double delta) 
	{
		const float DAMAGE_RATE = 5.0f;
		var overlappingMobs = playerHurtbox.GetOverlappingBodies();

		if (overlappingMobs.Count > 0) 
		{
			health -= DAMAGE_RATE * overlappingMobs.Count * (float)delta;
			healthBar.Value = health;
			if (health <= 0.0f) 
			{
				EmitSignal(nameof(HealthDepleted));
			}
		}
	}
}
