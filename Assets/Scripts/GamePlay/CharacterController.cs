using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Vector2 inputVector2;
    [SerializeField]
    private float speed = 4;
    [SerializeField]
    private Transform weapon1;
    [SerializeField]
    GameObject prefabBullet;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public AudioClip shootAudio;
    int vector = 1;
    public Vector3 offset = new Vector3(0, 0.1f, 0);
    float horizontal;
    private int dir = 0;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        inputVector2.x = Input.GetAxisRaw("Horizontal");
        inputVector2.y = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        // shoot as appropriate
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(prefabBullet, transform.position - transform.rotation * offset, Quaternion.identity);
            bullet.transform.eulerAngles = new Vector3(0, 0, -90);
            Rigidbody2D rg = bullet.GetComponent<Rigidbody2D>();
            rg.AddForce(weapon1.right * vector * 1000f);
            shootAudio.LoadAudioData();
            //shootSoundEffect.Play();
        }

        if (horizontal > 0 && dir == 1)
        {
            dir = 0;
            transform.Rotate(0, 180, 0);
        }
        if (horizontal < 0 && dir == 0)
        {
            dir = 1;
            transform.Rotate(0, 180, 0);
        }
    }

    private void FixedUpdate()
    {
        Vector2 newVec = inputVector2.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + newVec);
    }
    private void LateUpdate()
    {
        animator.SetFloat("Speed", inputVector2.magnitude);
        //if (inputVector2.x != 0)
        //{
        //    GameObject weapon = GameObject.FindGameObjectWithTag("Weapon");
        //    SpriteRenderer sprite = weapon.GetComponent<SpriteRenderer>();
        //    spriteRenderer.flipX = inputVector2.x < 0;
        //    sprite.flipX = inputVector2.x < 0;
        //    vector = inputVector2.x < 0 ? -1 : 1;
        //}
    }


}
