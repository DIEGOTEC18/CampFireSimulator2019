using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxController : MonoBehaviour
{
    public static bool inRange;
    public Transform stickHold;
    public Transform myStick;
    public bool isHolding = false;
    public GameObject myHit;
    public float forceStrength;
    public Rigidbody rb;
    private Collider col;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Input.GetButtonUp("Fire1"))
        {
            if(isHolding)
            {
                
                myStick.transform.parent = null;
                col.enabled = true;
                rb.isKinematic = false;
                rb.AddForce(transform.forward * forceStrength);
                col = null;
                myStick = null;
                rb = null;
                isHolding = false;
            }
            if (Physics.Raycast(transform.position, transform.TransformDirection((Vector3.forward)), out hit))
            {
                print("Raycast hit");
                
                if (hit.collider.gameObject.tag == "Stick" && !isHolding)
                {
                    myStick = hit.collider.transform;
                    rb = myStick.gameObject.GetComponent<Rigidbody>();
                    col = myStick.gameObject.GetComponent<Collider>();
                    myStick.position = stickHold.position;
                    myStick.parent = stickHold;
                    col.enabled = false;
                    rb.isKinematic = true;
                    isHolding = true;
                }
            }
        }
    }
}
