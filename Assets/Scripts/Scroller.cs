using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    public Image selectedImage;
    public Image deselectedImage;
    public Image disableImage;
    
    #pragma warning restore format
    public void SelectItem()
    {
        selectedImage.gameObject.SetActive(true);
        deselectedImage.gameObject.SetActive(false);
        disableImage.gameObject.SetActive(false);
        // Perform the action for the selected item here.
    }
    public void DeselectItem()
    {
        selectedImage.gameObject.SetActive(false);
        deselectedImage.gameObject.SetActive(true);
        disableImage.gameObject.SetActive(false);
    }
    public void DisableItem()
    {
        selectedImage.gameObject.SetActive(false);
        deselectedImage.gameObject.SetActive(false);
        disableImage.gameObject.SetActive(true);
    }
}

