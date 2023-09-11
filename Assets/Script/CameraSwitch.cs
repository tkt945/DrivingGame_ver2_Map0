using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//切換兩個攝影機

public class CameraSwitch : MonoBehaviour
{

    public GameObject cam1, cam2; //兩個不同的攝影機

    /* 放在Awake內，在物件執行之前就先封鎖住，避免物件的出現，直到使用者切換攝影機後再創造該物件，若是放在Start內則會造成全部的物件都已經產生且初始化後再封鎖住。 */
    void Awake()
    {

        //預設先開啟第一部攝影機


        //一定要先暫停不使用的攝影機後，再開啟要使用的攝影機！
        cam2.SetActive(false);
        cam1.SetActive(true);

        //沒有要顯示出來的物件則先暫時關閉，同時開啟要顯示的物件，避免背景執行浪費效能。若多部攝影機都拍著同個物件，則不需要關閉該物件，只需關閉攝影機即可

        //被關閉的物件和其子物件都會被隱藏(其身上的script都會一起被暫停)
    }

    void Update()
    {
        if (Input.GetKey("z") == true)
        {
            //若是按下鍵盤的z則切換成第二部攝影機
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
        else if (Input.GetKey("x") == true)
        {
            //若是按下鍵盤的x則切換成第一部攝影機
            cam2.SetActive(false);
            cam1.SetActive(true);
        }
    }
}