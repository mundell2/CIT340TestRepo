using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour
{
    Vector3 mouseWorldPosition;
    bool clickReleased = true;

    // Update is called once per frame
    void Update()
    {
        mouseWorldPosition = 
            Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        transform.position = mouseWorldPosition;
        if (Input.GetAxis("Fire1") == 0)
            clickReleased = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!clickReleased)
            return;

        if(collision.gameObject.tag == "Enemy")
        {
            if (Input.GetAxis("Fire1") == 1)
            {
                clickReleased = false;
                collision.gameObject.GetComponent<Enemy>().DoDamage(5);
            }
        }
    }
}
