using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingElement : MonoBehaviour
{

  public string direction;
  public float speed;

  public bool moveOther = false;

  private IEnumerator movementCorutine;


  // Use this for initialization
  void Start()
  {
    if (!moveOther)
    {
      StartCoroutine(Movement(direction, this.gameObject));
    }
  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnTriggerEnter(Collider other)
  {
    if (moveOther)
    {
      movementCorutine = Movement(direction, other.gameObject);
      StartCoroutine(movementCorutine);
    }
  }

  void OnTriggerExit(Collider other)
  {
    if (moveOther)
    {
      StopCoroutine(movementCorutine);
      movementCorutine = null;
    }
  }

  // Método corutina
  public virtual IEnumerator Movement(string direction, GameObject movingObject)
  {
    while (true)
    {
      switch (direction)
      {
        case "r":
          movingObject.transform.Translate(speed * Time.deltaTime, 0, 0);
          break;
        case "l":
          movingObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
          break;
        case "f":
          movingObject.transform.Translate(0, 0, speed * Time.deltaTime);
          break;
        case "b":
          movingObject.transform.Translate(0, 0, -speed * Time.deltaTime);
          break;
      }
      yield return new WaitForSeconds(0.1f);
    }
  }
}
