using Godot;
using System;

public class OrcMovement : Area2D
{
[Export] public int tileSize = 64;
	

	//TODO: this needs to be better
	public Random rand;
	public Vector2[] dir;
	public RayCast2D ray;
	public World world;
	


	public override void _Ready(){
		rand = new Random();
		Position = Position.Snapped(Vector2.One * tileSize) +new Vector2(64*rand.Next(3,19),64*rand.Next(3,9));
		Position += Vector2.One * tileSize/2;
		ray = (RayCast2D)GetNode("OrcRay");
		
		//TODO: need to figure out why i can't rename
		var envVariables = GetNode("/root/EnvVariables");
		world = (World)GetNode("/root/World");
		dir = new Vector2[] {Vector2.Left, Vector2.Right, Vector2.Up, Vector2.Down};

	}


	public override void _Input(InputEvent @event)
	{
		if (envVariables.getActionTaken() && envVariables.getIsMovementAllowed())
		{
			envVariables.setActionTaken(false);
			move(dir[rand.Next(4)]);
		}
	}

	public void _on_Area2D_area_entered(Area2D body){
		if (body.IsInGroup("Players")){
			world.startBattle();
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
