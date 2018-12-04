using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

  public static GameControl instance;
  public int actualLevel = 0;
  public int totalLevels = 0;

  void Awake()
  {
    if (GameControl.instance == null)
    {
      instance = this;
      DontDestroyOnLoad(this.gameObject);
    }
    else
    {
      Destroy(this.gameObject);
    }
  }

  public void LoadScene(string value)
  {
    if(value == "Main Menu"){
      GameControl.instance.actualLevel = 1;
    }
    SceneManager.LoadScene(value);
  }

  public void LoadNextscene()
  {
    SceneManager.LoadScene("Story");
  }

  public void LoadLevel(string value)
  {
    Debug.Log(value);
    GameControl.instance.actualLevel = int.Parse(value);
    SceneManager.LoadScene("Story");
  }

  public void Exit()
  {
    Application.Quit();
  }

  public void ReloadScene()
  {
    LoadScene(SceneManager.GetActiveScene().name);
  }

  public void ReactivatePoints()
  {
    GameObject[] points = GameObject.FindGameObjectsWithTag("Points");
    foreach (GameObject point in points)
    {
      point.SetActive(true);
    }
  }

  public void ClearScores(){
    Debug.Log("Level-");
    for(int i = 1; i<=  GameControl.instance.totalLevels; i++){
      Debug.Log("Level-"+ i.ToString());
      PlayerPrefs.SetInt("Level-"+ i.ToString(), 0);
      PlayerPrefs.SetInt("Complete-Level-"+ i.ToString(), 0);
      ReloadScene();
    }
  }

}
