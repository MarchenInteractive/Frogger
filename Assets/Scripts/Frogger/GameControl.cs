using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

  public static GameControl instanciate;

  void Awake()
  {
    if (GameControl.instanciate == null)
    {
      instanciate = this;
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

}
