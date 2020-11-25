using Godot;
using System;

public class OrcStats : Node2D
{
	private int hp = 100;
	
	public override void _Ready()
	{
		
	}

	//Setters and Getters
	public void setHP(int num){
		hp = num;
	}
	
	public int getHP(){
		return hp;
	}
	

}
