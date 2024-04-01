using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform movePoint;

    private Vector3 startPosition;

    [SerializeField]
    private float smoothMovement = 0.3f;
    private float initialMovement;

    private bool smoothMovementHalfed;

    private bool can_Move;
    private bool move_To_Initial;

    [SerializeField]
    private float halfDistance = 15f;

    [SerializeField]
    private bool activateMovementInStart;

    [SerializeField]
    private float timer = 1f;

    void Awake()
    {
        startPosition = transform.position;
        initialMovement = smoothMovement;

        // activate doors

        // add sound
    }

    // Start is called before the first frame update
    void Start()
    {
        if (activateMovementInStart)
        {
            Invoke(nameof(ActivateMovement), timer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (can_Move)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, smoothMovement);

            if (Vector3.Distance(transform.position, movePoint.position) <= halfDistance)
            {
                if (!smoothMovementHalfed)
                {
                    smoothMovement /= 2f;
                    smoothMovementHalfed = true;
                }
            }

            if (Vector3.Distance(transform.position, movePoint.position) == 0f)
            {
                can_Move = false;

                if (smoothMovementHalfed)
                {
                    smoothMovement = initialMovement;
                    smoothMovementHalfed = false;
                }

                // deactivate doors

                // stop playing the sound FX
            }
        }
    }

    public void ActivateMovement()
    {
        can_Move = true;

        // play dound fx

        // rotate
    }
}
