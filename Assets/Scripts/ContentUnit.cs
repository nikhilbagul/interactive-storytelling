using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContentUnit
{
    public int UnitID;
    public Sprite background;
    public string titleText;
    public Choice choiceA, choiceB;

    public ContentUnit(int newUnitID, Sprite newImage, string newtitleText, Choice newChoiceA, Choice newChoiceB)
    {
        UnitID = newUnitID;
        background = newImage;
        titleText = newtitleText;
        choiceA = newChoiceA;

        if (newChoiceB !=null)
        {
            choiceB = newChoiceB;
        }

        
        
    }

    public ContentUnit(int newUnitID)
    {
        UnitID = newUnitID;
    }
   
}

public class Choice
{
    public string choiceText;
    public int nextUnitID;

    public Choice(string newText, int newNextUnitID)
    {
        choiceText = newText;
        nextUnitID = newNextUnitID;
    }
}
