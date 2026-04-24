using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; 
        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            if (horizontal != 0 || vertical != 0)
            {
                Debug.Log("Klavye algýlandý! Yatay: " + horizontal + " Dikey: " + vertical);
            }
            Vector3 movement = new Vector3(horizontal, 0f, vertical);
            transform.Translate(movement * speed * Time.deltaTime);
        }
}