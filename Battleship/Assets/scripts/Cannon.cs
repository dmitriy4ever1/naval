using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonball;

     
    public void Fire(Vector3 targetPos)
    {
        Vector3 dir = targetPos - transform.position;
        Vector2 flatDir = new Vector2(dir.x, dir.y);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 180f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject bullet = Instantiate(cannonball, transform.position, Quaternion.identity);
        dir = dir.normalized;

        bullet.GetComponent<Rigidbody2D>().AddForce(dir);
    }
}
