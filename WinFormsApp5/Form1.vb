Imports System
Imports System.Diagnostics.Metrics
Imports System.Drawing
Imports System.Net
Imports System.Windows.Forms
Imports System.IO
Public Class Form1
    Dim num As Integer
    Dim VelocityY As Double = 0
    Dim gravity As Double = 0.5
    Dim r As New Random()
    Dim Score As Integer = 0
    Dim groundLevel As Integer
    Dim X As Integer
    Dim Diff As Double
    Private BestPath As String = "Best.txt"
    Dim Best As Integer

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
        If File.Exists(BestPath) Then
            Try
                Dim text As String = File.ReadAllText(BestPath)
                Best = Integer.Parse(text)
            Catch
                Best = 0
            End Try
            Label5.Text = "HighScore: " & Best
        End If

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        File.WriteAllText(BestPath, Best.ToString())
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Score > Best Then
            Best = Score
        End If
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
            If Score < 0 Then
                Label3.Visible = True
                Application.DoEvents()
                Threading.Thread.Sleep(1500)
                End
            End If
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
        ElseIf Diff = 6 Then
            gravity = 6
        ElseIf Diff = 7 Then
            gravity = 7
        ElseIf Diff = 8 Then
            gravity = 8
        ElseIf Diff = 9 Then
            gravity = 9
        ElseIf Diff = 10 Then
            gravity = 10
        ElseIf Diff = 11 Then
            gravity = 11
        ElseIf Diff = 12 Then
            gravity = 12
        ElseIf Diff = 13 Then
            gravity = 13
        ElseIf Diff = 14 Then
            gravity = 14
        ElseIf Diff = 15 Then
            gravity = 15
        ElseIf Diff = 16 Then
            gravity = 16
        ElseIf Diff = 17 Then
            gravity = 17
        ElseIf Diff = 18 Then
            gravity = 18
        ElseIf Diff = 19 Then
            gravity = 19
        ElseIf Diff = 20 Then
            gravity = 20
        End If
    End Sub
End Class
