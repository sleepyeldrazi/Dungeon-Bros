using Godot;
using System;

public class PlayerStats : Node2D
{
		
	private int hp = 100;
	private int mp = 100;
	private int coins = 0;
	private int str = 10;
	private Random rand;

	public override void _Ready()
	{
		World env = (World)GetNode("/root/World");
		rand = new Random();
		//TODO: FIX THIS ABOMINATION
		//env.getUILayer().GetChild<Control>(0).GetChild<Label>(0).Text = "HP: " + hp;
	}


	public int attack(){
		return rand.Next(6)+str;
	}
	//Getters and Setters
	public void setHP(int num){
		hp = num;
	}
	
	public int getHP(){
		return hp;
	}
	
	
	public void setMP(int num){
		mp = num;
	}
	
	public int getMP(){
		return mp;
	}
	
	public void setCoins(int num){
		coins = num;
	}
	
	public int getCoins(){
		return coins;
	}
	

}
