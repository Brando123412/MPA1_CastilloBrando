using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchBall : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    [SerializeField] Touch touch;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                //isTouch = true;
                Vector3 mousePosition = touch.position;
                mousePosition.z = 2;
                Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                rb.MovePosition(objectPosition);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                rb.AddForce(rb.velocity.x,rb.velocity.y,1,ForceMode.Impulse);
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("piso"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
