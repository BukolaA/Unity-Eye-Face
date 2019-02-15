using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float multiplier;
    float h;
    float v;

    [Header("Add your materials here")]
    [Tooltip("Array of Materials")]
    public Material[] matArray;
    private int matIndex = 0;

    private Renderer ren;

    // Use this for initialization
    void Start () {
		
	}   

    // Update is called once per frame
    void Update () {
        //RotateTransform();

        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
            ChangeMaterial();
        }
    }

    void FixedUpdate()
    {
        RotateTorque();
        MoveObject();
    }

    public void RotateTransform()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * multiplier);
        transform.Rotate(Vector3.up * Time.deltaTime * multiplier, Space.World);
    }

    public void RotateTorque()
    {
        h = Input.GetAxis("Horizontal") * multiplier * Time.deltaTime;
        v = Input.GetAxis("Vertical") * multiplier * Time.deltaTime;

        gameObject.GetComponent<Rigidbody>().AddTorque(transform.up * h);
        gameObject.GetComponent<Rigidbody>().AddTorque(transform.right * v);
    }

    public void MoveObject()
    {
        h = Input.GetAxis("Horizontal") * multiplier * Time.deltaTime;
        v = Input.GetAxis("Vertical") * multiplier * Time.deltaTime;
        gameObject.GetComponent<Transform>().Translate(transform.right * h * 0.1f);
    }

    public void ChangeMaterial()
    {
        ren = GetComponent<Renderer>();
        if (matIndex < 3)       
        {
            ren.material = matArray[matIndex];
            matIndex++;
        }else
        {
            matIndex = 0;
            ChangeMaterial();
        }
    }
    
}
