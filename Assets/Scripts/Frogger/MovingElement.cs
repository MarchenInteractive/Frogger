using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingElement : MonoBehaviour
{

  public string direction;
  public float speed;

  public bool movePlayer = false;

  public float maxX;
  public float minX;
  public float maxZ;
  public float minZ;

  private IEnumerator movementCorutine;


  // Use this for initialization
  void Start()
  {
    if (!movePlayer)
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
      Debug.Log(position);
      switch (direction)
      {
        case "r":
          movingObject.transform.Translate(speed * Time.deltaTime, 0, 0);
          if (position.x >= maxX)
          {
            movingObject.transform.position = new Vector3(minX, position.y, position.z);
          }
          break;
        case "l":
          movingObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
          if (position.x <= minX)
          {
            movingObject.transform.position = new Vector3(maxX, position.y, position.z);
          }
          break;
        case "f":
          movingObject.transform.Translate(0, 0, speed * Time.deltaTime);
          if (position.z >= maxZ)
          {
            movingObject.transform.position = new Vector3(position.x, position.y, minZ);
          }
          break;
        case "b":
          movingObject.transform.Translate(0, 0, -speed * Time.deltaTime);
          if (position.z <= minZ)
          {
            movingObject.transform.position = new Vector3(position.x, position.y, maxZ);
          }
          break;
      }
      yield return new WaitForSeconds(0.1f);
    }
  }
}
