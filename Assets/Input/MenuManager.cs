using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    List<MenuElement> menuElements = new List<MenuElement>();
    
    void Start()
    {
        InitializeElements();
        LoadElements();
        DebugLogElements();
    }

    void InitializeElements()
    {
        int idCounter = 0;
        foreach (Transform childTransform in transform)
        {
            menuElements.Add(new MenuElement(idCounter++, childTransform.gameObject, transform.childCount));
        }
    }

    void LoadElements()
    {
        foreach (MenuElement elementToLoad in menuElements)
        {
            foreach (MenuElement elementToObserve in menuElements)
            {
                elementToLoad.distancesToOtherElements.Add(Vector3.Distance(elementToLoad.obj.transform.position, elementToObserve.obj.transform.position));
                elementToLoad.directionsToOtherElements.Add(elementToObserve.obj.transform.position - elementToLoad.obj.transform.position);
            }
        }
    }

    void DebugLogElements()
    {
        foreach (MenuElement element in menuElements) { element.DebugLog(); }
    }


    void Update()
    {

    }

    public Vector3 NewCursorLocation(Vector3 currentCursorLocation, Vector3 inputDirection)
    {
        // TODO: find destination location using the current cursor position and the input direction
        // return a vector, not a game object
        return Vector3.zero;
    }
}

public class MenuElement
{
    public int ID;
    public GameObject obj;
    public List<float> distancesToOtherElements = new List<float>();
    public List<Vector3> directionsToOtherElements = new List<Vector3>();
    
    public MenuElement(int ID, GameObject obj, int numOfElements)
    {
        this.ID = ID;
        this.obj = obj;
    }

    public void DebugLog()
    {
        string debugInfo = "";

        for (int i = 0; i < distancesToOtherElements.Count; i++)
        {
            debugInfo += "Info about ID " + i + ": " + "[distance = " + distancesToOtherElements[i] + "] [direction =" + directionsToOtherElements[i] + "]\n";
        }
        
        Debug.Log
        (
            "ID: " + ID + ", Name: " + obj.name + "\n\n" + debugInfo
        );
    }
}
