using UnityEngine;

public class Table : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.GetComponent<Card>().data.card_name);
    }
}
