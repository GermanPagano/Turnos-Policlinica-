Imports System.IO

Public Class FormAgregarMedicos

    Public Property DoctorAgregado As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Verificar que todos los campos estén completos
        If TextBox1.Text <> "" AndAlso TextBox2.Text <> "" AndAlso TextBox3.Text <> "" AndAlso TextBox4.Text <> "" AndAlso TextBox5.Text <> "" Then
            ' Obtener los datos ingresados en los TextBox
            Dim especialidad As String = TextBox1.Text
            Dim apellido As String = TextBox2.Text
            Dim matricula As String = TextBox3.Text
            Dim dias As String = TextBox4.Text
            Dim horarios As String = TextBox5.Text

            ' Ruta del archivo CSV donde se almacenarán los datos de los médicos
            Dim rutaArchivoMedicos As String = "Data\doctores.csv"

            Try
                ' Utilizar un objeto StreamWriter en modo Append para agregar los médicos al final del archivo
                Using escritor As New StreamWriter(rutaArchivoMedicos, True)
                    ' Crear una cadena con los datos del médico en formato CSV
                    Dim datosMedico As String = $"{especialidad};{apellido};{matricula};{dias};{horarios}"

                    ' Escribir los datos del médico en el archivo CSV
                    escritor.WriteLine(datosMedico)
                End Using

                MessageBox.Show("Médico agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Crear una nueva cuenta de médico en el archivo "usuarios.csv"
                CrearNuevoUsuarioMedico(apellido)

                ' Limpiar los campos de entrada para permitir agregar nuevos médicos
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
            Catch ex As Exception
                MessageBox.Show("Error al guardar el médico en el archivo CSV: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Por favor, complete todos los campos antes de agregar el médico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' Indicar que se agregó un nuevo médico y cerrar el formulario de agregar médicos
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub FormAgregarMedicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CrearNuevoUsuarioMedico(apellido As String)
        ' Ruta del archivo CSV que contiene la información de los usuarios
        Dim rutaArchivoUsuarios As String = "Data\usuarios.csv"

        Try
            ' Utilizar un objeto StreamWriter en modo Append para agregar el nuevo usuario al final del archivo
            Using escritor As New StreamWriter(rutaArchivoUsuarios, True)
                ' Crear una cadena con los datos del nuevo usuario en formato CSV
                Dim datosUsuario As String = $"medico;{apellido};1234"

                ' Escribir los datos del nuevo usuario en el archivo CSV
                escritor.WriteLine(datosUsuario)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al crear el nuevo usuario: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class