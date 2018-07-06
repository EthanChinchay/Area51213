using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    
    public float MaxHp = 1f;
    public float CurrentHp;
    public PowerBehaviour currentPower;

    public float normalizedHp { get { return CurrentHp / MaxHp; } }

    public void ModifyHp (float addValue){
        CurrentHp = Mathf.Clamp(CurrentHp + addValue, 0, MaxHp);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
            

	}
}
