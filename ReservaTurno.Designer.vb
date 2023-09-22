<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReservaTurno
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
        MonthCalendar1 = New MonthCalendar()
        ComboBox1 = New ComboBox()
        Label1 = New Label()
        Button1 = New Button()
        Label2 = New Label()
        ComboBox2 = New ComboBox()
        Label3 = New Label()
        Label4 = New Label()
        ComboBox3 = New ComboBox()
        SuspendLayout()
        ' 
        ' MonthCalendar1
        ' 
        MonthCalendar1.Location = New Point(420, 145)
        MonthCalendar1.Name = "MonthCalendar1"
        MonthCalendar1.TabIndex = 0
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {""})
        ComboBox1.Location = New Point(301, 145)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(107, 23)
        ComboBox1.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(202, 147)
        Label1.Name = "Label1"
        Label1.Size = New Size(93, 21)
        Label1.TabIndex = 2
        Label1.Text = "Especialista"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.DodgerBlue
        Button1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(208, 354)
        Button1.Name = "Button1"
        Button1.Size = New Size(347, 54)
        Button1.TabIndex = 3
        Button1.Text = "Reservar"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.Location = New Point(202, 248)
        Label2.Name = "Label2"
        Label2.Size = New Size(66, 21)
        Label2.TabIndex = 5
        Label2.Text = "Horario"
        ' 
        ' ComboBox2
        ' 
        ComboBox2.DisplayMember = "Clinico"
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(301, 248)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(107, 23)
        ComboBox2.TabIndex = 4
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 24F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Label3.Location = New Point(259, 35)
        Label3.Name = "Label3"
        Label3.Size = New Size(275, 45)
        Label3.TabIndex = 6
        Label3.Text = "Reserva de turnos"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.Location = New Point(202, 190)
        Label4.Name = "Label4"
        Label4.Size = New Size(92, 21)
        Label4.TabIndex = 8
        Label4.Text = "Nombre Dr"
        ' 
        ' ComboBox3
        ' 
        ComboBox3.FormattingEnabled = True
        ComboBox3.Items.AddRange(New Object() {""})
        ComboBox3.Location = New Point(301, 188)
        ComboBox3.Name = "ComboBox3"
        ComboBox3.Size = New Size(107, 23)
        ComboBox3.TabIndex = 7
        ' 
        ' ReservaTurno
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label4)
        Controls.Add(ComboBox3)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(ComboBox2)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Controls.Add(ComboBox1)
        Controls.Add(MonthCalendar1)
        Name = "ReservaTurno"
        Text = "ReservaTurno"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox3 As ComboBox
End Class
