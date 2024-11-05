using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Movement_Menu : MonoBehaviour
{
    public Renderer meshRenderer; // Renderer to access the material's texture offset
    public float speed = 1f; // Speed at which the road texture moves

    // Update is called once per frame
    void Update()
    {
        // Move the texture offset of the material to create the road movement effect
        meshRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
