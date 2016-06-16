using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class PauseMenu_Manager : MonoBehaviour {

    public Blur_MOD mainCamera_blur;
    [SerializeField]
    private CanvasGroup pauseMenu_canvas, mainChapter_canvas, locationInfo_canvas;
    [SerializeField]
    private Canvas mainChapter;
    [SerializeField]
    private Image resume_button, quit_toDesktop_button;
    private bool isPaused;


    public delegate void LoadMainMenuEvent();
    public static event LoadMainMenuEvent loadMainMenuCall;
    //public delegate void GlobalPauseEvent();
    //public static event GlobalPauseEvent globalPauseEventCall;

    void OnEnable()
    {
        loadMainMenuCall += quitToMenu;        
    }


    void OnDisable()
    {
        loadMainMenuCall -= quitToMenu;
    }

    // Use this for initialization
    void Start ()
    {
        isPaused = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            print("Escape Pressed during Pause");

            mainCamera_blur.enabled = false;            
            resume_button.DOFade(0.0f, 0.3f);
            quit_toDesktop_button.DOFade(0.0f, 0.5f).OnComplete(enablePauseMenuFlag);
            
        }


        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused && mainChapter_canvas.blocksRaycasts)
        {
            print("Escape Pressed");
            
            mainCamera_blur.enabled = true;               
            resume_button.DOFade(1.0f, 0.3f);
            quit_toDesktop_button.DOFade(1.0f, 0.5f).OnComplete(disablePauseMenuFlag);
        }

    }
    void enablePauseMenuFlag()
    {
        pauseMenu_canvas.blocksRaycasts = false;
        mainChapter_canvas.blocksRaycasts = true;
        isPaused = false;
    }

    void disablePauseMenuFlag()
    {
        pauseMenu_canvas.blocksRaycasts = true;
        mainChapter_canvas.blocksRaycasts = false;
        isPaused = true;
    }

    public void onResume()  
    {
        mainCamera_blur.enabled = false;
        pauseMenu_canvas.blocksRaycasts = false;
        mainChapter_canvas.blocksRaycasts = true;
        resume_button.color = new Color(resume_button.color.r, resume_button.color.g, resume_button.color.b, 0.0f);
        quit_toDesktop_button.color = new Color(quit_toDesktop_button.color.r, quit_toDesktop_button.color.g, quit_toDesktop_button.color.b, 0.0f);
        isPaused = false;
    }

    public void onQuitClicked()
    {
        print("quit clicked !!");
        if (loadMainMenuCall != null)
        {
            loadMainMenuCall();
        }
    }

    public void quitToMenu()
    {
        mainCamera_blur.enabled = false;
        pauseMenu_canvas.blocksRaycasts = false;
        mainChapter_canvas.blocksRaycasts = false;
        resume_button.color = new Color(resume_button.color.r, resume_button.color.g, resume_button.color.b, 0.0f);
        quit_toDesktop_button.color = new Color(quit_toDesktop_button.color.r, quit_toDesktop_button.color.g, quit_toDesktop_button.color.b, 0.0f);

        locationInfo_canvas.DOFade(0.0f, 0.5f);
        mainChapter_canvas.DOFade(0.0f, 0.5f);
    }

    



}
