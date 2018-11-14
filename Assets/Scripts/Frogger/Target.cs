using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

  public Color activatedColor = Color.green;
  public Color deactivatedColor = Color.yellow;
  protected bool _status;
  protected Renderer targetRenderer;

  // Use this for initialization
  void Start()
  {
    targetRenderer = this.gameObject.GetComponent<Renderer>();
    targetRenderer.material.color = deactivatedColor;
    _status = false;
  }

  public bool GetStatus()
  {
    return _status;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag.Equals("Player"))
    {
      targetRenderer.material.color = activatedColor;
      _status = true;
      other.gameObject.transform.position = new Vector3(0.5f, 0, 1f);
    }
  }

}
