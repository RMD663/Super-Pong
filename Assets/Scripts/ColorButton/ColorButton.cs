using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    
    public static Action<GoalManager.TEAM, Color> ColorButtonPressed;
    
    [SerializeField]
    public GoalManager.TEAM team;
    
    private Button _button;
    private Color _color;

    private void Awake()
    {
        _button = GetComponent<Button>();

        if (_button == null)
        {
            Debug.LogError($"Missing image component on {gameObject.name}");
        } 
        
        _color = _button.colors.normalColor;
        
    }
    
    public void ChangeColor()
    {
        ColorButtonPressed?.Invoke(team, _color);
    }
}
