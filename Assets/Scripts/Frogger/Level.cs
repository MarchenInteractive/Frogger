using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level : MonoBehaviour
{

  public static Level instanciate;

  public Target[] targets;
  public Player player;
  public int nextLevel;
  public GameObject winPanel;
  public GameObject losePanel;
  public Text label_best;
  public GameObject[] points;
  private int bestPoints;


  // Use this for initialization
  void Start()
  {
    string level = (nextLevel-1).ToString();
    bestPoints = PlayerPrefs.GetInt("Level-"+level);
    label_best.text = bestPoints.ToString();
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
    if(bestPoints<player.points){
      label_best.text =  player.points.ToString();
      PlayerPrefs.SetInt("Level-"+ (nextLevel-1).ToString(), player.points);
    }
    PlayerPrefs.SetInt("Complete-Level-"+ (nextLevel-1).ToString(), 1);
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

  public void ReactivatePoints()
  {
    foreach (GameObject point in points)
    {
      point.tag = "Points";
    }
  }
}
