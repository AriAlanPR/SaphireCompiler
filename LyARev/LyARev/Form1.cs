using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LyARev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //variable global del tipo de la clase generada para hacer las operaciones con conexion al archivo de excel obtenido
        BDOLEDB BaseD;
        string codigoprocesado = ""; //variable que contiene los tokens asignados a cada linea de codigo de manera concatenada
        List<string> IDE = new List<string>(); //lista en la que se guardan los identificadores, tambien es usada para evitar
                                                //que se repitan
        private void tstrcargar_Click(object sender, EventArgs e)
        {
            //se establece una variable para obtener la ruta de forma vacia
            string ruta="";
            try
            {
                //se abre un archivo de dialogo para buscar el documento de excel al que se quiere conectar
                OpenFileDialog open = new OpenFileDialog();
                //se filtran los archivos a la extension .xlsx
                open.Filter = "archivo Excel(*.xlsx)|*.xlsx";
                //se establece el titulo de dialogo con el string asignado
                open.Title = "Documentos Excel";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    //si se obtuvo una ruta para el archivo de excel se guardara la ruta en la variable generada anteriormente
                    ruta = open.FileName;
                }
                //se libera de memoria la variable del archivo de dialogo
                open.Dispose();
                //luego de obtener la ruta podemos iniciar la base de datos
                BaseD = new BDOLEDB(ruta);
                //se da a entender al usuario que la conexion se logro cambiando el texto de un label que indica el estado de conexion
                tslblconexion.Text= "Enlazado :D";
                
                //dgvmatriztransicion.DataSource = BD.DT;
            }
            catch (NullReferenceException)
            {
                //si el archivo de excel es nulo se manda mensaje al usuario
                MessageBox.Show("El archivo Excel seleccionado es nulo :c");
            }
            catch (Exception ex)
            {
                //si ocurre una excepcion de cualquier tipo por alguna razon desconocida se manda mensaje al usuario con los
                //detalles del error ocurrido
                MessageBox.Show(":c No se pudo porque: " + ex.Message);
                //se da a entender al usuario que hubo un error cambiando el texto del label que indica el estado de conexion
                tslblconexion.Text = "Posible error de conexion";
            }
        }
        //token anterior(usado para verificacion de tipos dentro de la tabla de simbolos
        string ant;
        //variable que contiene todo el codigo ingresado por el usuario
        string codigoausar;
        private void tstrleer_Click(object sender, EventArgs e)
        {   //se encierra dentro de un try-catch para capturar posibles errores
            try
            {                
                bd.Eliminar();
                //se pone en blanco la variable codigoprocesado por si se usa una segunda vez
                codigoprocesado = "";
                //se vacia el progressbar por si ya fue cargado antes
                tsprgb1.Value = tsprgb1.Minimum;
                //se limpian los campos ingresados del datagridview antes de hacer de nuevo la lectura
                dgvmatriztransicion.Rows.Clear();
                dgverrores.Rows.Clear();
                dgvcade.Rows.Clear();
                dgvid.Rows.Clear();
                //si no hay texto ingresado manda mensaje al usuario
                if (string.IsNullOrWhiteSpace(txtleer.Text))
                    MensAdv("No se permite cuadro de texto vacio");
                else //inicia el else
                {
                    //se guarda en una variable todo el codigo para el analizador de codigo intermedio
                    codigoausar = txtleer.Text;
                    //se hace un arrego de strings que representa cada linea del texto ingresado
                    string[] elcodigo = txtleer.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);                   
                    tsprgb1.Maximum = elcodigo.Length; //se establece el numero de bloques para el progressbar
                    int numidentificador = 1, numcadena=1; //se genera una variable que contabiliza los identificadores obtenidos
                    
                    for (int i = 0; i < elcodigo.Length; i++)
                    {
                        //se incrementa el progressbar en 1 bloque cada vez que se entra a leer una nueva linea de codigo
                        tsprgb1.Increment(1);
                        //se asigna a la variable codigo la linea que se esta leyendo de codigo
                        string codigo = elcodigo[i];
                        //se quitan los espacios en blanco que hay al inicio y/o final de la cadena
                        codigo = codigo.Trim();
                        //se convierte la linea de codigo en un arreglo de cada palabra generada
                        string[] palabraslinea = codigo.Split(' ');
                        for (int j = 0; j < palabraslinea.Length; j++)
                        {
                            //se convierte el texto en un arreglo de caracteres de cada letra del texto
                            char[] caracter = palabraslinea[j].ToCharArray();
                            //se usa un contador(x) y el estado inicial se establece en 0
                            int x = 0;
                            //la variable conc ira concatenando cada letra recibida al escribir una palabra
                            //token guardara temporalmente el token aceptado para agregarlo a la lista y concatenarlo en una 
                            //variable que contiene el conjunto de tokens
                            string estado = "0", conc = "", token;
                            //se genera una variable booleana auxiliar para saber si ocurrio o no un error
                            bool error = false;
                            //el ciclo siguiente hara el recorrido en la matriz validando cada caracter ingresado para saber
                            //si es valido y, en caso de serlo identificara tambien que tipo de token se le asigno                    
                            while (x < caracter.Length) //&& error == false)
                            {   //mientras que el iterador sea menor que la cadena y no ocurra un error
                                    //en un string se guardara la celda resultante del recorrido de la matriz
                                    string resultado;
                                    if (error == false)
                                    {
                                        //se verifica que no haya minusculas ya que el manejador de excel no diferencia mayusculas y minusculas en
                                        //sus consultas y nuestro lenguaje esta hecho con la idea de que las palabras reservadas sean unicamente
                                        //mayusculas
                                        if (VerificarMinuscula(caracter[x].ToString())) //si el caracter es minuscula se envia a verificar si es identificador
                                            resultado = BaseD.Transicion(caracter[x].ToString() + "1", estado);
                                        else
                                        {   //si el caracter es de tipo caracter especial
                                            if (VerificarCarEs(caracter[x].ToString()))
                                            {
                                                //se guarda primero dentro de la variable resultado el nombre de columna del caracter
                                                resultado = BaseD.columnaCarEs(caracter[x].ToString());
                                                /*luego se hace el recorrido con el nombre de columna guardado en la variable resultado
                                                y la variable resultado se reemplaza por el resultado del recorrido en la matriz de transicion*/
                                                resultado = BaseD.Transicion(resultado, estado);
                                            }
                                            else
                                            {   /*si el caracter es un digito o una letra mayuscula no se necesita algun tipo de columna especial asi que:
                                     * se captura en una variable string el resultado que arrojo el caracter ingresado,
                                    dicho resultado sera la palabra reservada aceptada, el estado a donde se movera el apuntador, o un error */
                                                resultado = BaseD.Transicion(caracter[x].ToString(), estado);
                                            }
                                        }/*si se obtuvo un estado al cual mover el apuntador(cabezal de lectura), el estado debe ser un digito
                                         para poder mover el apuntador*/
                                        if (VerificarDigito(resultado))
                                        {
                                            estado = resultado; //se apunta al resultado obtenido de la transicion
                                            conc += caracter[x]; //se concatena el caracter en un string para formar la palabra ingresada
                                        }
                                        else
                                        {
                                            //se entrara aqui en caso de que lo recibido haya sido un error, no se entrada a este bloque
                                            //de codigo si es una palabra reservada aceptada ya que al aceptarla sera en fin de cadena, y en el
                                            //recorrido al llegar a fin de cadena, se termina el ciclo                                    
                                            error = true;
                                            conc += caracter[x];
                                        }
                                    }
                                    else
                                    {   // si ocurrio un error durante la lectura de la palabra unicamente se seguira concatenando hasta
                                        //formar dicha palabra, se reemplazara por Error en el cuadro de texto y se agregara a la lista
                                        //al terminar la lectura, despues se limpiara el texto de la variable conc
                                        conc += caracter[x];
                                    }                                                               
                                //se incrementa la variable del iterador
                                x++;
                            }//aqui termina el ciclo while
                            //la palabra se debe de agregar al final, ya que la rutina del while termina antes 
                            //de que se agregue a la lista la palabra
                            token = BaseD.Transicion("FDC", estado);
                            if (error || token == "error")
                            {
                                //si ocurrio un error al final se realiza la misma rutina de dentro del ciclo
                                //txtleer.Text= txtleer.Text.Replace(conc, "Error");
                                dgverrores.Rows.Add(conc, i + 1, j+1);
                                codigoprocesado += " error ";
                            }
                            else
                            {
                                //Se obtiene el token que se le asigna al texto leido y se agrega al datagridview el texto junto con su token
                                //dependiendo de si es IDENTIFICADOR o PALABRA RESERVADA
                                if (token == "IDE")
                                {
                                    if (IDE.Contains(conc) == false)
                                    {
                                        if (ErrorTipo(ant))
                                            ant = "ERROR";
                                        dgvid.Rows.Add(numidentificador, token, conc, ant);                                        
                                        IDE.Add(conc);
                                        token += numidentificador;
                                        AgregarIde(numidentificador, conc, ant, token);
                                        numidentificador++;                                        
                                    }
                                    else
                                        token += (IDE.IndexOf(conc) + 1);
                                }
                                else
                                    if (token == "CADE")
                                    {
                                        dgvcade.Rows.Add(numcadena, conc.Replace("_", " "));
                                        token += numcadena;
                                        numcadena++;
                                    }
                                    else
                                        dgvmatriztransicion.Rows.Add(conc, token);
                                codigoprocesado += " " + token + " "; //se concatena lo obtenido al conjunto de tokens previo
                                ant = token;
                            }
                            estado = "0"; //se reinicia el cabezal de lectura
                            conc = ""; //se limpia la variable con la palabra a concatenar                            
                        }//aqui termina el for usado para las palabras de la linea de codigo
                        //antes de iniciar una nueva linea de codigo se genera un salto de linea en el conjunto de tokens
                        codigoprocesado += "\r\n";
                    }//aqui termina el for de cada linea de codigo
                    tsprgb1.Increment(1); //se le incrementa un bloque al progressbar
                    //se envia un mensaje con el conjunto de tokens generados
                    Mensaje(codigoprocesado);

                }//aqui termina el else(caso de que no haya cuadro vacio)   

                //se contabiliza cada cosa
                lblpa.Text = dgvmatriztransicion.Rows.Count.ToString();
                lblerr.Text = dgverrores.Rows.Count.ToString();
                lblide.Text = dgvid.Rows.Count.ToString();
                lblcadenas.Text = dgvcade.Rows.Count.ToString();
            }//aqui termina el try
            catch (Exception x)
            {
                //al recibir un error se envia un mensaje al usuario con los detalles del error
                MensError(x.Message);
                //si la conexion de datos no es nula, dado que pudo ocurrir dicho error antes de que la conexion se cerrara se 
                //forzara el cierre de la conexion mediante el metodo cerrar de la clase generada para la conexion de datos.
                if (BaseD != null)
                    BaseD.Cerrar();
            }
        }
        //Agrega identificador nuevo a la base de datos de la tabla de simbolos
        public void AgregarIde(int numero, string identificador, string tipo, string tokun) 
        {
            switch (tipo)
            {
                case "PR02":
                    tipo = "CADE";
                    break;
                case "PR08":
                    tipo = "ENTE";
                    break;
                case "PR24":
                    tipo = "REAL";
                    break;
                case "PR03":
                    tipo = "CARA";
                    break;
            }
            string datos = "INSERT INTO TABLAID (numero, nombre, tipo, token) VALUES ("+numero+",\""+ identificador+"\",\""+tipo+"\", \""+tokun+"\")";
            bd.QueryconResultado(datos);
            
        }
        //metodo que verifica que el tipo de un identificador sea valido
        public bool ErrorTipo(string tipo)
        {
            if (tipo == "PR08" || tipo == "PR24" || tipo == "PR02" || tipo == "PR03")
                return false;
            else
                return true;
        }
        //metodos para enviar mensaje al usuario
        public void Mensaje(string str)
        {
            MessageBox.Show(str);
        }

        public void MensError(string str)
        {
            MessageBox.Show(str, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void MensAdv(string str)
        {
            MessageBox.Show(str, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //rutinas para identificar el tipo de caracter unicamente no existe una rutina que identifica mayusculas
        //metodo para verificar digitos
        public static bool VerificarDigito(string car)
        {
            int ascii = Encoding.ASCII.GetBytes(car)[0];
            if ((ascii >= 48 && ascii <= 57))
                return true;
            else
                return false;
        }
        //metodo para verificar que el caracter recibido sea una minuscula
        //este metodo se requiere ya que al hacer una consulta en excel no diferencia mayusculas y minusculas
        public static bool VerificarMinuscula(string car)
        {
            //lo hace obteniendo el primer caracter del string recibido, el string enviado debe ser unicamente una letra
            int ascii = Encoding.ASCII.GetBytes(car)[0];
            if ((ascii >= 97 && ascii <= 122))
                return true;
            else
                return false;
        }       
        //metodo que identifica que lo recibido sea caracter especial
        public static bool VerificarCarEs(string car)
        {
            int ascii = Encoding.ASCII.GetBytes(car)[0];
            if ((ascii >= 33 && ascii <= 47) || (ascii >= 58 && ascii <= 64) || (ascii >= 91 && ascii <= 96) || (ascii >= 123 && ascii <= 126))
                return true;
            else
                return false;
        }

        //al presionar el boton cerrar que se termine la aplicacion
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //codigo que se ejecuta al producirse el evento load
        private void Form1_Load(object sender, EventArgs e)
        {
            //se impide al usuario maximizar el formulario
            this.MaximizeBox = false;
            //se hace un focus al cuadro de texto
            txtleer.Focus();
            
        }

        private void dgverrores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtleer_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtleer_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void txtleer_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnguardar_Click(object sender, EventArgs e)
        {
            //se abre un savefiledialog para indicar en donde se guardara el documento
            SaveFileDialog fichero = new SaveFileDialog();
            //se define la extension del documento como Txt(bloc de notas)
            fichero.Filter = "Bloc de notas(*.txt)|*.txt";
            fichero.Title = "Nombre del archivo";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                //si se selecciono una ruta correcta se genera el txt
                GenerarTxt(codigoprocesado, fichero.FileName);
            }
        }                     

        //Metodo que genera un archivo txt en la ruta inidicada(direccion)
        public void GenerarTxt(string texto, string direccion)
        {
            try
            {
                //se genera un streamwriter
                System.IO.StreamWriter file = new System.IO.StreamWriter(direccion, true);
                file.WriteLine(texto); //se escribe el texto enviado al metodo
                //se cierra la conexion del streamwriter
                file.Close();
                //se envia mensaje de confirmacion de guardado al usuario
                Mensaje("Guardado correctamente en:\n" + direccion);
            }//se envia mensaje al usuario en caso de ocurrir un error
            catch (Exception x)
            {
                MensError(x.Message);
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbtncargartokens_Click(object sender, EventArgs e)
        {
            //se manda a llamar un metodo que solicita la ubicacion del archivo de texto con los tokens
            TxtPath();
        }
        //codigo de sintaxis
        //variables usadas en sintaxis 
        string[] lineasdetokens;
        string cadena;
        string cadenasemantica;
        public void LeerTxt(string path)
        {
            cadena = "";
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                cadena += line + "\r\n";
                counter++;
            }

            file.Close();
            txtleer.Text = cadena;
            cadenasemantica = cadena;
            // Suspend the screen.
            //System.Console.ReadLine();
        }
        
        //metodo que obtiene la ruta del archivo txt a ser analizado
        public void TxtPath()
        {
            //se establece una variable para obtener la ruta de forma vacia
            string ruta = "";
            
            try
            {
                //se abre un archivo de dialogo para buscar el documento de excel al que se quiere conectar
                OpenFileDialog open = new OpenFileDialog();
                //se filtran los archivos a la extension .xlsx
                open.Filter = "archivo de tokens Txt(*.txt)|*.txt";
                //se establece el titulo de dialogo con el string asignado
                open.Title = "Archivo de tokens";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    //si se obtuvo una ruta para el archivo de excel se guardara la ruta en la variable generada anteriormente
                    ruta = open.FileName;
                }
                //se libera de memoria la variable del archivo de dialogo
                open.Dispose();

                LeerTxt(ruta);
                //se hace un arrego de strings que representa cada linea del texto de tokens ingresados
                lineasdetokens = cadena.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (NullReferenceException)
            {
                //si el archivo de excel es nulo se manda mensaje al usuario
                MessageBox.Show("El archivo seleccionado es nulo :c");
            }
            catch (Exception ex)
            {
                //si ocurre una excepcion de cualquier tipo por alguna razon desconocida se manda mensaje al usuario con los
                //detalles del error ocurrido
                MessageBox.Show(":c No se pudo porque: " + ex.Message);
            }
        }

        private void tsbtncargargram_Click(object sender, EventArgs e)
        {
            //se establece una variable para obtener la ruta de forma vacia
            string route = "";
            try
            {
                //se abre un archivo de dialogo para buscar el documento de excel al que se quiere conectar
                OpenFileDialog open = new OpenFileDialog();
                //se filtran los archivos a la extension .xlsx
                open.Filter = "archivo Access(*.accdb)|*.accdb";
                //se establece el titulo de dialogo con el string asignado
                open.Title = "Documentos Access";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    //si se obtuvo una ruta para el archivo de excel se guardara la ruta en la variable generada anteriormente
                    route = open.FileName;
                }
                //se libera de memoria la variable del archivo de dialogo
                open.Dispose();
                //luego de obtener la ruta podemos iniciar la base de datos
                bd = new BD(route);
                //se da a entender al usuario que la conexion se logro cambiando el texto de un label que indica el estado de conexion
                tslblconexion.Text = "Enlazado a la gramática :D";

            }
            catch (NullReferenceException)
            {
                //si el archivo de excel es nulo se manda mensaje al usuario
                MessageBox.Show("El archivo Excel seleccionado es nulo :c");
            }
            catch (Exception ex)
            {
                //si ocurre una excepcion de cualquier tipo por alguna razon desconocida se manda mensaje al usuario con los
                //detalles del error ocurrido
                MessageBox.Show(":c No se pudo porque: " + ex.Message);
                //se da a entender al usuario que hubo un error cambiando el texto del label que indica el estado de conexion
                tslblconexion.Text = "Posible error de conexion";
            }
        }
        //variables para analisis sintactico
        BD bd;
        int n, token = -1;//n representa la variable auxiliar para recorrer por bloques la linea de tokens.
        //token es una variable que indica la posicion de la cual empezar a hacer recorrido.        
        string[] tokens;//lineas de tokens es un arreglo string separado por cada linea de tokens que hay
        //en el documento txt. tokens es un arreglo string que guarda los tokens por cada
        //linea que se recorrera.
        //metodos para analisis sintactico
        public void Convertir(string cade, string nuevovalor, int posicion)
        {
            lineasdetokens[posicion] = lineasdetokens[posicion].Replace(cade, nuevovalor);
            cadena = cadena.Replace(cade, nuevovalor);
        }

        public string Extraer(int posicion, int cantidad)
        {
            string conc = "";
            int conteo = 0;
            for (int x = token; conteo < n; x++)
            {
                conteo++;
                conc += tokens[x] + " ";
            }
            Mensaje(conc);
            return conc;
        }
        //analisis de la sintaxis del codigo
        private void tsbtnansintax_Click(object sender, EventArgs e)
        {
            string resultados = "";
            tsprgb1.Value = tsprgb1.Minimum;
            tsprgb1.Maximum = lineasdetokens.Length; //se establece el numero de bloques para el progressbar
            if (string.IsNullOrWhiteSpace(cadena))
                MensAdv("El archivo de tokens ingresado esta vacío.");
            else
            {
                try
                {
                    string r;
                    tslblconexion.Text = "Analizando...";

                    for (int i = 0; i < lineasdetokens.Length; i++)
                    {
                        do
                        {
                            cadena = lineasdetokens[i].Trim();
                            tokens = cadena.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            n = tokens.Length;
                            string query = "Select LI from Gramatica Where LD= \"" + cadena + "\"";
                            r = bd.Buscar(query);
                            if (r != " ")
                                Convertir(cadena, r, i);
                            else
                            {
                                bool cambiado = false;
                                while (n > 0)
                                {
                                    n -= 1;
                                    token = -1;
                                    if (n == 0 && cambiado == false)
                                        cadena = "ERROR";
                                    else
                                    {
                                        cadena += " ";
                                        while ((token + n) < tokens.Length)
                                        {
                                            token += 1;

                                            string aux = Extraer(token, n);

                                            aux = aux.Trim();
                                            r = bd.Buscar("Select LI from Gramatica Where LD=\"" + aux + "\"");
                                            if (r != " ")
                                            {
                                                Convertir(aux, r, i);
                                                token = tokens.Length * 5;
                                                cambiado = true;
                                                n = 0;
                                            }

                                        }
                                    }
                                }
                            }
                        } while (cadena != "S" && cadena != "ERROR");
                        tsprgb1.Increment(1);
                        resultados += "Linea " + i + " : " + cadena + "\r\n";

                    }

                    Mensaje( "Resultados:\r\n" + resultados);
                    tslblconexion.Text = "Análisis terminado.";
                }
                catch (Exception x)
                {
                    MensError(x.Message);
                    tslblconexion.Text = "Fallo en el análisis.";
                    if (bd != null)
                        bd.Cerrar();
                }
            }
        }
        //termina analisis sintactico

        //comienza analisis semantico

        private void tsbtngentoken_Click(object sender, EventArgs e)
        {
            try
            {
                
                int hay = bd.QueryconResultado("select tipo from TABLAID where tipo=\"ERROR\"");
                if (hay > 0)
                {
                    MensError("Error en tipo de dato de variables");
                }
                else
                {
                    tokenssem = cadenasemantica.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    lintokensem = cadenasemantica.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    ContInsComp();
                    cadenasemantica = cadenasemantica.Trim();
                    //cadenasemantica = cadenasemantica.Replace("PR6", "");
                    //cadenasemantica = cadenasemantica.Replace("PR8", "");
                    //cadenasemantica = cadenasemantica.Replace("PR24", "");
                    //cadenasemantica = cadenasemantica.Replace("PR2", "");
                    //cadenasemantica = cadenasemantica.Replace("PR3", "");

                    //cadenasemantica= cadenasemantica.Replace("CONE", "ENTE");
                    //cadenasemantica = cadenasemantica.Replace("CONR", "REAL");
                    //cadenasemantica= cadenasemantica.Replace("COME", "");
                    //cadenasemantica= cadenasemantica.Replace("CADE", "CADE");

                    //cadenasemantica = cadenasemantica.Replace("PR8", "ENTE");
                    //cadenasemantica = cadenasemantica.Replace("PR24", "REAL");
                    //cadenasemantica = cadenasemantica.Replace("PR2", "CADE");
                    //cadenasemantica = cadenasemantica.Replace("PR3", "CARA");

                    
                    for (int countini = 0; countini < tokenssem.Length; countini++)
                    {
                        if (tokenssem[countini].Contains("IDE"))
                        {
                            string tipotoken = bd.Buscar("Select tipo from TABLAID where token = \"" + tokenssem[countini] + "\"");
                            cadenasemantica = cadenasemantica.Replace(tokenssem[countini], tipotoken);
                        }

                        if (tokenssem[countini].Contains("CONE"))
                        {
                            cadenasemantica = cadenasemantica.Replace(tokenssem[countini], "ENTE");
                        }

                        if (tokenssem[countini].Contains("CONR"))
                        {
                            cadenasemantica = cadenasemantica.Replace(tokenssem[countini], "REAL");
                        }

                        if (tokenssem[countini].Contains("CADE"))
                        {
                            cadenasemantica = cadenasemantica.Replace(tokenssem[countini], "CADE");
                        }

                        if (tokenssem[countini].Contains("OPA"))
                        {
                            cadenasemantica = cadenasemantica.Replace(tokenssem[countini], "OPAR");
                        }

                        if (tokenssem[countini].Contains("OPR"))
                        {
                            cadenasemantica = cadenasemantica.Replace(tokenssem[countini], "OPRE");
                        }

                    }
                    
                    Mensaje(cadenasemantica);

                }
            }
            catch(Exception x )
            {
                MensError(x.Message);
            }
        }
        //variables usadas en semantica
        string[] tokenssem, lintokensem;
        //metodo para contar instrucciones compuestas
        public void ContInsComp()
        {
            int ifs=0, thens =0, cases=0, fors=0, dwhiles=0, whiles=0, inifin=0, elses =0;
            //analizar cada linea de tokens para semantica
            for (int a = 0; a < tokenssem.Length; a++)
            {
                switch (tokenssem[a])
                { 
                    case "PR27":
                        elses++;
                        break;
                    case "PR14":
                        elses--;
                        break;
                    case "PR26":
                        ifs++;
                        break;
                    case "PR13":
                        ifs--;
                        break;
                    case "PR4" :
                        cases++;
                        break;
                    case "PR5":
                        cases--;
                        break;
                    case "PR25":
                        fors++;
                        break;
                    case "PR12":
                        fors--;
                        break;
                    case "PR15" : //incrementa while cuando no hay un do while
                        if(whiles==0)
                        dwhiles++;
                        break;
                    case "PR21" : // incrementa do while cuando no hay while
                        if (dwhiles == 0)
                            whiles++;
                        else
                            dwhiles--; //cierra do while si hay un do while abierto
                        break;
                    case "PR11": //cierra un while
                        whiles--;
                        break;
                    case "PR18":
                        inifin++;
                        break;
                    case "PR10":
                        inifin--;
                        break;
                }
            }
            if (inifin != 0)
            { MensAdv("Instruccion de inicio-fin incorrecta"); }
            if (dwhiles != 0)
            {
                MensAdv("Instruccion HACER-MIENTRAS incorrecta");
            }
            if (whiles != 0)
            { MensAdv("Instruccion MIENTRAS-HACER incorrecta"); }

            if (fors != 0)
            { MensAdv("instruccion HACER-PASO incorrecta"); }

            if (cases != 0)
            { MensAdv("Instruccion CASO-DEFAULT incorrecta"); }
            if (ifs != 0)
            { MensAdv("Instruccion SI-FINSI incorrecta"); }
            if (elses != 0)
            {
                MensAdv("Instruccion SINO-FINSINO incorrecta");
            }

        }

        private void tsbtncarregsem_Click(object sender, EventArgs e)
        {
            //se establece una variable para obtener la ruta de forma vacia
            string route = "";
            try
            {
                //se abre un archivo de dialogo para buscar el documento de excel al que se quiere conectar
                OpenFileDialog open = new OpenFileDialog();
                //se filtran los archivos a la extension .xlsx
                open.Filter = "archivo Access(*.accdb)|*.accdb";
                //se establece el titulo de dialogo con el string asignado
                open.Title = "Documentos Access";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    //si se obtuvo una ruta para el archivo de excel se guardara la ruta en la variable generada anteriormente
                    route = open.FileName;
                }
                //se libera de memoria la variable del archivo de dialogo
                open.Dispose();
                //luego de obtener la ruta podemos iniciar la base de datos
                bd = new BD(route);
                //se da a entender al usuario que la conexion se logro cambiando el texto de un label que indica el estado de conexion
                tslblconexion.Text = "Enlazado a la gramática :D";

            }
            catch (NullReferenceException)
            {
                //si el archivo de excel es nulo se manda mensaje al usuario
                MessageBox.Show("El archivo Excel seleccionado es nulo :c");
            }
            catch (Exception ex)
            {
                //si ocurre una excepcion de cualquier tipo por alguna razon desconocida se manda mensaje al usuario con los
                //detalles del error ocurrido
                MessageBox.Show(":c No se pudo porque: " + ex.Message);
                //se da a entender al usuario que hubo un error cambiando el texto del label que indica el estado de conexion
                tslblconexion.Text = "Posible error de conexion";
            }
        }

        private void tsbtnansem_Click(object sender, EventArgs e)
        {
            string resultados = "";
            tsprgb1.Value = tsprgb1.Minimum;
            tsprgb1.Maximum = lintokensem.Length; //se establece el numero de bloques para el progressbar
            if (string.IsNullOrWhiteSpace(cadenasemantica))
                MensAdv("El archivo de tokens ingresado esta vacío.");
            else
            {
                try
                {
                    string r;
                    tslblconexion.Text = "Analizando...";
                    cadenasemantica = cadenasemantica.Replace("  ", " ");
                    lintokensem = cadenasemantica.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < lintokensem.Length; i++)
                    {
                        do
                        {
                            cadenasemantica = lintokensem[i].Trim();
                            tokenssem = cadenasemantica.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            n = tokenssem.Length;
                            string query = "Select LI from REGLAS Where LD= \"" + cadenasemantica + "\"";
                            r = bd.Buscar(query);
                            if (r != " ")
                                ConvertirSemantica(cadenasemantica, r, i);
                            else
                            {
                                bool cambiado = false;
                                while (n > 0)
                                {
                                    n -= 1;
                                    token = -1;
                                    if (n == 0 && cambiado == false)
                                        cadenasemantica = "ERROR";
                                    else
                                    {
                                        cadenasemantica += " ";
                                        while ((token + n) < tokenssem.Length)
                                        {
                                            token += 1;

                                            string aux = ExtraerSemantica(token, n);

                                            aux = aux.Trim();
                                            r = bd.Buscar("Select LI from REGLAS Where LD=\"" + aux + "\"");
                                            if (r != " ")
                                            {
                                                ConvertirSemantica(aux, r, i);
                                                token = tokenssem.Length * 5;
                                                cambiado = true;
                                                n = 0;
                                            }

                                        }
                                    }
                                }
                            }
                        } while (cadenasemantica != "S" && cadenasemantica != "ERROR");
                        tsprgb1.Increment(1);
                        resultados += "Linea " + i + " : " + cadenasemantica + "\r\n";

                    }

                    Mensaje("Resultados:\r\n" + resultados);
                    tslblconexion.Text = "Análisis terminado.";
                }
                catch (Exception x)
                {
                    MensError(x.Message);
                    tslblconexion.Text = "Fallo en el análisis.";
                    if (bd != null)
                        bd.Cerrar();
                }
            }
        }
        //metodos de analisis semantico 
        public void ConvertirSemantica(string cade, string nuevovalor, int posicion)
        {
            lintokensem[posicion] = lintokensem[posicion].Replace(cade, nuevovalor);
            cadenasemantica = cadenasemantica.Replace(cade, nuevovalor);
        }

        public string ExtraerSemantica(int posicion, int cantidad)
        {
            string conc = "";
            int conteo = 0;
            for (int x = token; conteo < n; x++)
            {
                conteo++;
                conc += tokenssem[x] + " ";
            }
            Mensaje(conc);
            return conc;
        }
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        
        //metodo que genera el postfijo mediante tokens en lugar de cadenas de caracteres
        //variables postfijo

        //aqui inicia el codigo intermedio
        public static string PFTokens(List<string> ENTRADA)
        {
            //entrada sera el texto de codigo ingresado por el usuario
            //test: 6 * X  * 4 + y * 6 + a * 3 / X * 4 * r 
            string s1 = null, s2 = null, s3 = null, aux1 = null, aux2 = null, carac="", carac2="", oo;
            int largo = 0, parcial = 1, ll = 0, jc = 0, ja = 0, lo, laux = 0, largo2 = 0, ce1 = 1, conta = 0;
            
            largo = ENTRADA.Count;
            int igual = 0;
            while (parcial <= largo)
            {
                if (ENTRADA[parcial - 1].Contains("IDE"))
                {
                    carac = "IDEN"; 
                }
                else
                    carac = ENTRADA[parcial - 1];

                switch (carac)
                {
                    case "CAE1": //=
                        igual++;
                        break;
                    case "CONU":
                    case "CONR":
                    case "CONE":                    
                        s1 = s1 + carac;                        
                        break;
                    case "IDEN":
                        s1 = s1 + ENTRADA[parcial-1];
                        break;
                    case "OPA3": //*
                    case "OPA2": //-
                    case "OPA1"://+
                    case "OPA4":// /
                    case "OPA5"://^
                    case "OPR1"://<
                    case "OPR2"://<=
                    case "OPR3"://<>
                    case "OPR4"://>
                    case "OPR5"://>=
                    case "OPR6"://==
                    case "OPL3"://!
                    case "OPL2"://||
                    case "OPL1"://&&
                        if (ll == 0)
                        {
                            aux1 = aux1 + carac;
                            ll = 1;
                        }
                        else
                        {
                            lo = aux1.Length - 1;//**--
                            //aqui se debe tomar el ultimo caracter y no el primero
                            oo = Convert.ToString(aux1.Substring(0, 4));
                            jc = jerarquia(carac);
                            ja = jerarquia(oo);
                            if (jc > ja)
                            {
                                if (aux1.Length > 4)
                                    aux2 = aux1.Substring(4, aux1.Length - 4);
                                aux1 = "";
                                aux1 = aux1 + carac + oo;

                            }
                            else
                            {
                                if (jc == ja)
                                {
                                    s1 = s1 + aux1.Substring(0, 4);
                                    laux = aux1.Length;
                                    if (laux >= 8)
                                        aux1 = aux1.Substring(4, laux - 4);
                                    else
                                        aux1 = "";
                                    aux1 = carac + aux1;
                                }
                                else
                                {
                                    s1 = s1 + aux1;
                                    aux1 = carac;
                                }
                            }
                        }
                        break;
                    case "CE13":
                        largo2 = parcial;
                        while (ce1 != 0)
                        {
                            carac2 = ENTRADA[largo2];
                            s2 = s2 + carac2;
                            conta++;
                            largo2++;
                            switch (carac2)
                            {
                                case "CE13": //(
                                    ce1++;
                                    break;
                                case "CE14": //)
                                    ce1--;
                                    break;
                            }

                        }
                        s2 = s2.Substring(0, conta - 4);
                        List<string> listas2 = new List<string>();
                        string[] arrs2 = s2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string item in arrs2)
                        {
                            listas2.Add(item);
                        }
                        s3 = PFTokens(listas2);
                        s1 = s1 + s3;
                        s2 = null;
                        conta = 0;
                        ce1 = 1;
                        parcial = largo2;
                        break;
                }
                parcial++;
            }
            if (string.IsNullOrEmpty(aux2) == false)
                aux1 += aux2;
            s1 = s1 + aux1;
            if (igual == 1)
                s1 += "CAE1";

            //mostrandotokensconespaciado
            aux1 = "";
            for (int q = 0; q < s1.Length; q= q + 4)
            {
                aux1 += s1.Substring(q, 4)+ " ";
            }
            MessageBox.Show(aux1);
            s1 = aux1;
            //
            return s1;
        }


        public string POSTFIJO(string ENTRADA)
        {
            //entrada sera el texto de codigo ingresado por el usuario
            string s1 = null, s2 = null, s3 = null, aux1 = null, aux2=null;
            int largo = 0, parcial = 1, ll = 0, jc = 0, ja = 0, lo, laux = 0, largo2 = 0, ce1 = 1, conta = 0;
            char oo, carac2 = ' ';
            largo = ENTRADA.Length;
            int igual = 0;
            while (parcial <= largo)
            {
                char carac;
                carac = Convert.ToChar(ENTRADA.Substring(parcial - 1, 1));
                
                switch (carac)
                {
                    case '=':
                        igual++;
                        break;
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'x':
                    case 'y':
                    case 'z':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case '0':
                        s1 = s1 + carac;
                        MessageBox.Show(s1);
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '^': //opa5
                        if (ll == 0)
                        {
                            aux1 = aux1 + carac;
                            ll = 1;
                        }
                        else
                        {
                            lo = aux1.Length - 1;
                            //aqui se debe tomar el ultimo caracter y no el primero
                            oo = Convert.ToChar(aux1.Substring(0, 1));
                            //jc=jerarquia(carac); se debe rehabilitar estos metodos de manera que acepte valores char en vez de string
                            //ja=jerarquia(oo);    solo si se desea reutilizar este método.
                            if (jc > ja)
                            {                               
                                if (aux1.Length > 1)
                                    aux2 = aux1.Substring(1, aux1.Length - 1);
                                aux1 = "";
                                aux1 = aux1 + carac + oo;
                                
                            }
                            else
                            {
                                if (jc == ja)
                                {
                                    s1 = s1 + aux1.Substring(0, 1);
                                    laux = aux1.Length;
                                    aux1 = aux1.Substring(1, laux - 1);
                                    aux1 = carac + aux1;
                                }
                                else
                                {
                                    s1 = s1+aux1;
                                    aux1 = Convert.ToString(carac);
                                }
                            }
                        }
                        MessageBox.Show(s1);
                        break;
                    case '(':
                        largo2 = parcial;
                        while (ce1 != 0)
                        {
                            carac2 = Convert.ToChar(ENTRADA.Substring(largo2, 1));
                            s2 = s2 + carac2;
                            conta++;
                            largo2++;
                            switch (carac2)
                            {
                                case '(':
                                    ce1++;
                                    break;
                                case ')':
                                    ce1--;
                                    break;
                            }

                        }
                        s2 = s2.Substring(0, conta - 1);
                        s3 = POSTFIJO(s2);
                        s1 = s1 + s3;
                        s2 = null;
                        conta = 0;
                        ce1 = 1;
                        parcial = largo2;
                        MessageBox.Show(s1);
                        break;
                }
                
                parcial++;                
            }
            if (string.IsNullOrEmpty(aux2) == false)
                aux1 += aux2;
            s1 = s1+aux1;
            MessageBox.Show(s1);
            if (igual == 1)
                s1 += '=';
            return s1;
        }
        public static int jerarquia(string jeej)
        {
            if (jeej.Contains("OPR"))
                jeej = "OPRE";
            switch (jeej)
            {
                case "OPA1":
                case "OPA2":
                    return 5;
                    break;
                case "OPA3":
                case "OPA4":
                    return 6;
                    break;
                case "OPA5":
                    return 7;
                    break;
                case "OPRE":
                    return 4;
                case "OPL3":
                    return 3;
                case "OPL1":
                    return 2;
                case "OPL2":
                    return 1;
                default :
                    return -1;
            }
        }

        private void btnpost_Click(object sender, EventArgs e)
        {
            try
            {
                tsbtncargartokens.PerformClick();
                pfatrp = PFTokens(ArregloTokens());  //POSTFIJO(txtleer.Text);
                Mensaje(pfatrp);
                txtleer.Text = pfatrp;
            }
            catch (Exception x)
            {
                MensError(x.Message);                
            }
        }
        //variable que contiene el postfijo generado
        string pfatrp;
        //formulario que contiene la tripleta
        Frmtripleta formtrp = new Frmtripleta();
        
        private void btncodint_Click(object sender, EventArgs e)
        {
            //contador para enumerar temporales
            int tmpnum = 2;
            //arreglo con los tokens en orden del postfijo
            string[] tkpf = pfatrp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //declaracion de temporales para los registros ax, bx
            string ax=null, bx=null;
            //cadenas auxiliares
            List<string> cadenaoriginal = new List<string>();
            foreach (string x in tkpf)
            {
                cadenaoriginal.Add(x); 
            }
            List<string> auxiliar1 = new List<string>();
            List<string> auxiliar2 = new List<string>();
            //contador
            int contador=0, vez=0;
            //bandera
            bool bandera1=false, bandera2=false; 
            //analisis de tokens
            do
            { //
                do
                {
                    auxiliar1.Add(cadenaoriginal[contador]);
                    if (cadenaoriginal[contador].Contains("OPA") || cadenaoriginal[contador] == "CAE1")
                    {
                        bandera1 = true;
                    }
                    contador++;
                } while (bandera1 == false);
                //contador=0;
                auxiliar2.Add(auxiliar1[auxiliar1.Count - 3]);
                auxiliar2.Add(auxiliar1[auxiliar1.Count - 2]);
                auxiliar2.Add(auxiliar1[auxiliar1.Count - 1]);

                if (vez == 0)
                {
                    formtrp.AgregarFila("T1", auxiliar2[0], "=");
                    formtrp.AgregarFila("T1", auxiliar2[1], auxiliar2[2]);
                    MessageBox.Show("T1 "+ auxiliar2[0]+ " =");
                    auxiliar1.RemoveAt(auxiliar1.Count - 1);
                    auxiliar1.RemoveAt(auxiliar1.Count - 1);
                    auxiliar1[auxiliar1.Count - 1] = "T1";
                    vez++;
                }
                else
                {
                    //agregado para coregir errorinis
                    if (auxiliar2[0].Length != 2 && auxiliar2[2] != "CAE1")
                    {
                        formtrp.AgregarFila("T" + tmpnum, auxiliar2[0], "=");
                        //formtrp.AgregarFila("T" + tmpnum, auxiliar2[1], auxiliar2[2]);
                        auxiliar2[0] = "T"+ tmpnum;
                        tmpnum++;
                    }
                    //agregado para corregir errorinis
                    formtrp.AgregarFila(auxiliar2[0], auxiliar2[1], auxiliar2[2]);
                    MessageBox.Show(auxiliar2[0]+ " "+ auxiliar2[1]+ " "+ auxiliar2[2]);
                    auxiliar1.RemoveAt(auxiliar1.Count - 1);
                    auxiliar1.RemoveAt(auxiliar1.Count - 1);
                    auxiliar1[auxiliar1.Count - 1] = auxiliar2[0];
                }
                
                //
                
                if (contador >= cadenaoriginal.Count)
                {
                    cadenaoriginal = auxiliar1;
                    bandera2 = true;
                }
                else
                {
                    cadenaoriginal.RemoveAt(contador - 1);
                    cadenaoriginal.RemoveAt(contador - 2);
                    cadenaoriginal[contador - 3] = auxiliar1[auxiliar1.Count - 1];
                    auxiliar1.Clear();
                    auxiliar2.Clear();
                    contador = 0;
                    bandera1 = false;
                }
                //formtrp.Show();
            } while (bandera2 == false);
            formtrp.Show();
        }
        //método que devuelve una lista tipo string que contiene los tokens del archivo leído.
        public List<string> ArregloTokens()
        {
            List<string> adevolver = new List<string>();
            for (int i = 0; i < lineasdetokens.Length; i++)
            {
                string[] tokenseparados = lineasdetokens[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string agregartoken in tokenseparados)
                {
                    adevolver.Add(agregartoken);
                }
            }
            return adevolver;
        }

        private void btnci_Click(object sender, EventArgs e)
        {
             
        }

        
    }
}
