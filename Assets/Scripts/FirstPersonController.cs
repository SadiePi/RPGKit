using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGKit.Dialogue;

public class FirstPersonController : MonoBehaviour
{
    public Camera cam;
    public CharacterController characterController;
    public float moveSpeed = 1;
    public float lookSpeed = 1;
    public float jumpPower = 1;
    public float gravity = -1;

    private float mouseX, mouseY;
    private Vector3 moveDirection = new Vector3();
    public Dialogue dialogue = null;
    private Prompt prompt = null;
    private bool dcont = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogue != null) {
            if(dcont) {
                if(!dialogue.Advance()) 
                    dialogue = null;
                else {
                    dcont = false;
                    Line l = dialogue.GetCurrentLine();

                    prompt = l.prompt;
                    print(l.text);

                    if(prompt != null) {
                        prompt.Reset();
                        for(int i = 0; i < l.prompt.options.Length; i++)
                            if(l.prompt.options[i].available)
                                print("\t" + (i+1) + ": " + l.prompt.options[i].text);
                    }
                }
            }

            if(Input.GetKeyDown(KeyCode.E) || (prompt != null && prompt.response != Prompt.Unanswered)) {
                prompt = null;
                dcont = true;
            }

            if(prompt != null) {
                if(Input.GetKeyDown(KeyCode.Keypad1)) prompt.response = 0;
                if(Input.GetKeyDown(KeyCode.Keypad2)) prompt.response = 1;
                if(Input.GetKeyDown(KeyCode.Keypad3)) prompt.response = 2;
                if(Input.GetKeyDown(KeyCode.Keypad4)) prompt.response = 3;
                if(Input.GetKeyDown(KeyCode.Keypad5)) prompt.response = 4;
                if(Input.GetKeyDown(KeyCode.Keypad6)) prompt.response = 5;
                if(Input.GetKeyDown(KeyCode.Keypad7)) prompt.response = 6;
                if(Input.GetKeyDown(KeyCode.Keypad8)) prompt.response = 7;
                if(Input.GetKeyDown(KeyCode.Keypad9)) prompt.response = 8;
            }
        } else {
            transform.localRotation = Quaternion.Euler(Vector3.up * (mouseX += Input.GetAxis("Mouse X") * lookSpeed));
            cam.transform.localRotation = Quaternion.Euler(Vector3.left * (mouseY += Input.GetAxis("Mouse Y") * lookSpeed));
            if(characterController.isGrounded) {
                moveDirection = transform.right * Input.GetAxis("Horizontal") * moveSpeed + transform.forward * Input.GetAxis("Vertical") * moveSpeed + transform.up * (Input.GetKey(KeyCode.Space)?jumpPower:0);
            } else {
                moveDirection.y += gravity * Time.deltaTime;
            }

            characterController.Move(moveDirection);

            if(Input.GetKeyDown(KeyCode.E)) {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.forward, out hit, 4)) {
                    hit.collider.transform.GetComponent<MeshRenderer>().material.color = Color.green;
                    StartCoroutine("uncolor", hit);
                    dialogue = hit.collider.GetComponent<Dialogue>();
                    dialogue.Reset();
                    dcont = true;
                }
            }
        }

        

    }

    private IEnumerator uncolor(RaycastHit hit) {
        yield return new WaitForSeconds(1);
        hit.collider.transform.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
