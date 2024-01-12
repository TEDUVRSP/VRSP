using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordInput : MonoBehaviour
{
    private TMP_InputField _inputField;
    [SerializeField] private GameObject inputField;
    [SerializeField] private GameObject desktopPanel;

    private void Start()
    {
        _inputField = inputField.GetComponent<TMP_InputField>();
    }

    public void ChangePanel()
    {
        if (_inputField.text.Equals("Stacy.2016")) 
        {
            gameObject.SetActive(false);
            desktopPanel.SetActive(true);
        }
    }
}
