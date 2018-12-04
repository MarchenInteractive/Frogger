using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

  // Public attributes
  public float stepDistance = 1f;
  public int lifes = 5;
  public int points = 0;
  public int tempPoints = 0;
  public Text label_lifes;
  public Text label_time;
  public Text label_points;
  //Private attributes
  private Vector3 _direction;
  private RaycastHit _hit;
  private Level _level;
  private bool _isActive = true;
  public bool receiveDamage = true;
  public int time = 30;
  private int _initialTime;
  private List<string> collisions = new List<string>();

  public bool isActive
  {
    get { return _isActive; }
    set { _isActive = value; }
  }

  // Use this for initialization
  void Start()
  {
    label_lifes.text = lifes.ToString();
    _initialTime = time;
    StartCoroutine(Timer());
  }

  // Update is called once per frame
  public virtual void Update()
  {
    if (_isActive)
    {
      //Detect keyboard events
      if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
      {
        MoveChar(Vector3.right);
      }
      if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
      {
        MoveChar(Vector3.left);
      }
      if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && this.gameObject.transform.position.z > 1)
      {
        MoveChar(Vector3.back);
      }
      if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
      {
        MoveChar(Vector3.forward);
      }
    }
  }

  // Fuction to move the character
  public virtual void MoveChar(Vector3 direction)
  {
    StartCoroutine(TimedMove(direction));
  }

  // Método corutina
  public virtual IEnumerator TimedMove(Vector3 direction)
  {
    this.transform.Translate(direction);
    yield return new WaitForSeconds(0.1f);
  }

  void OnTriggerEnter(Collider other)
  {
    collisions.Add(other.gameObject.tag);
    if (collisions.Contains("Target"))
    {
      tempPoints = 0;
      ReactivatePoints();
      collisions = new List<string>();
    }
    else if (collisions.Contains("Harmful"))
    {
      if (receiveDamage)
      {
        receiveDamage = false;
        StartCoroutine(Damage());
      }
    }
    if (other.gameObject.tag.Equals("Points"))
    {
      points += (lifes * 2) * time;
      tempPoints = points;
      label_points.text = points.ToString();
      other.gameObject.tag = "UsedPoints";
    }
  }

  void OnTriggerExit(Collider other)
  {
    if (!other.gameObject.tag.Equals("Harmful"))
    {
      receiveDamage = true;
    }
  }

  IEnumerator Damage()
  {
    ReactivatePoints();
    yield return new WaitForSeconds(0.1f);
    receiveDamage = false;
    this.gameObject.transform.position = new Vector3(0.5f, 0, 1);
    lifes -= 1;
    label_lifes.text = lifes.ToString();
    points = points - tempPoints;
    tempPoints = 0;
    label_points.text = points.ToString();
    collisions = new List<string>();
  }

  public void ReactivatePoints()
  {
    GameObject level = GameObject.Find("Level");
    level.GetComponent<Level>().ReactivatePoints();
  }

  IEnumerator Timer()
  {
    do
    {
      yield return new WaitForSeconds(1f);
      time -= 1;
      label_time.text = time.ToString();
      if (time <= 0)
      {
        this.gameObject.transform.position = new Vector3(0.5f, 0, 1);
        lifes -= 1;
        time = _initialTime;
      }
    } while (true);
  }
}