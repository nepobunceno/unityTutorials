using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {
    public Transform pointPrefab;   //Create a prefabricated object to transform
    [Range(10,1000)] public int resolution = 10; //Use 10 cubes to create the graph
    Transform[] points;

    private void Awake()
    {
        points = new Transform[resolution];

        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step; //Reduce size of the cube  
        Vector3 position;
        
        position.z = 0f;
        position.y = 0f;

        for (int i = 0; i < resolution; i++){
            Transform point = Instantiate(pointPrefab);   //Reference to the newly created object
            position.x = (i+.05f) * step - 1f; //Set initial position to -1
            //position.y = position.x * position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform,false); //Set parent as the prefabricated transform.
            points[i] = point;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i =0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
            point.localPosition = position;
        }
	}
}
