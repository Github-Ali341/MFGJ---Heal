using UnityEngine;
using System.Collections.Generic;

public class TabsGroup : MonoBehaviour
{
    [SerializeField] private List<Tab> tabs;
    [SerializeField] private List<GameObject> objectsToSwap;

    [SerializeField] private Color idleColor;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color activeColor;

    private Tab _selectedTab;

    private void OnEnable ()
    {
        OnTabSelected(tabs[0]);
    }

    public void Subscribe (Tab tab)
    {
        tabs ??= new List<Tab>();
        tabs.Add(tab);
    }

    public void OnTabEnter (Tab tab)
    {
        ResetTabs();

        if (_selectedTab != null && _selectedTab == tab) return;

        tab.SetBGColor(hoverColor);
    }

    public void OnTabExit (Tab tab)
    {
        ResetTabs();
    }

    public void OnTabSelected (Tab tab)
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
        foreach (Tab Tab in tabs)
        {
            if (_selectedTab != null && _selectedTab == Tab) continue;
            Tab.SetBGColor(idleColor);
        }
    }
}
