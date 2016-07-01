using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PopulateStoryGraph : MonoBehaviour
{

    public static List<ContentUnit> StoryGraph = new List<ContentUnit>();
    public Sprite[] ImagePool;
    public AudioClip[] AudioPool;

	// Use this for initialization
	void Start ()
    {
        StoryGraph.Add(new ContentUnit(0, ImagePool[0], "You are the new member in the team at work. The team hosts a light social gathering after work on a Friday night.","You meet Zafar, a co-worker. He offers you a drink !", new Choice("\"Sure ! I am cool with it\"", 1), new Choice("\"I don't drink !\"", 2), new Location("7 Degrees Brauhaus", "Golf Course Road", "Delhi NCR"), "June 2009"));
        StoryGraph.Add(new ContentUnit(1, ImagePool[1], "You had a great time that evening. You start seeing Zafar over the next couple of weeks.","A year later you are married to Zafar.", new Choice("Life is Good", 2), null, null, ""));
        StoryGraph.Add(new ContentUnit(2, ImagePool[2], "One evening you are invited to a small hangout at a mutual friend's place. You and Zafar decide to attend it to kill time.","Things have been pretty saturated between you too lately.", new Choice("Choice A3", 1), null, null, ""));

        StoryGraph[0].contentunit_audioclip = AudioPool[0];
        StoryGraph[1].contentunit_audioclip = AudioPool[1];
        StoryGraph[2].contentunit_audioclip = null;
              
    }
	
	
}
