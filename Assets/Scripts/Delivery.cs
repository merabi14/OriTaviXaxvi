using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = Color.green;
    [SerializeField] Color32 noPackageColor = Color.white;

    bool hasPackage = false;

    SpriteRenderer SpriteRenderer;

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            Destroy(collision.gameObject);
            hasPackage = true;
            Debug.Log("Package has been taken");
            SpriteRenderer.color = hasPackageColor;
        }
        else if (collision.tag == "Customer" && hasPackage)
        {
            Destroy(collision.gameObject);
            hasPackage = false;
            Debug.Log("Package has been delivered");
            SpriteRenderer.color = noPackageColor;
        }
    }
}
