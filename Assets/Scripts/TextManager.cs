using UnityEngine;
using System.Collections;


public class TextManager : MonoBehaviour {

    public GameObject line1;
    private string your_text;
    private GUIText Place ; //  Address, City, Time;
    

	// Use this for initialization
	void Start ()
    {
        //your_text = line1.GetComponent<GUIText>().text;
        Place = GameObject.Find("Place").GetComponent<GUIText>();
    }
	
	// Update is called once per frame
	void Update ()
    {
               
	}




    
}
