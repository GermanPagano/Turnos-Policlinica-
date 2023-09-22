<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAgregarMedicos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Label2 = New Label()
        TextBox3 = New TextBox()
        Label3 = New Label()
        TextBox4 = New TextBox()
        Label4 = New Label()
        TextBox5 = New TextBox()
        Label5 = New Label()
        Button1 = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(61, 84)
        Label1.Name = "Label1"
        Label1.Size = New Size(100, 21)
        Label1.TabIndex = 0
        Label1.Text = "Especialidad"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(167, 82)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(202, 23)
        TextBox1.TabIndex = 1
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(167, 121)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(202, 23)
        TextBox2.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.Location = New Point(61, 121)
        Label2.Name = "Label2"
        Label2.Size = New Size(72, 21)
        Label2.TabIndex = 2
        Label2.Text = "Apellido"
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(167, 162)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(202, 23)
        TextBox3.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(61, 162)
        Label3.Name = "Label3"
        Label3.Size = New Size(78, 21)
        Label3.TabIndex = 4
        Label3.Text = "Matricula"
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(167, 205)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(202, 23)
        TextBox4.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.Location = New Point(61, 205)
        Label4.Name = "Label4"
        Label4.Size = New Size(40, 21)
        Label4.TabIndex = 6
        Label4.Text = "Dias"
        ' 
        ' TextBox5
        ' 
        TextBox5.Location = New Point(167, 246)
        TextBox5.Name = "TextBox5"
        TextBox5.Size = New Size(202, 23)
        TextBox5.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.Location = New Point(61, 246)
        Label5.Name = "Label5"
        Label5.Size = New Size(73, 21)
        Label5.TabIndex = 8
        Label5.Text = "Horarios"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.DodgerBlue
        Button1.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(61, 307)
        Button1.Name = "Button1"
        Button1.Size = New Size(308, 106)
        Button1.TabIndex = 10
        Button1.Text = "Agregar a plantilla"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' FormAgregarMedicos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(413, 450)
        Controls.Add(Button1)
        Controls.Add(TextBox5)
        Controls.Add(Label5)
        Controls.Add(TextBox4)
        Controls.Add(Label4)
        Controls.Add(TextBox3)
        Controls.Add(Label3)
        Controls.Add(TextBox2)
        Controls.Add(Label2)
        Controls.Add(TextBox1)
        Controls.Add(Label1)
        Name = "FormAgregarMedicos"
        Text = "FormAgregarMedicos"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
End Class
