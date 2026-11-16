using Unity.VisualScripting;
using UnityEngine;

public class MoveCameraBase : MonoBehaviour
{

    void Start()
    {
        transform.position = new Vector3(5, 2, -10);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x < 73)
            {
                transform.position = new Vector3(transform.position.x + 17, transform.position.y, transform.position.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (transform.position.x > 5)
            {
                transform.position = new Vector3(transform.position.x - 17, transform.position.y, transform.position.z);
            }
        }
    }
}
