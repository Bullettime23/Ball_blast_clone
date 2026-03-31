using Unity.Mathematics;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    [SerializeField] private Transform leftWheel;
    [SerializeField] private Transform rightWheel;
    [SerializeField] private float wheelRadius;


    private float initialPosition;
    
    void Start()
    {
        initialPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = initialPosition - transform.position.x;
        initialPosition = transform.position.x;
        RotateWheelsByDistance(distance);
    }

    private void RotateWheelsByDistance(float distance)
    {
        float euelr = distance * 180 / (math.PI * 0.5f);
        leftWheel.Rotate(new Vector3(0, 0, euelr));
        rightWheel.Rotate(new Vector3(0, 0, euelr));
    }
}
