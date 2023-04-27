using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // Bullet의 transform 추적해서 파괴 

    [SerializeField]
    private Transform bulletTransform;

    private Stack<GameObject> bulletStack = new Stack<GameObject>();


    private void Start()
    {
        StartCoroutine(FindBullet());
    }

    private IEnumerator FindBullet()
    {
        bulletTransform.position = transform.position;


        yield return null;
    }

    private void LookForTargets()
    {
        float targetMaxRadius = 20f;
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, targetMaxRadius);

        foreach (Collider2D collider2D in collider2DArray)
        {
            Building building = collider2D.GetComponent<Building>();
            if (building != null)
            {
                if (bulletTransform == null)
                {
                    bulletTransform = building.transform;
                }
                else
                {
                    if (Vector3.Distance(transform.position, building.transform.position) <
                        Vector3.Distance(transform.position, bulletTransform.position))
                    {
                        bulletTransform = building.transform;
                    }
                }
            }
        }

        if (bulletTransform == null)
        {
            if (BuildingManager.Instance.GetHqBuilding() != null)
            {
                bulletTransform = BuildingManager.Instance.GetHqBuilding().transform;
            }

        }
    }
}
