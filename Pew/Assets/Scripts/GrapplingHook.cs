using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public GameObject hook;
    public GameObject hookHolder;

    public float hookTravelSpeed;
    public float playerTravelSpeed;

    public static bool fired;
    public bool hooked;
    public GameObject hookedObj;

    //How far hook travel
    public float maxDistance;
    private float currentDistance;

    //Player climbing variable
    private bool grounded;

    void Update()
    {
        //fire hook. Don't refire if fire
        if (Input.GetMouseButtonDown(0) && fired == false)
            fired = true;

        if (fired == true && hooked == false)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            //Stop hook from flying off the map
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);

            //rappel the hook

            if (currentDistance >= maxDistance)
                ReturnHook();
        }
            //While hooked
        if (hooked == true && fired == true)
        {                                           
            hook.transform.parent = hookedObj.transform;
                                                                         // Starting position   Hook position
            transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTravelSpeed);
            //calcuating the distance b/w player & Object
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);

            this.GetComponent<Rigidbody>().useGravity = false;


            if (distanceToHook < 1)
            {
                //ReturnHook();

                //if not on ground move upward and forward 
                if( grounded == false)
                {
                    this.transform.Translate(Vector3.forward * Time.deltaTime * 13f);
                    this.transform.Translate(Vector3.up * Time.deltaTime * 50f); //Move player upward on hooking
                }

                StartCoroutine("Climb");
            }
        } else {
            hook.transform.parent = hookHolder.transform;
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    IEnumerator Climb()
    {
        yield return new WaitForSeconds(0.1f);
        ReturnHook();
    }

    void ReturnHook()
    {
        hook.transform.rotation = hookHolder.transform.rotation;
        hook.transform.position = hookHolder.transform.position;
        fired = false;
        hooked = false;
    }

    //Ground if underneath the player
    void CheckIfGrounded()
    {
        RaycastHit hit;
        float distance = 1f;
        //moving downward
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            grounded = true;
        }else{
            grounded = false;
        }
    }
}
