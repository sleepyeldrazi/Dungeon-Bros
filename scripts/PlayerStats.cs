using Godot;
using System;

public class PlayerStats : Node2D
{
		
	private int hp = 100;
	private int mp = 100;
	private int coins = 0;

	public override void _Ready()
	{
		World env = (World)GetNode("/root/World");
		//TODO: FIX THIS ABOMINATION
		//env.getUILayer().GetChild<Control>(0).GetChild<Label>(0).Text = "HP: " + hp;
	}


	
	//Getters and Setters
	public void setHP(int num){
		hp = num;
	}
	
	public int getHP(){
		return hp;
	}
	
	

}
