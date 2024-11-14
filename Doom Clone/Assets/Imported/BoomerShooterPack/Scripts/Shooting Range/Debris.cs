using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    private Rigidbody rb;
    private Collider coll;

    private float lifetime = 5f;
    private float fadetime = 3f;
    
    void OnEnable(){
        rb = GetComponent<Rigidbody>();
        Invoke("DisablePhysics", lifetime);
    }

    private void DisablePhysics(){
        Destroy(rb);
        Destroy(coll);

        StartCoroutine(Fade());
    }

        IEnumerator Fade()
    {
        yield return new WaitForSeconds(lifetime);

        float percent = 0f;
        float fadeSpeed = 1f / fadetime;

        Renderer rend = GetComponent<Renderer>();

        foreach(Material mat in rend.materials)
        {
            Debug.Log(mat.name);
            Color initialColour = initialColour = mat.color;
            while(percent < 1f)
            {
                percent += Time.deltaTime * fadeSpeed;
                mat.color = Color.Lerp(initialColour, Color.clear, percent);
                yield return null;
            }
        }

        Destroy(gameObject);
    }
}
