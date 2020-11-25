using Godot;
using System;

public class PlayerMovement : Area2D
{
	[Export] public int tileSize = 64;
	public float offsetX;
	public float offsetY;

	
	//TODO: don't like this
	public Vector2 target = new Vector2();
	public Vector2 velocity = new Vector2();
	public RayCast2D ray;

	
	//Init
	public override void _Ready(){
		Position = Position.Snapped(Vector2.One * tileSize) + new Vector2(64,64);
		Position += Vector2.One * tileSize/2;
		ray = (RayCast2D)GetNode("PlayerRay");
		var envVariables = GetNode("/root/EnvVariables");

	}


	//Input event handling
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("click") && envVariables.getIsMovementAllowed())
		{
			envVariables.setActionTaken(true);
			target = GetGlobalMousePosition();
			offsetX = Position.x - target.x;
			offsetY = Position.y - target.y;
			if(Math.Abs(offsetX) > Math.Abs(offsetY)){
				if(offsetX > 0){
					velocity= Vector2.Left;
				} else {
					velocity = Vector2.Right;
				}
			} else {
				if(offsetY > 0){
					velocity = Vector2.Up;
				} else {
					velocity = Vector2.Down;
				}
			}
			move(velocity);
		}
	}
	

	
	//Extra functions
	public void move(Vector2 dir){
		ray.CastTo = dir * 32;
		ray.ForceRaycastUpdate();
		if (!ray.IsColliding()){
			Position += dir * tileSize;
		}
	}
	
}
