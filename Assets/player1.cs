
using UnityEngine;
using UnityEngine.SceneManagement;

public class player1 : MonoBehaviour
{
    public Rigidbody2D rb;

    public float JumpForce;

    public SpriteRenderer sp;

    public Color cyan;
    public Color pink;
    public Color magenta;
    public Color yellow;

    public GameObject circle;
    public GameObject colorChanger;

    private string currentColor;

    private void Start()
    {
        RandomColor();
    }

    private void RandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sp.color = cyan;
                break;
            case 1:
                sp.color = pink;
                currentColor = "Pink";
                break;
            case 2:
                currentColor = "Magenta";
                sp.color = magenta;
                break;
            case 3:
                currentColor = "Yellow";
                sp.color = yellow;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            if (rb.gravityScale.Equals(0))
            {
                rb.gravityScale = 2;
            }
            rb.velocity = Vector2.up * JumpForce;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ColorChanger")
        {
            RandomColor();
            Destroy(col.gameObject);
            Instantiate(circle , new Vector2(0, transform.position.y + 5), Quaternion.identity);
            Instantiate(colorChanger , new Vector2(0, transform.position.y + 9), Quaternion.identity).GetComponent<Collider2D>().enabled = true;
            return;
        }
        if (col.tag != currentColor)
        {
            Debug.Log("YOU LOSE!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
