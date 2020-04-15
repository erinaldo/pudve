﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PuntoDeVentaV2
{
    public partial class MisDatos : Form
    {
        // variable de text para poder dirigirnos a la carpeta principal para
        // poder jalar las imagenes o cualquier cosa que tengamos hay en ese directorio
        //public string rutaDirectorio = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

        FileStream IconoBtnActualizarDatos, IconoBtnSubirArchivo, IconoBtnBorrarImg;

        // creamos un objeto para poder usar las  
        // consultas que estan en esta clase
        Conexion cn = new Conexion();
        // creamos un objeto para poder usar las  
        // consultas que estan en esta clase 
        Consultas cs = new Consultas();

        // declaramos la variable que almacenara el valor de userNickName
        public string userName;
        public string passwordUser;

        // variables para poder hacer las consulta y actualizacion
        string buscar;
        string actualizar;
        string llenarCB;

        // variables para poder tomar el valor de los TxtBox y tambien hacer las actualizaciones
        // del valor que proviene de la base de datos ó tambien actualizar la Base de Datos
        string id;
        string nomComp; string rfc;
        string calle; string numExt;
        string numInt; string colonia;
        string mpio; string estado;
        string codPostal; string email;
        string telefono; string regimen;
        string logoTipo;

        // Variable para poder saber que tipo de persona 
        // es el cliente que inicio sesion en el Pudve
        string tipoPersona;

        // variables para poder hacer el recorrido y asignacion de los valores que estan el base de datos
        int index;
        DataTable dt, dtcb, cbreg;
        DataRow row, rows;

        // direccion de la carpeta donde se va poner las imagenes
        string saveDirectoryImg = @"C:\Archivos PUDVE\MisDatos\Usuarios\";
        // ruta donde estan guardados los archivos digitales
        string ruta_archivos_guadados = @"C:\Archivos PUDVE\MisDatos\CSD\";

        // objeto para el manejo de las imagenes
        FileStream File,File1;
        FileInfo info;

        // nombre de archivo
        string fileName;
        // directorio origen de la imagen
        string oldDirectory;
        // directorio para guardar el archivo
        string fileSavePath;
        // Nuevo nombre del archivo
        string NvoFileName;

        OpenFileDialog f;

        public MisDatos()
        {
            InitializeComponent();
        }
        public void cargarTxtBox()
        {
            index = 0;

            /****************************************************
            *   obtenemos los datos almacenados en el dt        *
            *   y se los asignamos a cada uno de los variables  *
            ****************************************************/
            id = dt.Rows[index]["ID"].ToString();
            nomComp = dt.Rows[index]["NombreCompleto"].ToString();
            rfc = dt.Rows[index]["RFC"].ToString();
            calle = dt.Rows[index]["Calle"].ToString();
            numExt = dt.Rows[index]["NoExterior"].ToString();
            numInt = dt.Rows[index]["NoInterior"].ToString();
            colonia = dt.Rows[index]["Colonia"].ToString();
            mpio = dt.Rows[index]["Municipio"].ToString();
            estado = dt.Rows[index]["Estado"].ToString();
            codPostal = dt.Rows[index]["CodigoPostal"].ToString();
            email = dt.Rows[index]["Email"].ToString();
            telefono = dt.Rows[index]["Telefono"].ToString();
            regimen = dt.Rows[index]["Regimen"].ToString();
            tipoPersona = dt.Rows[index]["TipoPersona"].ToString();
            logoTipo = dt.Rows[index]["LogoTipo"].ToString();

            /****************************************
            *   ponemos los datos en los TxtBox     *
            *   almancenados en las variables       *
            *   para mostrarlos en la Forma         *
            ****************************************/
            txtNombre.Text = nomComp;
            txtRFC.Text = rfc;
            txtCalle.Text = calle;
            txtNoExt.Text = numExt;
            txtNoInt.Text = numInt;
            txtColonia.Text = colonia;
            txtMpio.Text = mpio;
            txtEstado.Text = estado;
            txtCodPost.Text = codPostal;
            txtEmail.Text = email;
            txtTelefono.Text = telefono;
            LblRegimenActual.Text = regimen;


            // si el campo de la base de datos es difrente a null
            if (logoTipo != "")
            {
                if (System.IO.File.Exists(saveDirectoryImg + logoTipo))
                {
                    // usamos temporalmente el objeto File
                    using (File = new FileStream(saveDirectoryImg + logoTipo, FileMode.Open, FileAccess.Read))
                    {
                        // asignamos la imagen al PictureBox
                        pictureBox1.Image = Image.FromStream(File);
                        // destruimos o desactivamos el bjeto File
                        File.Dispose();
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }

            /********************************
            *   Relleno de los RadioButton  *
            ********************************/
            if (tipoPersona == "Física")
            {
                // Radio Button para persona Física
                rbPersonaFisica.Checked = true;
            }
            if (tipoPersona == "Moral")
            {
                // Radio Button para persona Física
                rbPersonaMoral.Checked = true;
            }
            // hacemos que el comboBox tenga la carga  
            // de valores de la tabla RegimenFiscal
            cargarComboBox();



            // Cargar datos de los archivos digitales

            cargar_archivos();
        }

        public void cargarComboBox()
        {
            // limpiamos los items del comboBox
            cbRegimen.Items.Clear();

            // insertamos en el campo del index 0 el texto Selecciona un Regimen
            cbRegimen.Items.Insert(0,"Selecciona un Regimen");
            
            /********************************
            *   Relleno de los RadioButton  *
            ********************************/

            // si es que no estan marcados los radio buttons
            if (rbPersonaFisica.Checked && rbPersonaMoral.Checked)
            {
                /************************************************ 
                *   hacemos el recorrido para poder agregar     * 
                *   los registros en el ComboBoxText            *
                ************************************************/
                for (index = 0; index < dtcb.Rows.Count; index++)
                {
                    // agregamos los valores del los Items en el comboBox
                    // estos son tomados desde la Tabla RegimenFiscal
                    cbRegimen.Items.Add(dtcb.Rows[index]["Descripcion"].ToString());
                }
            }

            // si es que esta marcado el persona Fisica
            if (rbPersonaFisica.Checked)
            {
                // String para llenar el ComboBox
                llenarCB = "SELECT CodigoRegimen, Descripcion FROM RegimenFiscal WHERE AplicaFisica LIKE 'Sí'";
                // la consulta realizada la almacenamos en cbreg
                cbreg = cn.cargarCBRegimen(llenarCB);
                /************************************************ 
                *   hacemos el recorrido para poder agregar     * 
                *   los registros en el ComboBoxText            *
                ************************************************/
                for (index = 0; index < cbreg.Rows.Count; index++)
                {
                    // agregamos los valores del los Items en el comboBox
                    // estos son tomados desde la Tabla RegimenFiscal
                    cbRegimen.Items.Add(cbreg.Rows[index]["Descripcion"].ToString());
                }
            }

            // si es que esta marcado el persona Fisica
            if (rbPersonaMoral.Checked)
            {
                // String para llenar el ComboBox
                llenarCB = "SELECT CodigoRegimen, Descripcion FROM RegimenFiscal WHERE AplicaMoral LIKE 'Sí'";
                // la consulta realizada la almacenamos en cbreg
                cbreg = cn.cargarCBRegimen(llenarCB);
                /************************************************ 
                *   hacemos el recorrido para poder agregar     * 
                *   los registros en el ComboBoxText            *
                ************************************************/
                for (index = 0; index < cbreg.Rows.Count; index++)
                {
                    // agregamos los valores del los Items en el comboBox
                    // estos son tomados desde la Tabla RegimenFiscal
                    cbRegimen.Items.Add(cbreg.Rows[index]["Descripcion"].ToString());
                }
            }

            cbRegimen.SelectedIndex = 0;
        }
    
        public void actualizarVariables()
        {
            // actualizamos los valores de la variables con los
            // nuevos valores que modifica el suarios de sus
            // datos para realizar el UpDate
            nomComp = txtNombre.Text;
            rfc = txtRFC.Text;
            calle = txtCalle.Text;
            numExt = txtNoExt.Text;
            numInt = txtNoInt.Text;
            colonia = txtColonia.Text;
            mpio = txtMpio.Text;
            estado = txtEstado.Text;
            codPostal = txtCodPost.Text;
            email = txtEmail.Text;
            telefono = txtTelefono.Text;
            // verificamos si el combobox esta en el primer registro
            if (cbRegimen.Text == "Selecciona un Regimen")
            {
                // si el registro de la base de datos esta en blanco
                // se deja igual en blanco
                if (regimen=="")
                {
                    regimen = "";
                }
                // si no se queda igual que el label que esta desde la consulta
                // inicial y no requiere ningun cambio
                else
                {
                    regimen = LblRegimenActual.Text;
                }
            }
            // de caso contrario se toma el texto seleccionado
            // del comboBox para hacer la actualizacion
            else
            {
                regimen = cbRegimen.Text;
            }
        }

        // funcion para poder cargar los datos segun corresponda en el TxtBox que corresponda
        public void data()
        {
            // hacemos que los txtBox tengan los valores de la consulta
            cargarTxtBox();
        }

        // funcion para poder cargar los datos al abrir la forma
        public void consulta()
        {
            index = 0;

            // String para hacer la consulta filtrada sobre
            // el usuario que inicia la sesion
            buscar = $"SELECT * FROM Usuarios WHERE Usuario = '{userName}' AND Password = '{passwordUser}'";

            // almacenamos el resultado de la Funcion CargarDatos
            // que esta en la calse Consultas
            dt = cn.CargarDatos(buscar);

            // almacenamos el resultado de la consulta en el dt
            if (dt.Rows.Count > 0)
            {
                row = dt.Rows[0];
            }

            // almacenamos el resultado de la Funcion ConsultaRegimenFiscal
            // que esta en la calse Consultas
            dtcb = cn.ConsultaRegimenFiscal();

            // almacenamos el resultado de la consulta en el dtcb
            while (index < dtcb.Rows.Count)
            {
                rows = dtcb.Rows[index];
                index++;
            }

            // llamamos la funcion data()
            data();
        }

        private void MisDatos_Load(object sender, EventArgs e)
        {
            // asignamos el valor de userName que sea
            // el valor que tiene userNickUsuario en el formulario Principal
            userName = FormPrincipal.userNickName;
            passwordUser = FormPrincipal.userPass;
            // realizamos la carga de los datos del usuario
            consulta();
            // usamos la variable File para abrir el archivo de imagen, poder leerlo y agregarlo al boton
            // despues de agregado se libera la imagen para su posterior manipulacion si asi fuera
            using (IconoBtnActualizarDatos = new FileStream(Properties.Settings.Default.rutaDirectorio + @"\PUDVE\icon\black\save.png", FileMode.Open, FileAccess.Read))
            {
                // Asignamos la imagen al BtnRegistrar
                btnActualizarDatos.Image = Image.FromStream(IconoBtnActualizarDatos);
            }
            using (IconoBtnSubirArchivo = new FileStream(Properties.Settings.Default.rutaDirectorio + @"\PUDVE\icon\black\cloud-upload.png", FileMode.Open, FileAccess.Read))
            {
                btnSubirArchivo.Image = Image.FromStream(IconoBtnSubirArchivo);
            }
            using (IconoBtnBorrarImg = new FileStream(Properties.Settings.Default.rutaDirectorio + @"\PUDVE\icon\black\close.png", FileMode.Open, FileAccess.Read))
            {
                btnBorrarImg.Image = Image.FromStream(IconoBtnBorrarImg);
            }

            // Asignar evento para solo permitir numeros enteros
            txtCodPost.KeyPress += new KeyPressEventHandler(SoloNumeros);
            txtTelefono.KeyPress += new KeyPressEventHandler(SoloNumeros);
        }

        private void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
            FormPrincipal.datosUsuario = cn.DatosUsuario(IDUsuario: FormPrincipal.userID, tipo: 0);
            MessageBox.Show("Datos actualizados correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ActualizarDatos(int tipo = 0)
        {
            // mandamos llamar la funcion actualizarVariables()
            actualizarVariables();

            if (tipo == 0)
            {
                if (cbRegimen.SelectedIndex == 0)
                {
                    if (string.IsNullOrWhiteSpace(LblRegimenActual.Text))
                    {
                        regimen = string.Empty;
                    }
                }
            }

            // el string para hacer el UPDATE
            actualizar = $"UPDATE Usuarios SET RFC = '{rfc}', Telefono = '{telefono}', Email = '{email}', NombreCompleto = '{nomComp}', Calle = '{calle}', NoExterior = '{numExt}', NoInterior = '{numInt}', Colonia = '{colonia}', Municipio = '{mpio}', Estado = '{estado}', CodigoPostal = '{codPostal}', Regimen = '{regimen}', TipoPersona = '{tipoPersona}' WHERE ID = '{id}'";

            // realizamos la consulta desde el metodo
            // que esta en la clase Conexion
            cn.EjecutarConsulta(actualizar);

            // Llamamos a la Funcion consulta
            consulta();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre completo", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtNombre.Focus();

                return false;
            }

            if (!VerificarRFC(txtRFC.Text))
            {
                if (!string.IsNullOrWhiteSpace(txtRFC.Text))
                {
                    MessageBox.Show("El RFC contiene un formato incorrecto, favor de verificarlo.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("El RFC no puede estar vacio, favor de verificarlo.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtRFC.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCodPost.Text))
            {
                MessageBox.Show("Se requiere el código postal", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtCodPost.Focus();

                return false;
            }

            if (txtCodPost.TextLength < 5)
            {
                MessageBox.Show("La longitud del código postal es incorrecta.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodPost.Focus();

                return false;
            }

            if (!ValidarEmail(txtEmail.Text))
            {
                if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("El formato del correo electrónico es incorrecto\n\nEjemplo: micorreo@ejemplo.com", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("El correo electrónico es requerido", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtEmail.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(LblRegimenActual.Text))
            {
                if (cbRegimen.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione un régimen fiscal", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }

            return true;
        }

        private bool VerificarRFC(string rfc)
        {
            bool respuesta = false;

            string regex = @"^([A-ZÑ&]{3,4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$";

            Match verificar = Regex.Match(rfc, regex, RegexOptions.IgnoreCase);

            if (verificar.Success)
            {
                var longitud = rfc.Length;

                //Fisica
                if (longitud == 13)
                {
                    rbPersonaFisica.PerformClick();
                }
                
                //Moral
                if (longitud == 12)
                {
                    rbPersonaMoral.PerformClick();
                }

                respuesta = true;
            }

            return respuesta;
        }

        private void rbPersonaFisica_Click(object sender, EventArgs e)
        {
            // se le asigna a la variable tipoPersona
            // el valor que es tipo de Física
            tipoPersona = "Física";
        }

        private void rbPersonaMoral_Click(object sender, EventArgs e)
        {
            // se le asigna a la variable tipoPersona
            // el valor que es tipo de Moral
            tipoPersona = "Moral";
        }

        private void btn_vnt_subir_archivos_Click(object sender, EventArgs e)
        {
            // Actualizamos los datos del usuario antes en caso de que haya agregado
            // nueva informacion en los campos requeridos
            ActualizarDatos(1);

            if (ValidarDatos())
            {
                Subir_archivos_digitales subir_arch = new Subir_archivos_digitales();

                subir_arch.FormClosed += delegate
                {
                    cargar_archivos();
                };

                subir_arch.ShowDialog();
            }
        }

        private void rbPersonaFisica_CheckedChanged(object sender, EventArgs e)
        {
            cargarComboBox();
        }

        private void btnSubirArchivo_Click(object sender, EventArgs e)
        {
            using (f = new OpenFileDialog())	// abrimos el opneDialog para seleccionar la imagen
            {
                // le aplicamos un filtro para solo ver 
                // imagenes de tipo *.jpg en el openDialog
                f.Filter = "JPG (*.JPG)|*.jpg";
                if (f.ShowDialog() == DialogResult.OK)		// si se abrio correctamente el openDialog
                {
                    /************************************************
                    *   usamos el objeto File para almacenar las    *
                    *   propiedades de la imagen                    * 
                    ************************************************/
                    using (File = new FileStream(f.FileName, FileMode.Open, FileAccess.Read))
                    {
                        pictureBox1.Image = Image.FromStream(File);		// carrgamos la imagen en el PictureBox
                        info = new FileInfo(f.FileName);				// obtenemos toda la informacion de la imagen
                        fileName = Path.GetFileName(f.FileName);		// obtenemos el nombre de la imagen
                        oldDirectory = info.DirectoryName;				// obtenemos el directorio origen de la imagen
                        File.Dispose();									// liberamos el objeto File
                    }
                }
            }
            if (!Directory.Exists(saveDirectoryImg))	// verificamos que si no existe el directorio
            {
                Directory.CreateDirectory(saveDirectoryImg);	// lo crea para poder almacenar la imagen
            }
            if (f.CheckFileExists)		// si el archivo existe
            {
                try 	// hacemos el intento de realizar la actualizacion de la imagen
                {
                    if (File != null)	// si el usuario selecciona un archivo valido
                    {
                        // obtenemos el nuevo nombre de la imagen con la 
                        // se va hacer la copia de la imagen
                        NvoFileName = userName + rfc + ".jpg";
                        TxtBoxNombreArchivo.Text = NvoFileName;		// ponemos en el TxtBox el nombre con el cual se va guardar el archivo
                        var source = TxtBoxNombreArchivo.Text;
                        var replacement = source.Replace('/', '_').Replace('\\', '_').Replace(':', '_').Replace('*', '_').Replace('?', '_').Replace('\"', '_').Replace('<', '_').Replace('>', '_').Replace('|', '_').Replace('-', '_').Replace(' ', '_');
                        NvoFileName = replacement;
                        TxtBoxNombreArchivo.Text = NvoFileName;		// ponemos en el TxtBox el nombre con el cual se va guardar el archivo
                        if (logoTipo != "")		// si el valor de la vairable es diferente a Null o de ""
                        {
                            if (File1 != null)		// si file1 es igual a null
                            {
                                File1.Dispose();    // Dasactivamos el objeto File1
                                // hacemos la nueva cadena de consulta para hacer el update
                                string insertImagen = $"UPDATE Usuarios SET LogoTipo = '{NvoFileName}' WHERE ID = '{id} '";
                                cn.EjecutarConsulta(insertImagen);		// hacemos que se ejecute la consulta
                                actualizarVariables();		// actualizamos las variables
                                cargarComboBox();		// cargamos los datos de nuevo
                                if (pictureBox1.Image != null)	// vereficamos si el pictureBox es Null
                                {
                                    pictureBox1.Image.Dispose();	// Liberamos el pictureBox para poder borrar su imagen                                    
                                    System.IO.File.Delete(logoTipo);  // borramos el archivo de la imagen
                                    // realizamos la copia de la imagen origen hacia el nuevo destino
                                    System.IO.File.Copy(oldDirectory + @"\" + fileName, saveDirectoryImg + NvoFileName, true);
                                    logoTipo = saveDirectoryImg + NvoFileName;      // obtenemos el nuevo path
                                    // leemos el archivo de imagen y lo ponemos el pictureBox
                                    using (File = new FileStream(logoTipo, FileMode.Open, FileAccess.Read))
                                    {
                                        pictureBox1.Image = Image.FromStream(File);		// carrgamos la imagen en el PictureBox
                                    }
                                }
                                // hacemos la nueva cadena de consulta para hacer el update
                                insertImagen = $"UPDATE Usuarios SET LogoTipo = '{NvoFileName}' WHERE ID = '{id}'";
                                cn.EjecutarConsulta(insertImagen);		// hacemos que se ejecute la consulta
                            }
                            else	// si es que file1 es igual a null
                            {
                                // realizamos la copia de la imagen origen hacia el nuevo destino
                                System.IO.File.Copy(oldDirectory + @"\" + fileName, saveDirectoryImg + NvoFileName, true);
                                logoTipo = saveDirectoryImg + NvoFileName;		// obtenemos el nuevo path
                            }
                        }
                        if (logoTipo == "" || logoTipo == null)		// si el valor de la variable es Null o esta ""
                        {

                            pictureBox1.Image.Dispose();	// Liberamos el pictureBox para poder borrar su imagen
                            // agregamos el nombre de archivo con toda la ruta para ver si se esta haciendo el proceso
                            TxtBoxNombreArchivo.Text = NvoFileName;
                            // realizamos la copia de la imagen origen hacia el nuevo destino
                            System.IO.File.Copy(oldDirectory + @"\" + fileName, saveDirectoryImg + NvoFileName, true);
                            logoTipo = saveDirectoryImg + NvoFileName;		// obtenemos el nuevo path
                            // hacemos la nueva cadena de consulta para hacer el update
                            string insertImagen = $"UPDATE Usuarios SET LogoTipo = '{NvoFileName}' WHERE ID = '{id}'";
                            cn.EjecutarConsulta(insertImagen);      // hacemos que se ejecute la consulta
                            // leemos el archivo de imagen y lo ponemos el pictureBox
                            using (File = new FileStream(logoTipo, FileMode.Open, FileAccess.Read))
                            {
                                pictureBox1.Image = Image.FromStream(File);		// carrgamos la imagen en el PictureBox
                            }
                        }
                    }
                }
                catch (IOException ex)	// si no se puede hacer el proceso
                {
                    // si no se borra el archivo muestra este mensaje
                    MessageBox.Show("Error al hacer el borrado No: " + ex);
                }
            }
            else if (f.FileName == "")	// si el nombre del archivo esta en blanco
            {
                // si no selecciona un archivo valido o ningun archivo muestra este mensaje
                MessageBox.Show("selecciona una Imagen", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void cbRegimen_Click(object sender, EventArgs e)
        {
            // al dar clic en el comboBox se despliega la lista de opciones
            cbRegimen.DroppedDown = true;
        }

        private void btnBorrarImg_Click(object sender, EventArgs e)
        {
            // borramos el archivo de la imagen
            System.IO.File.Delete(logoTipo);
            // ponemos la ruta del logoTipo en null
            logoTipo = null;
            // hacemos la nueva cadena de consulta para hacer el update
            string consultaUpdate = $"UPDATE Usuarios SET LogoTipo = '{logoTipo}' WHERE ID = '{id}'";
            // hacemos que se ejecute la consulta
            cn.EjecutarConsulta(consultaUpdate);
            //ponemos la imagen en limpio
            pictureBox1.Image = null;
            // Llamamos a la Funcion consulta
            consulta();
        }

        private bool ValidarEmail(string email)
        {
            try
            {
                var direccion = new System.Net.Mail.MailAddress(email);

                return direccion.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            //permite 0-9, eliminar
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }

        private void cargar_archivos()
        {
            if (Directory.Exists(ruta_archivos_guadados))
            {
                string[] nombres = new string[2];
                int i = 0;
                string[] id_usuario = new string[] { FormPrincipal.userID.ToString() };
                DataTable result;
                DataRow row;


                DirectoryInfo dir = new DirectoryInfo(ruta_archivos_guadados);

                foreach (var arch in dir.GetFiles())
                {
                    nombres[i] = arch.Name;

                    i++;
                }

                txt_certificado.Text = nombres[0];
                txt_llave.Text = nombres[1];


                // Obtiene fecha de caducidad

                if(txt_certificado.Text != "")
                {
                    result = cn.CargarDatos(cs.archivos_digitales(id_usuario, 2));

                    if (result.Rows.Count != 0)
                    {
                        row = result.Rows[0];

                        string fecha = row["fecha_caducidad_cer"].ToString();

                        if (fecha != "")
                        {
                            string fech = fecha.Substring(0, 10);

                            lb_fvencimiento.Text = fech;
                        }
                    }
                }
            }
        }
    }
}
