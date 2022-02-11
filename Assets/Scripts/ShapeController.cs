using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeController : MonoBehaviour
{
    bool controlActive=true;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controlActive)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                StartCoroutine(GiraDer());
                
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                StartCoroutine("GiraIzq");
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                StartCoroutine("GiraBot");
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                StartCoroutine("GiraBot");
            }
        }
        
    }

    IEnumerator GiraDer() {
        controlActive = false;
        float cont = 0;
        //Quaternion initial= parent.transform.rotation;
        //Quaternion final = parent.transform.rotation * Quaternion.Euler(0,90,0); ;
        //parent.transform.Rotate(0, 90, 0);
        parent.transform.RotateAround(parent.transform.position, Vector3.up, 90);
        //while (cont<1)
        //{
        //    parent.transform.rotation = Quaternion.Lerp(initial, final, cont);
        //    cont += Time.deltaTime*0.01f;
        //    Debug.Log(cont);
        //}

        yield return new WaitForSeconds(.3f);
        controlActive = true;
    }

    IEnumerator GiraIzq()
    {
        controlActive = false;
        //parent.transform.Rotate(0, -90, 0);
        parent.transform.RotateAround(parent.transform.position, Vector3.up, -90);
        yield return new WaitForSeconds(.3f);
        controlActive = true;
    }

    IEnumerator GiraTop()
    {
        controlActive = false;
        parent.transform.RotateAround(parent.transform.position, Vector3.right, 90);
        yield return new WaitForSeconds(.3f);
        parent.transform.Rotate(0, 0, 90);
        controlActive = true;
    }

    IEnumerator GiraBot()
    {
        controlActive = false;
        parent.transform.RotateAround(parent.transform.position, Vector3.right, -90);
        yield return new WaitForSeconds(.3f);
        //parent.transform.Rotate(0, 0, -90);
        controlActive = true;
    }
}
