using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCaster : MonoBehaviour
{
    public AudioSource audioSource;
    public float damage = 5f;

    public AudioClip shootSound;
    public GameObject Player;
    public GameObject Bullet;
    public GameObject SpawnPoint;
    private float _reloadDelay = 0f;
    private bool _shootingActivated = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BulletUpdate();
    }
    private void BulletUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _shootingActivated = true;
            audioSource.Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            _shootingActivated = false;
            audioSource.Stop();
        }
        if (_shootingActivated)
        {
            //audioSource.PlayOneShot(shootSound);
            var spawnDelay = Random.Range(0.08f, 0.2f);
            Invoke("SpawnBullet", spawnDelay);
        }
    }
    private void SpawnBullet()
    {
        /*            Player.GetComponent<Animator>().SetTrigger("Draw");
                                Player.GetComponent<Animator>().SetTrigger("Shoot");
                                audioSource.PlayOneShot(shootSound);*/
        _reloadDelay = 0f;
        var Arr = Instantiate(Bullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        //            Arr.transform.position = SpawnPoint.transform.position;
        Arr.transform.eulerAngles = new Vector3(SpawnPoint.transform.eulerAngles.x + 90f, SpawnPoint.transform.eulerAngles.y, SpawnPoint.transform.eulerAngles.z);
        Arr.GetComponent<BulletController>().damage = damage;
    }
}
