using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick MovingJoystick;

    float moveSpeed = 4.5f;
    public Transform MovingArrow;

    Animator anim;
    //AimningStuff
    public Transform ShootingArrow;
    public Joystick ShootingJoystick;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //using this later to change the default animations
    }

    // Update is called once per frame
    void Update()
    {
        MovingArrow.rotation = MovingArrow.rotation = Quaternion.Euler(0f, Mathf.Atan2(MovingJoystick.Horizontal, MovingJoystick.Vertical) * Mathf.Rad2Deg, 0f);
        if (Mathf.Abs(MovingJoystick.Horizontal) > .1f || Mathf.Abs(MovingJoystick.Vertical) > .1f) {

            if(!MovingArrow.gameObject.activeSelf)
                MovingArrow.gameObject.SetActive(true);

            transform.LookAt(new Vector3(MovingJoystick.Horizontal + transform.position.x, 0, MovingJoystick.Vertical + transform.position.z));
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            anim.SetBool("isRunning", true);

        }
        else
        {
            anim.SetBool("isRunning", false);
            if (MovingArrow.gameObject.activeSelf)
                MovingArrow.gameObject.SetActive(false);
        }


    }

    private void LateUpdate()
    {
        if(Mathf.Abs(ShootingJoystick.Horizontal) > .1f || Mathf.Abs(ShootingJoystick.Vertical) > .1f)
        {
            if (!ShootingArrow.gameObject.activeSelf)
                ShootingArrow.gameObject.SetActive(true);

            transform.LookAt(new Vector3(ShootingJoystick.Horizontal + transform.position.x, 0, ShootingJoystick.Vertical + transform.position.z));

            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        }
        else
        {
            if (ShootingArrow.gameObject.activeSelf)
                ShootingArrow.gameObject.SetActive(false);
        }
    }
}
