using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using TMPro;
 public class PlayerCollider : MonoBehaviour
 {
    private bool m_IsOnGround;
 
    public bool IsOnGround
    {
        get
        {
            if (m_IsOnGround)
            {
                m_IsOnGround = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
     void OnCollisionStay()
     {
         //If it touch things, then it's on ground, that's my rule
        m_IsOnGround = true;
     }
 }
public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20;
    PlayerCollider m_playerCollider;
    public float sideways = 20;
    public float jump = 20;
    public float maxhaed = 30;
    //private Rigidbody leikmadur;
    public static int count;
    public TextMeshProUGUI countText;
    
    void Start()
    {
        Debug.Log("byrja");
        m_playerCollider = GetComponent<PlayerCollider>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       
        //sný player
        if (Input.GetKey("f"))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey("g"))//snúa leikmanni
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }
        if (transform.position.y <= -10)
        {
            Endurræsa();
        }
        if (Input.GetKey("w"))//áfram
        {
            transform.position += transform.forward * speed ;
        }
        if (Input.GetKey("s"))// til baka
        {
            transform.position += -transform.forward * speed;

        }
        if (Input.GetKey("d"))//hægri
        {
            transform.position += transform.right * sideways;
        }
        if (Input.GetKey("a"))//vinstri
        {
            //hreyfir player um sideways í hvert skipti sem ýtt er á leftArrow
            transform.position += -transform.right * sideways;
        }
        if (transform.position.y < 10 && Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.up * jump;
            
        }
            //Debug.Log("búmm");
            //Vector3 movement = new Vector3(0, 10, 0);
        
        if (transform.position.y<=-10)
        {
            Endurræsa();
        }
    }
   
     async void OnCollisionEnter(Collision collision)
    {   
        // ef player keyrir á object sem heitir hlutur
        if (collision.collider.tag == "hlutur")
        {
            collision.collider.gameObject.SetActive(false);
            count = count + 1;
           // Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (collision.collider.tag == "pikk")
        {
            collision.collider.gameObject.SetActive(false);
            count = count + 5;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (collision.collider.tag == "hindrun")
        {
            collision.collider.gameObject.SetActive(false);
            count = count -3;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
    }
    void SetCountText()
    {
        countText.text = "Stig: " + count.ToString();
       
        if (count <= 0)
        {
            this.enabled = false;//kemur í veg fyrir að playerinn geti hreyfst áfram eftir dauðan
            countText.text = "Þú hefur dáið " + count.ToString()+" stigum";

            StartCoroutine(Bida());
            
        }
        
    }
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(1);
        Endurræsa();
    }
   
    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
    public void Endurræsa()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Level_1
        SceneManager.LoadScene(0);
    }

}
