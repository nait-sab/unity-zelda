using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurMouvement : MonoBehaviour
{
    // Composants
    public float vitesse;
    public Rigidbody2D physique;
    public Animator animateur;

    // Variables
    private Vector3 deplacement;

    void Start()
    {
        deplacement = Vector3.zero;
    }

    void Update()
    {
        deplacement = Vector3.zero;
        deplacement.x = Input.GetAxis("Horizontal");
        deplacement.y = Input.GetAxis("Vertical");
        UpdateDeplacement();
    }

    void UpdateDeplacement()
    {
        animateur.SetBool("mouvement", deplacement != Vector3.zero);

        if (deplacement != Vector3.zero)
        {
            DeplacerJoueur();
            animateur.SetFloat("deplacementX", deplacement.x);
            animateur.SetFloat("deplacementY", deplacement.y);
        } 
    }

    void DeplacerJoueur()
    {
        physique.MovePosition(transform.position + deplacement * vitesse * Time.deltaTime);
    }
}
