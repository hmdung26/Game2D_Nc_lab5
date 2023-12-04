using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private Text locationText;//hien thi va cham voi doi tuong nao
    public AudioClip collectSound;//doi tuong quan ly am thanh
    private bool hitStone = true;//kiem tra xem co va vaof Stone
    //dinh nghia ham xu ly va cham
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag=="Coin")//va cham coin
        {
            //bat am thanh
            hit.gameObject.GetComponent<Coin>().Dead();
            //tang 1 diem
        }
        if(hit.gameObject.tag=="Stone")//neu va phai da
        {
            if(hitStone)
            {
                //dua vao khoi lap de xu ly bang cach goi khoi lap
                StartCoroutine(EnableCollider(hit, 1));//goi da tien trinh
            }
        }
        //cap nhat text
        if(hit.gameObject.tag=="MushroomLocation")
        {
            locationText.text = "Va Cham Voi: Mushroom";
        }
        if (hit.gameObject.tag == "StoneLocation")
        {
            locationText.text = "Va Cham Voi: Stone";
        }
        if (hit.gameObject.tag == "FireLocation")
        {
            locationText.text = "Va Cham Voi: Fire";
        }
        if (hit.gameObject.tag == "HouseLocation")
        {
            locationText.text = "Va Cham Voi: House";
        }
    }
    //dinh ngia ham goi khoi lam yield
    private IEnumerator EnableCollider(ControllerColliderHit hit, float second)
    {
        hitStone = false;
        yield return new WaitForSeconds(second);//khoi lap
        hitStone = true;
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
