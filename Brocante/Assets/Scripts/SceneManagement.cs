using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private GameObject sceneParentInventory;
    [SerializeField] private GameObject sceneParentExamine;
    [SerializeField] private GameObject sceneParentDiscussion;


    public void ExamineObject()
    {
        if (IsItemSelect.IsItemAlreadySelect())
        {
            StaticObject.activeObject = IsItemSelect.GetItemSelect();
            InventoryToExamine();
        }
    }


    public void DiscussionToInventory()
    {
        sceneParentDiscussion.GetComponent<SaveScene>().DisactiveScene();
        sceneParentInventory.GetComponent<SaveScene>().ActiveScene();
    }

    public void InventoryToDiscussion()
    {

        sceneParentInventory.GetComponent<SaveScene>().DisactiveScene();
        sceneParentDiscussion.GetComponent<SaveScene>().ActiveScene();
    }

    public void InventoryToExamine()
    {
        Debug.Log("On change de scene");
        sceneParentExamine.GetComponent<SaveScene>().ActiveScene();
        sceneParentInventory.GetComponent<SaveScene>().DisactiveScene();

    }
    
    public void ExamineToInventory()
    {
        sceneParentExamine.GetComponent<SaveScene>().DisactiveScene();
        sceneParentInventory.GetComponent<SaveScene>().ActiveScene();
    }
    
    
}
