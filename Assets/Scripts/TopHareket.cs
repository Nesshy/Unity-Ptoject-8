using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Hepsi;
    public GameObject son;
    public GameObject ilk;
    public Rigidbody rb;
    public float hiz = 0.18f;
    public GameObject anh1;
    public GameObject anh2;
    public GameObject anh3;
    public GameObject ExitDoor;
    int sayac = 0;
    public Text zaman;
    float zamanSayaci = 300;
    bool oyunDevam = true;
    void Start()
    {
        ilk.gameObject.SetActive(true);
        son.gameObject.SetActive(false);
        Hepsi.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
        anh1.SetActive(true);
        anh2.SetActive(true);
        anh3.SetActive(true); 
        ExitDoor.SetActive(true);
    }
    public void Basla()
    {
        Hepsi.gameObject.SetActive(true);
        ilk.gameObject.SetActive(false);
        son.gameObject.SetActive(false);
        oyunDevam = true;
    }
    public void Cikis()
    {
        Application.Quit();
    }
    public void Tekrar()
    {
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        if(oyunDevam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 hareket = new Vector3(yatay, 0, dikey);
            rb.AddForce(hareket * hiz);
            zamanSayaci -= Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
        }
        if (sayac == 3)
        {
            ExitDoor.SetActive(false);
        }
        if (zamanSayaci < 0)
        {
            oyunDevam = false;
        }
        if(oyunDevam == false)
        {
            son.gameObject.SetActive(true);
            ilk.gameObject .SetActive(false);
            Hepsi.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        string objName = other.gameObject.name;
        string objTag = other.gameObject.tag;
        if(objName=="Finish")
        {
            oyunDevam=false;
        }
        if(objName=="Key1")
        {
            other.gameObject.SetActive(false);
            anh1.SetActive(false);
            sayac++;
        }
        if (objName == "Key2")
        {
            other.gameObject.SetActive(false);
            anh2.SetActive(false);
            sayac++;
        }
        if (objName == "Key3")
        {
            other.gameObject.SetActive(false);
            anh3.SetActive(false);
            sayac++;
        }
    }
    
}


