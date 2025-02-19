﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParserStarter : MonoBehaviour
{
    public string filename;

    public GameObject Rock;

    public GameObject Brick;

    public GameObject QuestionBox;

    public GameObject Stone;

    public GameObject Skybox;
    public GameObject Water;
    public GameObject Finish;
    public GameObject Coin;

    public Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        RefreshParse();
    }


    private void FileParser()
    {
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;

            while ((line = sr.ReadLine()) != null)
            {
                int column = 0;
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {
                    column++;
                    //Call SpawnPrefab
                    SpawnPrefab(letter,new Vector3(column, -row, 0));
                }

                row++;

            }

            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;

        switch (spot)
        {
            case 'b': Debug.Log("Spawn Brick");
                ToSpawn = Brick;
                ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
                ToSpawn.transform.localPosition = positionToSpawn;
                break;
            case '?': Debug.Log("Spawn QuestionBox"); 
                ToSpawn = QuestionBox;
                ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
                ToSpawn.transform.localPosition = positionToSpawn;
                break;
            case 'x': Debug.Log("Spawn Rock");
                ToSpawn = Rock;
                ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
                ToSpawn.transform.localPosition = positionToSpawn;
                break;
            case 's': Debug.Log("Spawn Rock");
                ToSpawn = Stone;
                ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
                ToSpawn.transform.localPosition = positionToSpawn;
                break;
            case 'w': Debug.Log("Spawn Water");
                ToSpawn = Water;
                ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
                ToSpawn.transform.localPosition = positionToSpawn;
                break;
            case 'f': Debug.Log("Spawn Finish");
                ToSpawn = Finish;
                ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
                ToSpawn.transform.localPosition = positionToSpawn;
                break;
            case 'c': Debug.Log("Spawn coin");
                ToSpawn = Coin;
                ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
                ToSpawn.transform.localPosition = positionToSpawn;
                break;
            default: Debug.Log("Default Entered");
                ToSpawn = Skybox;
                ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
                ToSpawn.transform.localPosition = positionToSpawn;
                break;
            //default: return;
                //ToSpawn = //Brick;       break;
        }

        //ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        //ToSpawn.transform.localPosition = positionToSpawn;
    }

    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;
        
        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }
}
