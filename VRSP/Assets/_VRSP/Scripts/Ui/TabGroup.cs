using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    [SerializeField] private List<CTabButton> tabButtons;
    [SerializeField] private Sprite tabIdle;
    [SerializeField] private Sprite tabHover;
    [SerializeField] private Sprite tabActive;
    [SerializeField] private CTabButton selectedCTab;
    [SerializeField] private List<GameObject> objectsToSwap;
    [SerializeField] private float pushDown = 6f;
    [SerializeField] private bool isFurniture;
    public void Subscribe(CTabButton button)
    {
        tabButtons ??= new List<CTabButton>();
        tabButtons.Add(button);
        foreach (var icon in button.icon)
        {
            var localPosition = icon.transform.localPosition;
            icon.pushedPosition = new Vector3(localPosition.x, localPosition.y - pushDown, localPosition.z);
        }
    }

    public void OnTabEnter(CTabButton button)
    {
        ResetTabs();

        if (selectedCTab==null || button != selectedCTab)
        {
            button.background.sprite = tabHover;
        }
    }
    public void OnTabExit(CTabButton button)
    {
        ResetTabs();
    }
    public void OnTabSelected(CTabButton button)
    {
        foreach (var icon in button.icon)
        {
            icon.MoveDown();
        }        
        selectedCTab= button;
        ResetTabs();
        button.background.sprite = tabActive;
        
        if (isFurniture)
        {
            foreach (var cTabButton in tabButtons)
            {
                if (cTabButton != selectedCTab)
                {
                    cTabButton.background.color = new Color(0.5f,0.5f,0.5f,1f);
                    cTabButton.GetComponent<Image>().color = new Color(0.5f,0.5f,0.5f,1f);
                    cTabButton.transform.GetChild(0).GetComponent<Image>().color = new Color(0.5f,0.5f,0.5f,1f);
                }else
                {
                    cTabButton.background.color = new Color(1f,1f,1f,1f);
                    cTabButton.GetComponent<Image>().color = new Color(1f,1f,1f,1f);
                    cTabButton.transform.GetChild(0).GetComponent<Image>().color = new Color(1f,1f,1f,1f);
                }
            }
            
            
        }
        else
        {
            int index = button.transform.GetSiblingIndex();
            for (int i = 0; i < objectsToSwap.Count; i++)
            {
                if (i==index)
                {
                    objectsToSwap[i].SetActive(true);
                }
                else
                {
                    objectsToSwap[i].SetActive(false);
                }
            }
        }
    }
    public void ResetTabs()
    {
        foreach (var button in tabButtons)
        {
            if (selectedCTab != null && button == selectedCTab) continue;
            foreach (var icon in button.icon)
            {
                icon.MoveUp();
            }
            button.background.sprite = tabIdle;
        }
    }
}
