using UnityEngine;
using System.Collections;

public class becomeBatman : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.parent.SetParent(null); // become Batman
	}
}
