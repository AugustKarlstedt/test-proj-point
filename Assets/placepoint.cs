using UnityEngine;
using System.Collections;

public class placepoint : MonoBehaviour
{

    public float maxDist = 10000;

    public float moveSpeed = 8.0f;

    public GameObject point;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // THE INTERESTING BITS

        // Check if we left-click
        // This part simply handles placing the point on the cube when hit
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from our current camera position forward
            Ray r = new Ray(this.transform.position, this.transform.forward);
            RaycastHit info = new RaycastHit();

            // If we hit something
            if (Physics.Raycast(r, out info, maxDist))
            {
                // Set our point to exactly where it hit
                point.transform.position = info.point;
            }
        }

        // THE REALLY INTERESTING PARTS
        
        // Transform our point into CAMERA space
        Vector3 pointPos = this.transform.InverseTransformPoint(point.transform.position);

        bool keypressed = false;
        Vector3 moveDir = Vector3.zero;

        // now that we're in CAMERA space, we can simply move in 3d space
        // EXACTLY as we see it. Y is up/down, X is left/right, Z is forward/back

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDir.y = moveSpeed * Time.deltaTime;
            keypressed = true;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDir.y = -moveSpeed * Time.deltaTime;
            keypressed = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDir.x = -moveSpeed * Time.deltaTime;
            keypressed = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDir.x = moveSpeed * Time.deltaTime;
            keypressed = true;
        }

        if (Input.GetKey(KeyCode.PageUp))
        {
            moveDir.z = moveSpeed * Time.deltaTime;
            keypressed = true;

        }

        if (Input.GetKey(KeyCode.PageDown))
        {
            moveDir.z = -moveSpeed * Time.deltaTime;
            keypressed = true;
        }

        if (keypressed)
        {
            // now we want to update the point's position, but we've made our calculations in CAMERA space
            // so we have to transform CAMERA space BACK into the LOCAL space of the point 
            point.transform.position = this.transform.TransformPoint(pointPos + moveDir);
        }

    }
}
