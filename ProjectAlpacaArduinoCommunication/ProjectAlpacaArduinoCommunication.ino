const int buttonPin = 2;
const int buttonPin2 = 4;
int buttonState = 0;
int buttonState2 = 0;
void setup() 
{
  Serial.begin(9600);
  pinMode(buttonPin, INPUT);
  pinMode(3, OUTPUT);
  pinMode(buttonPin2, INPUT);
  pinMode(5, OUTPUT);
}

void loop() 
{
  buttonState = digitalRead(buttonPin);
  buttonState2 = digitalRead(buttonPin2);
  Serial.println((String) buttonState + (String) buttonState2);
  // put your main code here, to run repeatedly:
  if (buttonState == HIGH)
  {
    digitalWrite(3, HIGH);
  }
  else
  {
    digitalWrite(3, LOW);
  }
  if (buttonState2 == HIGH)
  {
    digitalWrite(5, HIGH);
  }
  else
  {
    digitalWrite(5, LOW);
  }
  delay(20);
}
