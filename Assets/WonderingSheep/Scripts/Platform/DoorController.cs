using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Transform[] children;

    [SerializeField]
    private bool deactivateInStart;

    // Start is called before the first frame update
    void Start()
    {
        children = transform.GetComponentsInChildren<Transform>();

        if (deactivateInStart)
        {
            OpenDoors();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenDoors()
    {
        foreach (Transform c in children)
        {
            if (c.CompareTag(Tags.DOOR_TAG))
            {
                c.gameObject.GetComponent<Collider>().isTrigger = true;
            }
        }
    }
}
