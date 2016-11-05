using UnityEngine;
using System.Collections;

public class cameracontrol : MonoBehaviour
{

    public float moveSpeed = 2.0f;
    public float rotateSpeed = 2.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 currentPos = this.transform.position;
        bool keypressed = false;
        Vector3 moveDir = Vector3.zero;
        Vector3 rotateDir = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W))
            {
                rotateDir.x = rotateSpeed * Time.deltaTime;
                keypressed = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                rotateDir.x = -rotateSpeed * Time.deltaTime;
                keypressed = true;
            }

            if (Input.GetKey(KeyCode.A))
            {
                rotateDir.y = -rotateSpeed * Time.deltaTime;
                keypressed = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                rotateDir.y = rotateSpeed * Time.deltaTime;
                keypressed = true;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                rotateDir.z = -rotateSpeed * Time.deltaTime;
                keypressed = true;
            }

            if (Input.GetKey(KeyCode.E))
            {
                rotateDir.z = rotateSpeed * Time.deltaTime;
                keypressed = true;
            }

            if (keypressed)
            {
                this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles + rotateDir);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveDir += this.transform.forward * moveSpeed * Time.deltaTime;
                keypressed = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                moveDir += this.transform.forward * -moveSpeed * Time.deltaTime;
                keypressed = true;
            }

            if (Input.GetKey(KeyCode.A))
            {
                moveDir += this.transform.right * -moveSpeed * Time.deltaTime;
                keypressed = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                moveDir += this.transform.right * moveSpeed * Time.deltaTime;
                keypressed = true;
            }

            if (keypressed)
            {
                this.transform.position += moveDir;
            }
        }



    }
}
