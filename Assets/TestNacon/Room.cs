using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    [Tooltip("0 = up  ,  1 = down  ,  2 = right  ,  3 = left")]
    private GameObject[] walls;
    public bool isVisitedRoom;
    //public bool[] testStatus;
    //private IEnumerator Start()
    //{
    //    yield return new WaitForSeconds(1);
    //    if(isVisitedRoom == true)
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
    public void UpdateRoom(bool[] status)
    {
        for(int i = 0; i < status.Length; i++)
        {
            walls[i].SetActive(status[i]);
        }
    }
}
