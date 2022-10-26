using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEventnbTimes : MonoBehaviour

{
    public Actionable[] actions;

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
            c.transform.position = posToGo.position;
            c.enabled = true;

            cptTime++;

            if(cptTime == nbTimes){
                foreach (Actionable action in actions)
                {
                    action.Activate();
                }
            }
        }
    }
}
