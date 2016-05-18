using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayInterface : MonoBehaviour {

    public Image targetImage;
    public Text targetTitleText;
    public Text targetChoice_AText;
    public Text targetChoice_BText;

    [Range(1, 5)]
    public float lerpTime = 1f;
    float currentLerpTime;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	public void displayContentUnit(ContentUnit activeContentUnitToDisplay)       //Fetch the Content from the current Content Unit to Display
    {
        targetImage.sprite = activeContentUnitToDisplay.background;
        targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, 0);        //make the alpha of the new content unit: 0

        targetTitleText.text = activeContentUnitToDisplay.titleText;
        targetTitleText.color = new Color(targetTitleText.color.r, targetTitleText.color.g, targetTitleText.color.b, 0);

        targetChoice_AText.text = activeContentUnitToDisplay.choiceA.choiceText;
        targetChoice_AText.color = new Color(targetChoice_AText.color.r, targetChoice_AText.color.g, targetChoice_AText.color.b, 0);

        //Checks if the active Content unit has more than >2 choices
        if (activeContentUnitToDisplay.choiceB == null)
        {
            targetChoice_BText.transform.gameObject.SetActive(false);
            StartCoroutine(Fader());
        }
        else
        {
            targetChoice_BText.transform.gameObject.SetActive(true);
            targetChoice_BText.text = activeContentUnitToDisplay.choiceB.choiceText;
            targetChoice_BText.color = new Color(targetChoice_BText.color.r, targetChoice_BText.color.g, targetChoice_BText.color.b, 0);
            StartCoroutine(Fader());
        }
    }


    public IEnumerator Fader()
    {
        currentLerpTime = 0;
        Debug.Log("Fader Coroutine started");
        float inverseLerpTime = 1 / lerpTime;

        while (targetImage.color.a<1)
        {
            //increment timer once per frame
            currentLerpTime += Time.deltaTime;
            float perc = currentLerpTime * inverseLerpTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            targetImage.color = Color.Lerp(targetImage.color, new Color(255, 255, 255, 1), perc*Time.deltaTime);

            yield return null;
        }

        Debug.Log("Fade complete");
    }




    }
