using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPaddleData", menuName = "Custom/Paddle Data")]
public class PaddleData : ScriptableObject
{
    public MovementComponent.PLAYER Player;
    public Color PlayerColor;
    public String PaddleName;

    public void UpdateColor(Color color)
    {
        PlayerColor = color;
    }
    
    public void UpdateName(string newName)
    {
        PaddleName = newName;
        
        if(Player == MovementComponent.PLAYER.P1)
        {
            PlayerPrefs.SetString("PaddleOne", PaddleName);
        }
        else
        {
            PlayerPrefs.SetString("PaddleTwo", PaddleName);
        }
        
        PlayerPrefs.Save();
        
    }
}
