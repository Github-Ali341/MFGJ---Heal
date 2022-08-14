using UnityEngine;
using System.Collections.Generic;

public class TabsGroup : MonoBehaviour
{
    [SerializeField] private List<TabButton> tabs;
    [SerializeField] private List<GameObject> objectsToSwap;

    [SerializeField] private Color idleColor;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color activeColor;

    private TabButton _selectedTab;

    private void OnEnable ()
    {
        OnTabSelected(tabs[0]);
    }

    public void Subscribe (TabButton tab)
    {
        if (tabs == null) tabs = new List<TabButton>();
        tabs.Add(tab);
    }

    public void OnTabEnter (TabButton tab)
    {
        ResetTabs();

        if (_selectedTab != null && _selectedTab == tab) return;

        tab.SetBGColor(hoverColor);
    }

    public void OnTabExit (TabButton tab)
    {
        ResetTabs();
    }

    public void OnTabSelected (TabButton tab)
    {
        _selectedTab = tab;
        ResetTabs();
        tab.SetBGColor(activeColor);
        int index = tab.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++)
        {
            objectsToSwap[i].SetActive(i == index);
        }
    }

    public void ResetTabs ()
    {
        foreach (TabButton tabButton in tabs)
        {
            if (_selectedTab != null && _selectedTab == tabButton) continue;
            tabButton.SetBGColor(idleColor);
        }
    }
}
