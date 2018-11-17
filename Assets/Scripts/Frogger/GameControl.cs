using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

  public static GameControl instance;
  public int actualLevel = 0;

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
    SceneManager.LoadScene(value);
  }

  public void LoadNextscene()
  {
    Debug.Log(actualLevel);
    SceneManager.LoadScene("Story");
  }

  public void ReloadScene()
  {
    LoadScene(SceneManager.GetActiveScene().name);
  }

}
