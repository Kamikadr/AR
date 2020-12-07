using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{
    [SerializeField]
    GameObject obj;
    private ARTrackedImageManager trackedImage;

    private void Awake()
    {
        trackedImage = FindObjectOfType<ARTrackedImageManager>();
        obj = Instantiate(obj, Vector3.zero, Quaternion.identity);
        //obj = trackedImage.trackedImagePrefab;
        /*foreach (GameObject obj in gameObjects)
        {
            GameObject newObject = Instantiate(obj, Vector3.zero, Quaternion.identity);
            newObject.name = obj.name;
            spawnedGameObjects.Add(newObject.name, newObject);
        }*/
    }
    private void OnEnable()
    {
        trackedImage.trackedImagesChanged += ImageChanged;
    }
    private void OnDisable()
    {
        trackedImage.trackedImagesChanged -= ImageChanged;
    }
    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage image in eventArgs.added)
        {
            UpdateImage(image);
        }
        foreach (ARTrackedImage image in eventArgs.updated)
        {
            UpdateImage(image);
        }
    }
    private void UpdateImage(ARTrackedImage trackedImage)
    {
        Vector3 position = trackedImage.transform.position;
        GameObject prefab = obj;
        prefab.transform.position = position;
        prefab.SetActive(true);

        /*foreach (GameObject gameObject in spawnedGameObjects.Values)
        {
            if (gameObject.name != name)
            {
                gameObject.SetActive(false);
            }
        }*/
    }



}

