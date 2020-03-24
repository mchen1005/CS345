using UnityEngine;
using System.Collections;
 
public class Footsteps : MonoBehaviour {

        public float stepRate = 0.5f;
        public float stepCoolDown;
        public AudioClip footsteps;
        // Use this for initialization
        CharacterController cc;
        void Start () {
        cc = GetComponent<CharacterController>();
        }
       
        // Update is called once per frame
        void Update () {
                stepCoolDown -= Time.deltaTime;
                if (cc.isGrounded == true && (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f){
                        GetComponent<AudioSource>().pitch = 1f + Random.Range (-0.2f, 0.2f);
                        GetComponent<AudioSource>().PlayOneShot (footsteps, 0.9f);
                        stepCoolDown = stepRate;
                }
        }
}