using Godot;
using System;

public class Movement : Area2D
{
	[Export] public int speed = 200;
	[Export] public int tileSize = 64;
	
	public Vector2 target = new Vector2();
	public Vector2 velocity = new Vector2();
	public RayCast2D ray;
	public float offsetX;
	public float offsetY;
	public int steps = 0;



	public override void _Ready(){
		Position = Position.Snapped(Vector2.One * tileSize) + new Vector2(64,64);
		Position += Vector2.One * tileSize/2;
		ray = (RayCast2D)GetNode("RayCast2D");
	}



	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("click"))
		{
			GD.Print("Start: " + Position);
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
			GD.Print("  End: " + Position);
		}
	}

/*	public override void _PhysicsProcess(float delta)
	{
		velocity = Position.DirectionTo(target) * speed;
		
		// LookAt(target);
		if (Position.DistanceTo(target) > 5)
		{
			velocity = MoveAndSlide(velocity);
		}
	}*/
	
	public void move(Vector2 dir){
		ray.CastTo = dir * 10;
		ray.ForceRaycastUpdate();
		if (!ray.IsColliding()){
			Position += dir * tileSize;
		}
	}
	
/*	
onready var ray = $RayCast2D

func move(dir):
	ray.cast_to = inputs[dir] * tile_size
	ray.force_raycast_update()
	if !ray.is_colliding():
		position += inputs[dir] * tile_size



	public bool isMoving(){
		return (velocity != Vector2.Zero);
	}
	
	public override void _PhysicsProcess(float delta){
		if (!isMoving()) return;
		if (steps == 64) {
			velocity = new Vector2(0,0);
			steps = 0;
			GD.Print(Position);
		}
		MoveAndSlide(velocity);
		steps++;
	}*/
}
