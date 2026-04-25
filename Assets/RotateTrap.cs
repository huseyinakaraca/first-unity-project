using UnityEngine;
public class RotateTrap : MonoBehaviour
{
    public float donusHizi = 100f;
    void Update()
    {
        transform.Rotate(0, donusHizi * Time.deltaTime, 0);
    }
}