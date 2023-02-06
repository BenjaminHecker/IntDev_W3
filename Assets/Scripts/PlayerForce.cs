using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForce : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;

    public Rigidbody2D armBody;

    private Rigidbody2D mainBody;

    public float power;

    public AudioSource audioSource;
    public AudioClip jumpClip;

    private void Start()
    {
        mainBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(jumpClip);
            armBody.AddForce(transform.up * power, ForceMode2D.Impulse);
        }

        Vector3 move = Vector3.zero;

        move.x += Input.GetAxisRaw("Horizontal");
        move.y += Input.GetAxisRaw("Vertical");

        mainBody.velocity = move.normalized * moveSpeed;
    }
}
