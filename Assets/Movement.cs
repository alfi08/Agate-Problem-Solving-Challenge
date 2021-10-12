using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  private Rigidbody2D Rb;
  private Vector2 direction;
  private float ms;

  [SerializeField]
  private GameObject boxPoint;
  // Start is called before the first frame update
  void Start()
  {
    ms = 3f;
    Rb = GetComponent<Rigidbody2D>();
    spawnBoxPoint();
  }

  // Update is called once per frame
  private void FixedUpdate()
  {
    float hor = Input.GetAxisRaw("Horizontal");
    float ver = Input.GetAxisRaw("Vertical");

    Rb.velocity = new Vector2(ms * hor, ms * ver);

    if (Input.GetMouseButton(0))
    {
      Vector2 mouse = Input.mousePosition;
      Ray castPoint = Camera.main.ScreenPointToRay(mouse);
      Rb.velocity = new Vector2(ms * castPoint.origin.x, ms * castPoint.origin.y);
    }
  }

  private void spawnBoxPoint()
  {
    bool isSpawn = false;
    Vector3 randomPos = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 0f);
    Debug.Log(randomPos);
    // while (!isSpawn)
    // {
    //   Vector3 randomPos = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 0f);
    //   if ((randomPos - transform.position).magnitude < 3)
    //   {
    //     continue;
    //   }
    //   else
    //   {
    //     Instantiate(boxPoint, randomPos, Quaternion.identity);
    //   }
    // }
  }
}
