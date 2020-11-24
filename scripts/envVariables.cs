using Godot;
using System;

public class envVariables : Node2D
{
	private static bool actionTaken = false;
	public override void _Ready()
	{
		
	}

	public static bool getActionTaken(){
		return actionTaken;
	}
	
	public static void setActionTaken(bool action){
		actionTaken = action;
	}
}
