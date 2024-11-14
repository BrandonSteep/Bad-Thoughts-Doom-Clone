using System.Collections;
using UnityEngine;

public class ShellCasing : MonoBehaviour
{
    [SerializeField] private float ForceMin = 0.1f;
    [SerializeField] private float ForceMax = 0.25f;
    [SerializeField] private float torque = 0.5f;
    [SerializeField] private Rigidbody rb;
    
    [SerializeField] private AudioClip casingSound;

    private float lifetime = 2f;
    private bool hasLanded = false;
    
    // private float fadetime = 1f; // Used to Fade over time - Only works if Material is set to Fade

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();

        if(rb == null){
            rb = this.gameObject.AddComponent<Rigidbody>();
            rb.mass = 0.1f;
        }

        AddForce();
    }

    private void AddForce()
    {
        float force = Random.Range(ForceMin, ForceMax);
        rb.AddForce((transform.right + new Vector3(0f, (force * 0.5f), 0f)) * force, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * (force * torque));

        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(lifetime);

        float fadePercent = 0f;
        float fadeTimer = 1f / lifetime;

        Vector3 fromScale = transform.localScale;

        while(fadePercent < 1f)
        {
            // Debug.Log(fadePercent);
            fadePercent += Time.deltaTime * fadeTimer;

            transform.localScale = Vector3.Lerp(fromScale, Vector3.zero, fadePercent);
            yield return null;
        }

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground" && !hasLanded)
        {
            hasLanded = true;
            this.gameObject.AddComponent<AudioSource>().PlayOneShot(casingSound);
            //GetComponent<Collider>().enabled = false;
            Destroy(rb, 1f);
        }
    }
}
