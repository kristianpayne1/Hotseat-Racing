using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control
{
    public float time;
    public float ThrottleInput;
    public float BrakeInput;
    public float SteerInput;

    public Control(float time, float ThrottleInput, float BrakeInput, float SteerInput)
    {
        this.time = time;
        this.ThrottleInput = ThrottleInput;
        this.BrakeInput = BrakeInput;
        this.SteerInput = SteerInput;
    }
}

public class BotManager : MonoBehaviour
{
    public static BotManager Instance {get; private set;}

    public Car carController;
    public Queue<Control> botControls;
    public bool disableBot = true;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        botControls = new Queue<Control>();
        botControls.Enqueue(new Control(0f, 1f, 0f, 0f));
        botControls.Enqueue(new Control(1.08f, 0f, 1f, -1f));
        Debug.Log(botControls.Count);
    }

     void Awake() {
        Instance = this;
        carController = GetComponentInChildren<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!disableBot)
        {
            timer += Time.deltaTime;
            updateBotControls();
        }
    }

    void updateBotControls()
    {
        Queue<Control> prevControls = new Queue<Control>(botControls);
        if(botControls.Count != 0)
        {
            Control nextControls = botControls.Dequeue();
            float time = nextControls.time;
            if(timer > time)
            {
                carController.Throttle = nextControls.ThrottleInput;
                carController.Brake = nextControls.BrakeInput;
                carController.Steer = nextControls.SteerInput;
            } else {
                botControls = prevControls;
            }
        }
    }
}
