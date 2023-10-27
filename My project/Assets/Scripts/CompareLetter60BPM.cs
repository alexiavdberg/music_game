using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CompareLetter60BPM : MonoBehaviour
{
    private string haiku = $"Devant l’écran lisse\nJuste un épisode de plus\nNos yeux existent ";
    private int letterIndex = 0;
    private char typedLetter;
    private char currentLetter;
    private float range;
    public Pulse pulse;
    public TextMeshProUGUI haiku_text;
    private string debut;  // Texte correctement saisi
    private string fin;  // Texte restant à saisir
    private float score = 0;
    public float pourcentageScore1;
    private float maxScore;

    private void Start()
    {
        debut = "";
        fin = haiku;
        maxScore = haiku.Length;
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

        typedLetter = (char)0;
        pourcentageScore1 = (score * 100) / maxScore;
        AccesVariables._pourcentageScore1 = pourcentageScore1;

        if (fin.Length == 0)
        {
            Debug.Log($"Finito! Score : {pourcentageScore1}");
            SceneManager.LoadSceneAsync("EndScreen1");
        }
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
        score++;
    }

    private void IncorrectLetter()
    {
        debut += $"<color=red>{currentLetter}</color>";  // Ajoute la lettre correcte au texte correctement saisi
        fin = fin.Substring(1);  // Enlève la lettre correcte du texte restant
        UpdateTextMeshPro();  // Mise à jour de TextMeshProUGUI
    }
}