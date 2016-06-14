using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class main : MonoBehaviour
{

    public TextAsset level1Text;
    public TextAsset level2Text;
    public TextAsset level3Text;
    public Text experience;
    public Text levelName;
    public Text levelInfo;
    public Text levelPop;
    public Text winText;
    public GameObject island_picture;

    float timeToGo;
    int currentLevel;
    List<TextAsset> levels;

    void Start()
    {
        timeToGo = Time.fixedTime + 1.0f;

        currentLevel = 0;
        levels = new List<TextAsset> { };
        levels.Add(level1Text);
        levels.Add(level2Text);
        levels.Add(level3Text);
        LevelLoad(levels[currentLevel]);

        experience.text = master.level.island.exp.ToString() + '/' + master.level.expNeeded.ToString();
        levelName.text = master.level.name;
        levelInfo.text = master.level.info;
        levelPop.text = "Herbivores: " + master.level.island.popHerb.ToString() + '/' + master.level.popCaps[0].ToString() + " | " + "Carnivores: " + master.level.island.popCarn.ToString() + '/' + master.level.popCaps[1];
        winText.text = "";
    }

    void Update()
    {

        experience.text = master.level.island.exp.ToString() + '/' + master.level.expNeeded.ToString();
        levelPop.text = "Herbivores: " + master.level.island.popHerb.ToString() + '/' + master.level.popCaps[0].ToString() + " | " + "Carnivores: " + master.level.island.popCarn.ToString() + '/' + master.level.popCaps[1];

        if (master.level.island.exp == master.level.expNeeded)
        {
            winText.text = "Level Complete! Click To Continue";
            if (Input.GetMouseButtonDown(0))
            {
                currentLevel += 1;
                LevelLoad(levels[currentLevel]);
            }
        }
        else if (master.level.island.popHerb == 0)
        {
            winText.text = "Level Failed! Click to Restart";
            if (Input.GetMouseButtonDown(0))
            {
                LevelLoad(levels[currentLevel]);
            }
        }
        else
        {
            float timeUsed = Time.time;
            if (Time.fixedTime >= timeToGo)
            {
                timeToGo = Time.fixedTime + 1.0f;
                foreach (var animal in master.level.island.animals.Values)
                {
                    if (animal.pop >= 0 && animal.type == "Herbivore")
                    {
                        animal.pop += animal.pop / master.level.incrRatio;
                    }
                    else if (animal.pop >= 0 && animal.type == "Carnivore")
                    {
                        int carnDecr = animal.pop * animal.rate;
                        System.Random rnd = new System.Random();
                        int random = rnd.Next(1, animal.prey.Length);
                        int count = 0;
                        while (carnDecr > 0 && count > animal.prey.Length)
                        {
                            if (master.level.island.animals[animal.prey[random]].pop > 0)
                            {
                                master.level.island.animals[animal.prey[random]].pop -= 1;
                                carnDecr -= 1;
                            }
                            else
                            {
                                if (random == animal.prey.Length)
                                {
                                    random = 0;
                                }
                                else
                                {
                                    random += 1;
                                }
                            }
                            count += 1;
                        }
                    }
                }
                int tempHerbPop = 0;
                int tempCarnPop = 0;
                foreach (var animal in master.level.island.animals.Values)
                {
                    if (animal.type == "Herbivore")
                    {
                        tempHerbPop += animal.pop;
                    }
                    else if (animal.type == "Carnivore")
                    {
                        tempCarnPop += animal.pop;
                    }
                }
                master.level.island.popHerb = tempHerbPop;
                master.level.island.popCarn = tempCarnPop;
                if (master.level.island.popHerb >= master.level.popCaps[0] && master.level.island.popHerb <= master.level.popCaps[1])
                {
                    master.level.island.exp += 1;
                }
            }
        }
    }

    void LevelLoad(TextAsset levelTextFile)
    {

        master.level.island = new master.island();
        string[] levelLines = levelTextFile.text.Split(new string[] { "\n", "\r\n", "\r", "\n\r" }, StringSplitOptions.RemoveEmptyEntries);
        master.level.name = levelLines[0];
        master.level.info = levelLines[1];
        master.level.incrRatio = Int32.Parse(levelLines[2]);
        master.level.expNeeded = Int32.Parse(levelLines[3]);
        string[] popNeededStr = levelLines[4].Split(',');
        int[] popNeeded = new int[popNeededStr.Length];

        for (int i = 0; i < popNeededStr.Length; i++)
        {
            popNeeded[i] = Convert.ToInt32(popNeededStr[i].ToString());
        }

        master.level.popNeeded = popNeeded;
        string[] popCapsStr = levelLines[5].Split(',');
        int[] popCaps = new int[popCapsStr.Length];
        for (int i = 0; i < popCapsStr.Length; i++)
        {
            popCaps[i] = Convert.ToInt32(popCapsStr[i].ToString());
        }
        master.level.popCaps = popCaps;
        string[] initPopsStr = levelLines[6].Split(',');
        string[] initPopsIntStr = levelLines[7].Split(',');
        int[] initPopsInt = new int[initPopsIntStr.Length];
        for (int i = 0; i < initPopsIntStr.Length; i++)
        {
            initPopsInt[i] = Convert.ToInt32(initPopsIntStr[i].ToString());
        }
        Dictionary<string, int> initPops = new Dictionary<string, int> { };
        for (int i = 0; i < initPopsStr.Length; i++)
        {
            initPops.Add(initPopsStr[i], initPopsInt[i]);
        }
        master.level.initPops = initPops;

        foreach (var key in master.level.initPops.Keys)
        {
            master.animal animal = master.level.island.animals[key];
            for (int i = 0; i <= master.level.initPops[key]; i++)
            {
                Add_Animal(animal.name, animal.type);
            }
        }
    }

    void Add_Animal(string spriteTag, string type)
    {
        GameObject spriteToDuplicate = GameObject.FindWithTag(spriteTag);
        if (type == "Carnivore")
        {
            master.level.island.popCarn += 1;
        }
        else
        {
            master.level.island.popHerb += 1;
        }

        //Adding the sprite to the screen
        float x = island_picture.GetComponent<Renderer>().bounds.size.x;
        float y = island_picture.GetComponent<Renderer>().bounds.size.y;

        Vector3 currentPosition = spriteToDuplicate.transform.position;
        currentPosition = new Vector3(UnityEngine.Random.Range((-x / 2), (x / 2)), UnityEngine.Random.Range((-y / 2) + 7, (y / 2) - 7), 0f);
        GameObject tmpObj = GameObject.Instantiate(spriteToDuplicate, currentPosition, Quaternion.identity) as GameObject;
    }
}
