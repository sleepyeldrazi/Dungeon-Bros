using Godot;
using System;

public class GUI : Control
{
	public PlayerStats player1;
	public OrcStats orc;
	public Label hp;
	public Label mp;
	public Label coins;
	public World world;
	public Popup inv;
	
	
	public override void _Ready()
	{
		world = (World)GetNode("/root/World");
		player1 = (PlayerStats)GetNode("/root/World/Player/PlayerStats");
		orc = (OrcStats)GetNode("/root/World/Orc/OrcStats");
		hp = (Label)GetNode("HP");	
		mp = (Label)GetNode("MP");	
		coins = (Label)GetNode("Coins");
		inv = world.getInv();
		var envVariables = GetNode("/root/EnvVariables");
		
		updateStats();
	}
	
	public void updateStats(){
		hp.Text = "HP: " + player1.getHP();
		mp.Text = "MP: " + player1.getMP();
		coins.Text = "Coins: " + player1.getCoins();
	}


	private void _on_Inventory_pressed()
	{
 		envVariables.setIsMovementAllowed(false);
		inv.PopupCentered();
		
	}
	
	public void closeInv()
	{
		inv.Hide();
		
	}
}


