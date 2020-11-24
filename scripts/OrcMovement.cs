using Godot;
using System;

public class OrcMovement : Area2D
{
[Export] public int tileSize = 64;
	
	public Vector2 target = new Vector2();
	public Vector2 velocity = new Vector2();
	public RayCast2D ray;
	public float offsetX;
	public float offsetY;
	public int steps = 0;
	public Random rand;
	public Vector2[] dir;
	


	public override void _Ready(){
		Position = Position.Snapped(Vector2.One * tileSize) + new Vector2(128,128);
		Position += Vector2.One * tileSize/2;
		ray = (RayCast2D)GetNode("OrcRay");
		
		var envVariables = GetNode("/root/EnvVariables");
		rand = new Random();
		
		dir = new Vector2[] {Vector2.Left, Vector2.Right, Vector2.Up, Vector2.Down};

	}


	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("click"))
		{
			envVariables.setActionTaken(false);
			move(dir[rand.Next(4)]);
		}
	}
	
	
	public void move(Vector2 dir){
		ray.CastTo = dir * 32;
		ray.ForceRaycastUpdate();
		if (!ray.IsColliding()){
			Position += dir * tileSize;
		}
	}
	
}
