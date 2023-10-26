using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AffichageTexte : MonoBehaviour
{
    public TextMeshProUGUI textObject; // Référence à l'objet TextMeshProUGUI dans l'inspecteur Unity

    private string[] textArray = new string[]
    {
        "M","O","N"," ","H","A","I","K","U"

    };

    private void Start()
    {
        if (textObject == null)
        {
            Debug.LogError("Veuillez assigner un objet TextMeshProUGUI dans l'inspecteur Unity.");
            return;
        }

        // Assurez-vous que le tableau n'est pas vide
        if (textArray != null && textArray.Length > 0)
        {
            // Concaténez tous les éléments du tableau en une seule ligne horizontale
            string concatenatedText = string.Join(" ", textArray);

            // Affichez le texte dans l'objet TextMeshProUGUI
            textObject.text = concatenatedText;
        }
    }
}