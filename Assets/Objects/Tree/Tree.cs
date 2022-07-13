using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float health = 9;
    // public GameObject treeRoot;
    private Color defaultColor;

    SpriteRenderer sprite;

    public float Health
    {
        set
        {
            health = value;

            if (health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        defaultColor = sprite.color;
    }
    public void Hit(float damage)
    {
        Health -= damage;
        StartCoroutine("SwitchColor");
    }

    IEnumerator SwitchColor()
    {
        sprite.color = new Color(0, 0, 0, 0.6f);
        yield return new WaitForSeconds(0.10f);
        sprite.color = defaultColor;
    }

    public void Defeated()
    {
        // gameObject.SetActive(false);
        // treeRoot.SetActive(true);
        RemoveObject();
    }

    public void RemoveObject()
    {
        Destroy(gameObject);
    }
}
