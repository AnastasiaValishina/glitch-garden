using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gunPosition;
    public void Fire()
    {
        Instantiate(projectile, gunPosition.transform.position, gunPosition.transform.rotation);
    }


}
