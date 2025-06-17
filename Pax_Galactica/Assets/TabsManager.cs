using UnityEngine;
using UnityEngine.UI;

public class TabsManager : MonoBehaviour
{
    public GameObject[] Tabs;
    public Image[] Buttons;
    public Sprite InactiveTabBG, ActiveTabBG;
    public Vector2 InactiveTabSize, ActiveTabSize;
    public float InactiveTabPos, ActiveTabPos;

    public void SwitchToTab(int tabId)
    {
        foreach (var tab in Tabs) { 
            tab.SetActive(false);
        }
        Tabs[tabId].SetActive(true);
        foreach (var but in Buttons) { 
            but.sprite = InactiveTabBG;
            but.rectTransform.sizeDelta = InactiveTabSize;
            but.rectTransform.anchoredPosition = new Vector2(
                but.rectTransform.anchoredPosition.x,
                InactiveTabPos
            );
        }
        Buttons[tabId].sprite = ActiveTabBG;
        Buttons[tabId].rectTransform.sizeDelta = ActiveTabSize;
        Buttons[tabId].rectTransform.anchoredPosition = new Vector2(Buttons[tabId].rectTransform.anchoredPosition.x, ActiveTabPos);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
