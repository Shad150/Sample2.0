using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeController : MonoBehaviour
{
    private CameraShake _camShake;
    [SerializeField] private float _shakeDuration;
    [SerializeField] private float _shakeIntensity;

    private bool controlActive=true, reversed;
    public GameObject parent;
    public Transform targetDir;
    private Vector3 targetDegrees;
    [SerializeField] private float duration = 0.5f;

    private void Start()
    {
        _camShake = FindObjectOfType<CameraShake>();
    }

    void Update()
    {
        if (controlActive)
        {
            //print("b");
            if (Input.GetAxis("Horizontal") > 0)
            {
                //StartCoroutine(Gira(parent.transform.forward * 45f));
                controlActive = false;
                targetDegrees = Vector3.up * -90f;
                targetDir.Rotate(targetDegrees, Space.World);
                StartCoroutine(Gira());
                StartCoroutine(_camShake.Shake(_shakeDuration, _shakeIntensity));
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                //StartCoroutine(Gira(parent.transform.forward * -45f));
                controlActive = false;
                targetDegrees = Vector3.up * 90f;
                targetDir.Rotate(targetDegrees, Space.World);
                StartCoroutine(Gira());
                StartCoroutine(_camShake.Shake(_shakeDuration, _shakeIntensity));
            }
            else if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(1))
            {
                //StartCoroutine(Gira(parent.transform.forward * 45f));
                controlActive = false;
                targetDegrees = Vector3.forward * -90f;
                targetDir.Rotate(targetDegrees, Space.World);
                StartCoroutine(Gira());
                StartCoroutine(_camShake.Shake(_shakeDuration, _shakeIntensity));
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
            {
                //StartCoroutine(Gira(parent.transform.forward * -45f));
                controlActive = false;
                targetDegrees = Vector3.forward * 90f;
                targetDir.Rotate(targetDegrees, Space.World);
                StartCoroutine(Gira());
                StartCoroutine(_camShake.Shake(_shakeDuration, _shakeIntensity));
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                //StartCoroutine(Gira(parent.transform.right * 45f));
                controlActive = false;
                targetDegrees = Vector3.right * 90f;
                targetDir.Rotate(targetDegrees, Space.World);
                StartCoroutine(Gira());
                StartCoroutine(_camShake.Shake(_shakeDuration, _shakeIntensity));
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                //StartCoroutine(Gira(parent.transform.right * -45f));
                controlActive = false;
                targetDegrees = Vector3.right * -90f;
                targetDir.Rotate(targetDegrees, Space.World);
                StartCoroutine(Gira());
                StartCoroutine(_camShake.Shake(_shakeDuration, _shakeIntensity));
            }
        }
        //else
        //{
        //    //print((parent.transform.rotation * Quaternion.Inverse(targetDir.rotation)).eulerAngles.magnitude % 359);
        //    float diff = Vector3.Distance(parent.transform.rotation.eulerAngles, targetDir.rotation.eulerAngles);
        //    print(diff%90);
        //    if (reversed)
        //    {
        //        if (diff % 90 < 5)
        //        {
        //            print("a");
        //            parent.transform.rotation = targetDir.rotation;
        //            controlActive = true;
        //        }
        //    }
        //    else
        //    {
        //        if (diff % 90 -90f < 5)
        //        {
        //            print("a");
        //            parent.transform.rotation = targetDir.rotation;
        //            controlActive = true;
        //        }
        //    }


        //    parent.transform.Rotate(targetDegrees * Time.deltaTime, Space.World);

        //}


        IEnumerator Gira()
        {
            controlActive = false;
            Quaternion initial = parent.transform.rotation;

            for (float i = 0; i < duration; i += Time.deltaTime)
            {
                parent.transform.rotation = Quaternion.Slerp(initial, targetDir.rotation, i / duration);
                yield return null;
            }
            parent.transform.rotation = targetDir.rotation;
            //parent.transform.Rotate(0, -90, 0);
            //parent.transform.RotateAround(parent.transform.position, Vector3.up, -90);
            //parent.transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * Quaternion.Euler(0, -90, 0), 0.3f);
            yield return new WaitForSeconds(.2f);
            controlActive = true;
        }
    }
}
