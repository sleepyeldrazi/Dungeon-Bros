using Godot;
using System;

public class World : Node2D
{

	public override void _Ready()
	{
			
			var player = GD.Load<PackedScene>("res://scenes/Player.tscn").Instance();
			var orc = GD.Load<PackedScene>("res://scenes/Orc.tscn").Instance();
			AddChild(player);
			AddChild(orc);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
