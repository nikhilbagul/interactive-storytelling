using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    
    public Texture2D customCursor2;

    // Use this for initialization
    void Start ()
    {
        Cursor.SetCursor(customCursor2, new Vector2(0, 0), CursorMode.ForceSoftware);        
    }
    
}
