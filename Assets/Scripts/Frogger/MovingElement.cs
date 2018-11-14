using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingElement : MonoBehaviour
{

  public string direction;
  public float steps = 0.5f;

  public bool movePlayer = false;

  public float maxX;
  public float minX;

  public string typeOfObstacle;
  public float speedChange;

  private IEnumerator movementCorutine;


  // Use this for initialization
  void Start()
  {
    if (!movePlayer)
    {
      StartCoroutine(Movement(direction, this.gameObject));
    }
    if (typeOfObstacle != "")
    {
      StartCoroutine(Changer());
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if (movePlayer & other.gameObject.tag == "Player")
    {
      movementCorutine = Movement(direction, other.gameObject);
      StartCoroutine(movementCorutine);
    }
  }

  void OnTriggerExit(Collider other)
  {
    if (movePlayer)
    {
      StopCoroutine(movementCorutine);
      movementCorutine = null;
    }
  }

  // Método corutina
  public virtual IEnumerator Movement(string direction, GameObject movingObject)
  {
    Vector3 position;
    while (true)
    {
      position = movingObject.transform.position;
      switch (direction)
      {
        case "r":
          movingObject.transform.position = new Vector3(position.x + steps, position.y, position.z);
          if (position.x >= maxX)
          {
            movingObject.transform.position = new Vector3(minX, position.y, position.z);
          }
          break;
        case "l":
          movingObject.transform.position = new Vector3(position.x - steps, position.y, position.z);
          if (position.x <= minX)
          {
            movingObject.transform.position = new Vector3(maxX, position.y, position.z);
          }
          break;
      }
      yield return new WaitForSeconds(0.1f);
    }
  }

  IEnumerator Changer()
  {
    do
    {
      switch (typeOfObstacle)
      {
        case "turtles":
          if (this.gameObject.tag.Equals("Safe"))
          {
            yield return new WaitForSeconds(speedChange);
            this.gameObject.tag = ("Harmful");
          }
          else if (this.gameObject.tag.Equals("Harmful"))
          {
            yield return new WaitForSeconds(speedChange / 2);
            this.gameObject.tag = ("Safe");
          }
          break;
        default:
          break;
      }
    } while (true);
  }

}
