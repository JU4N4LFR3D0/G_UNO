//autor original desconocido

#include <AFMotor.h> //Se importa la libreria del shield
#define LINE_BUFFER_LENGTH 512 //Se define el tamaño del buffer

char STEP = MICROSTEP ;//Modo de paso de los motores a microstep
const int laserpin = 2;//Pin del laser
const int stepsPerRevolution = 200;//200 steps por revolucion

// Inicializando las instancias de los motores a pasos
AF_Stepper myStepperY(stepsPerRevolution,1);            
AF_Stepper myStepperX(stepsPerRevolution,2);  

//Structura para coordenadas
struct point { 
  float x; 
  float y; 
  float z; 
};

// Posicion del actuador
struct point actuatorPos;

//Configuracion de dibujo
float StepInc = 1;
int StepDelay = 1;
int LineDelay =0;
int laserDelay = 10;

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

// variable switch para output log
boolean verbose = false;

//  El programa requiere interpretar las siguientes instrucciones basicas
//  de codigo G
//
//  G1 <- Para movimiento
//  G4 P300 <- Espera 150ms
//  M300 S30 <- laser encendido
//  M300 S50 <- laser apagado
//  Ignora comentarios que empiezan con '('
//  Ignora otros comandos

void setup() {
  
  Serial.begin( 9600 ); //Puerto serial a 9600 baudios

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
  char line[ LINE_BUFFER_LENGTH ]; //arreglo de tamaño del buffer
  char c; 
  int lineIndex;
  bool lineIsComment, lineSemiColon;

  //inicializando variables
  lineIndex = 0;
  lineSemiColon = false;
  lineIsComment = false;

  while (1) { //while infinito
    while ( Serial.available()>0 ) { //while si el serial tiene disponibles bytes para lectura
      c = Serial.read(); //devuelve el primer byte disponible de la comunicacion serie
      if (( c == '\n') || (c == '\r') ) {             // deteccion de final de linea
        if ( lineIndex > 0 ) { // hay una linea en espera
          line[ lineIndex ] = '\0'; //fin de linea
          if (verbose) { 
            Serial.print( "Received : "); 
            Serial.println( line ); 
          }
          processIncomingLine( line, lineIndex ); //procesar linea
          lineIndex = 0;
        } 
        else { 
          // vacio, skip
        }
        lineIsComment = false;
        lineSemiColon = false;
        Serial.println("ok");    
      } 
      else {
        if ( (lineIsComment) || (lineSemiColon) ) {
          if ( c == ')' )  lineIsComment = false;     // termina el comentario si es igual a ')'
        } 
        else { //si no es comentario o punto y coma
          if ( c <= ' ' ) {                           // Ignora los espacios y caracteres menores (menores a 32)
          } 
          else if ( c == '/' ) {                      // Ignora la barra
          } 
          else if ( c == '(' ) {                      // Detecta comentario
            lineIsComment = true;
          } 
          else if ( c == ';' ) {                      //detecta punto y coma
            lineSemiColon = true;
          } 
          else if ( lineIndex >= LINE_BUFFER_LENGTH-1 ) { //Error: sobrecarga del buffer
            Serial.println( "ERROR - lineBuffer overflow" );
            lineIsComment = false;
            lineSemiColon = false;
          } 
          else if ( c >= 'a' && c <= 'z' ) {          // detecta si es del abecedario en miusculas
            line[ lineIndex++ ] = c-'a'+'A';          // ajusta el valor para guardar el equivalente en mayusculas
          } 
          else {                                      //si no es ningun caso anterior entonces guarda el caracter
            line[ lineIndex++ ] = c;
          }
        }
      }
    }
  }
}

//Metodo para procesar una linea de comando de codigo G
//recibe una linea y su longitud
void processIncomingLine( char* line, int charNB ) {

  //variables
  int currentIndex = 0;//indice
  char buffer[ 64 ];//buffer para leer la linea
  struct point newPos;//nueva posicion

  //inicializando la posicion
  newPos.x = 0.0;
  newPos.y = 0.0;

  while( currentIndex < charNB ) { //while para leer la linea de comando
    switch ( line[ currentIndex++ ] ) { //switch del primer digito
    case 'Q': //Si es Q apaga el laser
      laserOFF(); 
      break;
    case 'E': //si es E enciende el laser
      laserON(); 
      break;
    case 'W': //movimiento en +Y
      moveTo('W'); 
      break;
    case 'A': //movimiento en -X
      moveTo('A'); 
      break;
    case 'S': //movimiento en -Y
      moveTo('S'); 
      break;
    case 'D': //movimiento en +X
      moveTo('D'); 
      break;
    case 'H': //Ir al Home
      moveTo('H'); 
      break;
    case 'Z': //Establecer el Zeros
      Ypos = 0;
      Xpos = 0; 
      break;  
    case 'G': //G es un comando
      buffer[0] = line[ currentIndex++ ]; //almacena en el buffer el primer digito
      buffer[1] = '\0';

      switch ( atoi( buffer ) ){ //switch para verificar el tipo de comando (int)
      case 0: //G0 y G1 se consideran igual
      case 1:
        char* indexX = strchr( line+currentIndex, 'X' );  //obtiene el indice de la primera aparicion del digito "X"
        char* indexY = strchr( line+currentIndex, 'Y' );  //obtiene el indice de la primera aparicion del digito "Y"
        if ( indexY <= 0 ) {  // no se encontro una cordenada Y
          newPos.x = atof( indexX + 1); 
          newPos.y = actuatorPos.y;
        } 
        else if ( indexX <= 0 ) { // no se encontro una coordenada X
          newPos.y = atof( indexY + 1);
          newPos.x = actuatorPos.x;
        } 
        else { //se encontraron las coordenadas
          newPos.y = atof( indexY + 1); // convierte a float la coordenada Y
          indexY = '\0';
          newPos.x = atof( indexX + 1); // convierte a float la coordenada X
        }
        drawLine(newPos.x, newPos.y ); // manda llamar a drawLine con las nuevas coordenadas
        actuatorPos.x = newPos.x;
        actuatorPos.y = newPos.y;
        break;
      }
      break;
    case 'M': //comando de tipo M
      buffer[0] = line[ currentIndex++ ];//almacena en el buffer el primer digito
      buffer[1] = line[ currentIndex++ ];//almacena en el buffer el segundo digito
      buffer[2] = line[ currentIndex++ ];//almacena en el buffer el tercer digito
      buffer[3] = '\0';
      switch ( atoi( buffer ) ){ //switch del int de 3 digitos almacenado en el buffer
      case 300: //comando de apagado/encendido de laser
        {
          char* indexS = strchr( line+currentIndex, 'S' ); //busca una "S" y devuelve el indice
          float Spos = atof( indexS + 1); //convierte a float el numero despues de la S
          if (Spos == 30) { //si es igual a 30 entonces enciende el laser
            laserON(); 
          }
          if (Spos == 50) { //si es igual a 50 entonces apaga el laser
            laserOFF(); 
          }
          break;
        }
      case 114:                                // M114 - reportar posicion
        Serial.print( "Absolute position : X = " );
        Serial.print( actuatorPos.x );
        Serial.print( "  -  Y = " );
        Serial.println( actuatorPos.y );
        break;
      default:
        Serial.print( "Command not recognized : M"); //No se reconocio el comando
        Serial.println( buffer );
      }
    }
  }
}

//Metodo para dibujar una linea
//recibe las coordenadas X y Y destino
void drawLine(float x1, float y1) {

  if (verbose)
  {
    Serial.print("fx1, fy1: ");
    Serial.print(x1);
    Serial.print(",");
    Serial.print(y1);
    Serial.println("");
  }  

  //Limita las coordenadas a los maximos y minimos
  if (x1 >= Xmax) { 
    x1 = Xmax; 
  }
  if (x1 <= Xmin) { 
    x1 = Xmin; 
  }
  if (y1 >= Ymax) { 
    y1 = Ymax; 
  }
  if (y1 <= Ymin) { 
    y1 = Ymin; 
  }

  if (verbose)
  {
    Serial.print("Xpos, Ypos: ");
    Serial.print(Xpos);
    Serial.print(",");
    Serial.print(Ypos);
    Serial.println("");
    Serial.print("x1, y1: ");
    Serial.print(x1);
    Serial.print(",");
    Serial.print(y1);
    Serial.println("");
  }

  //  Conversion de milimetros a steps
  x1 = (int)(x1*StepsPerMillimeterX);
  y1 = (int)(y1*StepsPerMillimeterY);
  float x0 = Xpos;
  float y0 = Ypos;

  // calcula las diferencias de coordenadas entre la
  // posicion actual y la de destino
  long dx = abs(x1-x0);
  long dy = abs(y1-y0);

  // calcula la direccion da avance en los ejes
  int sx = x0<x1 ? StepInc : -StepInc;
  int sy = y0<y1 ? StepInc : -StepInc;

  //variables
  long i;
  long over = 0;

  //determina las diferencias entre dx y dy, y avanza un step segun sea
  //necesario en el motor del eje X o Y, hasta llegar al destino
  if (dx > dy) {
    for (i=0; i<dx; ++i) {
      myStepperX.onestep(sx,STEP);
      over+=dy;
      if (over>=dx) {
        over-=dx;
        myStepperY.onestep(sy,STEP);
      }
    delay(StepDelay);
    }
  }
  else {
    for (i=0; i<dy; ++i) {
      myStepperY.onestep(sy,STEP);
      over+=dx;
      if (over>=dy) {
        over-=dy;
        myStepperX.onestep(sx,STEP);
      }
      delay(StepDelay);
    }    
  }

  if (verbose)
  {
    Serial.print("dx, dy:");
    Serial.print(dx);
    Serial.print(",");
    Serial.print(dy);
    Serial.println("");
    Serial.print("Going to (");
    Serial.print(x0);
    Serial.print(",");
    Serial.print(y0);
    Serial.println(")");
  }

  // espera por linea
  delay(LineDelay);

  //actualiza la posicion del actuador
  Xpos = x1;
  Ypos = y1;
}

//Metodo para mover el actuador
void moveTo(char dir) {

  float m1 = Xpos; //Obtener la posicion del actuador x
  float n1 = Ypos; //Obtener la posicion del actuador y

  switch (dir) { //switch de la direccion
    case 'W': 
      n1 += moveStep; //En caso de W suma 1 al Y
      break;
    case 'S': 
      n1 -= moveStep; //En caso de S resta 1 al Y
      break;
    case 'A': 
      m1 -= moveStep; //En caso de A resta 1 al X
      break;
    case 'D': 
      m1 += moveStep; //En caso de D suma 1 al X
      break;
    case 'H': // En caso de H v al home
      m1 = 0;
      n1 = 0;
      break;
    default: 
      return;
  }
  //laserOFF();
  drawLine(m1, n1);
}

//metodo para laser apagado
void laserOFF() { 
  digitalWrite(2, LOW); 
  delay(laserDelay); 
  Zpos=Zmax;
  if (verbose) { 
    Serial.println("LASER OFF");   
  } 
}

//metodo para laser encendido
void laserON() { 
  digitalWrite(2, HIGH); 
  delay(laserDelay); 
  Zpos=Zmin;
  if (verbose) { 
    Serial.println("LASER ON"); 
  } 
}

/* Tabla de valores ASCII |BIN|HEX|DEC|CODIGO ASCII|...|...|
  0000000	0	  0	  NUL
  0000001	1	  1	  SOH
  0000010	2	  2	  STX
  0000011	3	  3	  ETX
  0000100	4	  4	  EOT
  0000101	5	  5	  ENQ
  0000110	6	  6	  ACK
  0000111	7	  7	  BEL
  0001000	8	  8	  BS
  0001001	9	  9	  TAB
  0001010	A	  10	LF
  0001011	B	  11	VT
  0001100	C	  12	FF
  0001101	D	  13	CR
  0001110	E	  14	SO
  0001111	F	  15	SI
  0010000	10	16	DLE
  0010001	11	17	DC1
  0010010	12	18	DC2
  0010011	13	19	DC3
  0010100	14	20	DC4
  0010101	15	21	NAK
  0010110	16	22	SYN
  0010111	17	23	ETB
  0011000	18	24	CAN
  0011001	19	25	EM
  0011010	1A	26	SUB
  0011011	1B	27	ESC
  0011100	1C	28	FS
  0011101	1D	29	GS
  0011110	1E	30	RS
  0011111	1F	31	US
  0100000	20	32	SP
  0100001	21	33	!	 
  0100010	22	34	 	 
  0100011	23	35	#	 
  0100100	24	36	$	 
  0100101	25	37	%	 
  0100110	26	38	&	 
  0100111	27	39	 	 
  0101000	28	40	(	 
  0101001	29	41	)	 
  0101010	2A	42	*	 
  0101011	2B	43	+	 
  0101100	2C	44	,	 
  0101101	2D	45	-	 
  0101110	2E	46	.	 
  0101111	2F	47	/	 
  0110000	30	48	0	 
  0110001	31	49	1	 
  0110010	32	50	2	 
  0110011	33	51	3	 
  0110100	34	52	4	 
  0110101	35	53	5	 
  0110110	36	54	6	 
  0110111	37	55	7	 
  0111000	38	56	8	 
  0111001	39	57	9	 
  0111010	3A	58	:	 
  0111011	3B	59	;	 
  0111100	3C	60	<	 
  0111101	3D	61	=	 
  0111110	3E	62	>	 
  0111111	3F	63	?	 
  1000000	40	64	@	 
  1000001	41	65	A	 
  1000010	42	66	B	 
  1000011	43	67	C	 
  1000100	44	68	D	 
  1000101	45	69	E	 
  1000110	46	70	F	 
  1000111	47	71	G	 
  1001000	48	72	H	 
  1001001	49	73	I	 
  1001010	4A	74	J	 
  1001011	4B	75	K	 
  1001100	4C	76	L	 
  1001101	4D	77	M	 
  1001110	4E	78	N	 
  1001111	4F	79	O	 
  1010000	50	80	P	 
  1010001	51	81	Q	 
  1010010	52	82	R	 
  1010011	53	83	S	 
  1010100	54	84	T	 
  1010101	55	85	U	 
  1010110	56	86	V	 
  1010111	57	87	W	 
  1011000	58	88	X	 
  1011001	59	89	Y	 
  1011010	5A	90	Z	 
  1011011	5B	91	[	 
  1011100	5C	92	\	 
  1011101	5D	93	]	 
  1011110	5E	94	^	 
  1011111	5F	95	_	 
  1100000	60	96	`	 
  1100001	61	97	a	 
  1100010	62	98	b	 
  1100011	63	99	c	 
  1100100	64	100	d	 
  1100101	65	101	e	 
  1100110	66	102	f	 
  1100111	67	103	g	 
  1101000	68	104	h	 
  1101001	69	105	i	 
  1101010	6A	106	j	 
  1101011	6B	107	k	 
  1101100	6C	108	l	 
  1101101	6D	109	m	 
  1101110	6E	110	n	 
  1101111	6F	111	o	 
  1110000	70	112	p	 
  1110001	71	113	q	 
  1110010	72	114	r	 
  1110011	73	115	s	 
  1110100	74	116	t	 
  1110101	75	117	u	 
  1110110	76	118	v	 
  1110111	77	119	w	 
  1111000	78	120	x	 
  1111001	79	121	y	 
  1111010	7A	122	z	 
  1111011	7B	123	{	 
  1111100	7C	124	l	 
  1111101	7D	125	}	 
  1111110	7E	126	~	 
  1111111	7F	127	DEL
*/
