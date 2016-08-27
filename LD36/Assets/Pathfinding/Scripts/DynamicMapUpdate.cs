using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DynamicMapUpdate : MonoBehaviour 
{
    public float UpdateTimer = 0.5F;
    public Vector3 lastPosition;
    public Bounds lastBounds;
    public bool isUpdating = false;
    void Start () 
    {
        lastPosition = transform.position;
        lastBounds = GetComponent<Renderer>().bounds;
        UpdateMapOnce();
        StartCoroutine(UpdateMap());
	}	

    void Update()
    {
        if (transform.position != lastPosition && !isUpdating)
        {
            isUpdating = true;
            StartCoroutine(UpdateMap());
        }
    }

    IEnumerator UpdateMap()
    {
        if (transform.position != lastPosition)
        {
            Bounds bR = GetComponent<Renderer>().bounds;
            Pathfinder.Instance.DynamicRaycastUpdate(lastBounds);
            Pathfinder.Instance.DynamicRaycastUpdate(bR);
            lastPosition = transform.position;
            lastBounds = bR;
            Debug.Log("Update NavMesh");
        }

        yield return new WaitForSeconds(UpdateTimer);

        isUpdating = false;
    }

    private void UpdateMapOnce()
    {
        Bounds bR = GetComponent<Renderer>().bounds;
        Pathfinder.Instance.DynamicRaycastUpdate(lastBounds);
        Pathfinder.Instance.DynamicRaycastUpdate(bR);
        lastPosition = transform.position;
        lastBounds = bR;
    }

    void OnDestroy()
    {
        UpdateMapOnce();
    }
}
