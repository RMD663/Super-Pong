using UnityEngine;
using System;

public class ResetButton : MonoBehaviour
{
    public static Action ResetPreferences;
    private String PrefKey => "67";
    
    public void OnReset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        
        ResetPreferences?.Invoke();
    }
}
