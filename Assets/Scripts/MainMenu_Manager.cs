using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Audio;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu_Manager : MonoBehaviour {

    public delegate void LoadLoadingScreenEvent();
    public static event LoadLoadingScreenEvent loadScreenSequenceCall;

    public AudioMixerSnapshot noSirens;
    public AudioMixerSnapshot muffledSirens;
    public AudioMixerSnapshot DisableMainMenuAudio;
    public AudioSource muffledSirens_audioSource;
    private int elapsedTime, clip_startTime;

    [SerializeField]
    private Image mainMenuBG, mainMenuplayButton, mainMenuexitButton, mainMenuTitle;
    [SerializeField]
    private CanvasGroup mainMenuCanvas;
    [SerializeField]
    private Transform Title_goToTransform, Title_transform, Title_offScreenPosition;
    private bool disableMainMenu;
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
        disableMainMenu = false;
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

        disableMainMenu = true;
        DisableMainMenuAudio.TransitionTo(2.0f);
    }

    public void onQuitClick()
    {
        print("quitting game !!");
        Application.Quit();

        disableMainMenu = true;
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
        StartCoroutine(SnapshotSwitcher());    
    }

    //Audio manager section begins
    public IEnumerator SnapshotSwitcher()
    {
        while(!disableMainMenu)
        {
            elapsedTime = (int)Time.time;
            if (elapsedTime % 17 == 0 && !muffledSirens_audioSource.isPlaying)
            {
                    clip_startTime = elapsedTime;
                    muffledSirens_audioSource.Play();
                    muffledSirens.TransitionTo(3.0f);
                    //print(muffledSirens_audioSource.clip.length);
                    print(clip_startTime);
                             
            }

            if (elapsedTime == clip_startTime + 12)
            {
                noSirens.TransitionTo(2.0f);
            }
            yield return null;
        }       
    }
  
    
    



}
