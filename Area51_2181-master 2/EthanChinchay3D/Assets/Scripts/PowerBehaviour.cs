using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBehaviour : MonoBehaviour {

    PlatformerMovement activePlayer;
    public Collider TriggerArea;
    public readonly string ContainerBase = "PowerContainer";
    public readonly Vector3 idPoint = new Vector3(2f, 0.25f, 0f);
    public readonly Vector3 Center;

	// Use this for initialization
	void Start () {
        if (activePlayer){
            TriggerArea.enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AssignActivePlayer (PlatformerMovement targetPlayer){
        activePlayer = targetPlayer;
        transform.SetParent(activePlayer.transform.Find(ContainerBase));
        transform.localPosition = idPoint;
        transform.rotation = targetPlayer.transform.rotation;
        TriggerArea.enabled = false;
        //GetComponent<Animator>().SetFloat ("ALspeed")
    }

    public void AttackRoundAbout(){
        transform.parent.localPosition = Vector3.zero;
        GetComponent<Animator>().SetTrigger("Roundabout");
    }

	public void ResetPoint() {
        transform.parent.localPosition = idPoint;
	}
}
