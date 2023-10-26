using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompareLetter : MonoBehaviour
{
    private string haiku = "bonjour";
    private int letterIndex = 0;
    private char typedLetter;
    public float range;
    public Pulse pulse;

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            // Debug.Log("Detected key code: " + e.keyCode);
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

        char currentLetter = haiku[letterIndex];

        // Faites défiler les lettres de la phrase en fonction du temps
        if ((range >= 3f && range < 3.5f || range > 4.5f && range <= 5f) && typedLetter != (char)0)
        {
            // char inputLetter = Input.inputString[0];
            Debug.Log($"Entré : {typedLetter}  Attendu :{currentLetter}");


            if (typedLetter == currentLetter)
            {
                Debug.Log($"Lettre correcte : {currentLetter}");
            }
            else
            {
                Debug.Log($"Lettre incorrecte : {typedLetter}");
            }
            letterIndex++;
        }
        else if ((range >= 3.5f && range <= 4.5f) && typedLetter != (char)0)
        {
            Debug.Log($"Mauvais timing : {currentLetter}");
            letterIndex++;
        }

        if (letterIndex == haiku.Length)
        {
            Debug.Log("Finito!");
        }

        typedLetter = (char)0;
    }
}