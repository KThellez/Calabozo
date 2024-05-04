using System;
using System.Threading;

public class Program
{
	public static void Main()
	{
		CalabozoOkiris juego = new CalabozoOkiris();
		juego.IniciarJuego();
	}
}


class CalabozoOkiris
{
	public void IniciarJuego()
    {
        Jugador jugador = CrearJugador();

        Console.WriteLine("Bienvenido " + jugador.nombre + " aventurero");
		StatsJugador(jugador);
		
        Console.WriteLine("El valiente aventurero " + jugador.nombre + " se encuentra frente a la entrada de un antiguo calabozo conocido como el Calabozo de las Sombras. Se dice que en su interior yacen tesoros inimaginables, pero también peligros mortales. Determinado a obtener riquezas y fama, el aventurero se adentra en las oscuras profundidades del calabozo.");
		
        ComenzarCalabozo(jugador);
    }
	
	private Jugador CrearJugador()
    {
        Console.WriteLine("Ingresa tu Nombre aventurero");
        string nombre = Console.ReadLine();
        return new Jugador(nombre, 100, 7, 5, 0);
    }
	
	private void ComenzarCalabozo(Jugador jugador)
    {
        Console.WriteLine("Camino de la Luz: Al principio del calabozo, "+ jugador.nombre +" encuentra una bifurcación en el camino.");
		
        Console.WriteLine("A su izquierda, un pasillo iluminado por antorchas y con un suelo pulido. A su derecha, una senda oscura y llena de misterios.");
        Console.WriteLine("¿Qué camino tomará el aventurero?");
        
		Console.WriteLine("1 para izquierda, 2 para derecha.");
        int opcion = Convert.ToInt32(Console.ReadLine());
		Opciones("1", "2", "Opción inválida. Por favor, selecciona 1 o 2.", opcion, jugador, (string caso) => { CaminoDeLaLuz(jugador); }, (string caso) => { CaminoDeLasSombras(jugador); });
    }
	
	private void CaminoDeLaLuz(Jugador jugador)
    {
		int opcion = 0; 
        Console.WriteLine("El aventurero avanza por el pasillo iluminado, sintiéndose más seguro bajo la cálida luz de las antorchas.");
		opcion = GenerarNumeroAleatorio(1,3);
		Opciones("Oh!, ¿que sera eso?, " + jugador.nombre + " se encontro una criatura.\n¿Sera amigable?\nDeseas interactura con ella\n1 Si, 2 No", "Oh no!!!, "+jugador.nombre+" cayo en una trampa mortal, Tira un dado, si el valor es mayor a 3 sobrevive si no, aqui termino su historia...", "", opcion, jugador, (string caso) => { CriaturaAmigable(jugador); }, (string caso) => { Trampa(jugador); },(string caso) => { Tesoro(jugador); },jugador.nombre+" encontraste un tesoro, ¿deseas abrirlo?");
    }
	private void CaminoDeLasSombras(Jugador jugador)
    {
		int opcion = 0;
        Console.WriteLine("El aventurero elige adentrarse en la senda oscura, preparándose para lo desconocido."); 
		opcion = GenerarNumeroAleatorio(1,3);
		Opciones("Oh!, ¿que sera eso?, " + jugador.nombre + " se encontro una criatura, aunque no la logro ver bien.\n¿sera amigable?\nOh no, no lo es...\nQue comeince la batalla!!!", "...  "+jugador.nombre+" tiene que resolver un puzzle para avanzar en el calabozo... ", "", opcion, jugador, (string caso) => { PrimerEnemigo(jugador); }, (string caso) => { Puzzle(jugador); },(string caso) => { CofreSospechoso(jugador); },jugador.nombre+" encontraste un cofre sospechoso, ¿deseas abrirlo?");
		
    }
	private void CriaturaAmigable(Jugador jugador)
    {
        int opcion = int.Parse(Console.ReadLine());
		switch (opcion)
			{
				case 1:
					Cargar();
					StatsJugador(jugador);
					Console.WriteLine("Viejo Sabio...");
					Console.WriteLine("¡Bienvenido, valiente aventurero! Veo que buscas riquezas y gloria en los oscuros pasillos de este antiguo calabozo... ");
					Console.WriteLine("Sí, eso es correcto. He venido en busca de tesoros y desafíos que superar."); 
					Console.WriteLine("...");
					Console.WriteLine("por cierto... Mi nombre es " + jugador.nombre);
					Console.WriteLine("Viejo Sabio: Entiendo. Pero ten cuidado, joven. Este calabozo está lleno de peligros mortales y trampas astutas. Si no prestas atención, podrías caer en desgracia.");
					Console.WriteLine(jugador.nombre + ": Aprecio tu advertencia, viejo sabio. ¿Tienes algún consejo para mí antes de que continúe mi búsqueda?");
					Console.WriteLine("Viejo Sabio: Por supuesto "+jugador.nombre+". En el Camino de la Luz, encontrarás bifurcaciones y decisiones que tomar. Recuerda que no todas las respuestas están a la vista. A veces, la sabiduría y el conocimiento son tus mejores armas.");
					Console.WriteLine(jugador.nombre +": Entendido. Gracias por tus palabras, viejo sabio. Seguiré adelante con precaución y sabiduría.");
					Console.WriteLine("Viejo Sabio: Que la luz guíe tus pasos, joven "+jugador.nombre+". Y que encuentres lo que buscas en los rincones más oscuros de este calabozo.");
					CaminoDeLaLuz2(jugador);
					break;
				case 2:
					Cargar();
					StatsJugador(jugador);
					Console.WriteLine("Criatura desconocida: Mal educado...");
					Console.WriteLine("");
					Console.WriteLine(jugador.nombre + "  sigue su camino... sin mirar a la criatura.  ");
					CaminoDeLaLuz2(jugador);
					break;
				default:
					Console.WriteLine("Eleccion incorrecta.");
					CriaturaAmigable(jugador);
					break;
			}
		CaminoDeLaLuz2(jugador);
    }
	private void Trampa(Jugador jugador)
    {
		Console.WriteLine("Presiona Enter para Lanzar el dado...");
		string entrada = Console.ReadLine();
		int numero = GenerarNumeroAleatorio(1,6);
		Console.WriteLine("Tu dado es: " + numero);
		if(numero > 3)
		{
			numero = 2;
		}
		else
		{
			numero = 1;
			jugador.salud = 0;
			jugador.armadura = 0;
		}
		Console.WriteLine("Presiona Enter para continuar...");
	    entrada = Console.ReadLine();
		Opciones(jugador.nombre+" murio...", "Te haz salvado... por los pelos", "", numero, jugador, (string caso) => { Muerte(jugador, "al caer en una trampa mortal"); }, (string caso) => { CaminoDeLaLuz2(jugador); });
    }
	private void Tesoro(Jugador jugador)
    {
		Console.WriteLine("Abriendo el tesoro...");
		int item = GenerarNumeroAleatorio(1,6);
		int tesoro = 0;
        switch (item)
		{	
			case 1:
				Cargar();
				StatsJugador(jugador);
				Console.WriteLine("Su tesoro es un aumento de armadura");
				tesoro = GenerarNumeroAleatorio(0,25);
				jugador.armadura += tesoro;
				StatsJugador(jugador);
				CaminoDeLaLuz2(jugador);
				break;
			case 2:
				Cargar();
				StatsJugador(jugador);
				Console.WriteLine("Era un tesoro maligno, ten cuidado puede hacerte daño...");
				tesoro = GenerarNumeroAleatorio(0,15);
				jugador.armadura -= tesoro;
				Console.WriteLine("Debuff de armadura de " + tesoro);
				Batalla(jugador, "Tesoro Embrujado", 50 ,10 ,5);
				StatsJugador(jugador);
				CaminoDeLaLuz2(jugador);
				break;
			case 3:
				Cargar();
				StatsJugador(jugador);
				Console.WriteLine("Su tesoro es un aumento de fuerza");
				tesoro = GenerarNumeroAleatorio(0,7);
				Console.WriteLine("Aumento de " + tesoro + " de armadura");
				jugador.fuerza += tesoro;
				StatsJugador(jugador);
				CaminoDeLaLuz2(jugador);
				break;
			case 4:
				Cargar();
				StatsJugador(jugador);
				Console.WriteLine("Lo sentimos no hay tesoro");
				StatsJugador(jugador);
				CaminoDeLaLuz2(jugador);
				break;
			case 5:
				Cargar();
				StatsJugador(jugador);
				Console.WriteLine("Su tesoro es un aumento de inteligencia");
				tesoro = GenerarNumeroAleatorio(0,7);
				jugador.inteligencia += tesoro;
				Console.WriteLine("Aumento de " + tesoro + " de inteligencia");
				StatsJugador(jugador);
				CaminoDeLaLuz2(jugador);
				break;
			case 6:
				Cargar();
				StatsJugador(jugador);
				Console.WriteLine("Encontraste una posion de vida...");
				if(jugador.salud != 100)
				{
					tesoro = GenerarNumeroAleatorio(0,25);
					if((tesoro + jugador.salud) >= 100)
					{
						Console.WriteLine("tu posion es de " + tesoro + " puntos de salud...");
						jugador.salud = 100;
					}
					else
					{
						StatsJugador(jugador);
						Console.WriteLine("tu posion es de " + tesoro + " puntos de salud...");
						jugador.salud += tesoro;
					}
				}
				StatsJugador(jugador);
				CaminoDeLaLuz2(jugador);
				break;
			default:
				Console.WriteLine("");
				break;
		}
    }
	private void PrimerEnemigo(Jugador jugador)
    {
		Enemigo enemigo = new Enemigo("Ghoblin", 100, 25 , 20);
		Batalla(jugador, enemigo);
         
    }
	private void Puzzle(Jugador jugador)
    {
        Console.WriteLine("Te encuentras frente a una pared con varios símbolos grabados en ella.");
		Console.WriteLine("Debes encontrar la secuencia correcta de símbolos para abrir la puerta.");
		Console.WriteLine("Los símbolos disponibles son: A, B, C, D, E");
		Console.WriteLine("Ingresa la secuencia de símbolos (por ejemplo, ABCD):");
		string respuesta = Console.ReadLine();
		if (respuesta.ToUpper() == "CABDE")
		{
			Console.WriteLine("¡Has resuelto el puzzle y la puerta se abre!");
		}
		else
		{
			Console.WriteLine("Incorrecto. La pared emite un ruido ominoso y una trampa se activa.");
			Trampa(jugador);
		}
    }
	private void CofreSospechoso(Jugador jugador)
    {
        Console.WriteLine("Abriendo el cofre tesoro ...");
		int item = GenerarNumeroAleatorio(1,6);
		int tesoro = 0;
        switch (item)
		{	
			case 1:
				Cargar();
				StatsJugador(jugador);
				Console.WriteLine("Su tesoro es un aumento de armadura");
				tesoro = GenerarNumeroAleatorio(0,50);
				jugador.armadura += tesoro;
				StatsJugador(jugador);
				CaminoDeLaSombra2(jugador);
				break;
			case 2:
				Cargar();
				StatsJugador(jugador);
				Console.WriteLine("Era un cofre poseido, ten cuidado puede hacerte daño...");
				tesoro = GenerarNumeroAleatorio(0,50);
				jugador.armadura -= tesoro;
				Console.WriteLine("Debuff de armadura de " + tesoro);
				Batalla(jugador, "Cofre Embrujado", 75 ,15 ,2);
				StatsJugador(jugador);
				CaminoDeLaSombra2(jugador);
				break;
			case 3:
				Cargar();
				StatsJugador(jugador);
				Console.WriteLine("Su tesoro es un aumento de fuerza");
				tesoro = GenerarNumeroAleatorio(0,25);
				Console.WriteLine("Aumento de " + tesoro + " de armadura");
				jugador.fuerza += tesoro;
				StatsJugador(jugador);
				CaminoDeLaSombra2(jugador);
				break;
			case 4:
				Cargar();
				StatsJugador(jugador);
				Console.WriteLine("Era un cofre poseido, ten cuidado puede hacerte daño...");
				tesoro = GenerarNumeroAleatorio(0,75);
				jugador.armadura -= tesoro;
				Console.WriteLine("Debuff de armadura de " + tesoro);
				Batalla(jugador, "Cofre Embrujado", 50 ,25 ,15);
				StatsJugador(jugador);
				CaminoDeLaSombra2(jugador);
				break;
			case 5:
				Cargar();
				StatsJugador(jugador);
				Console.WriteLine("Su tesoro es un aumento de inteligencia");
				tesoro = GenerarNumeroAleatorio(0,15);
				jugador.inteligencia += tesoro;
				Console.WriteLine("Aumento de " + tesoro + " de inteligencia");
				StatsJugador(jugador);
				CaminoDeLaSombra2(jugador);
				break;
			case 6:
				Cargar();
				StatsJugador(jugador);
				Console.WriteLine("Encontraste una posion de vida...");
				if(jugador.salud != 100)
				{
					tesoro = GenerarNumeroAleatorio(0,25);
					if((tesoro + jugador.salud) >= 100)
					{
						Console.WriteLine("tu posion es de " + tesoro + " puntos de salud...");
						jugador.salud = 100;
					}
					else
					{
						StatsJugador(jugador);
						Console.WriteLine("tu posion es de " + tesoro + " puntos de salud...");
						jugador.salud += tesoro;
					}
				}
				StatsJugador(jugador);
				CaminoDeLaSombra2(jugador);
				break;
			default:
				Console.WriteLine("");
				break;
		} 
    }
	private void CaminoDeLaSombra2(Jugador jugador)
    {
		Console.WriteLine("El aventurero se adentra en las sombras del calabozo, sintiendo una presión opresiva en el aire.");

    Console.WriteLine("De repente, " + jugador.nombre + " se encuentra con una facción secreta que opera en las sombras del calabozo.");
    Console.WriteLine("La facción ofrece a " + jugador.nombre + " la oportunidad de unirse a ellos o enfrentarse a consecuencias desconocidas.");
    Console.WriteLine("¿Qué hará " + jugador.nombre + "?");
    Console.WriteLine("1. Unirse a la facción y obtener beneficios exclusivos.");
    Console.WriteLine("2. Rechazar la oferta y continuar su camino en solitario.");

    int opcion = Convert.ToInt32(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            Console.WriteLine(jugador.nombre + " decide unirse a la facción y obtiene beneficios exclusivos para su viaje.");
            break;
        case 2:
            Console.WriteLine(jugador.nombre + " rechaza la oferta de la facción y continúa su camino en solitario.");
            break;
        default:
            Console.WriteLine("Selección inválida. " + jugador.nombre + " continúa su camino.");
            break;
    }
    Console.WriteLine("Más adelante, " + jugador.nombre + " se encuentra en un laberinto de ilusiones donde nada es lo que parece.");
    Console.WriteLine("Para avanzar, debe confiar en su intuición y encontrar el camino correcto a través de las ilusiones.");
    Console.WriteLine("¿Qué hará " + jugador.nombre + " en esta situación?");
    Console.WriteLine("1. Confíar en su intuición y encontrar el camino correcto.");
    Console.WriteLine("2. Intentar romper las ilusiones con la fuerza bruta.");

    opcion = Convert.ToInt32(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            Console.WriteLine(jugador.nombre + " confía en su intuición y encuentra el camino correcto a través del laberinto de ilusiones.");
            break;
        case 2:
            Console.WriteLine(jugador.nombre + " intenta romper las ilusiones con la fuerza bruta, pero descubre que son inquebrantables.");
            Console.WriteLine("Después de un tiempo perdido, encuentra la salida y continúa su camino.");
            break;
        default:
            Console.WriteLine("Selección inválida. " + jugador.nombre + " continúa su camino.");
            break;
    }

    Console.WriteLine("En las profundidades más oscuras del calabozo, " + jugador.nombre + " se enfrenta a un desafío de la oscuridad profunda.");
    Console.WriteLine("Criaturas de pesadilla y desafíos aterradores ponen a prueba su coraje y determinación.");
    Console.WriteLine("¿Qué hará " + jugador.nombre + " en esta situación?");
    Console.WriteLine("1. Enfrentar el desafío con valentía y determinación.");
    Console.WriteLine("2. Intentar huir de la oscuridad.");

    opcion = Convert.ToInt32(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            Console.WriteLine(jugador.nombre + " enfrenta el desafío con valentía y determinación, superando todas las dificultades.");
            break;
        case 2:
            Console.WriteLine(jugador.nombre + " intenta huir de la oscuridad, pero se encuentra atrapado en un ciclo sin fin de miedo y confusión.");
            Console.WriteLine("Finalmente, encuentra el camino de regreso a la luz y continúa su camino.");
            break;
        default:
            Console.WriteLine("Selección inválida. " + jugador.nombre + " continúa su camino.");
            break;
    }
        Console.WriteLine("Esta historia continuara...");  
    }
	private void CaminoDeLaLuz2(Jugador jugador)
    {
		Console.WriteLine("El aventurero avanza por el pasillo iluminado, sintiéndose seguro bajo la luz de las antorchas.");
        Console.WriteLine("De repente, el espíritu de un aventurero perdido aparece frente a " + jugador.nombre + ".");
        Console.WriteLine("El espíritu ruega por ayuda para encontrar la paz eterna.");
        Console.WriteLine("¿Qué hará " + jugador.nombre + "?");
        Console.WriteLine("1. Ayudar al espíritu a encontrar la paz.");
        Console.WriteLine("2. Seguir adelante en su búsqueda.");
    
        int opcion = Convert.ToInt32(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                Console.WriteLine("Conmovido por la historia del espíritu, " + jugador.nombre + " decide ayudarlo a encontrar la paz.");
                Console.WriteLine("Tras completar una serie de tareas, el espíritu encuentra la paz y desaparece, dejando tras de sí una recompensa.");
                break;
            case 2:
                Console.WriteLine(jugador.nombre + " decide seguir adelante en su búsqueda, dejando atrás al espíritu errante.");
                break;
            default:
                Console.WriteLine("Selección inválida. " + jugador.nombre + " continúa su camino.");
                break;
        }
        Console.WriteLine("Más adelante, " + jugador.nombre + " entra en una sala de espejos mágicos que reflejan versiones alternativas de sí mismo.");
        Console.WriteLine("Para avanzar, debe resolver un enigma relacionado con los espejos.");
        Console.WriteLine("¿Qué hará " + jugador.nombre + " en esta situación?");
        Console.WriteLine("1. Resolver el enigma y avanzar.");
        Console.WriteLine("2. Intentar romper los espejos.");
    
        opcion = Convert.ToInt32(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                Console.WriteLine(jugador.nombre + " resuelve el enigma de los espejos y avanza con éxito.");
                break;
            case 2:
                Console.WriteLine(jugador.nombre + " intenta romper los espejos, pero descubre que son indestructibles.");
                Console.WriteLine("Después de un tiempo perdido, encuentra la salida y continúa su camino.");
                break;
            default:
                Console.WriteLine("Selección inválida. " + jugador.nombre + " continúa su camino.");
                break;
        }
        Console.WriteLine("En su camino, " + jugador.nombre + " se encuentra con un comerciante ambulante que ofrece una variedad de objetos mágicos y herramientas útiles.");
        Console.WriteLine("¿Qué hará " + jugador.nombre + " en esta situación?");
        Console.WriteLine("1. Comprar objetos para mejorar su equipo.");
        Console.WriteLine("2. Vender objetos que ha encontrado en el calabozo.");
        Console.WriteLine("3. Ignorar al comerciante y continuar su viaje.");
    
        opcion = Convert.ToInt32(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                Console.WriteLine(jugador.nombre + " compra algunos objetos útiles del comerciante y continúa su viaje.");
                break;
            case 2:
                Console.WriteLine(jugador.nombre + " vende algunos objetos al comerciante y obtiene algo de oro.");
                break;
            case 3:
                Console.WriteLine(jugador.nombre + " ignora al comerciante y sigue adelante en su búsqueda.");
                break;
            default:
                Console.WriteLine("Selección inválida. " + jugador.nombre + " continúa su camino.");
                break;
        }
        Console.WriteLine("Esta historia continuara...");  
    }
	private void Opciones(string caso1, string caso2, string predeterminado, int opcion, Jugador jugador, Action<string> funcion1 , Action<string> funcion2, Action<string> funcion3 = null, string caso3 = null, Action<string> funcion4 = null,string caso4 = null)
	{
		if (caso3 != null)
		{
			switch (opcion)
			{
				case 1:
					Cargar();
					StatsJugador(jugador);
					Console.WriteLine(caso1);
					funcion1(caso1); 
					break;
				case 2:
					Cargar();
					StatsJugador(jugador);
					Console.WriteLine(caso2);
					funcion2(caso2); 
					break;
				case 3:
					Cargar();
					StatsJugador(jugador);
					Console.WriteLine(caso3);
					funcion3(caso3); 
					break;
				default:
					Console.WriteLine(predeterminado);
					ComenzarCalabozo(jugador);
					break;
			}
		}
		else if (caso4 != null)
		{
			switch (opcion)
			{
				case 1:
					Cargar();
					StatsJugador(jugador);
					Console.WriteLine(caso1);
					funcion1(caso1); 
					break;
				case 2:
					Cargar();
					StatsJugador(jugador);
					Console.WriteLine(caso2);
					funcion2(caso2);
					break;
				case 3:
					Cargar();
					StatsJugador(jugador);
					Console.WriteLine(caso3);
					funcion3(caso3); 
					break;
				case 4:
					Cargar();
					StatsJugador(jugador);
					Console.WriteLine(caso4);
					funcion4(caso4); 
					break;
				default:
					Console.WriteLine(predeterminado);
					ComenzarCalabozo(jugador);
					break;
			}
		}
		else
		{
			switch (opcion)
			{
				case 1:
					Cargar();
					StatsJugador(jugador);
					Console.WriteLine(caso1);
					funcion1(caso1);
					break;
				case 2:
					Cargar();
					StatsJugador(jugador);
					Console.WriteLine(caso2);
					funcion2(caso2);
					break;
				default:
					Console.WriteLine(predeterminado);
					ComenzarCalabozo(jugador);
					break;
			}
		}
	}
	private void Batalla(Jugador jugador, Enemigo enemigo)
	{
		while (jugador.salud > 0 && enemigo.salud > 0)
		{
			Console.WriteLine("Presiona Enter para atacar...");
			Console.ReadLine();
			int ataqueJugador = GenerarNumeroAleatorio(jugador.fuerza, (jugador.fuerza + jugador.inteligencia * 2));
			int ataque = ataqueJugador - (enemigo.defensa/GenerarNumeroAleatorio(1,enemigo.defensa));
			if (ataque < 0)
				ataque = 0;
			enemigo.salud -= ataque;
			Console.WriteLine("Has causado " + ataque + " de daño al " + enemigo.nombre + ". Su salud restante: " + enemigo.salud);
			if (enemigo.salud > 0)
			{
				int ataqueEnemigo = GenerarNumeroAleatorio(enemigo.ataque - 5, enemigo.ataque + 5);
				int danioEnemigo = ataqueEnemigo - jugador.armadura;
				if (danioEnemigo < 0)
					danioEnemigo = 0;
				jugador.salud -= danioEnemigo;
				Console.WriteLine("El " + enemigo.nombre + " te ha causado " + danioEnemigo + " de daño. Tu salud restante: " + jugador.salud);
			}
		}
		if (jugador.salud <= 0)
		{
			Muerte(jugador, "fuiste derrotado por el " + enemigo.nombre);
		}
		else
		{
			Console.WriteLine("¡Has derrotado al " + enemigo.nombre + "!");
		}
	}

	static void StatsJugador(Jugador jugador)
	{
		Console.WriteLine("\n" + jugador.nombre + "\n" + jugador.salud + " HP\n" + jugador.armadura + " Armadura\n" + jugador.fuerza + " Fuerza\n" + jugador.inteligencia + " Inteligencia\n");
	}
	static void Cargar()
        {
			Console.WriteLine("\n");
			Console.Write(".");
            Thread.Sleep(100);
			Limpiar();
			for (int i = 0; i < 2; i++)
			{
				Console.Write(".");
				Thread.Sleep(100); 
			}
			Limpiar();
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(100); 
            }
			Limpiar();
			Console.WriteLine("\n");
        }
	static void Limpiar()
	{
		Console.WriteLine("\n");
		Console.Clear();
	}
	static int GenerarNumeroAleatorio(int minValor, int maxValor)
    {
        if (minValor > maxValor)
        {
            throw new ArgumentException("minValor no puede ser mayor al maxValor");
        }

        Random random = new Random();
        return random.Next(minValor, maxValor + 1); 
    }
	
	
	private void Muerte(Jugador jugador, string razon)
    {
		StatsJugador(jugador);
        Console.WriteLine(jugador.nombre + " murio " + razon);  
		Console.WriteLine("Fin..");  
    }
	private void Batalla(Jugador jugador, string Enemigo, int vida, int fuerza, int critico)
	{
		while(vida > 0 && jugador.salud > 0)
		{
			if(vida > 0)
			{
				Console.WriteLine(Enemigo + " Attaca a " + jugador.nombre);
				int ataque = GenerarNumeroAleatorio(fuerza, (fuerza+critico));
				jugador.salud -= ataque - jugador.armadura; 
				Console.WriteLine("Presiona Enter para atacar...");
				string entrada = Console.ReadLine();
				ataque = GenerarNumeroAleatorio(jugador.fuerza, (jugador.fuerza+jugador.inteligencia*2));
			}
		}
		
		if(jugador.salud < 1)
		{
			Muerte(jugador, " fue asesinado por "+ Enemigo);
		}
	}
}



class Jugador
{
    public string nombre;
    public int salud;
    public int fuerza;
    public int inteligencia;
	public int armadura;

    public Jugador(string nombre, int salud, int fuerza, int inteligencia, int armadura)
    {
        this.nombre = nombre;
        this.salud = salud;
        this.fuerza = fuerza;
        this.inteligencia = inteligencia;
		this.armadura = armadura;
    }
}

class Enemigo
{
    public string nombre;
    public int salud;
    public int ataque;
    public int defensa;

    public Enemigo(string nombre, int salud, int ataque, int defensa)
    {
        this.nombre = nombre;
        this.salud = salud;
        this.ataque = ataque;
        this.defensa = defensa;
    }
}

class Objeto
{
    public string nombre;
    public string tipo;

    public Objeto(string nombre, string tipo)
    {
        this.nombre = nombre;
        this.tipo = tipo;
    }
}