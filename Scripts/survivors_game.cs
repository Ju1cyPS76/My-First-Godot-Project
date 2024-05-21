using Godot;
using System;

public partial class survivors_game : Node2D
{
	private PackedScene mob;
	private PathFollow2D spawnPath;
	private CanvasLayer gameOverScreen;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		mob = ResourceLoader.Load<PackedScene>("res://Scenes/mob.tscn");
		spawnPath = GetNode<PathFollow2D>("Player/Path2D/PathFollow2D");
		gameOverScreen = GetNode<CanvasLayer>("GameOver");
	}

	private void SpawnMob() 
	{
		CharacterBody2D newMob = (CharacterBody2D)mob.Instantiate();
		spawnPath.ProgressRatio = GD.Randf();
		newMob.GlobalPosition = spawnPath.GlobalPosition;
		AddChild(newMob);
	}

	private void _on_timer_timeout()
	{
		GD.Print("Spawn");
		SpawnMob();
	}

	private void _on_player_health_depleted()
	{
		gameOverScreen.Visible = true;
		GetTree().Paused = true;
	}
}
