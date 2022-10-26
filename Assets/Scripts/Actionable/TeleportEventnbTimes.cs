using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEventnbTimes : MonoBehaviour

{
    public Actionable[] actions;

    public GameObject eventWeird;

    public Transform posToGo;
    public int nbTimes = 3;

    private int cptTime;

    // Start is called before the first frame update
    void Start()
    {
        cptTime = 0;
    }

    protected void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){

            CharacterController c = other.GetComponent<CharacterController>();

            c.enabled = false;
            c.transform.position = new Vector3(c.transform.position.x, c.transform.position.y ,posToGo.position.z);
            c.enabled = true;



            if(cptTime == nbTimes){
                foreach (Actionable action in actions)
                {
                    action.Activate();
                }
            }
            else
            {
                if(cptTime == nbTimes - 1)
                {
                    eventWeird.SetActive(true);
                }
            }

            cptTime++;
        }
    }
}
