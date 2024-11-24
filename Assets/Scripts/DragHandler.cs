using UnityEngine;

public class DragHandler : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    public Animator characterAnimator;
    public string animationNameOnDrop = "stand_tocrouch";
    public string animationNameWhileDragging = "dragging";

    private Vector3 lastPosition; // For unneccessary drag placement
    public bool isDragging = false;

    void Start()
    {
        lastPosition = transform.position;
    }

    void OnMouseDown()
    {
        // For stopping drag once earthquake starts
        if (HorizontalEarthquake.isEarthquakeActive)
        {
            Debug.Log("Cannot drag during an earthquake!");
            return;
        }

        offset = transform.position - MouseWorldPosition();
        transform.GetComponent<Collider>().enabled = false;
        isDragging = true;

        // Play dragging animation
        if (characterAnimator != null && !string.IsNullOrEmpty(animationNameWhileDragging))
        {
            if (characterAnimator.HasState(0, Animator.StringToHash(animationNameWhileDragging)))
            {
                characterAnimator.Play(animationNameWhileDragging);
            }
        }
    }

    private void OnMouseDrag()
    {
        if (!isDragging) return;
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        if (!isDragging) return;

        isDragging = false;
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            if (hitInfo.transform.tag == destinationTag)
            {
                transform.position = hitInfo.transform.position;
                lastPosition = transform.position;

                if (characterAnimator != null)
                {
                    if (characterAnimator.HasState(0, Animator.StringToHash(animationNameOnDrop)))
                    {
                        characterAnimator.Play(animationNameOnDrop);
                    }
                    else
                    {
                        Debug.LogError("Animation state " + animationNameOnDrop + " not found in the Animator Controller.");
                    }
                }
            }
            else
            {
                transform.position = lastPosition;
            }
        }
        else
        {
            transform.position = lastPosition;
        }

        transform.GetComponent<Collider>().enabled = true;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}


//Uncomment for mobile input
/* using UnityEngine;

public class DragHandler : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    public Animator characterAnimator;
    public string animationNameOnDrop = "stand_tocrouch";
    public string animationNameWhileDragging = "dragging";

    private Vector3 lastPosition; // For unnecessary drag placement
    public bool isDragging = false;
    private int touchId = -1;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        if (HorizontalEarthquake.isEarthquakeActive)
        {
            if (isDragging)
            {
                // Reset if dragging during earthquake
                transform.position = lastPosition;
                isDragging = false;
            }
            return;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    OnTouchStart(touch);
                    break;

                case TouchPhase.Moved:
                    OnTouchMove(touch);
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    OnTouchEnd(touch);
                    break;
            }
        }
    }

    void OnTouchStart(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform == transform)
        {
            touchId = touch.fingerId;
            offset = transform.position - MouseWorldPosition(touch.position);
            transform.GetComponent<Collider>().enabled = false;
            isDragging = true;

            // Play dragging animation
            if (characterAnimator != null && !string.IsNullOrEmpty(animationNameWhileDragging))
            {
                if (characterAnimator.HasState(0, Animator.StringToHash(animationNameWhileDragging)))
                {
                    characterAnimator.Play(animationNameWhileDragging);
                }
            }
        }
    }

    void OnTouchMove(Touch touch)
    {
        if (isDragging && touch.fingerId == touchId)
        {
            transform.position = MouseWorldPosition(touch.position) + offset;
        }
    }

    void OnTouchEnd(Touch touch)
    {
        if (!isDragging || touch.fingerId != touchId) return;

        isDragging = false;
        touchId = -1;

        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.CompareTag(destinationTag))
            {
                transform.position = hitInfo.transform.position;
                lastPosition = transform.position;

                // Play drop animation
                if (characterAnimator != null)
                {
                    if (characterAnimator.HasState(0, Animator.StringToHash(animationNameOnDrop)))
                    {
                        characterAnimator.Play(animationNameOnDrop);
                    }
                    else
                    {
                        Debug.LogError("Animation state " + animationNameOnDrop + " not found in the Animator Controller.");
                    }
                }
            }
            else
            {
                transform.position = lastPosition;
            }
        }
        else
        {
            transform.position = lastPosition;
        }

        transform.GetComponent<Collider>().enabled = true;
    }

    Vector3 MouseWorldPosition(Vector2 screenPosition)
    {
        var mouseScreenPos = new Vector3(screenPosition.x, screenPosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
} */