using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject escapeTrigger;
    public GameObject resetPoint;
    public GameObject treasure;

    public LayerMask layers;
    public Transform target;

    public float _time = 0.2f;
    public float _distance = 0.1f;
    public float _delayBetweenShakes = 0f;

    public float accelerationTime = 60;
    private float minSpeed;
    public float time;
    public float currentSpeed = 0f;
    public float maxSpeed = 3f;

    private float _timer;
    private Vector3 _randomPos;
    private Vector3 _startPos;

    Vector3 minScale;
    public Vector3 targetScale;
    public float speed = 2f;
    public float duration = 5f;

    public AudioSource biteSound;
    public AudioSource chestCollectSound;
    public bool hasTouched = false;
    public bool sleepingBoss = true;
    public bool repeatable = false;
    public bool treasureTaken = false;

    // Start is called before the first frame update
    private void Start()
    {
        escapeTrigger.SetActive(false);
    }
    IEnumerator ScaleBoss()
    {
        minScale = transform.localScale;
        //yield return new WaitForSeconds(2);
        if (repeatable == true)
        {
            yield return new WaitForSeconds(2);
            yield return RepeatLerp(minScale, targetScale, duration);
        }
    }

    private IEnumerator Shake()
    {
        _timer = 0f;
        _startPos = transform.position;

        while (_timer < _time)
        {
            _timer += Time.deltaTime;

            _randomPos = _startPos + (Random.insideUnitSphere * _distance);

            transform.position = _randomPos;

            if (_delayBetweenShakes > 0f)
            {
                yield return new WaitForSeconds(_delayBetweenShakes);
            }
            else
            {
                yield return null;
            }
        }
        transform.position = _startPos;
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (0 != (layers.value & 1 << other.gameObject.layer) && hasTouched == false)
        {
            if (Input.GetKey(KeyCode.E))
            {
                chestCollectSound.Play();
                hasTouched = true;
                Debug.Log("Player spawned boss");
                repeatable = true;

                StartCoroutine(Shake());
                StartCoroutine(ScaleBoss());

                treasure.SetActive(false);
                escapeTrigger.SetActive(true);

                treasureTaken = true;
                sleepingBoss = false;
            }
        }
        else if (hasTouched == true)
        {
            //Debug.Log("Player has already spawned the boss.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (0 != (layers.value & 1 << collision.gameObject.layer))
        {
            Debug.Log("Ouch. boss touched you.");
            biteSound.Play();
            collision.transform.GetComponent<PlayerMovement>().RecieveDamage(100);
        }
    }

    void Update()
    {
        if (sleepingBoss == false)
        {
            transform.LookAt(target);
            currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, time / accelerationTime);
            transform.position -= transform.forward * currentSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, currentSpeed);
            time += Time.deltaTime;
        }

        if (player.curHP <= 0 && sleepingBoss == false)
        {
            time = 0;
            currentSpeed = 0;
            this.transform.position = resetPoint.transform.position;
        }
    }
}
