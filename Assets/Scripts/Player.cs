using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // config params
    [SerializeField] Rigidbody player;
    [SerializeField] Camera mainCamera;
    [SerializeField] float playerPushSpeed;
    [SerializeField] float playerSlideSpeed;

    void FixedUpdate()
    {
        player.AddForce(0f, 0f, playerPushSpeed * Time.deltaTime);
        mainCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.211f, player.transform.position.z - 0.454f);
        if (player.transform.position.y < 0f)
        {
            FindObjectOfType<GameManager>().Invoke("RestartGame", 0.4f);
        }
        RespondTouch();
    }

    private void RespondTouch()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x > Screen.width / 2)
            {
                player.AddForce(playerSlideSpeed * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
            }
            if (touch.position.x < Screen.width / 2)
            {
                player.AddForce(-playerSlideSpeed * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Side Wall" || collision.collider.tag=="Obstacle")
        {
            FindObjectOfType<GameManager>().Invoke("RestartGame", 0.4f);
        }
    }
}