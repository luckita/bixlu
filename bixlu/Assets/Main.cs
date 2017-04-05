using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public double CurrentTime = 0; //por si lo queremos para algo, je ne sais pas...

    private string[] scenes;
    public Material[] skyboxes = new Material[5];
    private int sceneIndex = 0;

    void Start()
    {
        //sah, esto se hace con un struct, pero yo quiero jail time
        scenes = new string[] {
            "MainScene",
            "ValuesScene",
            "AboutScene",
            "ProjsScene",
            "MathQuizzerScene"
        };

        //  DisplayNextScene();//eso es si fueran ordenaditos, pero nope

        changeSkybox();
        DisplayScene("MainScene");//este es por nombre, me pa que va por aca

}

void Update()
    {
        //Scene changes

        //Display main scene, cleared
        if (Input.GetKeyDown(KeyCode.H))//home
        {
            DisplayScene("MainScene");

            //porque nunca se vio codigo mas horrible
            GameObject.Find("MainScene").transform.Find("aboutus").gameObject.SetActive(false);
            GameObject.Find("MainScene").transform.Find("ourprojs").gameObject.SetActive(false);
            GameObject.Find("MainScene").transform.Find("ourvalues").gameObject.SetActive(false);
            GameObject.Find("MainScene").transform.Find("USB1").gameObject.SetActive(false);
            GameObject.Find("MainScene").transform.Find("USB2").gameObject.SetActive(false);
            GameObject.Find("MainScene").transform.Find("USB3").gameObject.SetActive(false);
        }
        //Display About us, Our values and Our project and cables from logo
        if (Input.GetKeyDown(KeyCode.E))//elements
        {
            DisplayScene("MainScene");
            //porque nunca se vio codigo mas horrible
            GameObject.Find("MainScene").transform.Find("aboutus").gameObject.SetActive(true);
            GameObject.Find("MainScene").transform.Find("ourprojs").gameObject.SetActive(true);
            GameObject.Find("MainScene").transform.Find("ourvalues").gameObject.SetActive(true);
            GameObject.Find("MainScene").transform.Find("USB1").gameObject.SetActive(true);
            GameObject.Find("MainScene").transform.Find("USB2").gameObject.SetActive(true);
            GameObject.Find("MainScene").transform.Find("USB3").gameObject.SetActive(true);
        }
        //Display Our Values scene
        if (Input.GetKeyDown(KeyCode.V))//values
        {
            DisplayScene("ValuesScene");
        }
        //Display Our Projects scene
        if (Input.GetKeyDown(KeyCode.P))//projects
        {
            DisplayScene("ProjsScene");
        }
        //Display Math Quizzer scene
        if (Input.GetKeyDown(KeyCode.M))//mathquizzer
        {
            DisplayScene("MathQuizzerScene");
        }
        //Display About us scene
        if (Input.GetKeyDown(KeyCode.A))//About
        {
            DisplayScene("AboutScene");
        }
        changeSkybox();

    }


    //no lo estoy usando, pero lo voy a dejar
    private void  DisplayNextScene()
    {
        if (sceneIndex > 0)
        {
            Find(scenes[sceneIndex]).SetActive(false);
        }
        Find(scenes[sceneIndex++]).SetActive(true);
    }

    private void DisplayScene(string nextSceneName)
    {
        //eto e epantoso, voy a ir en cana
        sceneIndex = 0;
        int pos = Array.IndexOf(scenes, nextSceneName);
        if (pos > -1)
        {
            while (sceneIndex < scenes.Length)
            {
                if (sceneIndex == pos)
                {
                    Find(scenes[sceneIndex]).SetActive(true);
                }
                else
                {
                    Find(scenes[sceneIndex]).SetActive(false);
                }
                sceneIndex++;
            }
        }
        sceneIndex = pos;
    }

    private void changeSkybox()
    {
        Skybox sceneSkybox = Camera.main.GetComponent<Skybox>();
        sceneSkybox.material = skyboxes[sceneIndex];
    }

    private GameObject Find(string name)
    {

        GameObject result = GameObject.Find(name);
        if (result != null)
        {
            return result;
        }
        GameObject world = GameObject.Find("World");
        return world.transform.Find(name).gameObject;
    }
}
