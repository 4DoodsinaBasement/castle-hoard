using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMenuController : MonoBehaviour
{
    public MenuManager menuManager;

    public int startingElementID;
    public Vector3 inputDirection = new Vector3(0,0,0);
    MenuElement currentElement;
    
    // Start is called before the first frame update
    void Start()
    {
        currentElement = menuManager.menuElements[startingElementID];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentElement = menuManager.GetElementByDirection(currentElement, inputDirection);
            transform.position = currentElement.position;
        }
    }
}
