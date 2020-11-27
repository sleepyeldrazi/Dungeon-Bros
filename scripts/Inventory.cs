using Godot;
using System;

public class Inventory : Popup
{

	public GUI gui;
	public World world;
		
	public override void _Ready()
	{
		world = (World)GetNode("/root/World");

	}


	private void _on_Close_pressed()
	{
		gui = world.getGUI();
		gui.closeInv();
	}

}



