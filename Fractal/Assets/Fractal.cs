using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour {

    public float childScale;
    public Mesh mesh;
    public Material material;
    public int maxDepth;
    private int depth;

    //Positions in array must macht the direction for orientation
    private static Vector3[] childDirections = { Vector3.up, Vector3.right, Vector3.left, Vector3.forward, Vector3.back };
    private static Quaternion[] childOrientations = { Quaternion.identity, Quaternion.Euler(0f, 0f, -90f), Quaternion.Euler(0f, 0f, 90f), Quaternion.Euler(90f, 0f, 0f), Quaternion.Euler(-90f, 0f, 0f) };

    // Use this for initialization
    void Start () {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        if (depth < maxDepth)
        {
            StartCoroutine(CreateChildren());
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator CreateChildren()    //Enumaerators are like iterators
    {
        for(int i =0; i < childDirections.Length; i++)
        {
            //Yield is used by iterator to track progress.
            yield return new WaitForSeconds(0.5f);  //Wait for a bit to draw the next part of the fractal
            new GameObject("Fractal child").AddComponent<Fractal>().Initialize(this, i);
        }
    }

    private void Initialize (Fractal parent, int childIndex)
    {
        mesh = parent.mesh;
        material = parent.material;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        transform.parent = parent.transform;
        childScale = parent.childScale;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
        transform.localRotation = childOrientations[childIndex];
    }

    
}
