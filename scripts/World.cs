using Godot;
using System;

public class World : Node2D
{
	private PackedScene battleDialog = (PackedScene)GD.Load("res://scenes/BattleDialog.tscn");
	private CanvasLayer uiLayer = new CanvasLayer();
	Popup battle;
	

	public override void _Ready()
	{
			var player = GD.Load<PackedScene>("res://scenes/Player.tscn").Instance();
			var orc = GD.Load<PackedScene>("res://scenes/Orc.tscn").Instance();
			var envVariables = GetNode("/root/EnvVariables");
			var charStats = GD.Load<PackedScene>("res://scenes/GUI.tscn").Instance();
			battle = (Popup)battleDialog.Instance();
			uiLayer.AddChild(charStats);
			AddChild(player);
			AddChild(orc);
			AddChild(uiLayer);
	}


	public CanvasLayer getUILayer(){
		return uiLayer;
	}
	public void startBattle(){
		uiLayer.AddChild(battle);
		envVariables.setIsMovementAllowed(false);
		battle.PopupCentered();
	}
	
	public void endBattle(){
		if(GetNode("Orc").GetChild<OrcStats>(0).getHP() <=0){
			GD.Print("You win!");
			battle.Hide();
			envVariables.setIsMovementAllowed(true);
			RemoveChild(GetNode("Orc"));
		} 
	}

}
