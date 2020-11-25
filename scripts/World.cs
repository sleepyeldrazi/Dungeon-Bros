using Godot;
using System;

public class World : Node2D
{
	private PackedScene battleDialog = (PackedScene)GD.Load("res://scenes/BattleDialog.tscn");
	private CanvasLayer uiLayer = new CanvasLayer();

	public override void _Ready()
	{
			var player = GD.Load<PackedScene>("res://scenes/Player.tscn").Instance();
			var orc = GD.Load<PackedScene>("res://scenes/Orc.tscn").Instance();
			var envVariables = GetNode("/root/EnvVariables");
			var charStats = GD.Load<PackedScene>("res://scenes/GUI.tscn").Instance();
			uiLayer.AddChild(charStats);
			AddChild(player);
			AddChild(orc);
			AddChild(uiLayer);

	}


	public CanvasLayer getUILayer(){
		return uiLayer;
	}
	public void startBattle(){
		Popup battle = (Popup)battleDialog.Instance();
		uiLayer.AddChild(battle);
		//envVariables.setIsMovementAllowed(false);
		battle.PopupCentered();
	}

}
