using System;
using UnityEngine;
using UnityEngine.UI;

public class PaddleColor : MonoBehaviour
{
    public PaddleData paddleData;
    public GoalManager.TEAM paddleTeam;
    
    private RawImage _paddleImage;

    private void Awake()
    {
        _paddleImage = GetComponent<RawImage>();
        if (_paddleImage == null)
        {
            Debug.LogError($"PaddleColor: No mesh renderer found in: {gameObject.name}");
        }
        _paddleImage.color = paddleData.PlayerColor;
    }

    void ChangeColor(GoalManager.TEAM team, Color color)
    {
       
        if(team == paddleTeam)
        {
            if (_paddleImage.color == color)
            {
                _paddleImage.color = Color.white;
            }
            else
            {
                _paddleImage.color = color;
            }
           
            paddleData.UpdateColor(color);
            
        }
        
    }
    
    private void OnEnable()
    {
        ColorButton.ColorButtonPressed += ChangeColor;
    }

    void OnDisable()
    {
        ColorButton.ColorButtonPressed -= ChangeColor;
    }
}
