using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckControler : MonoBehaviour
{
    public float xSpeed = 0;
    public float xSpeedrandom = 0.25f;
    private float ySpeed = 0;
        private bool isAlive = true;
    private SpriteRenderer theSpriteRender;
    Collider2D m_Collider;
    // Start is called before the first frame update
    void Start()
    {
        theSpriteRender = GetComponent<SpriteRenderer>();
        m_Collider = GetComponent<Collider2D>();
        xSpeed = xSpeed + Random.Range(-xSpeedrandom, xSpeedrandom);
        if (xSpeed >= 0) theSpriteRender.flipX = true;
        else theSpriteRender.flipX = false;
        StartCoroutine(ChangeDirection(Random.Range(2.5f, 4f)));
        Invoke("Disappear", 20);
    }

    void LateUpdate()
    {
        transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0f);
    }

    public void setDirection(float dir)
    {
        xSpeed *= dir;
    }

    public void GetDown()
    {
        isAlive = false;
        m_Collider.enabled = false;
        theSpriteRender.flipY = true;
        ySpeed = -1f;
        StartCoroutine(DisappearSec(0.7f));
        Destroy(GetComponent<Animator>());
        StartCoroutine(PlaySound(0.3f));
    }

    IEnumerator DisappearSec(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(GameObject);
    }
    IEnumerator PlaySound(float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<AudioSource>().Play();
    }
    IEnumerator ChangeDirection(float time)
    {
        yield return new WaitForSeconds(time);
        if (isAlive) ySpeed = Mathf.Abs(xSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
