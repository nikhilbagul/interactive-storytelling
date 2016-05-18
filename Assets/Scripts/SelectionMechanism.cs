using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectionMechanism : MonoBehaviour
{
    public DisplayInterface refObj; 
    public ContentUnit activeContentUnit;
    private int currentUnitID;
    

    void Start()
    {
        activeContentUnit = PopulateStoryGraph.StoryGraph[0];                    // Initialises the First Content Unit to Display
        currentUnitID = activeContentUnit.UnitID;
        refObj.displayContentUnit(activeContentUnit);
    }


    public void userChoiceAHandler()                                             //Input Management
    {
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

}
