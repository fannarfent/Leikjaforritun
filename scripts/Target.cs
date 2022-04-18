
using UnityEngine;
using TMPro;
public class Target : MonoBehaviour
{
    // setur default á health //
    public float health = 50f;
    // setur deafault fyrir stigagjöf //
    public int stigagjof = 5;
    // count fyrir stig //
    public static int count;
    public TextMeshProUGUI countText;
    // fall til að updatea stiga textan þegar gefið er stig//
    public void SetCountText()
    {
        countText.text = "Stig: " + count.ToString();
    }
    // fall sem lætur óvin eða hlut meiða sig þegar raycast hitir þá //
    public void TakeDamage(float amount){
        // mínusar magn af lífi sem er sett á byssu //
        health -= amount;
        // ef líf er minna en eða jafnt og 0 kallar það á dauða fallip
        if(health<= 0f){
            Die();
            count = count + stigagjof;
        
            SetCountText();
        }
    // eyðir ovini þegar hann deyr
    void Die (){
        Destroy(gameObject);
        
        Debug.Log(count);

    }
    }
}
