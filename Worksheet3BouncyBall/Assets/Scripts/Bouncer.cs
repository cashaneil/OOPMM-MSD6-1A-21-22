using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    //int for bouncer's hitpoints
    public int bouncerHP = 100;

    //variable of type rigidbody2d to store rigibody2d component
    Rigidbody2D myrb;

    //variable of type spriterenderer to store spriterenderer component
    SpriteRenderer m_SpriteRenderer;

    //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;
    //These are the values that the Color Sliders return
    float m_Red = 1f;
    float m_Green = 0.4f;
    float m_Blue = 0f;
    float m_Alpha = 1f;

    // Start is called before the first frame update
    void Start()
    {
        myrb = this.gameObject.GetComponent<Rigidbody2D>();

        //to add force to move circle to left
        myrb.velocity = new Vector2(-3.0f, 0.0f);

        //setup components for controlling color
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if bouncer's HP is less than or equal to 0, destroy game object
        if (bouncerHP <=0)
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D mycollider)
    {
        //on collision, reduce bouncer's hp by 10
        DamageandOpacity();
    }

    public void DamageandOpacity()
    {
        bouncerHP -= 10; //reduce bouncerHP by 10
        Debug.Log("Bouncer's HP: " + bouncerHP); //print out new HP

        m_Alpha -= 0.1f; //reduce alpha color by 0.1
        Debug.Log("New Alpha: " + m_Alpha);

        //Set the Color to the values gained from the Sliders
        m_NewColor = new Color(m_Red, m_Green, m_Blue, m_Alpha);

        //Set the SpriteRenderer to the Color defined by the Sliders
        m_SpriteRenderer.color = m_NewColor;
    }

    public void Die()
    {
        Destroy(gameObject);
        Debug.Log("Bouncer Has Died");
    }
}
