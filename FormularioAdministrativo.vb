Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class FormularioAdministrativo

    ' funcion al cargar el form
    Private Sub FormularioAdministrativo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' determinamos un temaño normal para la ventana
        Me.WindowState = FormWindowState.Normal

        ' saludito de arriba
        Label1.Text = "Bienvenido,Administrador"

        ' Configurar las columnas del DataGridView
        DataGridView1.ColumnCount = 5
        DataGridView1.Columns(0).Name = "Especialidad"
        DataGridView1.Columns(1).Name = "Apellido"
        DataGridView1.Columns(2).Name = "Matricula"
        DataGridView1.Columns(3).Name = "Dias"
        DataGridView1.Columns(4).Name = "Horarios"
        ' Cargar los datos de los médicos en el DataGridView
        CargarDatosMedicos()


        ' Configurar las columnas del DataGridView2
        DataGridView2.ColumnCount = 6
        DataGridView2.Columns(0).Name = "Email"
        DataGridView2.Columns(1).Name = "Nombre"
        DataGridView2.Columns(2).Name = "Apellido"
        DataGridView2.Columns(3).Name = "Dni"
        DataGridView2.Columns(4).Name = "Tel"
        DataGridView2.Columns(5).Name = "Direccion"
        ' Cargar los datos de los pacientes en el DataGridView2
        CargarDatosPacientes()

    End Sub


    ' cargar datos de los medicos en plantilla 
    Private Sub CargarDatosMedicos()
        ' Ruta del archivo CSV que contiene la información de los médicos
        Dim rutaArchivoMedicos As String = "Data\doctores.csv"

        Try
            ' Verificar si el archivo existe
            If File.Exists(rutaArchivoMedicos) Then
                ' Leer todas las líneas del archivo CSV
                Dim lineas As String() = File.ReadAllLines(rutaArchivoMedicos)

                ' Si el archivo tiene al menos una línea (cabecera), proceder a cargar los datos
                If lineas.Length > 0 Then
                    ' Limpiar el DataGridView antes de cargar los datos
                    DataGridView1.Rows.Clear()

                    ' Recorrer todas las líneas del archivo, excepto la primera (cabecera)
                    For i As Integer = 0 To lineas.Length - 1
                        Dim campos As String() = lineas(i).Split(";")

                        ' Verificar si la línea tiene la cantidad de campos esperada
                        If campos.Length = 5 Then
                            ' Agregar una nueva fila al DataGridView con los datos del médico
                            DataGridView1.Rows.Add(campos)
                        End If
                    Next
                Else
                    ' Si el archivo está vacío, mostrar un mensaje de advertencia
                    MessageBox.Show("El archivo CSV de médicos está vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                ' Si el archivo no existe, mostrar un mensaje de error
                MessageBox.Show("El archivo CSV de médicos no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ' Mostrar un mensaje en caso de error al leer el archivo CSV
            MessageBox.Show("Error al leer el archivo CSV de médicos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' evento onclick del boton agregar medicos
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Crear una instancia del formulario FormAgregarMedicos
        Dim formularioAgregarMedicos As New FormAgregarMedicos()

        ' Mostrar el formulario FormAgregarMedicos como un diálogo modal
        If formularioAgregarMedicos.ShowDialog() = DialogResult.OK Then
            DataGridView1.Rows.Clear()
            CargarDatosMedicos()
        End If
    End Sub


    ' funcion para borrar doctores de la plantilla
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Verificar si se ha seleccionado una fila en el DataGridView
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Obtener la fila seleccionada
            Dim filaSeleccionada As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Obtener el valor de la columna de la matrícula del médico seleccionado
            Dim matricula As String = filaSeleccionada.Cells("Matricula").Value.ToString()

            ' Ruta del archivo CSV que contiene la información de los médicos
            Dim rutaArchivoMedicos As String = "Data\doctores.csv"

            Try
                ' Crear un archivo temporal para almacenar los datos actualizados
                Dim rutaArchivoTemporal As String = "Data\temp_doctores.csv"

                ' Abrir el archivo CSV original en modo de lectura
                Using lector As New StreamReader(rutaArchivoMedicos)
                    ' Abrir el archivo temporal en modo de escritura
                    Using escritor As New StreamWriter(rutaArchivoTemporal)
                        ' Recorrer el archivo CSV original
                        While Not lector.EndOfStream
                            Dim linea As String = lector.ReadLine()

                            ' Verificar si la línea contiene la matrícula del médico que se desea borrar
                            If Not linea.Contains(matricula) Then
                                ' Escribir la línea en el archivo temporal
                                escritor.WriteLine(linea)
                            End If
                        End While
                    End Using
                End Using

                ' Borrar el archivo CSV original
                File.Delete(rutaArchivoMedicos)

                ' Renombrar el archivo temporal con el nombre del archivo original
                File.Move(rutaArchivoTemporal, rutaArchivoMedicos)

                ' Volver a cargar los datos desde el archivo CSV actualizado en el DataGridView
                DataGridView1.Rows.Clear()
                CargarDatosMedicos()

                MessageBox.Show("Médico eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error al eliminar el médico: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Por favor, seleccione un médico para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub




    ' funcion para cargar los datos de los pacientes en el grid view
    Private Sub CargarDatosPacientes()
        ' Ruta del archivo CSV que contiene la información de los pacientes
        Dim rutaArchivoPacientes As String = "Data\pacientes.csv"

        Try
            ' Verificar si el archivo existe
            If File.Exists(rutaArchivoPacientes) Then
                ' Leer todas las líneas del archivo CSV
                Dim lineas As String() = File.ReadAllLines(rutaArchivoPacientes)

                ' Si el archivo tiene al menos una línea (cabecera), proceder a cargar los datos
                If lineas.Length > 1 Then
                    ' Limpiar el DataGridView2 antes de cargar los datos
                    DataGridView2.Rows.Clear()

                    ' Recorrer todas las líneas del archivo, excepto la primera (cabecera)
                    For i As Integer = 1 To lineas.Length - 1
                        Dim campos As String() = lineas(i).Split(";")

                        ' Verificar si la línea tiene la cantidad de campos esperada
                        If campos.Length = 6 Then
                            ' Agregar una nueva fila al DataGridView2 con los datos del paciente
                            DataGridView2.Rows.Add(campos(0), campos(1), campos(2), campos(3), campos(4), campos(5))
                        End If
                    Next
                Else
                    ' Si el archivo está vacío, mostrar un mensaje de advertencia
                    MessageBox.Show("El archivo CSV de pacientes está vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                ' Si el archivo no existe, mostrar un mensaje de error
                MessageBox.Show("El archivo CSV de pacientes no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ' Mostrar un mensaje en caso de error al leer el archivo CSV
            MessageBox.Show("Error al leer el archivo CSV de pacientes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' funcion para agregar un nuevo paciente ( esto tambien creara un nuevo usuario )
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Crear una instancia del formulario FormAgregarPaciente
        Dim formularioAgregarPaciente As New FormAgregarPaciente()

        ' Mostrar el formulario FormAgregarPaciente como un diálogo modal
        If formularioAgregarPaciente.ShowDialog() = DialogResult.OK Then
            DataGridView2.Rows.Clear()
            CargarDatosPacientes()
        End If
    End Sub


    ' funcion para borrar un paciente ' 
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        ' Verificar si se ha seleccionado una fila en el DataGridView2
        If DataGridView2.SelectedRows.Count > 0 Then
            ' Obtener la fila seleccionada
            Dim filaSeleccionada As DataGridViewRow = DataGridView2.SelectedRows(0)

            ' Obtener el valor de la columna del email del paciente seleccionado
            Dim email As String = filaSeleccionada.Cells("Email").Value.ToString()

            ' Ruta del archivo CSV que contiene la información de los pacientes
            Dim rutaArchivoPacientes As String = "Data\pacientes.csv"

            Try
                ' Crear un archivo temporal para almacenar los datos actualizados
                Dim rutaArchivoTemporal As String = "Data\temp_pacientes.csv"

                ' Abrir el archivo CSV original en modo de lectura
                Using lector As New StreamReader(rutaArchivoPacientes)
                    ' Abrir el archivo temporal en modo de escritura
                    Using escritor As New StreamWriter(rutaArchivoTemporal)
                        ' Recorrer el archivo CSV original
                        While Not lector.EndOfStream
                            Dim linea As String = lector.ReadLine()

                            ' Verificar si la línea contiene el email del paciente que se desea borrar
                            If Not linea.Contains(email) Then
                                ' Escribir la línea en el archivo temporal
                                escritor.WriteLine(linea)
                            End If
                        End While
                    End Using
                End Using

                ' Borrar el archivo CSV original
                File.Delete(rutaArchivoPacientes)

                ' Renombrar el archivo temporal con el nombre del archivo original
                File.Move(rutaArchivoTemporal, rutaArchivoPacientes)

                ' Volver a cargar los datos desde el archivo CSV actualizado en el DataGridView2
                DataGridView2.Rows.Clear()
                CargarDatosPacientes()

                MessageBox.Show("Paciente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error al eliminar el paciente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Por favor, seleccione un paciente para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


End Class