using Godot;
using System;

public class Battle : Node2D
{
	public PlayerStats player1;
	public OrcStats orc;
	public Label player1HP;
	public Label orcHP;
	public Random rand;
	public World env;
	
	public override void _Ready()
	{
		rand = new Random();
		env = (World)GetNode("/root/World");
		player1 = (PlayerStats)GetNode("/root/World/Player/PlayerStats");
		orc = (OrcStats)GetNode("/root/World/Orc/OrcStats");
		player1HP = (Label)GetNode("Player1/Player1HP");
		player1HP.Text = "HP: " + player1.getHP();
		orcHP = (Label)GetNode("OrcHP");
		orcHP.Text = "HP: " + orc.getHP();
	}



	
	private void _on_Attack_pressed()
{
   		orc.setHP(orc.getHP()-(int)rand.Next(10));
		roundEnd();

}

	private void roundEnd(){
		orcHP.Text = "HP: " + orc.getHP();
		player1HP.Text = "HP: " + player1.getHP();
		
		env.endBattle();
	}


}




