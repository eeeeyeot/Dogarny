using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class StageManager : Singleton<StageManager>
{
    [System.Serializable]
    public class Stage
    {
        public string stageText;
        public int unLocked;
        public bool isInteractable;
        public int stars;

    }

    public Transform chaTransform;
    public string colliderName { get; set; }
    private NavMeshAgent agent;
    private string destination;


    public List<Stage> levelList;

    public GameObject button;

    public float perspectiveZoomSpeed = 0.5f;

    void Start()
    {
        agent = chaTransform.GetComponent<NavMeshAgent>();
        destination = "Town";
    }


    public void StageMove(Vector3 position)
    {
        agent.SetDestination(position);
    }

    public void Destination(string desti)
    {
        destination = desti;
    }

    void Update()
    {
        //if (Input.GetMouseButtonUp(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit, 100.0f, 1 << LayerMask.NameToLayer("MoveAgent")))
        //    {
        //        //Debug.Log(hit.transform.gameObject.name);
        //        Destination(hit.transform.name);
        //        StageMove(hit.point);
        //    }
        //}

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f, 1 << LayerMask.NameToLayer("MoveAgent")))
            {
                //Debug.Log(hit.transform.gameObject.name);
                Destination(hit.transform.name);
                StageMove(hit.point);
            }
        }
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudediff = prevTouchDeltaMag = touchDeltaMag;

            Camera.main.fieldOfView += deltaMagnitudediff * perspectiveZoomSpeed;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 7.0f, 20.0f);
        }

    }

    public void CheckStage(string name)
    {
        colliderName = name;
        if (destination == name)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }
}
