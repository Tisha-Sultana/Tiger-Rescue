using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI PointsText;
    [SerializeField] private GameManager manager; // Use private field with SerializeField to expose it in the Inspector
   // [SerializeField]TextMeshProUGUI finalScore; // Use TextMeshProUGUI for TextMeshPro components
void Start(){
Score();
}
    public void Score()
    {
       // gameObject.SetActive(true);
        //you cant activate an object that is disabled using that same object
        if (PointsText != null)
        {
            PointsText.text = manager.GetScore().ToString() + " Points!";
           // finalScore.text = score.ToString() + " Points"; // Update the final score text
        }
        else
        {
            Debug.LogError("PointsText is not assigned in the Inspector!");
        }
    }
}
