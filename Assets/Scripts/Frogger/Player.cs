using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  // Public attributes
  public float stepDistance = 1f;
  public float lifes = 5f;

  //Private attributes
  private Vector3 _direction;
  private RaycastHit _hit;
  private Level _level;
  private SmoothFollow _smoothFollow;
  private bool _isSafe = false;

  // Use this for initialization
  void Start()
  {
  }

  // Update is called once per frame
  public virtual void Update()
  {
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
  public virtual void MoveChar(Vector3 direction)
  {
    StartCoroutine(TimedMove(direction));
  }

  // Método corutina
  public virtual IEnumerator TimedMove(Vector3 direction)
  {
    this.transform.Translate(direction);
    yield return new WaitForSeconds(0.1f);
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag.Equals("Safe"))
    {
      _isSafe = true;
    }
    if (other.gameObject.tag.Equals("Harmful"))
    {
      StartCoroutine(Damage(other));
    }
  }

  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag.Equals("Safe"))
    {
      Debug.Log("Exit");
      _isSafe = false;
    }
  }

  IEnumerator Damage(Collider other)
  {
    yield return new WaitForSeconds(0.1f);
    if (!_isSafe)
    {
      Debug.Log("Harm");
      this.gameObject.transform.position = new Vector3(0.5f, 0, 1);
      lifes -= 1;
    }
  }
}