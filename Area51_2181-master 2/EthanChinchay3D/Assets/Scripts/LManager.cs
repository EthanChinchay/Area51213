using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LManager : MonoBehaviour {

    public Image HpBar;
    float Hp;
    public PlayerScript playerScript;
    public Gradient barColors;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(HpBar.fillAmount != playerScript.normalizedHp){
            float delta = Mathf.Abs(HpBar.fillAmount - playerScript.normalizedHp);
            if (delta < 0.2f) { delta = 0.2f; }
            HpBar.fillAmount = Mathf.MoveTowards(HpBar.fillAmount, playerScript.normalizedHp,2f * delta * Time.deltaTime);
            HpBar.color = barColors.Evaluate(HpBar.fillAmount);

        }
	}
}
