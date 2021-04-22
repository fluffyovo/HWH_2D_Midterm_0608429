using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [Header("想吃甜甜圈的小熊")]
    public GameObject bearmi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "甜甜圈")
        {
            bearmi.SetActive(false);
            
        }
        Destroy(gameObject);
    }
}
