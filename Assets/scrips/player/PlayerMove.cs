using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3;
    public float leftRightSpeed = 6;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;

    public Button leftButton;
    public Button rightButton;
    public Button jumpButton;

    void Start()
    {
        // Subscribe to button click events
        leftButton.onClick.AddListener(MoveLeft);
        rightButton.onClick.AddListener(MoveRight);
        jumpButton.onClick.AddListener(Jump);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        // Button for moving left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        // Button for moving right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        // Button for jumping
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        if (isJumping == true)
        {
            // No additional movement during jump
        }
    }

    void MoveLeft()
    {
        if (this.gameObject.transform.position.x != LevelBoundary.leftSide)
        {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
        }
    }

    void MoveRight()
    {
        if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
        {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
        }
    }

    void Jump()
    {
        if (isJumping == false)
        {
            isJumping = true;
            playerObject.GetComponent<Animator>().Play("jump");
            StartCoroutine(Jumpseq());
        }
    }
    IEnumerator Jumpseq()
    {
        float jumpHeight = 3f;

        Vector3 originalPosition = transform.position;
        Quaternion originalRotation = transform.rotation;

        yield return new WaitForSeconds(0.45f);

        float elapsedTime = 0f;
        while (elapsedTime < 0.45f)
        {
            transform.position = originalPosition + Vector3.up * jumpHeight * Mathf.Sin((elapsedTime / 0.45f) * Mathf.PI);
            transform.rotation = originalRotation;  // Keep the original rotation during the jump
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isJumping = false;
        comingDown = false;
        transform.rotation = originalRotation;  // Ensure the final rotation is set to the original rotation
        playerObject.GetComponent<Animator>().Play("Two Cycle Sprint");
    }


}
