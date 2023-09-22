Imports System.Reflection.Emit
Imports Microsoft.VisualBasic.FileIO
Imports SistemadeRegistrodeTurnosparaPoliconsultorio.FormularioPaciente
Imports System.IO
Public Class FormularioMedico

    ' heredo el valor del usuario para trabajar con el 
    Public Property Usuario As String

    ' clase medico que posee las propiedades del doctor logeado
    Public Class Medico
        Public Property Especialidad As String
        Public Property Apellido As String
        Public Property Matricula As String
        Public Property Dias As String
        Public Property Horarios As String
    End Class

    ' Variable de clase para almacenar los datos del medico
    Private datosMedico As Medico

    ' funcion que se ejecuta cuando se carga el formulario medico
    Private Sub FormularioMedico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ocultar los labels al cargar el formulario
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False

        ' Verificar que la propiedad Usuario esté configurada
        If Not String.IsNullOrWhiteSpace(Usuario) Then
            ' Obtener los datos del médico desde el archivo CSV
            datosMedico = ObtenerDatosMedico(Usuario)

            ' Mostrar los labels cuando se han obtenido los datos del médico
            Label1.Visible = True
            Label2.Visible = True
            Label3.Visible = True
            Label4.Visible = True
            Label5.Visible = True

            ' Mostrar los datos del médico en los controles del formulario
            Label1.Text = datosMedico.Especialidad
            Label2.Text = datosMedico.Apellido
            Label3.Text = datosMedico.Matricula
            Label4.Text = datosMedico.Dias
            Label5.Text = datosMedico.Horarios

            ' llamo a la funcion para determinar las columnas de mi datagrid
            ConfigurarColumnasDataGridView()
            ' Cargar los turnos del médico en el DataGridView
            CargarTurnosDelMedico(datosMedico.Apellido)
        Else
            ' Si la propiedad Usuario no está configurada, mostrar un mensaje de error
            MessageBox.Show("Error: No se ha especificado el médico para mostrar sus datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' funcion para obtener los datos del medico logeado desde el archivo doctores.csv
    Private Function ObtenerDatosMedico(usuario As String) As Medico
        ' Ruta del archivo CSV donde se almacenan los datos de los clientes
        Dim rutaArchivoDoctores As String = "Data\doctores.csv"

        ' Leer los clientes desde el archivo CSV
        Try
            Using parser As New TextFieldParser(rutaArchivoDoctores)
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(";")

                While Not parser.EndOfData
                    Dim campos As String() = parser.ReadFields()

                    ' Verificar si el cliente coincide con el usuario (correo electrónico) buscado
                    If campos.Length >= 5 AndAlso campos(1) = usuario Then
                        ' Crear un objeto Cliente y asignar los valores
                        Dim medico As New Medico()
                        medico.Especialidad = campos(0)
                        medico.Apellido = campos(1)
                        medico.Matricula = campos(2)
                        medico.Dias = campos(3)
                        medico.Horarios = campos(4)
                        ' Retornar el objeto Cliente con los datos
                        Return medico
                    End If
                End While

                ' Agregar una salida de depuración si no se encontraron datos del cliente para el usuario
                Debug.WriteLine("No se encontraron datos del cliente para el usuario: " & usuario)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo CSV de clientes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Si no se encontraron datos del cliente, retornar un objeto Cliente vacío
        Return New Medico()
    End Function


    ' funcion que configuta los nobres de las columnas del data grid 
    Private Sub ConfigurarColumnasDataGridView()
        DataGridView1.ColumnCount = 5
        DataGridView1.Columns(0).Name = "Especialidad"
        DataGridView1.Columns(1).Name = "Apellido"
        DataGridView1.Columns(2).Name = "Fecha"
        DataGridView1.Columns(3).Name = "Hora"
        DataGridView1.Columns(4).Name = "Paciente"
    End Sub


    ' funcion turnos del medico , para que los pueda ver en su agenda personal
    Private Sub CargarTurnosDelMedico(apellidoMedico As String)
        ' Ruta del archivo CSV donde se almacenan los turnos
        Dim rutaArchivoTurnos As String = "Data\turnos.csv"

        ' Limpiar el DataGridView antes de cargar los datos
        DataGridView1.Rows.Clear()

        ' Leer los turnos desde el archivo CSV y mostrar los turnos del médico en el DataGridView
        Try
            Using parser As New TextFieldParser(rutaArchivoTurnos)
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(";")

                While Not parser.EndOfData
                    Dim campos As String() = parser.ReadFields()

                    ' Verificar si el turno coincide con el apellido del médico buscado
                    If campos.Length >= 3 AndAlso campos(1) = apellidoMedico Then
                        ' Agregar el turno al DataGridView
                        DataGridView1.Rows.Add(campos)
                    End If
                End While
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo CSV de turnos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' evento onlick del boton eliminar turno , en esta vista es el boton de paciente atendido
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Verificar si se ha seleccionado una fila en el DataGridView
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Obtener la fila seleccionada
            Dim filaSeleccionada As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Obtener los datos del turno que se desea borrar
            Dim especialidad As String = filaSeleccionada.Cells("Especialidad").Value.ToString()
            Dim doctor As String = filaSeleccionada.Cells("Apellido").Value.ToString()
            Dim fecha As String = filaSeleccionada.Cells("Fecha").Value.ToString()
            Dim horario As String = filaSeleccionada.Cells("Hora").Value.ToString()

            ' Ruta del archivo CSV donde se almacenan los turnos
            Dim rutaArchivoTurnos As String = "Data\turnos.csv"

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
                            If Not linea.Contains($"{especialidad};{doctor};{fecha};{horario}") Then
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
                CargarTurnosDelMedico(datosMedico.Apellido)

                MessageBox.Show("Turno borrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error al borrar el turno: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Por favor, seleccione un turno para borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub



End Class
