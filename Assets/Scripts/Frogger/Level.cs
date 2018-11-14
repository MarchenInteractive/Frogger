using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

  public Target[] targets;
  public string nextLevel;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (GameDone())
    {
      Debug.Log("Win");
    }
  }

  public bool GameDone()
  {
    foreach (Target target in targets)
    {
      if (!target.GetStatus())
      {
        return false;
      };
    }
    return true;
  }
}
