using Godot;
using System;

public class World : Node2D
{
	private PackedScene battleDialog = (PackedScene)GD.Load("res://scenes/BattleDialog.tscn");
	private CanvasLayer uiLayer = new CanvasLayer();
	private Node player;
	private PlayerStats plStats;
	private Node orc;
	private OrcStats orcStats;
	private GUI gui;
	Popup battle;
	

	public override void _Ready()
	{
			player = GD.Load<PackedScene>("res://scenes/Player.tscn").Instance();
			orc = GD.Load<PackedScene>("res://scenes/Orc.tscn").Instance();
			var envVariables = GetNode("/root/EnvVariables");
			var charStats = GD.Load<PackedScene>("res://scenes/GUI.tscn").Instance();
			plStats = player.GetChild<PlayerStats>(0);
			orcStats = orc.GetChild<OrcStats>(0);
			battle = (Popup)battleDialog.Instance();
			
			uiLayer.AddChild(charStats);
			AddChild(player);
			AddChild(orc);
			AddChild(uiLayer);
			
			gui = uiLayer.GetChild<GUI>(0);
	}

	public CanvasLayer getUILayer(){
		return uiLayer;
	}
	
	public void startBattle(){
		uiLayer.GetChild<GUI>(0).Hide();
		uiLayer.AddChild(battle);
		envVariables.setIsMovementAllowed(false);
		battle.PopupCentered();
	}
	
	public void endBattle(){
		if(orcStats.getHP() <=0 && plStats.getHP() > 0) {
			GD.Print("You win!");
			plStats.setCoins(orcStats.getCoinReward());
			battle.Hide();
			RemoveChild(GetNode("Orc"));
			uiLayer.GetChild<GUI>(0).Show();
		} else if (plStats.getHP() <=0) {
			GetTree().ReloadCurrentScene();
			GetTree().ChangeScene("res://scenes/Dead.tscn");
		}
		gui.updateStats();
		envVariables.setIsMovementAllowed(true);
	}

}
