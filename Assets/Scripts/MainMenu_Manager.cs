using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class MainMenu_Manager : MonoBehaviour {

    public delegate void LoadLoadingScreenEvent();
    public static event LoadLoadingScreenEvent loadScreenSequenceCall;
    public Image mainMenuBG, playButton, exitButton;
    public CanvasGroup mainMenuCanvas;

    void OnEnable()
    {
        loadScreenSequenceCall += MainMenu_fadeOut;
    }


    void OnDisable()
    {
        loadScreenSequenceCall -= MainMenu_fadeOut;
    }

    public void onPlayClick()
    {
        print("play clicked !!");
        if (loadScreenSequenceCall != null)
        {
            loadScreenSequenceCall();
        }
        
    }

    void MainMenu_fadeOut()
    {
        mainMenuCanvas.interactable = false;
        mainMenuBG.DOFade(0.0f, 0.4f);
        playButton.DOFade(0.0f, 0.4f);
        exitButton.DOFade(0.0f, 0.4f).OnComplete(disableMainMenu);
    }

    void disableMainMenu()
    {
        mainMenuCanvas.alpha = 0;
    }


}
