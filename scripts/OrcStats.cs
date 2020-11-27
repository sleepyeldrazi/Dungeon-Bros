using Godot;
using System;

public class OrcStats : Node2D
{
	private int hp = 100;
	private int str = 10;
	private int coins;
	private Random rand;
	
	public override void _Ready()
	{
		rand = new Random();
		coins = rand.Next(1, str+31);
	}

	public int attack(){
		return rand.Next(6)+str;
	}

	//Setters and Getters
	public void setHP(int num){
		hp = num;
	}
	
	public int getHP(){
		return hp;
	}
	
	public int getCoinReward(){
		return coins;
	}
	

}
