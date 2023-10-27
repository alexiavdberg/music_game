using UnityEngine;
using TMPro;

public class EndLevel3 : MonoBehaviour
{
    public TextMeshProUGUI textScore;

    private void Start()
    {
        textScore.text = $"Score : {(int)AccesVariables._pourcentageScore3}%"; 
    }
}