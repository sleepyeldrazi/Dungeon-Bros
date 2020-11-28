using Godot;
using System;

public class Inventory : Popup
{

	public GUI gui;
	public World world;
		
	public override void _Ready()
	{
		var envVariables = GetNode("/root/EnvVariables");
		world = (World)GetNode("/root/World");

	}


	private void _on_Close_pressed()
	{
		envVariables.setIsMovementAllowed(true);
		gui = world.getGUI();
		gui.closeInv();
	}

}



