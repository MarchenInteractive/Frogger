using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	// Public attributes
	public float stepDistance = 1f;
	public float lifes = 5f;

	//Private attributes
	private Vector3 _direction;
  private bool _isReadyToMove;
  private RaycastHit _hit;
	private Level _level;
  private SmoothFollow _smoothFollow;

	// Use this for initialization
	void Start () {
		_isReadyToMove = true;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		//Detect keyboard events
		if (Input.GetKeyDown(KeyCode.RightArrow))
      {
        MoveChar(Vector3.right);
      }
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
         MoveChar(Vector3.left);
      }
      if (Input.GetKeyDown(KeyCode.DownArrow))
      {
        MoveChar(Vector3.back);
      }
      if (Input.GetKeyDown(KeyCode.UpArrow))
      {
        MoveChar(Vector3.forward);
      }
	}

	// Fuction to move the character
	public virtual void MoveChar(Vector3 direction) {
		// Detect Damage
    if(!DetectDamage(direction) && _isReadyToMove) 
    {
      StartCoroutine(TimedMove(direction));
    }else{
			this.gameObject.transform.position = new Vector3(0,0,0);
			lifes -= 1;
		}
  }

	// Método corutina
	public virtual IEnumerator TimedMove(Vector3 direction){
    _isReadyToMove = false;
    this.transform.Translate(direction);
    yield return new WaitForSeconds(0.1f);
    _isReadyToMove = true;
	}

	//Function that detects if a collision exist
	public virtual bool DetectDamage(Vector3 direction){
		// Save the data of the collision in the property _hit
		if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out _hit, 1))
    {
			// Detect if the collsion was with a Harmful Element
      if(_hit.collider.gameObject.tag.Equals("Harmful")) 
        {
        	return true;
        }
		}
		return false;
	}
}
