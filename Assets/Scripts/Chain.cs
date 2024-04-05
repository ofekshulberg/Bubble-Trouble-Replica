using UnityEngine;

public class Chain : MonoBehaviour
{
    public Transform player;

    public float chainSpeed = 2f;

    public static bool isFired;

    void Start()
    {
        isFired = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isFired = true;
        }

        if (isFired)
        {
            transform.localScale = transform.localScale + Vector3.up * Time.deltaTime * chainSpeed;
        }

        else
        {
            transform.position = player.position;
            transform.localScale = new Vector3(1f, 0f, 1f);
        }
    }
}
