Imports System.IO

Public Class FormAgregarPaciente
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Obtener los datos ingresados por el administrador
        Dim email As String = TextBox1.Text
        Dim nombre As String = TextBox2.Text
        Dim apellido As String = TextBox3.Text
        Dim dni As String = TextBox4.Text
        Dim telefono As String = TextBox5.Text
        Dim direccion As String = TextBox6.Text

        ' Validar que los campos no estén vacíos
        If Not String.IsNullOrWhiteSpace(email) AndAlso
           Not String.IsNullOrWhiteSpace(nombre) AndAlso
           Not String.IsNullOrWhiteSpace(apellido) AndAlso
           Not String.IsNullOrWhiteSpace(dni) AndAlso
           Not String.IsNullOrWhiteSpace(telefono) AndAlso
           Not String.IsNullOrWhiteSpace(direccion) Then

            ' Ruta del archivo CSV que contiene la información de los pacientes
            Dim rutaArchivoPacientes As String = "Data\pacientes.csv"

            Try
                ' Abrir el archivo CSV en modo de escritura y agregar el nuevo paciente al final
                Using escritor As New StreamWriter(rutaArchivoPacientes, append:=True)
                    ' Formatear la línea con los datos del nuevo paciente
                    Dim nuevaLinea As String = $"{email};{nombre};{apellido};{dni};{telefono};{direccion}"

                    ' Escribir la línea en el archivo
                    escritor.WriteLine(nuevaLinea)
                End Using

                ' Mostrar un mensaje de éxito
                MessageBox.Show("Paciente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Crear una nueva cuenta de paciente en el archivo "usuarios.csv"
                Dim rutaArchivoUsuarios As String = "Data\usuarios.csv"
                Using escritorUsuarios As New StreamWriter(rutaArchivoUsuarios, append:=True)
                    Dim nuevaCuentaPaciente As String = $"paciente;{email};1234"
                    escritorUsuarios.WriteLine(nuevaCuentaPaciente)
                End Using

                ' Cerrar el formulario "FormAgregarPaciente" con DialogResult.OK
                DialogResult = DialogResult.OK
                Close()
            Catch ex As Exception
                ' Mostrar un mensaje en caso de error al escribir el archivo CSV
                MessageBox.Show("Error al guardar el paciente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            ' Mostrar un mensaje de error si algún campo está vacío
            MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub FormAgregarPaciente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class