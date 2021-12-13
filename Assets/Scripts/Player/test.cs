using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] public GameObject projectile;
    [SerializeField] public int magSize;
    [SerializeField] public GameObject Magazine;

    public GameObject[] bullets;

    Queue<GameObject> projectilePool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < magSize; i++)
        {
            bullets[i] = Instantiate(projectile);
            //GameObject pro = Instantiate(projectile);
            //pro.transform.parent = Magazine.transform;
            //pro.SetActive(false);
            //projectilePool.Enqueue(pro);
        }
    }

    public GameObject[] getBullets () {
        return bullets;
    }
}
