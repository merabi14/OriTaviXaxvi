using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform car;
    void LateUpdate()
    {
        transform.position = new Vector3(car.position.x, car.position.y, -1);
    }
}
