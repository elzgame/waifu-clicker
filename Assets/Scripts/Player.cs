using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera cam;
    public AudioClip sound;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        cam = FindObjectOfType<Camera>();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                GameManager.source.PlayOneShot(sound);
                GameManager.score++;
                hit.transform.gameObject.GetComponent<Player>().anim.Play("Idle");
                hit.transform.gameObject.GetComponent<Player>().anim.Play("Player");
            }
        }
    }
}
