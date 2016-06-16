using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class LoadingScreenManager : MonoBehaviour {

    public Transform ChapterThumbnail_transform;
    public Transform ChapterThumbnail_goToTransform;
    public Image loadingScreenBG, ChapterThumbnail;
    public Image loadingBar1, loadingBar2, loadingBar3;
    public Image ChapterThumbnail_hoverstate;
    public CanvasGroup LoadingScreenCanvas;

    private Sequence loadingScreenSequence;   
    

    void OnEnable()
    {
        MainMenu_Manager.loadScreenSequenceCall += loadScreenFadeInSequenceHandler;
        InteractableChapterSelectBox.loadChapterContentsCall += loadingScreen_fadeOut;
    }


    void OnDisable()
    {
        MainMenu_Manager.loadScreenSequenceCall -= loadScreenFadeInSequenceHandler;
        InteractableChapterSelectBox.loadChapterContentsCall -= loadingScreen_fadeOut;
    }


    void loadScreenFadeInSequenceHandler()
    {
        //print(cutsceneBox_transform.localPosition);
        loadingScreenSequence = DOTween.Sequence();
        loadingScreenSequence.Insert(0.0f, loadingScreenBG.DOFade(1.0f, 0.5f));
        loadingScreenSequence.Insert(0.5f, ChapterThumbnail_transform.DOMove(new Vector3(ChapterThumbnail_goToTransform.position.x, ChapterThumbnail_goToTransform.position.y, ChapterThumbnail_goToTransform.position.z), 0.75f));
        loadingScreenSequence.Insert(1.0f, ChapterThumbnail.DOFade(1.0f, 1.0f)).OnComplete(fillLoadingBar);
    }    

    void fillLoadingBar()
    {
        loadingBar3.DOFade(1.0f, 0.5f);
        loadingBar1.DOFillAmount(1.0f, 5.0f);
        loadingBar2.DOFillAmount(1.0f, 5.0f).OnComplete(activateHoverStateAnimation);
    }

    void activateHoverStateAnimation()
    {
        ChapterThumbnail_hoverstate.DOFade(1.0f, 0.5f).OnComplete(deactivateHoverStateAnimation);
    }

    void deactivateHoverStateAnimation()
    {
        ChapterThumbnail_hoverstate.DOFade(0.0f, 0.5f);
        LoadingScreenCanvas.blocksRaycasts = true;
    }

    void loadingScreen_fadeOut()
    {
        loadingScreenBG.DOFade(0.0f, 0.4f);
        ChapterThumbnail.DOFade(0.0f, 0.4f);
        ChapterThumbnail_hoverstate.DOFade(0.0f, 0.4f);
        loadingBar2.DOFillAmount(0.0f, 0.2f);
        loadingBar1.DOFillAmount(0.0f, 0.2f);
        loadingBar3.DOFade(0.0f, 0.4f).OnComplete(disableLoadingScreenInputs);
    }

    void disableLoadingScreenInputs()
    {
        LoadingScreenCanvas.blocksRaycasts = false;
    }

}
