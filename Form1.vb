Imports Microsoft.VisualBasic.FileIO

Public Class Form1

    ' funcion que se ejecuta al hacer click en el boton de acceder a la app
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Obtener los valores ingresados por el usuario
        Dim usuarioIngresado As String = TextBox1.Text.Trim()
        Dim contrasenaIngresada As String = TextBox2.Text

        ' Verificar las credenciales y obtener el tipo de usuario (categoría) desde el archivo CSV ' 
        Dim tipoUsuario As String = VerificarCredenciales(usuarioIngresado, contrasenaIngresada)

        ' Abrir la ventana adecuada según el tipo de usuario
        If Not String.IsNullOrEmpty(tipoUsuario) Then
            AbrirVentanaSegunUsuario(tipoUsuario)
        Else
            MessageBox.Show("Credenciales inválidas. Inténtalo nuevamente.", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    ' funcion que determina si las credenciales ingresadas estan en la lista de usuarios con acceso
    Private Function VerificarCredenciales(usuario As String, contrasena As String) As String
        ' Ruta del archivo CSV donde se almacenan los usuarios registrados ' 
        Dim rutaArchivoUsuarios As String = "Data\usuarios.csv"
        ' Leer los usuarios desde el archivo CSV ' 
        Try
            Using parser As New TextFieldParser(rutaArchivoUsuarios)
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(";")

                While Not parser.EndOfData
                    Dim campos As String() = parser.ReadFields()

                    ' Verificar si las credenciales coinciden con algún usuario registrado
                    If campos.Length = 3 AndAlso campos(1) = usuario AndAlso campos(2) = contrasena Then
                        ' Retornar el tipo de usuario (categoría) desde el archivo CSV
                        Return campos(0)
                    End If
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo CSV de usuarios: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ' Si no se encontraron credenciales válidas, retornar un valor nulo
        Return Nothing
    End Function


    ' funcion para determinar que ventana ( form ) abrir dependiendo del cliente logeado
    Private Sub AbrirVentanaSegunUsuario(tipoUsuario As String)
        ' Abrir la ventana del panel adecuada según el tipo de usuario
        Select Case tipoUsuario
            Case "medico"
                '  la variable que contiene el nombre de usuario o correo electrónico del médico que inició sesión
                Dim usuarioMedico As String = TextBox1.Text ' Obtiene el nombre de usuario o correo electrónico del médico
                Dim frmMedico As New FormularioMedico()
                frmMedico.Usuario = usuarioMedico ' Asignar el valor a la propiedad Usuario
                frmMedico.Show()

            Case "paciente"
                Dim frmPaciente As New FormularioPaciente()
                frmPaciente.Usuario = TextBox1.Text
                frmPaciente.Show()

            Case "administrativo"
                Dim frmAdmin As New FormularioAdministrativo()
                frmAdmin.Show()

            Case Else
                ' Si el tipo de usuario no coincide con ninguno de los casos anteriores,
                MessageBox.Show("Tipo de usuario no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
        ' Cerrar el formulario de acceso (Form1)
        Me.Hide()
    End Sub


    ' Funcion para Verificar si se presionó la tecla "Enter
    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        ' Verificar si se presionó la tecla "Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Ejecutar el evento del botón de inicio de sesión
            btnLogin_Click(sender, e)
        End If
    End Sub


    ' al cargar el formulario se ejecutara esta funcion load
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Habilitar el evento KeyPreview para capturar las pulsaciones de teclas en el formulario( el enter )
        Me.KeyPreview = True

        ' Configurar el botón de inicio de sesión como el botón de aceptar para el formulario
        Me.AcceptButton = Button1
        TextBox2.UseSystemPasswordChar = True
    End Sub

End Class
