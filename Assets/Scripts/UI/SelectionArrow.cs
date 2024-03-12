
using UnityEngine;
using UnityEngine.UI;


public class SelectionArrow : MonoBehaviour
{
   [SerializeField] private RectTransform[] options;
    private RectTransform rect;
    private int currentPosition;

    public void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            ChangePosition(1);

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
            Interact();
    }

    private void ChangePosition(int _change)
    {
        currentPosition += _change;

        if (currentPosition < 0)
            currentPosition = options.Length - 1;
        else if (currentPosition > options.Length - 1)
            currentPosition = 0;

        //assign the y position of the current option to the arrow
        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0);

    }


    private void Interact()
    {


        options[currentPosition].GetComponent<Button>().onClick.Invoke();


    }
}
