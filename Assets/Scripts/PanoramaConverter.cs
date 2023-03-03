using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PanoramaConverter : MonoBehaviour
{
    //read in the image
    public Texture2D image;

    // Start is called before the first frame update
    void Start()
    {
        //read the image
        //m_image = Resources.Load("Assets/Panoramas/input.jpg") as Texture2D;
        //check if image was found
        if (!image)
        {   
            Debug.Log("Couldn't find anything");
            return;
        }

        m_SplitImage();
    }

    //function that splits the image into 4 parts along the x axis
    private void m_SplitImage()
    {
        //mapping from part number to front, back, left, right
        Dictionary<int, string> partToName = new Dictionary<int, string>();
        partToName.Add(0, "front");
        partToName.Add(1, "left");
        partToName.Add(2, "back");
        partToName.Add(3, "right");
        //initialize array of size 4 for the 4 parts of the image
        Texture2D[] images = new Texture2D[4];
        //get the image width and divide it by 4
        int quarterWidth = image.width / 4;
        //get the image height
        int height = image.height;
        //loop through the 4 parts of the image
        for (int i = 0; i < 4; i++)
        {
            var currentWidth = quarterWidth * (i + 1);
            //create a new texture2d for each part of the image
            images[i] = new Texture2D(quarterWidth, height);
            //loop through the width of the image
            for (int x = currentWidth - quarterWidth; x < currentWidth; x++)
            {
                //loop through the height of the image
                for (int y = 0; y < height; y++)
                {
                    //get the pixel color at the current x and y position
                    Color pixel = image.GetPixel(x, y);
                    //set the pixel color at the current x and y position in the new texture2d
                    images[i].SetPixel(x, y, pixel);
                }
            }

            //apply the changes to the texture2d
            images[i].Apply();
            //save the texture2d as a png
            byte[] bytes = images[i].EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/Panoramas/" + partToName[i] + ".png", bytes);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}