using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class DisplayInterface : MonoBehaviour {

    public Image targetImage;
    public Text targetTitleText;
    public Text targetChoice_AText;
    public Text targetChoice_BText;
    public Text targetPlace, targetAddress, targetCity, targetTime;
    public CanvasGroup contentUnit_canvasgroup;
 

    private Sequence fadeComponents;


    [Range(1, 5)]
    public float lerpTime = 1f;
    float currentLerpTime;

    // Use this for initialization
    void Start ()
    {
        
        
    }
	
	public void displayContentUnit(ContentUnit activeContentUnitToDisplay)       //Fetch the Content from the current Content Unit to Display
    {

        print("Fade begins");
        fadeComponents = DOTween.Sequence();

        targetImage.sprite = activeContentUnitToDisplay.background;
        targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, 0);        //make the alpha of the new content unit: 0
        fadeComponents.Insert(0.0f, targetImage.DOFade(1.0f, 3f));                                              // add to fade sequence
        

        targetTitleText.text = activeContentUnitToDisplay.titleText;
        targetTitleText.color = new Color(targetTitleText.color.r, targetTitleText.color.g, targetTitleText.color.b, 0);   //make the alpha of the new content unit: 0
        fadeComponents.Insert(2.0f, targetTitleText.DOFade(1.0f, 3f));

        targetChoice_AText.text = activeContentUnitToDisplay.choiceA.choiceText;
        targetChoice_AText.color = new Color(targetChoice_AText.color.r, targetChoice_AText.color.g, targetChoice_AText.color.b, 0);   //make the alpha of the new content unit: 0
        fadeComponents.Insert(3.0f, targetChoice_AText.DOFade(1.0f, 3f));

        //Checks if the active Content unit has more than >2 choices
        if (activeContentUnitToDisplay.choiceB == null)
        {
            targetChoice_BText.transform.gameObject.SetActive(false);
            //StartCoroutine(Dialogue_Fader(false));
        }
        else
        {
            targetChoice_BText.transform.gameObject.SetActive(true);
            targetChoice_BText.text = activeContentUnitToDisplay.choiceB.choiceText;                
            targetChoice_BText.color = new Color(targetChoice_BText.color.r, targetChoice_BText.color.g, targetChoice_BText.color.b, 0);    //make the alpha of the new content unit: 0
            fadeComponents.Insert(4.0f, targetChoice_BText.DOFade(1.0f, 3f));
            //StartCoroutine(Dialogue_Fader(true));
        }


        if (activeContentUnitToDisplay.locationInfo == null)                    //checks if the current content unit has location info
        {
            targetPlace.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            targetPlace.transform.parent.gameObject.SetActive(true);                    //fetch the location info from the current content unit
            targetPlace.text = activeContentUnitToDisplay.locationInfo.place;
            targetAddress.text = activeContentUnitToDisplay.locationInfo.address;
            targetCity.text = activeContentUnitToDisplay.locationInfo.city;

            targetPlace.color = new Color(targetPlace.color.r, targetPlace.color.g, targetPlace.color.b, 0);
            targetAddress.color = new Color(targetAddress.color.r, targetAddress.color.g, targetAddress.color.b, 0);
            targetCity.color = new Color(targetCity.color.r, targetCity.color.g, targetCity.color.b, 0);

            fadeComponents.Insert(7.0f, targetPlace.DOFade(1.0f, 2f));
            fadeComponents.Insert(7.0f, targetAddress.DOFade(1.0f, 2f));
            fadeComponents.Insert(7.0f, targetCity.DOFade(1.0f, 2f));
            //StartCoroutine(LocationInfo_Fader());
        }

        if (activeContentUnitToDisplay.timeStamp.Equals(""))
        {
            targetTime.transform.gameObject.SetActive(false);
        }
        else
        {
            targetTime.transform.gameObject.SetActive(true);
            targetTime.text = activeContentUnitToDisplay.timeStamp;

            targetTime.color = new Color(targetTime.color.r, targetTime.color.g, targetTime.color.b, 0);
            fadeComponents.Insert(8.0f, targetTime.DOFade(1.0f, 2f));
        }

        fadeComponents.OnComplete(onFadeComplete);

    }

    
    public void onFadeComplete()
    {
        contentUnit_canvasgroup.blocksRaycasts = true;
        print("Fade complete");
        
    }
    



    /*
    public IEnumerator Dialogue_Fader(bool choiceB)                  //responsible for fading in current content unit's Image, Title text, Choices
    {
        currentLerpTime = 0;
        Debug.Log("Fader Coroutine started");
        float inverseLerpTime = 1 / lerpTime;

        while (targetImage.color.a<=1)
        {
            //increment timer once per frame
            currentLerpTime += Time.deltaTime;
            float perc = currentLerpTime * inverseLerpTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            targetImage.color = Color.Lerp(targetImage.color, new Color(255, 255, 255, 1), perc*Time.deltaTime);
            targetTitleText.color = Color.Lerp(targetTitleText.color, new Color(255, 255, 255, 1), perc * Time.deltaTime);
            targetChoice_AText.color = Color.Lerp(targetChoice_AText.color, new Color(255, 255, 255, 1), perc * Time.deltaTime);

            if (choiceB)
            {
                targetChoice_BText.color = Color.Lerp(targetChoice_BText.color, new Color(255, 255, 255, 1), perc * Time.deltaTime);
            }

            yield return null;
        }

        Debug.Log("Fade complete");
     }

    public IEnumerator LocationInfo_Fader()              //responsible for fading in current content unit's location info
    {
        currentLerpTime = 0;
        float inverseLerpTime = 1 / (lerpTime);

        while (targetCity.color.a < 1)
        {
            //increment timer once per frame
            currentLerpTime += Time.deltaTime;
            float perc = currentLerpTime * inverseLerpTime;
            if (currentLerpTime > (lerpTime))
            {
                currentLerpTime = (lerpTime);
            }

            targetPlace.color = Color.Lerp(targetPlace.color, new Color(212, 236, 255, 0.75f), perc * Time.deltaTime);
            targetAddress.color = Color.Lerp(targetAddress.color, new Color(212, 236, 255, 0.75f), perc * Time.deltaTime);
            targetCity.color = Color.Lerp(targetCity.color, new Color(212, 236, 255, 0.75f), perc * Time.deltaTime);

            yield return null;
        }

        Debug.Log("Fade complete");
    }

    
    */

}
