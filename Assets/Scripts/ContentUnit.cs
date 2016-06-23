using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContentUnit
{
    public int UnitID;
    public Sprite background;
    public string titleText;
    public Choice choiceA, choiceB;
    public Location locationInfo;
    public string timeStamp;
    //public AudioClip audio_clip;

    public ContentUnit(int newUnitID, Sprite newImage, string newtitleText, Choice newChoiceA, Choice newChoiceB , Location newlocationInfo, string newTimeStamp)
    {
        UnitID = newUnitID;
        background = newImage;
        titleText = newtitleText;
        choiceA = newChoiceA;
        timeStamp = newTimeStamp;

        if (newChoiceB !=null)
        {
            choiceB = newChoiceB;
        }

        if (newlocationInfo != null)
        {
            locationInfo = newlocationInfo;
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
