using UnityEngine;
using System.Collections;

public class RandomTexture : MonoBehaviour {

    public Texture2D[] TextureList;

    void Start()
    {
        GetComponent<Renderer>().material.SetTexture("_MainTex", TextureList[Random.Range(0, TextureList.Length)]);
    }
}
