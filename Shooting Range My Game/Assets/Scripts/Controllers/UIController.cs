using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Tap To Start")]
    public GameObject PanelTapToStart;

    [Header("In Game Panel")]
    public GameObject PanelInGame;
    public GameObject Cursor;
    public TextMeshProUGUI TextLevel;
    public TextMeshProUGUI Magazine;

    public static UIController instance;
    GameController GC;
    Transform Player;
    int level;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartMethods();
    }

    void StartMethods()
    {
        GC = GameController.instance;
        GetLevel();
        ShowTapToStartPanel();
    }

    void GetLevel()
    {
        level = GC.level;
    }

    void ShowTapToStartPanel()
    {
        PanelTapToStart.SetActive(true);
    }

    void CloseTapToStart()
    {
        PanelTapToStart.SetActive(false);
    }

    public void ButtonActionTapToStart()
    {
        CloseTapToStart();
        EventManager.Start();
        ShowInGamePanel();
    }

    void ShowInGamePanel()
    {
        PanelInGame.SetActive(true);
        FillTextLevel();
    }

    void FillTextLevel()
    {
        TextLevel.text = level.ToString();
    }

    void CloseInGamePanel()
    {
        PanelInGame.SetActive(false);
    }

    public void UpdateMagazine(string updateMagazine)
    {
        Magazine.text = updateMagazine;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
}
