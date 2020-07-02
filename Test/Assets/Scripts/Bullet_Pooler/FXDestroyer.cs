using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestroyFx");
    }
    IEnumerator DestroyFx()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
