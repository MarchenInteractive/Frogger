using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingElement : MonoBehaviour {

	public string direction;
	public float speed;

	// Use this for initialization
	void Start () {
		StartCoroutine(Movement(direction));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Método corutina
	public virtual IEnumerator Movement(string direction){
		while(true){
			switch(direction){
			case "r":
    		this.gameObject.transform.Translate(speed*Time.deltaTime,0,0);
				break;
			case "l":
    		this.gameObject.transform.Translate(-speed*Time.deltaTime,0,0);
				break;
			case "f":
    		this.gameObject.transform.Translate(0,0,speed*Time.deltaTime);
				break;
			case "b":
    		this.gameObject.transform.Translate(0,0,-speed*Time.deltaTime);
				break;
		}
    	yield return new WaitForSeconds(0.1f);
		}	
	}
}
