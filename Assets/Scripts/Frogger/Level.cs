using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

  public static Level instanciate;

  public Target[] targets;
  public Player player;
  public int nextLevel;
  public GameObject winPanel;
  public GameObject losePanel;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (GameDone())
    {
      winPanel.SetActive(true);
    }
    if (GameLose())
    {
      losePanel.SetActive(true);
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
    GameControl.instance.actualLevel = nextLevel;
    player.isActive = false;
    return true;
  }

  public bool GameLose()
  {
    if (player.lifes == 0)
    {
      player.isActive = false;
      return true;
    }
    return false;
  }
}
