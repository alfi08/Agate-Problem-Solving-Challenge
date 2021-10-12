using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  private Rigidbody2D Rb;
  private Vector2 direction;
  private float ms;

  [SerializeField] private GameObject boxPoint;
  [SerializeField] private int BoxPointCount;
  // Start is called before the first frame update
  private void Start()
  {
    ms = 3f;
    Rb = GetComponent<Rigidbody2D>();

    for (int i = 0; i < BoxPointCount; i++)
    {
      spawnBoxPoint(i);
    }
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

  private void spawnBoxPoint(int i)
  {
    // Vector3 randomPos = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f), 0f);
    // if ((randomPos - transform.position).sqrMagnitude > 3)
    // {
    //   Debug.Log($"{i} masuk");
    //   Instantiate(boxPoint, randomPos, Quaternion.identity);
    // }else{
    //   Debug.Log($"{i} tidak masuk");
    // }

    bool isSpawn = false;
    while (!isSpawn)
    {
      Vector3 randomPos = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f), 0f);
      if ((randomPos - transform.position).magnitude < 3)
      {
        continue;
      }
      else
      {
        Instantiate(boxPoint, randomPos, Quaternion.identity);
        isSpawn = true;
      }
    }
  }
}
