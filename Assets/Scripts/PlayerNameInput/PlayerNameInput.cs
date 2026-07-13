using System;
using TMPro;
using UnityEngine;

public class PlayerNameInput : MonoBehaviour
{
    public PaddleData PaddleData;
    
    private TMP_InputField _inputText;
    
    private void Start()
    {
        _inputText =  GetComponent<TMP_InputField>();
    }

    public void NameChanged()
    {
        PaddleData.UpdateName(_inputText.text);
    }
}
