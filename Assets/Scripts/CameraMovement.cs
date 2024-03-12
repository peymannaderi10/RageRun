
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float currentPosX;


    [SerializeField] private Transform alex;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Update()
    {
        transform.position = new Vector3(alex.position.x + lookAhead, alex.position.y, transform.position.z);

        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * alex.localScale.x), Time.deltaTime * cameraSpeed);

    }

    public void MovetoStart(Transform _spawn) { 
    
        currentPosX = _spawn.parent.position.x;
    }


}

