using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    bool isGrounded = true;
    bool isGameOver = false;
    public Transform cameraTransform;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI loseText;
    int score = 0;
    void Update()
    {
        if (isGameOver) return; 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();
        Vector3 moveDirection = (camForward * vertical + camRight * horizontal).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // AJAN 1: Küp herhangi bir þeye çarptýðý an Konsol'a adýný ve etiketini yazdýracak!
        Debug.Log("KÜP ÞUNA ÇARPTI: " + collision.gameObject.name + " | ETÝKETÝ: " + collision.gameObject.tag);

        if (collision.gameObject.name == "Plane")
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy") && !isGameOver)
        {
            // AJAN 2: Eðer çarptýðý þeyin etiketi gerçekten Enemy ise bunu yazdýracak!
            Debug.Log("DÜÞMANA ÇARPIÞMA ONAYLANDI! Kaybetme ekraný tetikleniyor...");
            StartCoroutine(LoseRoutine());
        }
    }
    IEnumerator LoseRoutine()
    {
        isGameOver = true;
        loseText.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "Skor: " + score;
            if (score >= 3)
            {
                scoreText.text = "TEBRÝKLER!";
                Time.timeScale = 0;
            }
        }
    }
}