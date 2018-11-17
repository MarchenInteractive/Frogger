using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FlowchartHelper : MonoBehaviour
{

  public Flowchart flchart;

  // Use this for initialization
  void Start()
  {
    flchart.SetIntegerVariable("nextLevel", GameControl.instance.actualLevel);
    flchart.ExecuteBlock("Main");
  }

  // Update is called once per frame
  void Update()
  {

  }
}

