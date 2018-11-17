using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

  // Public attributes
  public float stepDistance = 1f;
  public float lifes = 5f;
  public int points = 0;
  public Text label_lifes;
  public Text label_time;

  //Private attributes
  private Vector3 _direction;
  private RaycastHit _hit;
  private Level _level;
  private SmoothFollow _smoothFollow;
  private bool _isActive = true;
  private bool _isSafe = false;
  public int time = 30;
  private int _initialTime;

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
      label_lifes.text = lifes.ToString();
      //Detect keyboard events
      if (Input.GetKeyDown(KeyCode.RightArrow))
      {
        MoveChar(Vector3.right);
      }
      if (Input.GetKeyDown(KeyCode.LeftArrow))
      {
        MoveChar(Vector3.left);
      }
      if (Input.GetKeyDown(KeyCode.DownArrow))
      {
        MoveChar(Vector3.back);
      }
      if (Input.GetKeyDown(KeyCode.UpArrow))
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
    if (other.gameObject.tag.Equals("Safe"))
    {
      _isSafe = true;
    }
    if (other.gameObject.tag.Equals("Harmful"))
    {
      StartCoroutine(Damage(other));
    }
    if (other.gameObject.tag.Equals("Points"))
    {
      points += 10 * time;
      Destroy(other.gameObject);
    }
  }

  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag.Equals("Safe"))
    {
      _isSafe = false;
    }
  }

  IEnumerator Damage(Collider other)
  {
    yield return new WaitForSeconds(0.1f);
    if (!_isSafe)
    {
      this.gameObject.transform.position = new Vector3(0.5f, 0, 1);
      lifes -= 1;
    }
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