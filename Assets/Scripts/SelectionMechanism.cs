using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class SelectionMechanism : MonoBehaviour
{
    public DisplayInterface refObj; 
    public ContentUnit activeContentUnit;
    public CanvasGroup contentUnit_canvasgroup;
    private int currentUnitID;

    public delegate void PostChoiceInputEvent();
    public static event PostChoiceInputEvent PostChoiceInputEventCall;

    void Start()
    {
        currentUnitID = 0;
    }

    void OnEnable()
    {
        InteractableChapterSelectBox.loadChapterContentsCall += StartSelectionMechanism;        
    }


    void OnDisable()
    {
        InteractableChapterSelectBox.loadChapterContentsCall -= StartSelectionMechanism;
    }

    void StartSelectionMechanism()
    {
        activeContentUnit = PopulateStoryGraph.StoryGraph[currentUnitID];                    // Initialises the First Content Unit to Display
        refObj.displayContentUnit(activeContentUnit);
    }

    
    public void userChoiceAHandler()                                             //Input Management
    {
             
        contentUnit_canvasgroup.blocksRaycasts = false;                         
        activeContentUnit = PopulateStoryGraph.StoryGraph[activeContentUnit.choiceA.nextUnitID];
        refObj.displayContentUnit(activeContentUnit);
        currentUnitID = activeContentUnit.UnitID;

        if (PostChoiceInputEventCall != null)
        {
            PostChoiceInputEventCall();
        }
    }

    public void userChoiceBHandler()
    {
        activeContentUnit = PopulateStoryGraph.StoryGraph[activeContentUnit.choiceB.nextUnitID];
        refObj.displayContentUnit(activeContentUnit);
        currentUnitID = activeContentUnit.UnitID;
        //print("current unit ID is : " + currentUnitID);

        if (PostChoiceInputEventCall != null)
        {
            PostChoiceInputEventCall();
        }
    }

    public void userTitleClickHandler()
    {

    }

    public void userLevelSelect()
    {
        
    }

}
