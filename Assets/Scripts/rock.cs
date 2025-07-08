using UnityEngine;

public class rock : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
       if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
