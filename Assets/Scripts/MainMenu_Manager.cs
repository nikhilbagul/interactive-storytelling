using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class MainMenu_Manager : MonoBehaviour {

    public delegate void LoadLoadingScreenEvent();
    public static event LoadLoadingScreenEvent loadScreenSequenceCall;

    [SerializeField]
    private Image mainMenuBG, mainMenuplayButton, mainMenuexitButton, mainMenuTitle;
    [SerializeField]
    private CanvasGroup mainMenuCanvas;
    [SerializeField]
    private Transform Title_goToTransform, Title_transform, Title_offScreenPosition;

    private Sequence MainMenuFadeSequence;

    void OnEnable()
    {
        loadScreenSequenceCall += MainMenu_fadeOut;
        PauseMenu_Manager.loadMainMenuCall += FetchMainMenu;
    }


    void OnDisable()
    {
        PauseMenu_Manager.loadMainMenuCall -= FetchMainMenu;
        loadScreenSequenceCall -= MainMenu_fadeOut;
    }

    void Start()
    {
        FetchMainMenu();
    }

    void FetchMainMenu()
    {
        mainMenuTitle.color = new Color(255, 255, 255, 1.0f);
        MainMenuFadeSequence = DOTween.Sequence();
        MainMenuFadeSequence.Insert(0.0f, mainMenuBG.DOFade(1.0f, 0.4f));
        MainMenuFadeSequence.Insert(0.0f, Title_transform.DOMove(new Vector3(Title_goToTransform.position.x, Title_goToTransform.position.y, Title_goToTransform.position.z), 0.75f));
        MainMenuFadeSequence.Insert(0.0f, mainMenuplayButton.DOFade(1.0f, 0.4f));
        MainMenuFadeSequence.Insert(0.0f, mainMenuexitButton.DOFade(1.0f, 0.4f)).OnComplete(enableMainMenuInputs);
    }

    public void onPlayClick()
    {
        disableMainMenuInputs();
        print("play clicked !!");
        if (loadScreenSequenceCall != null)
        {
            loadScreenSequenceCall();
        }
        
    }

    void MainMenu_fadeOut()
    {
            MainMenuFadeSequence = DOTween.Sequence();
            MainMenuFadeSequence.Insert(0.0f, mainMenuBG.DOFade(0.0f, 0.4f));
            MainMenuFadeSequence.Insert(0.0f, mainMenuTitle.DOFade(0.0f, 0.4f));
            MainMenuFadeSequence.Insert(0.0f, mainMenuplayButton.DOFade(0.0f, 0.4f));
            MainMenuFadeSequence.Insert(0.0f, mainMenuexitButton.DOFade(0.0f, 0.4f));
            MainMenuFadeSequence.Insert(0.0f, Title_transform.DOMove(new Vector3(Title_offScreenPosition.position.x, Title_offScreenPosition.position.y, Title_offScreenPosition.position.z), 0.75f));
    }

    void disableMainMenuInputs()
    {
        mainMenuCanvas.blocksRaycasts = false;
    }

    void enableMainMenuInputs()
    {
        mainMenuCanvas.blocksRaycasts = true;        
    }




}
