using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour {

    public float childScale;
    public Mesh mesh;
    public Material material;
    public int maxDepth;
    private int depth;

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
        //Yield is used by iterator to track progress.
        yield return new WaitForSeconds(0.5f);  //Wait for a bit to draw the next part of the fractal
        new GameObject("Fractal child").AddComponent<Fractal>().Initialize(this, Vector3.up);
        yield return new WaitForSeconds(0.5f);
        new GameObject("Fractal child").AddComponent<Fractal>().Initialize(this, Vector3.right);
    }

    private void Initialize (Fractal parent, Vector3 direction)
    {
        mesh = parent.mesh;
        material = parent.material;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        transform.parent = parent.transform;
        childScale = parent.childScale;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = direction * (0.5f + 0.5f * childScale);
    }
}
