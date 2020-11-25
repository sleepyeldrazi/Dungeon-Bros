using Godot;
using System;

public class GUI : Control
{
	public PlayerStats player1;
	public OrcStats orc;
	public Label hp;
	public Label mp;
	public Label coins;
	
	
	public override void _Ready()
	{
		player1 = (PlayerStats)GetNode("/root/World/Player/PlayerStats");
		orc = (OrcStats)GetNode("/root/World/Orc/OrcStats");
		hp = (Label)GetNode("HP");
		hp.Text = "HP: " + player1.getHP();
	}



}
