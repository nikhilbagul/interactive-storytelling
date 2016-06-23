using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class InteractableText : MonoBehaviour {

    private Text this_text;
    private Outline whiteGlow;
   
	// Use this for initialization
	void Start () {

        this_text = gameObject.GetComponent<Text>();
        whiteGlow = gameObject.GetComponent<Outline>();

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void increaseFontSize()
    {

        this_text.fontSize = 17;
        print("Mouse Over !!");

    }
    public void decreaseFontSize()
    {
        print("Mouse Exit !!");
        this_text.fontSize = 16;
    }

    public void enableGlow()
    {
        whiteGlow.effectColor = new Color(255, 255, 255, 0.25f);        
    }
    public void disableGlow()
    {
        whiteGlow.effectColor = new Color(255, 255, 255, 0.0f);
    }



}
