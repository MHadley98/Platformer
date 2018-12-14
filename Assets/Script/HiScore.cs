using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using statement for unity ui code
using UnityEngine.UI;

public class HiScore : MonoBehaviour {

    //text components used to display hiscores
    public List<Text> hiScoreDisplays = new List<Text>();

    //internal data for score values
    private List<int> hiScoreData = new List<int>();



	// Use this for initialization
	void Start ()
    {

        //load hiscore data from player prefs
        LoadHiScoreData();

        //get current score from player prefs
        int currentScore = PlayerPrefs.GetInt("score", 0);

        //Check if we got a new hiscore
        bool haveNewHiScore = IsNewHiScore(currentScore);
        if (haveNewHiScore == true)
        {

            //Add new score to the data
            AddScoreToList(currentScore);

            //save updated data
            SaveHiScoreData();

        }

        //update th evisual display
        UpdateVisualDisplay();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LoadHiScoreData()
    {

        for (int i = 0; i<hiScoreDisplays.Count; ++i)
        {
            //using loop index, get the name for player prefs key
            string prefsKey = "hiScore" + i.ToString();

            //use this key to get the hiscore value from player prefs
            int hiScoreValue = PlayerPrefs.GetInt(prefsKey, 0);

            //store this score value in our internal data list
            hiScoreData.Add(hiScoreValue);
        }

    }

    private void UpdateVisualDisplay()
    {
        for (int i = 0; i < hiScoreDisplays.Count; ++i)
        {
            //find specific text and numbers in our list
            //set the text to the numerical score
            hiScoreDisplays[i].text = hiScoreData[i].ToString();
        }
    }

    private bool IsNewHiScore(int scoreToCheck)
    {
        //loop through hiscores and see if ours is higher than any of them
        for (int i = 0; i < hiScoreDisplays.Count; ++i)
        {
            //is our score higher than the hiscore we're checking this loop?
           if (scoreToCheck > hiScoreData[i])
            {
                //score is higher
                //return that we do have hiscore
                return true;
            }
        }

        //default: false
        //return that we don't have a hiscore
        return false;
    }

    private void AddScoreToList(int newScore)
    {
        //loop through the hiscorew and find where the new score fits
        for(int i = 0; i < hiScoreDisplays.Count; ++i)
        {
            //is our score higher than score we're checking in the list
            if (newScore > hiScoreData[i])
            {
                //our score IS higher
                //since we're going from highest to lowest the first time our score is higher, this is where it must go

                //insert our score into the list here
                hiScoreData.Insert(i, newScore);

                //trim the last item off the list
                hiScoreData.RemoveAt(hiScoreData.Count-1);

                //we're done, we must exit early
                return;

            }
        }
    }

    private void SaveHiScoreData()
    {

        for (int i = 0; i < hiScoreDisplays.Count; ++i)
        {
            //using loop index, get the name for player prefs key
            string prefsKey = "hiScore" + i.ToString();

            //get the current hiscore entry from the data
            int hiScoreEntry = hiScoreData[i];

            //save this data to the playerprefs
            PlayerPrefs.SetInt(prefsKey, hiScoreEntry);
        }

        //save the playerprefs to disc
        PlayerPrefs.Save();

    }

}
