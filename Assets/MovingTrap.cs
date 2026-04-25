using UnityEngine;
public class MovingTrap : MonoBehaviour
{
    public float mesafe = 5f;
    public float hiz = 3f;
    Vector3 baslangicNoktasi;
    void Start()
    {
        baslangicNoktasi = transform.position;
    }
    void Update()
    {
        float hareket = Mathf.PingPong(Time.time * hiz, mesafe);
        transform.position = baslangicNoktasi + new Vector3(0, 0, hareket);
    }
}