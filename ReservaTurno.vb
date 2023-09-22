Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class ReservaTurno

    ' iniciamos turnoagregado como una bandera , en valor false
    Public Property TurnoAgregado As Boolean = False

    ' Variable para almacenar el apellido del cliente
    Private apellidoCliente As String

    ' variable con el valor del dia laboral del medico
    Private diasLaboralesMedico As List(Of String)

    ' Constructor que acepta el apellido del cliente como parámetro
    Public Sub New(ByVal apellidoCliente As String)
        InitializeComponent()

        ' Almacenar el apellido del cliente en la variable privada del formulario
        Me.apellidoCliente = apellidoCliente
    End Sub

    ' Constructor por defecto (sin parámetros) para el apellido cliente
    Public Sub New()
        InitializeComponent()
        Me.apellidoCliente = ""
    End Sub

    ' funcio que se ejecuta al cargar el formulario de reserva de turno
    Private Sub ReservaTurno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configurar el calendario para que solo se puedan seleccionar fechas futuras
        MonthCalendar1.MinDate = DateTime.Today

        ' Leer el archivo CSV de doctores y cargar las especialidades en el ComboBox1
        CargarEspecialidadesDesdeArchivoDoctores()

        ' Leer el archivo CSV de doctores y cargar los horarios en el ComboBox2
        CargarHorariosDesdeArchivoDoctores()

        ' Cargar los nombres de los especialistas en ComboBox3 de acuerdo con la especialidad seleccionada en ComboBox1
        If ComboBox1.SelectedItem IsNot Nothing Then
            ComboBox3.Items.AddRange(GetNombresEspecialistasPorEspecialidad(ComboBox1.SelectedItem.ToString()).ToArray())
        End If
    End Sub


    ' funcion para filtrar el valor de los combobox
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Limpiar ComboBox3 al cambiar la selección de ComboBox1
        ComboBox3.Items.Clear()

        ' Cargar los nombres de los especialistas en ComboBox3 de acuerdo con la especialidad seleccionada en ComboBox1
        If ComboBox1.SelectedItem IsNot Nothing Then
            ComboBox3.Items.AddRange(GetNombresEspecialistasPorEspecialidad(ComboBox1.SelectedItem.ToString()).ToArray())
        End If
    End Sub


    ' funcion que lee los la data de los doctores desde el archivo csv  y carga el combobox1
    Private Sub CargarEspecialidadesDesdeArchivoDoctores()
        Dim rutaArchivoDoctores As String = "Data\doctores.csv"

        Try
            If File.Exists(rutaArchivoDoctores) Then
                Dim especialidades As New List(Of String)()

                ' Leer todas las líneas del archivo doctores.csv
                Dim lineas As String() = File.ReadAllLines(rutaArchivoDoctores)

                ' Obtener las especialidades únicas del archivo
                For Each linea As String In lineas
                    Dim campos As String() = linea.Split(";")
                    If campos.Length >= 1 AndAlso Not especialidades.Contains(campos(0)) Then
                        especialidades.Add(campos(0))
                    End If
                Next

                ' Agregar las especialidades al ComboBox1
                ComboBox1.Items.Clear()
                ComboBox1.Items.AddRange(especialidades.ToArray())
            Else
                MessageBox.Show("El archivo CSV de doctores no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo CSV de doctores: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' funcion para cargar los horarios de los doctores tomando la data del archivo csv y cargando el combobox2
    Private Sub CargarHorariosDesdeArchivoDoctores()
        Dim rutaArchivoDoctores As String = "Data\doctores.csv"

        Try
            If File.Exists(rutaArchivoDoctores) Then
                Dim horarios As New List(Of String)()

                ' Leer todas las líneas del archivo doctores.csv
                Dim lineas As String() = File.ReadAllLines(rutaArchivoDoctores)

                ' Obtener los horarios únicos del archivo desde la última columna
                For Each linea As String In lineas
                    Dim campos As String() = linea.Split(";")
                    If campos.Length >= 5 AndAlso Not horarios.Contains(campos(4)) Then
                        horarios.Add(campos(4))
                    End If
                Next

                ' Agregar los horarios al ComboBox2
                ComboBox2.Items.Clear()
                ComboBox2.Items.AddRange(horarios.ToArray())
            Else
                MessageBox.Show("El archivo CSV de doctores no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo CSV de doctores: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' funcion para obtener los nombres de los doctores , filtrando por su especialidad 
    Private Function GetNombresEspecialistasPorEspecialidad(especialidad As String) As List(Of String)
        Dim rutaArchivoDoctores As String = "Data\doctores.csv"
        Dim nombresEspecialistas As New List(Of String)()

        Try
            If File.Exists(rutaArchivoDoctores) Then
                ' Leer todas las líneas del archivo doctores.csv
                Dim lineas As String() = File.ReadAllLines(rutaArchivoDoctores)

                ' Obtener los nombres de los especialistas que coinciden con la especialidad seleccionada
                For Each linea As String In lineas
                    Dim campos As String() = linea.Split(";")
                    If campos.Length >= 2 AndAlso campos(0) = especialidad AndAlso Not nombresEspecialistas.Contains(campos(1)) Then
                        nombresEspecialistas.Add(campos(1))
                    End If
                Next
            Else
                MessageBox.Show("El archivo CSV de doctores no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo CSV de doctores: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return nombresEspecialistas
    End Function


    ' funcion de evento onclick para reservar el turno
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Verificar que todos los campos estén seleccionados
        If ComboBox1.SelectedItem IsNot Nothing AndAlso ComboBox2.SelectedItem IsNot Nothing AndAlso MonthCalendar1.SelectionStart <> DateTime.MinValue Then
            ' Obtener la fecha seleccionada en el calendario
            Dim fechaSeleccionada As Date = MonthCalendar1.SelectionStart

            ' Obtener la especialidad seleccionada en el ComboBox
            Dim especialidadSeleccionada As String = ComboBox1.SelectedItem.ToString()

            ' Obtener el horario seleccionado en el ComboBox
            Dim horarioSeleccionado As String = ComboBox2.SelectedItem.ToString()

            ' Obtener nombre de medico seleccionada en el ComboBox
            Dim doctorseleccionado As String = ComboBox3.SelectedItem.ToString()

            ' Ruta del archivo CSV donde se almacenarán las reservas
            Dim rutaArchivoTurnos As String = "Data\turnos.csv"

            Try
                ' Utilizar un objeto StreamWriter en modo Append para agregar las reservas al final del archivo
                Using escritor As New StreamWriter(rutaArchivoTurnos, True)
                    ' Crear una cadena con los datos de la reserva en formato CSV
                    Dim datosReserva As String = $"{especialidadSeleccionada};{doctorseleccionado};{fechaSeleccionada.ToString("dd/MM/yyyy")};{horarioSeleccionado};{apellidoCliente}" ' Agregar el apellido del cliente

                    ' Escribir los datos de la reserva en el archivo CSV
                    escritor.WriteLine(datosReserva)
                End Using

                MessageBox.Show("Reserva realizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error al guardar la reserva en el archivo CSV: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Por favor, seleccione todos los campos antes de reservar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' Indicar que se agregó un nuevo turno
        TurnoAgregado = True
        ' Cerrar el formulario de reserva
        Me.Close()
    End Sub


End Class
