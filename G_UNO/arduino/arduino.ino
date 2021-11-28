//autor original desconocido
#include <Servo.h>
#include <AFMotor.h>           //Se importa la libreria del shield
#define LINE_BUFFER_LENGTH 512 //Se define el tamaño del buffer

char STEP = MICROSTEP;              //Modo de paso de los motores a microstep
const int stepsPerRevolution = 48; //200 steps por revolucion

// Servo position for Up and Down 
const int penZUp = 120;
const int penZDown = 80;

// Servo on PWM pin 10
const int penServoPin =10;

// create servo object to control a servo 
Servo penServo; 

// Inicializando las instancias de los motores a pasos
AF_Stepper myStepperY(stepsPerRevolution, 2);
AF_Stepper myStepperX(stepsPerRevolution, 1);

//Structura para coordenadas
struct point
{
  float x;
  float y;
  float z;
};

// Posicion del actuador
struct point actuatorPos;

//Configuracion de dibujo
float StepInc = 1;
int StepDelay = 1;
int LineDelay = 0;
int penDelay = 50;

//movimiento rapido
int moveStep = 1;

// Relacion de pasos por milimetro en los ejes X y Y
float StepsPerMillimeterX = 100.0;
float StepsPerMillimeterY = 100.0;

// Definiendo los limites maximos y minimos de los ejes
float Xmin = 0;
float Xmax = 40;
float Ymin = 0;
float Ymax = 40;
float Zmin = 0;
float Zmax = 1;

// variables de posicion
float Xpos = Xmin;
float Ypos = Ymin;
float Zpos = Zmax;

//  El programa requiere interpretar las siguientes instrucciones basicas
//  de codigo G
//
//  G1 <- Para movimiento
//  G4 P300 <- Espera 150ms
//  M300 S30 <- actuador encendido
//  M300 S50 <- actuador apagado
//  Ignora comentarios que empiezan con '('
//  Ignora otros comandos

void setup()
{

  Serial.begin(9600); //Puerto serial a 9600 baudios

  penServo.attach(penServoPin);
  penServo.write(penZUp);
  delay(100);

  //Velocidad de los steppers
  myStepperX.setSpeed(600);
  myStepperY.setSpeed(600);

  //Info inicial
  Serial.println("Mini CNC Plotter alive and kicking!");
  Serial.print("X range is from ");
  Serial.print(Xmin);
  Serial.print(" to ");
  Serial.print(Xmax);
  Serial.println(" mm.");
  Serial.print("Y range is from ");
  Serial.print(Ymin);
  Serial.print(" to ");
  Serial.print(Ymax);
  Serial.println(" mm.");
}

void loop()
{

  delay(100); // Espera 100ms

  //Variables
  char line[LINE_BUFFER_LENGTH]; //arreglo de tamaño del buffer
  char c;
  int lineIndex;
  bool lineIsComment, lineSemiColon;

  //inicializando variables
  lineIndex = 0;
  lineSemiColon = false;
  lineIsComment = false;

  while (1)
  { //while infinito
    while (Serial.available() > 0)
    {                    //while si el serial tiene disponibles bytes para lectura
      c = Serial.read(); //devuelve el primer byte disponible de la comunicacion serie
      if ((c == '\n') || (c == '\r'))
      { // deteccion de final de linea
        if (lineIndex > 0)
        {                                       // hay una linea en espera
          line[lineIndex] = '\0';               //fin de linea
          processIncomingLine(line, lineIndex); //procesar linea
          lineIndex = 0;
        }
        else
        {
          // vacio, skip
        }
        lineIsComment = false;
        lineSemiColon = false;
        Serial.println("ok");
      }
      else
      {
        if ((lineIsComment) || (lineSemiColon))
        {
          if (c == ')')
            lineIsComment = false; // termina el comentario si es igual a ')'
        }
        else
        { //si no es comentario o punto y coma
          if (c <= ' ')
          { // Ignora los espacios y caracteres menores (menores a 32)
          }
          else if (c == '/')
          { // Ignora la barra
          }
          else if (c == '(')
          { // Detecta comentario
            lineIsComment = true;
          }
          else if (c == ';')
          { //detecta punto y coma
            lineSemiColon = true;
          }
          else if (lineIndex >= LINE_BUFFER_LENGTH - 1)
          { //Error: sobrecarga del buffer
            Serial.println("ERROR - lineBuffer overflow");
            lineIsComment = false;
            lineSemiColon = false;
          }
          else if (c >= 'a' && c <= 'z')
          {                                    // detecta si es del abecedario en miusculas
            line[lineIndex++] = c - 'a' + 'A'; // ajusta el valor para guardar el equivalente en mayusculas
          }
          else
          { //si no es ningun caso anterior entonces guarda el caracter
            line[lineIndex++] = c;
          }
        }
      }
    }
  }
}

//Metodo para procesar una linea de comando de codigo G
//recibe una linea y su longitud
void processIncomingLine(char *line, int charNB)
{

  //variables
  int currentIndex = 0; //indice
  char buffer[64];      //buffer para leer la linea
  struct point newPos;  //nueva posicion

  //inicializando la posicion
  newPos.x = 0.0;
  newPos.y = 0.0;

  while (currentIndex < charNB)
  { //while para leer la linea de comando
    switch (line[currentIndex++])
    {                                   //switch del primer digito
    case 'G':                           //G es un comando
      buffer[0] = line[currentIndex++]; //almacena en el buffer el primer digito
      buffer[1] = '\0';

      switch (atoi(buffer))
      {       //switch para verificar el tipo de comando (int)
      case 0: //G0 y G1 se consideran igual
      case 1:
        char *indexX = strchr(line + currentIndex, 'X'); //obtiene el indice de la primera aparicion del digito "X"
        char *indexY = strchr(line + currentIndex, 'Y'); //obtiene el indice de la primera aparicion del digito "Y"
        if (indexY <= 0)
        { // no se encontro una cordenada Y
          newPos.x = atof(indexX + 1);
          newPos.y = actuatorPos.y;
        }
        else if (indexX <= 0)
        { // no se encontro una coordenada X
          newPos.y = atof(indexY + 1);
          newPos.x = actuatorPos.x;
        }
        else
        {                              //se encontraron las coordenadas
          newPos.y = atof(indexY + 1); // convierte a float la coordenada Y
          indexY = '\0';
          newPos.x = atof(indexX + 1); // convierte a float la coordenada X
        }
        drawLine(newPos.x, newPos.y, true); // manda llamar a drawLine con las nuevas coordenadas
        actuatorPos.x = newPos.x;
        actuatorPos.y = newPos.y;
        break;
      }
      break;
    case 'M':                           //comando de tipo M
      buffer[0] = line[currentIndex++]; //almacena en el buffer el primer digito
      buffer[1] = line[currentIndex++]; //almacena en el buffer el segundo digito
      buffer[2] = line[currentIndex++]; //almacena en el buffer el tercer digito
      buffer[3] = '\0';
      switch (atoi(buffer))
      {         //switch del int de 3 digitos almacenado en el buffer
      case 300: //comando de apagado/encendido de actuador
      {
        char *indexS = strchr(line + currentIndex, 'S'); //busca una "S" y devuelve el indice
        float Spos = atof(indexS + 1);                   //convierte a float el numero despues de la S
        if (Spos == 30)
        { //si es igual a 30 entonces enciende el actuador
          penDown();
        }
        if (Spos == 50)
        { //si es igual a 50 entonces apaga el actuador
          penUp();
        }
        if (Spos == 99)
        { //movimiento en +Y
          moveTo('W');
        }
        if (Spos == 98)
        { //movimiento en -X
          moveTo('A');
        }
        if (Spos == 97)
        { //movimiento en -Y
          moveTo('S');
        }
        if (Spos == 96)
        { //movimiento en +X
          moveTo('D');
        }
        if (Spos == 95)
        { //Ir al Home
          Serial.print("Going home");
          moveTo('H');
        }
        if (Spos == 94)
        { //Establecer el Zeros
          Serial.print("Zeros");
          actuatorPos.x = 0;
          actuatorPos.y = 0;
          Xpos = 0;
          Ypos = 0;
        }
        break;
      }
      case 114: // M114 - reportar posicion
        Serial.print("Absolute position : X = ");
        Serial.print(actuatorPos.x);
        Serial.print("  -  Y = ");
        Serial.println(actuatorPos.y);
        break;
      default:
        Serial.print("Command not recognized : M"); //No se reconocio el comando
        Serial.println(buffer);
      }
    }
  }
}

//Metodo para dibujar una linea
//recibe las coordenadas X y Y destino
void drawLine(float x1, float y1, bool check)
{

  //Limita las coordenadas a los maximos y minimos
  if (check)
  {
    if (x1 >= Xmax)
    {
      x1 = Xmax;
    }
    if (x1 <= Xmin)
    {
      x1 = Xmin;
    }
    if (y1 >= Ymax)
    {
      y1 = Ymax;
    }
    if (y1 <= Ymin)
    {
      y1 = Ymin;
    }
  }

  //  Conversion de milimetros a steps
  x1 = (int)(x1 * StepsPerMillimeterX);
  y1 = (int)(y1 * StepsPerMillimeterY);
  float x0 = Xpos;
  float y0 = Ypos;

  // calcula las diferencias de coordenadas entre la
  // posicion actual y la de destino
  long dx = abs(x1 - x0);
  long dy = abs(y1 - y0);

  // calcula la direccion da avance en los ejes
  int sx = x0 < x1 ? StepInc : -StepInc;
  int sy = y0 < y1 ? StepInc : -StepInc;

  //variables
  long i;
  long over = 0;

  //determina las diferencias entre dx y dy, y avanza un step segun sea
  //necesario en el motor del eje X o Y, hasta llegar al destino
  if (dx > dy)
  {
    for (i = 0; i < dx; ++i)
    {
      myStepperX.onestep(sx, STEP);
      over += dy;
      if (over >= dx)
      {
        over -= dx;
        myStepperY.onestep(sy, STEP);
      }
      delay(StepDelay);
    }
  }
  else
  {
    for (i = 0; i < dy; ++i)
    {
      myStepperY.onestep(sy, STEP);
      over += dx;
      if (over >= dy)
      {
        over -= dy;
        myStepperX.onestep(sx, STEP);
      }
      delay(StepDelay);
    }
  }

  // espera por linea
  delay(LineDelay);

  //actualiza la posicion del actuador
  Xpos = x1;
  Ypos = y1;
}

//Metodo para mover el actuador
void moveTo(char dir)
{
  float m1 = actuatorPos.x; //Obtener la posicion del actuador x
  float n1 = actuatorPos.y; //Obtener la posicion del actuador y

  switch (dir)
  { //switch de la direccion
  case 'W':
    n1 = n1 + 1; //En caso de W suma 1 al Y
    break;
  case 'S':
    n1 = n1 - 1; //En caso de S resta 1 al Y
    break;
  case 'A':
    m1 = m1 - 1; //En caso de A resta 1 al X
    break;
  case 'D':
    m1 = m1 + 1; //En caso de D suma 1 al X
    break;
  case 'H': // En caso de H v al home
    m1 = 0;
    n1 = 0;
    break;
  default:
    return;
  }

  drawLine(m1, n1, false);
  actuatorPos.x = m1;
  actuatorPos.y = n1;
}

//  Raises pen
void penUp() { 
  penServo.write(penZUp); 
  delay(penDelay); 
  Zpos=Zmax; 
  digitalWrite(15, LOW);
  digitalWrite(16, HIGH);
}
//  Lowers pen
void penDown() { 
  penServo.write(penZDown); 
  delay(penDelay); 
  Zpos=Zmin; 
  digitalWrite(15, HIGH);
  digitalWrite(16, LOW);
}
