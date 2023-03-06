using UnityEngine;
using TMPro;


public class RoundUI : MonoBehaviour
{
	public TMP_Text roundText;

	public int totalWave;

   
    // Update is called once per frame
    void Update()
	{
		roundText.text = PlayerStats.Rounds.ToString() + "/"+ totalWave + " Wave";
	}
}
