using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUI : MonoBehaviour
{
    public Transform optionUI;
    public void ClickOption()
    {
        optionUI.gameObject.SetActive(!optionUI.gameObject.activeSelf);
    }

    public void ClickGameExit()
    {
        Application.Quit();
    }
}
