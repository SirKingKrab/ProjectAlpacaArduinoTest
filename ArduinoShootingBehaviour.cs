using UnityEngine;
using System.Collections;
using System.IO.Ports;
public class ArduinoShootingBehaviour : MonoBehaviour
{	
	public Rigidbody2D rocket;
	private Rigidbody2D rocketIns;
    //Serial Ports depend on Computer. Check Arduino Port for the correct port. 
    SerialPort serial = new SerialPort("COM5", 9600);
	public bool isShooting;
	public bool isRunning;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

	}

	void Update()
	{
        //Checks for Arduino Serial Communication Port
		if(!serial.IsOpen)
		{
			serial.Open();
		}

        //Parse the string of two bits into a value to initiate shooting or a faster run.
		string data = serial.ReadLine();
		int shoot = int.Parse(data.Substring (0, 1));
		int fast = int.Parse(data.Substring (1, 1));
		
		if (shoot == 1) 
		{
			isShooting = true;
		} 
		else 
		{
			isShooting = false;
		}
		
		if (fast == 1) 
		{
			isRunning = true;
		} 
		else 
		{
			isRunning = false;
		}
		

		if (isShooting) 
		{
			rocketIns = Instantiate (rocket, this.transform.position, this.transform.rotation) as Rigidbody2D;
			rocketIns.AddForceAtPosition (new Vector2 (2000, 0), this.transform.position);
		} 
		if (isRunning) 
		{
			this.transform.parent.gameObject.GetComponent<Controller2DCustom> ().setSpeed (60);
		} 
		else 
		{
			this.transform.parent.gameObject.GetComponent<Controller2DCustom>().setSpeed(30);
		}
	}
}