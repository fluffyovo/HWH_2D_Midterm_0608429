using UnityEngine;

public class TriggerArea : MonoBehaviour
{

    [Header("想吃甜甜圈的小熊")]
    public GameObject bearmi;
    public GameObject bearmi2;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "甜甜圈")
        {
            bearmi.SetActive(false);
            bearmi2.SetActive(true);
            //Destroy(gameObject);
            
        }
    }
}
