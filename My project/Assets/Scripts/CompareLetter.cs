using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompareLetter : MonoBehaviour
{
    private string haiku = $"Téléphone en main";
    private int letterIndex = 0;
    private char typedLetter;
    private char currentLetter;
    private float range;
    public Pulse pulse;
    public TextMeshProUGUI haiku_text;
    private string debut;  // Texte correctement saisi
    private string fin;  // Texte restant à saisir

    private void Start()
    {
        debut = "";
        fin = haiku;
        UpdateTextMeshPro();  // Mise à jour du TextMeshProUGUI
    }

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            typedLetter = e.character; // Obtenir la lettre de la touche pressée
        }
        else
        {
            typedLetter = (char)0;
        }
    }

    private void Update()
    {
        range = pulse.range;
        currentLetter = fin[0];  // La lettre actuelle est celle à l'indice 0 du texte restant

        if ((range >= 3f && range < 3.2f || range > 4.8f && range <= 5f) && typedLetter != (char)0)
        {
            // Debug.Log($"Entré : {typedLetter}  Attendu : {currentLetter}");

            if (typedLetter == currentLetter)
            {
                CorrectLetter();
            }
            else
            {
                // Debug.Log($"Lettre incorrecte : {typedLetter}");
                IncorrectLetter();
            }
        }
        else if ((range >= 3.2f && range <= 4.8f) && typedLetter != (char)0)
        {
            // Debug.Log($"Mauvais timing : {currentLetter}");
            IncorrectLetter();
        }

        if (fin.Length == 0)
        {
            Debug.Log("Finito!");
        }

        typedLetter = (char)0;
    }

    private void UpdateTextMeshPro()
    {
        haiku_text.text = $"{debut}{fin}";
    }

    private void CorrectLetter()
    {
        debut += $"<color=green>{currentLetter}</color>";  // Ajoute la lettre correcte au texte correctement saisi
        fin = fin.Substring(1);  // Enlève la lettre correcte du texte restant
        UpdateTextMeshPro();  // Mise à jour de TextMeshProUGUI
    }

    private void IncorrectLetter()
    {
        debut += $"<color=red>{currentLetter}</color>";  // Ajoute la lettre correcte au texte correctement saisi
        fin = fin.Substring(1);  // Enlève la lettre correcte du texte restant
        UpdateTextMeshPro();  // Mise à jour de TextMeshProUGUI
    }
}