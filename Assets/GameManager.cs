using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;
    private GameObject pinObjects;
    private FallTrigger[] pins;
    
    void Start()
    {
        SetPins();
        inputManager.OnResetPressed.AddListener(HandleReset);
    }
    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }

    private void SetPins()
    {
        if (pinObjects)
        {
            foreach (Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }
        pinObjects = Instantiate(pinCollection, pinAnchor.transform.position, Quaternion.identity, transform);
        pins = Resources.FindObjectsOfTypeAll<FallTrigger>();
        foreach (FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }    
    
    void Update()
    {
        
    }
}
