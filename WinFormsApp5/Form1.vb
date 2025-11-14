Imports System
Imports System.Drawing
Imports System.Windows.Forms
Public Class Form1
    Dim num As Integer
    Dim VelocityY As Double = 0
    Dim gravity As Double = 0.5
    Dim r As New Random()
    Dim Score As Integer = 0
    Dim groundLevel As Integer
    Dim X As Integer
    Dim Diff As Double

    Private Sub Form1_MouseMove(Sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        PictureBox1.Location = New Point(e.X - 90, 466)
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.DoubleBuffered = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Visible = False
        PictureBox2.BringToFront()
        num = r.Next(1, 6)
        groundLevel = Me.ClientSize.Height - PictureBox2.Height
        Timer1.Interval = 20
        Timer1.Start()
        Timer2.Start()
        Label1.Text = "Score: 0"
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        VelocityY += gravity
        PictureBox2.Top += CInt(VelocityY)
        If PictureBox2.Bounds.IntersectsWith(PictureBox1.Bounds) Then
            Score += 1
            Label1.Text = "Score: " & Score.ToString()
            PictureBox2.Top = -64
            num = r.Next(1, 6)
            Diff += 0.25
            Select Case num
                Case 1
                    PictureBox2.Location = New Point(12, -104)
                Case 2
                    PictureBox2.Location = New Point(162, -104)
                Case 3
                    PictureBox2.Location = New Point(312, -104)
                Case 4
                    PictureBox2.Location = New Point(462, -104)
                Case 5
                    PictureBox2.Location = New Point(612, -104)
            End Select
            VelocityY = 0
        End If
        If PictureBox2.Top >= groundLevel Then
            PictureBox2.Top = groundLevel
            VelocityY = 0

            num = r.Next(1, 6)
        End If
        X = PictureBox1.Left
        If X < -37 Then
            PictureBox1.Location = New Point(-37, 466)
            Cursor.Position = New Point(60, 300)
        End If
        If X > 575 Then
            PictureBox1.Location = New Point(575, 466)
            Cursor.Position = New Point(640, 300)

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If PictureBox2.Top = groundLevel Then
            Score -= 1
            Label1.Text = "Score: " & Score.ToString()
            Diff -= 0.25
            Select Case num
                Case 1
                    PictureBox2.Location = New Point(12, -104)
                Case 2
                    PictureBox2.Location = New Point(162, -104)
                Case 3
                    PictureBox2.Location = New Point(312, -104)
                Case 4
                    PictureBox2.Location = New Point(462, -104)
                Case 5
                    PictureBox2.Location = New Point(612, -104)
            End Select

        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If Score < 0 Then
            Label3.Visible = True
            Application.DoEvents()
            Threading.Thread.Sleep(1500)
            End
        ElseIf Score > 19 Then
            Label4.Visible = True
            Application.DoEvents()
            Threading.Thread.Sleep(1500)
            End
        End If
        If Diff = 1 Then
            gravity = 1
        ElseIf Diff = 2 Then
            gravity = 2
        ElseIf Diff = 3 Then
            gravity = 3
        ElseIf Diff = 4 Then
            gravity = 4
        ElseIf Diff = 5 Then
            gravity = 5
        End If
    End Sub
End Class
