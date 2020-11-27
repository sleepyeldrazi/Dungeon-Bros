using Godot;
using System;

public class Battle : Node2D
{
	public PlayerStats player1;
	public OrcStats orc;
	public Label player1HP;
	public Label orcHP;
	public Random rand;
	public World world;
	
	public override void _Ready()
	{
		rand = new Random();
		world = (World)GetNode("/root/World");
		player1 = (PlayerStats)GetNode("/root/World/Player/PlayerStats");
		orc = (OrcStats)GetNode("/root/World/Orc/OrcStats");
		player1HP = (Label)GetNode("Player1/Player1HP");
		player1HP.Text = "HP: " + player1.getHP();
		orcHP = (Label)GetNode("OrcHP");
		orcHP.Text = "HP: " + orc.getHP();
	}
	
	private void _on_Attack_pressed()
{
   		orc.setHP(orc.getHP()-player1.attack());
		if(orc.getHP() <= 0){
			world.endBattle();
		} else {
			player1.setHP(player1.getHP()-orc.attack());
		}
		roundEnd();
}

	private void roundEnd(){
		orcHP.Text = "HP: " + orc.getHP();
		player1HP.Text = "HP: " + player1.getHP();
		if(player1.getHP() <= 0){
			world.endBattle();
		}
	}


}




