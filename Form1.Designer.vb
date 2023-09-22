<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Label2 = New Label()
        Button1 = New Button()
        Panel1 = New Panel()
        Label3 = New Label()
        Panel2 = New Panel()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = Color.Silver
        Label1.Location = New Point(181, 117)
        Label1.Margin = New Padding(5, 0, 5, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(90, 24)
        Label1.TabIndex = 0
        Label1.Text = "Usuario"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(112, 148)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(222, 33)
        TextBox1.TabIndex = 1
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(112, 245)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(222, 33)
        TextBox2.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.Silver
        Label2.Location = New Point(163, 200)
        Label2.Margin = New Padding(5, 0, 5, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(128, 24)
        Label2.TabIndex = 2
        Label2.Text = "Contraseña"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(112, 315)
        Button1.Name = "Button1"
        Button1.Size = New Size(222, 55)
        Button1.TabIndex = 4
        Button1.Text = "Ingresar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(30), CByte(38), CByte(70))
        Panel1.BackgroundImageLayout = ImageLayout.None
        Panel1.Controls.Add(Label3)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(444, 57)
        Panel1.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.White
        Label3.Location = New Point(126, 22)
        Label3.Name = "Label3"
        Label3.Size = New Size(208, 25)
        Label3.TabIndex = 0
        Label3.Text = "POLICLINICA PAGANO"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(30), CByte(38), CByte(70))
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 467)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(444, 57)
        Panel2.TabIndex = 0
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(11F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoValidate = AutoValidate.EnablePreventFocusChange
        BackColor = Color.AliceBlue
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(444, 524)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(Button1)
        Controls.Add(TextBox2)
        Controls.Add(Label2)
        Controls.Add(TextBox1)
        Controls.Add(Label1)
        Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Location = New Point(200, 200)
        Margin = New Padding(5, 6, 5, 6)
        MaximumSize = New Size(460, 563)
        MinimumSize = New Size(460, 563)
        Name = "Form1"
        Opacity = 0.93R
        ShowIcon = False
        Text = "INGRESAR"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
End Class
