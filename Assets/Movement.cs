using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  private Rigidbody2D Rb;
  private Vector2 direction;
  public float ms;
  // Start is called before the first frame update
  void Start()
  {
    Rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    float hor = Input.GetAxisRaw("Horizontal");
    float ver = Input.GetAxisRaw("Vertical");

    Rb.velocity = new Vector2(ms * hor, ms * ver);

    if (Input.GetMouseButton(1))
    {
      Vector2 mouse = Input.mousePosition;
      Ray castPoint = Camera.main.ScreenPointToRay(mouse);
      Rb.velocity = new Vector2(ms * castPoint.origin.x, ms * castPoint.origin.y);
    }
  }
}
