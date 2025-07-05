using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alvo : MonoBehaviour
{

    public SpriteRenderer sR;
    public bool isActive;

    [SerializeField] private int pointValue;

    private void Awake()
    {
        sR = GetComponent<SpriteRenderer>();
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isActive)
        {
            AlvoManager.score += pointValue;
            AlvoManager.instance.UpdtUI();
            Destroy(gameObject);
        }
    }
    
}
