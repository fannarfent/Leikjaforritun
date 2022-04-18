
using UnityEngine;
using TMPro;
public class Shooting2 : MonoBehaviour
{
    // setur hversu mikið damage maður gerir með skoti
    public float damage = 20f;
    // hversu langt vopnið drífur //
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public static int count;
    public TextMeshProUGUI countText;
    // gáir hvort það sé buið að ítta á skottakka (mouse1) ef svo kallar það á skot fallið //
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            Shoot();
        }
    }
    // skot fallið
    void Shoot ()
    {
        // spilar muzzleflash effectið //
        muzzleFlash.Play();
        // gerir raycast //
        RaycastHit hit;
        // ef raycastið hittir eitthvað sækir það hvað það er og eef það er eitthvað sem getur tekið damage lætur það taka damge //
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null){
                target.TakeDamage(damage);
            }
        }
    }
}
