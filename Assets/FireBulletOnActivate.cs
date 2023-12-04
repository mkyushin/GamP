using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;

    [SerializeField] private Transform barrelLocation;
    public GameObject muzzleFlashPrefab;
    [SerializeField] private Animator gunAnimator;
    public int BulletCnt;
    public Canvas Dialog;
    [SerializeField] private AudioSource SoundSource;
    public AudioClip emptyBulletSound;
    public AudioClip shootingSound;
    private bool isFire = false;


    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);



        SoundSource = GetComponent<AudioSource>();
        if (SoundSource == null)
            SoundSource = gameObject.AddComponent<AudioSource>();
        BulletCnt = 10;
        Dialog.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFire)
        {
            gunAnimator.SetTrigger("Fire");
            SoundSource.PlayOneShot(shootingSound);
            BulletCnt--;
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
            Destroy(tempFlash, 5);
        }
        
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        
        
            //Calls animation on the gun that has the relevant animation events that will fire
            
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = spawnPoint.position;
            spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
            Destroy(spawnedBullet, 5);
            isFire = true;


            

        if (BulletCnt == 0)
        {
            SoundSource.PlayOneShot(emptyBulletSound);
            Dialog.gameObject.SetActive(true);
        }




    }


}
