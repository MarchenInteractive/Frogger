using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour {

	public GameObject[] levels;

	// Use this for initialization
	void Start () {
		for(int i = 0;i<levels.Length;i++){
		Debug.Log("Complete-Level-"+ (i+1).ToString());
			if(PlayerPrefs.GetInt("Complete-Level-"+ (i+1).ToString())==1){
				levels[i].GetComponent<Button>().interactable = true;
				levels[i].transform.GetChild(1).transform.GetComponent<Text>().text = PlayerPrefs.GetInt("Level-"+ (i+1).ToString()).ToString();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
