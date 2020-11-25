using Godot;
using System;

public class envVariables : Node2D
{
	private static bool actionTaken = false;
	private static bool isMovementAllowed = true;

	public override void _Ready()
	{
		
	}

	public static bool getActionTaken(){
		return actionTaken;
	}
	
	public static void setActionTaken(bool action){
		actionTaken = action;
	}

		public static bool getIsMovementAllowed(){
		return isMovementAllowed;
	}
	
	public static void setIsMovementAllowed(bool action){
		isMovementAllowed = action;
	}
}
