using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

  public static GameControl instance;

	public int characterMoves{
    get 
    { 
      return _characterMoves;  
    }
    set 
    { 
      _characterMoves = value;  
    }
  }

	public float activePlayTime 
  {
    get 
    { 
      return _activePlayTime; 
    }
    set 
    { 
      _activePlayTime = value; 
    }
  }

	public Level levelmanager 
  {
    get 
    {
      return _level;
    }
    set 
    {
      _level = value;
    }
  }

	private int _characterMoves;
  private float _activePlayTime;
  // private List<Target> targets;
  private Level _level;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
