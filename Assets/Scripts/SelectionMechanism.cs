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
    

    void Start()
    {

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
        activeContentUnit = PopulateStoryGraph.StoryGraph[0];                    // Initialises the First Content Unit to Display
        //currentUnitID = activeContentUnit.UnitID;
        refObj.displayContentUnit(activeContentUnit);
    }

    
    public void userChoiceAHandler()                                             //Input Management
    {
             
        contentUnit_canvasgroup.blocksRaycasts = false;                         
        activeContentUnit = PopulateStoryGraph.StoryGraph[activeContentUnit.choiceA.nextUnitID];
        refObj.displayContentUnit(activeContentUnit);
    }

    public void userChoiceBHandler()
    {
        activeContentUnit = PopulateStoryGraph.StoryGraph[activeContentUnit.choiceB.nextUnitID];
        refObj.displayContentUnit(activeContentUnit);
    }

    public void userTitleClickHandler()
    {

    }

    public void userLevelSelect()
    {
        
    }

}
