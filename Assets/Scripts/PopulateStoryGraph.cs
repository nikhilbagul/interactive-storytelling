using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PopulateStoryGraph : MonoBehaviour
{

    public static List<ContentUnit> StoryGraph = new List<ContentUnit>();
    public Sprite[] ImagePool;
    

	// Use this for initialization
	void Start ()
    {
        StoryGraph.Add(new ContentUnit(0, ImagePool[0], "Content Unit 1 ", new Choice("Choice A1", 1), new Choice("Choice B1", 2), new Location("7 Degrees Brauhaus", "Golf Course Road", "Delhi NCR"), "June 2009"));
        StoryGraph.Add(new ContentUnit(1, ImagePool[1], "Content Unit 2 ", new Choice("Choice A2", 0), null, null, ""));
        StoryGraph.Add(new ContentUnit(2, ImagePool[2], "Content Unit 3 ", new Choice("Choice A3", 1), null, null, ""));
       
    }
	
	
}
