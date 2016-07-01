using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContentUnit
{
    public int UnitID;
    public Sprite background;
    public string titleText;
    public string supporting_text;
    public Choice choiceA, choiceB;
    public Location locationInfo;
    public string timeStamp;
    public AudioClip contentunit_audioclip;

    public ContentUnit(int newUnitID, Sprite newImage, string newtitleText, string newSupporting_text, Choice newChoiceA, Choice newChoiceB, Location newlocationInfo, string newTimeStamp)
    {
        UnitID = newUnitID;
        background = newImage;
        titleText = newtitleText;
        supporting_text = newSupporting_text;
        choiceA = newChoiceA;
        timeStamp = newTimeStamp;

        if (newChoiceB != null)
        {
            choiceB = newChoiceB;
        }

        if (newlocationInfo != null)
        {
            locationInfo = newlocationInfo;
        }

    }

    public ContentUnit(AudioClip audioclip)
    {
        if(null != audioclip)
        {
            contentunit_audioclip = audioclip;
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

public class Location
{
    public string place, address, city;

    public Location(string newplace, string newaddress, string newcity)
    {
        place = newplace;
        address = newaddress;
        city = newcity;
    }

    
}
