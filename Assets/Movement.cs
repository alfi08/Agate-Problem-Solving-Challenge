using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  public float ms;
  Rigidbody2D Rb;
  // Start is called before the first frame update
  void Start()
  {
    Rb = GetComponent<Rigidbody2D>();
    Rb.velocity = new Vector2(ms * 3, ms * 3);
  }

  // Update is called once per frame
  void Update()
  {
    float hor = Input.GetAxisRaw("Horizontal");
    float ver = Input.GetAxisRaw("Vertical");

    Rb.velocity = new Vector2(ms * hor, ms * ver);
  }
}
