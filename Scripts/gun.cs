using Godot;
using System;

public partial class gun : Area2D // Detects things in it's radius using it's collison detector
{
	private static readonly PackedScene BULLET = ResourceLoader.Load<PackedScene>("res://Scenes/bullet.tscn");
	private Marker2D shootingPoint;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		shootingPoint = GetNode<Marker2D>("WeaponPivot/Pistol/ShootingPoint");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		var enemiesInRange = GetOverlappingBodies();

		if(enemiesInRange.Count > 0) 
		{
			var targetEnemy = enemiesInRange[0];
			LookAt(targetEnemy.GlobalPosition);
		}
	}

	private void Shoot() {
		Area2D newBullet = (Area2D)BULLET.Instantiate();
		newBullet.GlobalPosition = shootingPoint.GlobalPosition;
		newBullet.GlobalRotation = shootingPoint.GlobalRotation;
		shootingPoint.AddChild(newBullet);
	}

	private void _on_timer_timeout()
	{
		Shoot();
	}

}


