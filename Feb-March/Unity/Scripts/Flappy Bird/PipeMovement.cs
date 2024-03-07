using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField] 
    private Transform pipeTransform;
    
    [SerializeField]
    private int deadZone = -16;

    // Update is called once per frame
    void Update()
    {
        pipeTransform.position += Vector3.left * (moveSpeed * Time.deltaTime);
        if (pipeTransform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
    