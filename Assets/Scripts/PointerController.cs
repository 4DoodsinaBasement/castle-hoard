using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    public GameObject spellBinding;
    Vector3 direction;
    float angle;
    bool Ready = true;
    int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePointer();

        if (Input.GetMouseButtonDown(0) && Ready)
        {
            Vector3 spellLocation = new Vector3(0,0,0);
            //spellLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //spellLocation.z = 0;
            Instantiate(spellBinding, spellLocation, Quaternion.identity);
            timer = spellBinding.GetComponent<basicSpell>().Cooldown;
            Ready = false;
        }

        if(!Ready)
        {
            timer--;
            if (timer == 0)
            {
                Ready = true;
            }
        }

    }

    void MovePointer()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
