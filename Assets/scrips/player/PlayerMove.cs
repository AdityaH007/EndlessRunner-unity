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

        // Set initial position and rotation
        transform.position = new Vector3(-0.98f, -7.635f, -14.13f);
        transform.rotation = Quaternion.identity;  // Set to zero rotation

        // Set initial position of character model relative to the player
        playerObject.transform.localPosition = new Vector3(0f, -1.166364f, 0f);
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
        float forwardMovementDuringJump = 2f;

        Vector3 originalPosition = transform.position;
        Quaternion originalRotation = playerObject.transform.rotation;  // Store the original rotation of the player model

        float elapsedTime = 0f;

        while (elapsedTime < 0.45f)
        {
            // Calculate the vertical position using a sine wave for a smooth jump
            float verticalPosition = originalPosition.y + jumpHeight * Mathf.Sin((elapsedTime / 0.45f) * Mathf.PI);

            // Move the player to the new position
            transform.position = new Vector3(transform.position.x, verticalPosition, transform.position.z);

            // Move the player forward in the local Z-axis
            transform.Translate(Vector3.forward * Time.deltaTime * forwardMovementDuringJump, Space.Self);

            // Keep the original rotation during the jump
            playerObject.transform.rotation = originalRotation;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is set to the ground level
        transform.position = new Vector3(transform.position.x, -7.7f, transform.position.z);

        isJumping = false;
        comingDown = false;

        // Ensure the final rotation is set to the original rotation
        playerObject.transform.rotation = originalRotation;

        playerObject.GetComponent<Animator>().Play("Two Cycle Sprint");
    }

}
