using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampFire : MonoBehaviour
{
    // Start is called before the first frame update
    public int noSticks;
    public float radius;
    public GameObject myFire;
    public bool fireStarted = false;
    public Text text;
    private int sticksRemaining;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        int i = 0;
        int count = 0;
        for(i = 0; i < hitColliders.Length; i++)
        {
            if(hitColliders[i].gameObject.tag == "Stick")
            {
                count += 1;
            }
        }
        sticksRemaining = noSticks - count;
        if (count >= noSticks && !fireStarted)
        {
            fireStarted = true;
        }
        else {
            if(fireStarted)
            {
                text.text = "Press X to start Fire!";
            }
            else
            {
                text.text = sticksRemaining + " sticks to go!";
            }
        }
        count = 0;
        if(Input.GetButton("Fire3") && fireStarted)
        {
            StartFire();
        }
    }

    void StartFire()
    {
        Instantiate(myFire, transform.position, Quaternion.identity);
    }
}
