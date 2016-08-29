using UnityEngine;
using System.Collections;


public class RecalculateNavMesh : MonoBehaviour
{
    void Start()
    {
        Bounds bR = GetComponent<Renderer>().bounds;
        //Pathfinder.Instance.DynamicRaycastUpdate(bR);
    }
}
