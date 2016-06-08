using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractableChapterSelectBox : MonoBehaviour {


    public Image ChapterThumbnail_hoverstate;
    
    public delegate void StartSelectionMechanism();
    public static event StartSelectionMechanism loadChapterContentsCall;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onChapterThumbnailEnter()
    {
        ChapterThumbnail_hoverstate.color = new Color(ChapterThumbnail_hoverstate.color.r, ChapterThumbnail_hoverstate.color.g, ChapterThumbnail_hoverstate.color.b, 1);
    }

    public void onChapterThumbnailExit()
    {
        ChapterThumbnail_hoverstate.color = new Color(ChapterThumbnail_hoverstate.color.r, ChapterThumbnail_hoverstate.color.g, ChapterThumbnail_hoverstate.color.b, 0);
    }

    public void onChapterThumbnailClick()
    {
        print("Chapter requested !!");
        if (loadChapterContentsCall != null)
        {
            loadChapterContentsCall();
        }
    }

    
}
