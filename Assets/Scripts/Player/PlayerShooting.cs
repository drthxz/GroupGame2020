using UnityEngine;

public class PlayerShooting : Shooting
{
    public int damagePerShot = 20;
    private float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    //LineRenderer gunLine;
    AudioSource gunAudio;
    //Light gunLight;
    float effectsDisplayTime = 0.2f;
    public float speed;


    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        //gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        //gunLight = GetComponent<Light> ();
        bulletCom = bullet.GetComponent<Bullet>();
        bulletCom.disappear = disappear;
    }


    protected override void Update ()
    {
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        //gunLine.enabled = false;
        //gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f;

        //gunAudio.Play ();

        //gunLight.enabled = true;

        //gunParticles.Stop ();
        //gunParticles.Play ();

        //gunLine.enabled = true;
        //gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        bulletCom.type = type;
        bulletCom.attack = attack;
        GameObject temp = Instantiate(bullet, transform.position, new Quaternion(0f,0f,0f,0f));
        temp.GetComponent<Rigidbody>().velocity = (point.transform.forward * 10f* speed);

        //gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
    }
}
