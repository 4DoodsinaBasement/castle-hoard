using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public List<MenuElement> menuElements = new List<MenuElement>();
    

    void Start()
    {
        InitializeElements();
        LoadElements();
        DebugLogElements();
    }

    void Update()
    {
        
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
                elementToLoad.LoadElementData(elementToObserve);
            }
        }
    }

    void DebugLogElements()
    {
        foreach (MenuElement element in menuElements) { element.DebugLog(); }
    }

    void DebugDrawElements()
    {
        foreach (MenuElement element in menuElements) { element.DebugDraw(); }
    }

    public MenuElement GetElementByDirection(MenuElement currentElement, Vector3 inputDirection)
    {
        List<MenuElement> eligableElements = new List<MenuElement>();
        MenuElement elementToReturn = null;

        foreach (MenuElement otherElement in menuElements)
        {
            if (currentElement.ID != otherElement.ID)
            {
                if (Vector3.Angle(inputDirection, currentElement.GetDirectionToElement(otherElement)) <= 65f)
                {
                    eligableElements.Add(otherElement);
                }
            }
        }

        foreach (MenuElement otherEligableElement in eligableElements)
        {
            otherEligableElement.DebugLog();
            otherEligableElement.DebugDraw(1.0f);
            // TODO: Calculate best element based on otherEligableElement distance and direction

            // if (elementToReturn == null) { elementToReturn = otherEligableElement; }
            // else
            // {
            //     if (currentElement.GetDistanceToElement(otherEligableElement) < currentElement.GetDistanceToElement(elementToReturn)) 
            //     {
            //         elementToReturn = otherEligableElement;
            //     }
            // }
        }

        if (elementToReturn == null) { elementToReturn = currentElement; }

        return elementToReturn;
    }
}



public class MenuElement
{
    public int ID;
    public GameObject obj;
    public Vector3 position;
    List<float> distancesToOtherElements = new List<float>();
    List<Vector3> directionsToOtherElements = new List<Vector3>();
    
    public MenuElement(int ID, GameObject obj, int numOfElements)
    {
        this.ID = ID;
        this.obj = obj;
        this.position = obj.transform.position;
    }

    public void LoadElementData(MenuElement otherElement)
    {
        distancesToOtherElements.Add(Vector3.Distance(position, otherElement.position));
        directionsToOtherElements.Add(otherElement.position - position);
    }

    public float GetDistanceToElement(MenuElement otherElement)
    {
        return distancesToOtherElements[otherElement.ID];
    }

    public Vector3 GetDirectionToElement(MenuElement otherElement)
    {
        return directionsToOtherElements[otherElement.ID];
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

    public void DebugDraw()
    {
        Debug.DrawLine(position + new Vector3(0.5f,0,0), position + new Vector3(0,0.5f,0), Color.white);
        Debug.DrawLine(position + new Vector3(0,0.5f,0), position + new Vector3(-0.5f,0,0), Color.white);
        Debug.DrawLine(position + new Vector3(-0.5f,0,0), position + new Vector3(0,-0.5f,0), Color.white);
        Debug.DrawLine(position + new Vector3(0,-0.5f,0), position + new Vector3(0.5f,0,0), Color.white);

        Debug.DrawLine(position + new Vector3(0.25f,0,0), position + new Vector3(0,0.25f,0), Color.black);
        Debug.DrawLine(position + new Vector3(0,0.25f,0), position + new Vector3(-0.25f,0,0), Color.black);
        Debug.DrawLine(position + new Vector3(-0.25f,0,0), position + new Vector3(0,-0.25f,0), Color.black);
        Debug.DrawLine(position + new Vector3(0,-0.25f,0), position + new Vector3(0.25f,0,0), Color.black);
    }

    public void DebugDraw(float drawDuration)
    {
        Debug.DrawLine(position + new Vector3(0.5f,0,0), position + new Vector3(0,0.5f,0), Color.white, drawDuration);
        Debug.DrawLine(position + new Vector3(0,0.5f,0), position + new Vector3(-0.5f,0,0), Color.white, drawDuration);
        Debug.DrawLine(position + new Vector3(-0.5f,0,0), position + new Vector3(0,-0.5f,0), Color.white, drawDuration);
        Debug.DrawLine(position + new Vector3(0,-0.5f,0), position + new Vector3(0.5f,0,0), Color.white, drawDuration);

        Debug.DrawLine(position + new Vector3(0.25f,0,0), position + new Vector3(0,0.25f,0), Color.black, drawDuration);
        Debug.DrawLine(position + new Vector3(0,0.25f,0), position + new Vector3(-0.25f,0,0), Color.black, drawDuration);
        Debug.DrawLine(position + new Vector3(-0.25f,0,0), position + new Vector3(0,-0.25f,0), Color.black, drawDuration);
        Debug.DrawLine(position + new Vector3(0,-0.25f,0), position + new Vector3(0.25f,0,0), Color.black, drawDuration);
    }
}
