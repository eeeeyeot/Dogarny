using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Character : MonoBehaviour
{
    private float offsetX = 10.0f;
    private float offsetY = 9.0f;
    private float offsetZ = 6.0f;

    public void OnEnable()
    {
        Camera.main.transform.position = this.transform.position + new Vector3(offsetX, offsetY, offsetZ);
        Camera.main.transform.rotation = Quaternion.Euler(new Vector3(45.0f, -90.0f, 0.0f));
    }
    public void OnTriggerEnter(Collider other)
    {
        StageManager.Instance.CheckStage(other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        StageManager.Instance.CheckStage(other.name);
    }

    public void Update()
    {
        //Camera.main.transform.position = this.transform.position + new Vector3(offsetX, offsetY, 0.0f);
    }
}
