using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{

  // Use this for initialization
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      Vector3 position = other.gameObject.transform.position;
      other.gameObject.transform.position = new Vector3(position.x * -1, position.y, position.z);
    }
  }
}
