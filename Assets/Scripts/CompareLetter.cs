using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompareLetter : MonoBehaviour
{
    private string targetPhrase = "bonjour le mondebonjour le mondebonjour le mondebonjour le mondebonjour le mondebonjour le mondebonjour le monde"; // Phrase que le joueur doit taper
    private int currentLetterIndex = 0; // Indice de la lettre en cours
    private float BPM = 60f;
    private float timeBetweenBeats; // Temps entre chaque battement en secondes
    private float nextBeatTime = 0f; // Temps du prochain battement
    private char eventChar;

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            // Debug.Log("Detected key code: " + e.keyCode);
            eventChar = e.character; // Obtenir la lettre correspondante à la touche pressée
        }
    }

    private void Start()
    {
        timeBetweenBeats = 60f / BPM;
    }

    private void Update()
    {
        // Faites défiler les lettres de la phrase en fonction du temps
        if (Time.time >= nextBeatTime)
        {
            char currentLetter = targetPhrase[currentLetterIndex];

            if (eventChar != null)
            {
                // char inputLetter = Input.inputString[0];
                Debug.Log(eventChar);

                if (eventChar == currentLetter)
                {
                    // La lettre correspond à la lettre en cours, c'est un succès !
                    Debug.Log("Lettre correcte : " + currentLetter);
                }
                else
                {
                    // La lettre ne correspond pas à la lettre en cours, c'est un échec.
                    Debug.Log("Lettre incorrecte : " + eventChar);
                }
            }

            currentLetterIndex++;

            if (currentLetterIndex >= targetPhrase.Length)
            {
                // Vous avez terminé de taper la phrase
                // Vous pouvez réinitialiser currentLetterIndex ici si vous souhaitez continuer le jeu.
                Debug.Log("Finito!");
            }

            // Mettre à jour le temps du prochain battement
            nextBeatTime += timeBetweenBeats;
        }
    }
}