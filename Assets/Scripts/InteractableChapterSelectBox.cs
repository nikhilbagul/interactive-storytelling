using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractableChapterSelectBox : MonoBehaviour {


    public Image ChapterThumbnail_hoverstate;
    public Text ChapterName_Text;
    
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
        ChapterName_Text.color = new Color(ChapterName_Text.color.r, ChapterName_Text.color.g, ChapterName_Text.color.b, 0.75f);
    }

    public void onChapterThumbnailExit()
    {
        ChapterThumbnail_hoverstate.color = new Color(ChapterThumbnail_hoverstate.color.r, ChapterThumbnail_hoverstate.color.g, ChapterThumbnail_hoverstate.color.b, 0);
        ChapterName_Text.color = new Color(ChapterName_Text.color.r, ChapterName_Text.color.g, ChapterName_Text.color.b, 0.0f);
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
