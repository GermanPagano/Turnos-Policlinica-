Imports System.Reflection.Emit
Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports System.Data

' este es el formulario de la @VISTA PACIENTE
Public Class FormularioPaciente

    ' propiedad publica que hereda el usuario , desde el formulario de acceso (Form1)
    Public Property Usuario As String

    ' clase cliente donde se almacenan todos los datos del cliente ( paciente ) 
    Public Class Cliente
        Public Property Email As String
        Public Property Nombre As String
        Public Property Apellido As String
        Public Property Documento As String
        Public Property Telefono As String
        Public Property Direccion As String
    End Class

    ' Variable de clase para almacenar los datos del cliente
    Private datosCliente As Cliente


    ' funcion que se ejecuta al cargar el formulario vista paciente
    Private Sub FormularioPaciente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Configurar el DataGridView
        DataGridView1.ColumnCount = 5
        DataGridView1.Columns(0).Name = "Especialidad"
        DataGridView1.Columns(1).Name = "Doctor"
        DataGridView1.Columns(2).Name = "Día"
        DataGridView1.Columns(3).Name = "Horario"
        DataGridView1.Columns(4).Name = "Paciente"

        ' Leer el archivo CSV de turnos y cargar los datos en el DataGridView
        CargarDatosDesdeArchivoCSV()
    End Sub


    ' funcion que se ejecuta en el momento justo en que el cuestionario es ejecutado
    Private Sub FormularioPaciente_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' se determina el tamaño de la ventana del form
        Me.WindowState = FormWindowState.Normal

        ' Ocultar los labels al cargar el formulario
        Label1.Visible = False
        Label9.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False


        ' Obtener los datos del cliente desde el archivo CSV y almacenarlos en la variable de clase
        datosCliente = ObtenerDatosCliente(Usuario)

        ' Mostrar los labels cuando se han obtenido los datos del cliente
        Label1.Visible = True
        Label9.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        Label6.Visible = True

        ' Mostrar los datos del cliente en los controles del formulario
        Label1.Text = "Bienvenido, " & datosCliente.Nombre
        Label2.Text = datosCliente.Nombre
        Label9.Text = datosCliente.Apellido
        Label3.Text = datosCliente.Email
        Label4.Text = datosCliente.Documento
        Label5.Text = datosCliente.Telefono
        Label6.Text = datosCliente.Direccion
    End Sub


    ' funcion para obtener los datos del cliente ( paciente )  desde el archivo csv
    Private Function ObtenerDatosCliente(usuario As String) As Cliente
        ' Ruta del archivo CSV donde se almacenan los datos de los clientes
        Dim rutaArchivoClientes As String = "Data\pacientes.csv"

        ' Leer los clientes desde el archivo CSV
        Try
            Using parser As New TextFieldParser(rutaArchivoClientes)
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(";")

                While Not parser.EndOfData
                    Dim campos As String() = parser.ReadFields()

                    ' Verificar si el cliente coincide con el usuario (correo electrónico) buscado
                    If campos.Length >= 5 AndAlso campos(0) = usuario Then
                        ' Crear un objeto Cliente y asignar los valores
                        Dim cliente As New Cliente()
                        cliente.Email = campos(0)
                        cliente.Nombre = campos(1)
                        cliente.Apellido = campos(2)
                        cliente.Documento = campos(3)
                        cliente.Telefono = campos(4)
                        cliente.Direccion = campos(5)
                        ' Retornar el objeto Cliente con los datos
                        Return cliente
                    End If
                End While

                ' Agregar una salida de depuración si no se encontraron datos del cliente para el usuario
                Debug.WriteLine("No se encontraron datos del cliente para el usuario: " & usuario)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo CSV de clientes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Si no se encontraron datos del cliente, retornar un objeto Cliente vacío
        Return New Cliente()
    End Function


    ' funcion que se ejecuta en el evento onclick del boton para reservar un nuevo turno
    Private Sub BtnReservarTurno_Click(sender As Object, e As EventArgs) Handles BtnReservarTurno.Click

        ' Crear una instancia del formulario ReservaTurno
        Dim formularioReservaTurno As New ReservaTurno(datosCliente.Apellido)

        ' Mostrar el formulario ReservaTurno de manera no modal
        formularioReservaTurno.ShowDialog()

        ' Verificar si se agregó un nuevo turno
        If formularioReservaTurno.TurnoAgregado Then
            ' Si se agregó un nuevo turno, borrar todos los turnos previamente cargados en el DataGridView
            DataGridView1.Rows.Clear()
        End If

        ' Después de cerrar el formulario de reserva, cargar los datos nuevamente en el DataGridView
        CargarDatosDesdeArchivoCSV()
    End Sub


    ' funcion para cargar los datos de los turnos desde el archivo csv
    Private Sub CargarDatosDesdeArchivoCSV()
        ' ruta del archivo que contiene los turnos
        Dim rutaArchivoTurnos As String = "Data\turnos.csv"

        ' promesa que intenta obtener los datos del turno
        Try
            If File.Exists(rutaArchivoTurnos) Then
                Dim lineas As String() = File.ReadAllLines(rutaArchivoTurnos)

                ' Obtener el apellido del paciente logueado
                ' Obtener los datos del cliente desde el archivo CSV y almacenarlos en la variable de clase
                datosCliente = ObtenerDatosCliente(Usuario)
                Dim apellidoPacienteLogueado As String = datosCliente.Apellido

                For Each linea As String In lineas
                    Dim campos As String() = linea.Split(";")

                    If campos.Length = 5 Then
                        Dim paciente As String = campos(4)

                        ' Comprobar si el turno corresponde al paciente logueado
                        If paciente = apellidoPacienteLogueado Then
                            DataGridView1.Rows.Add(campos(0), campos(1), campos(2), campos(3), paciente)
                        End If
                    End If
                Next
            Else
                MessageBox.Show("El archivo CSV de turnos no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' si la promesa es rechazada capturo el error y lo muestro 
        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo CSV de turnos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' funcion que se ejecuta en el evento onclick del boton cancelar turno
    Private Sub BtnCancelarTurno_Click(sender As Object, e As EventArgs) Handles BtnCancelarTurno.Click
        ' Verificar si se ha seleccionado una fila en el DataGridView
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Obtener la fila seleccionada
            Dim filaSeleccionada As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Obtener los datos del turno que se desea borrar
            Dim especialidad As String = filaSeleccionada.Cells("Especialidad").Value.ToString()
            Dim doctor As String = filaSeleccionada.Cells("Doctor").Value.ToString()
            Dim dia As String = filaSeleccionada.Cells("Día").Value.ToString()
            Dim horario As String = filaSeleccionada.Cells("Horario").Value.ToString()

            ' Ruta del archivo CSV donde se almacenan los turnos
            Dim rutaArchivoTurnos As String = "Data\turnos.csv"

            ' promesa que intenta retornar el turno a borrar 
            Try
                ' Crear un archivo temporal para almacenar los datos actualizados
                Dim rutaArchivoTemporal As String = "Data\temp_turnos.csv"

                ' Abrir el archivo CSV original en modo de lectura
                Using lector As New StreamReader(rutaArchivoTurnos)
                    ' Abrir el archivo temporal en modo de escritura
                    Using escritor As New StreamWriter(rutaArchivoTemporal)
                        ' Recorrer el archivo CSV original
                        While Not lector.EndOfStream
                            Dim linea As String = lector.ReadLine()

                            ' Verificar si la línea contiene los datos del turno que se desea borrar
                            If Not linea.Contains($"{especialidad};{doctor};{dia};{horario}") Then
                                ' Escribir la línea en el archivo temporal
                                escritor.WriteLine(linea)
                            End If
                        End While
                    End Using
                End Using

                ' Borrar el archivo CSV original
                File.Delete(rutaArchivoTurnos)

                ' Renombrar el archivo temporal con el nombre del archivo original
                File.Move(rutaArchivoTemporal, rutaArchivoTurnos)

                ' Volver a cargar los datos desde el archivo CSV actualizado en el DataGridView
                DataGridView1.Rows.Clear()
                CargarDatosDesdeArchivoCSV()

                MessageBox.Show("Turno borrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' si la promesa es rechazada capturo el error y lo muestro 
            Catch ex As Exception
                MessageBox.Show("Error al borrar el turno: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Por favor, seleccione un turno para borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class
