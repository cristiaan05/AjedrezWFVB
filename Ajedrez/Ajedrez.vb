Public Class Ajedrez
    Dim tableroGraf(7, 7) As PictureBox
    Public tableroPosiciones(7, 7) As Integer
    Dim posibles(7, 7) As Boolean
    Public jaqueN(7, 7) As Boolean
    Public jaqueB(7, 7) As Boolean
    Dim turno As Boolean = True
    Dim peligroNegro As Boolean = False
    Dim peligroBlanco As Boolean = False
    Dim haySeleccion As Boolean = False

    Dim pieza As Integer
    Dim posicionX As Integer
    Dim posicionY As Integer
    Dim posicionSelX As Integer
    Dim posicionSelY As Integer

    Dim mover As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Public reyB As Rey
    Public reinaB As Reina
    Public alfilesB(1) As Alfil
    Public caballosB(1) As Caballo
    Public torresB(1) As Torre
    Public peonesB(7) As Peon

    Public reyN As Rey
    Public reinaN As Reina
    Public alfilesN(1) As Alfil
    Public caballosN(1) As Caballo
    Public torresN(1) As Torre
    Public peonesN(7) As Peon

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        mover = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        If mover Then
            Me.Top = Cursor.Position.Y - mousey
            Me.Left = Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object,
                              ByVal e As MouseEventArgs) Handles Me.MouseUp
        mover = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Restart()
    End Sub

    Private Sub Ajedrez_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tableroPosiciones = New Integer(7, 7) {
            {-5, -3, -4, -10, -100, -4, -3, -5},
            {-1, -1, -1, -1, -1, -1, -1, -1},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {1, 1, 1, 1, 1, 1, 1, 1},
            {5, 3, 4, 10, 100, 4, 3, 5}
        }

        tableroGraf = New PictureBox(7, 7) {
            {c00, c01, c02, c03, c04, c05, c06, c07},
            {c10, c11, c12, c13, c14, c15, c16, c17},
            {c20, c21, c22, c23, c24, c25, c26, c27},
            {c30, c31, c32, c33, c34, c35, c36, c37},
            {c40, c41, c42, c43, c44, c45, c46, c47},
            {c50, c51, c52, c53, c54, c55, c56, c57},
            {c60, c61, c62, c63, c64, c65, c66, c67},
            {c70, c71, c72, c73, c74, c75, c76, c77}
        }

        'Creo las piezas Negras
        reyN = New Rey(-100, 0, 4)
        reinaN = New Reina(-10, 0, 3)
        alfilesN(0) = New Alfil(-4, 0, 2)
        alfilesN(1) = New Alfil(-4, 0, 5)
        caballosN(0) = New Caballo(-3, 0, 1)
        caballosN(1) = New Caballo(-3, 0, 6)
        torresN(0) = New Torre(-5, 0, 0)
        torresN(1) = New Torre(-5, 0, 7)
        peonesN(0) = New Peon(-1, 1, 0)
        peonesN(1) = New Peon(-1, 1, 1)
        peonesN(2) = New Peon(-1, 1, 2)
        peonesN(3) = New Peon(-1, 1, 3)
        peonesN(4) = New Peon(-1, 1, 4)
        peonesN(5) = New Peon(-1, 1, 5)
        peonesN(6) = New Peon(-1, 1, 6)
        peonesN(7) = New Peon(-1, 1, 7)

        'Creo las piezas Blancas
        reyB = New Rey(100, 7, 4)
        reinaB = New Reina(10, 7, 3)
        alfilesB(0) = New Alfil(4, 7, 2)
        alfilesB(1) = New Alfil(4, 7, 5)
        caballosB(0) = New Caballo(3, 7, 1)
        caballosB(1) = New Caballo(3, 7, 6)
        torresB(0) = New Torre(5, 7, 0)
        torresB(1) = New Torre(5, 7, 7)
        peonesB(0) = New Peon(1, 6, 0)
        peonesB(1) = New Peon(1, 6, 1)
        peonesB(2) = New Peon(1, 6, 2)
        peonesB(3) = New Peon(1, 6, 3)
        peonesB(4) = New Peon(1, 6, 4)
        peonesB(5) = New Peon(1, 6, 5)
        peonesB(6) = New Peon(1, 6, 6)
        peonesB(7) = New Peon(1, 6, 7)

        ActualizarPosiciones()
    End Sub

    Public Sub victoria_A_Medias()

    End Sub

    Public Sub ActualizarPosiciones()
        For y = 0 To 7
            For x = 0 To 7
                Select Case tableroPosiciones(x, y)
                    Case 1
                        tableroGraf(x, y).Image = My.Resources.peonblanco
                    Case 3
                        tableroGraf(x, y).Image = My.Resources.caballoblanco
                    Case 4
                        tableroGraf(x, y).Image = My.Resources.alfilblanco
                    Case 5
                        tableroGraf(x, y).Image = My.Resources.torreblanca
                    Case 10
                        tableroGraf(x, y).Image = My.Resources.reinablanca
                    Case 100
                        tableroGraf(x, y).Image = My.Resources.reyblanco
                    Case -1
                        tableroGraf(x, y).Image = My.Resources.peonegro
                    Case -3
                        tableroGraf(x, y).Image = My.Resources.caballonegro
                    Case -4
                        tableroGraf(x, y).Image = My.Resources.alfilnegro
                    Case -5
                        tableroGraf(x, y).Image = My.Resources.torrenegra
                    Case -10
                        tableroGraf(x, y).Image = My.Resources.reinanegra
                    Case -100
                        tableroGraf(x, y).Image = My.Resources.reynegro
                    Case Else
                        tableroGraf(x, y).Image = Nothing
                End Select
            Next
        Next
        mostrarJaque()
    End Sub

    Public Sub mostrarJaque()
        peligroBlanco = False
        peligroNegro = False
        For y As Integer = 0 To 7
            For x As Integer = 0 To 7
                If jaqueN(y, x) = True And reyN.PiezaPosicionY = y And reyN.PiezaPosicionX = x Then
                    tableroGraf(y, x).BackgroundImage = My.Resources.jaque
                    peligroNegro = True
                End If
            Next
        Next

        For y As Integer = 0 To 7
            For x As Integer = 0 To 7
                If jaqueB(y, x) = True And reyB.PiezaPosicionY = y And reyB.PiezaPosicionX = x Then
                    tableroGraf(y, x).BackgroundImage = My.Resources.jaque
                    peligroBlanco = True
                End If
            Next
        Next
    End Sub

    Public Sub llenarJaqueN()
        limpiarJaqueN()
        For r As Integer = 0 To 7
            peonesB(r).jaqueRey()
            For y As Integer = 0 To 7
                For x As Integer = 0 To 7
                    If peonesB(r).jaque(y, x) Then
                        jaqueN(y, x) = True
                    End If
                Next
            Next
        Next

        For r As Integer = 0 To 1
            torresB(r).jaqueRey()
            For y As Integer = 0 To 7
                For x As Integer = 0 To 7
                    If torresB(r).jaque(y, x) Then
                        jaqueN(y, x) = True
                    End If
                Next
            Next
        Next

        For r As Integer = 0 To 1
            alfilesB(r).jaqueRey()
            For y As Integer = 0 To 7
                For x As Integer = 0 To 7
                    If alfilesB(r).jaque(y, x) = True Then
                        jaqueN(y, x) = True
                    End If
                Next
            Next
        Next

        For r As Integer = 0 To 1
            caballosB(r).jaqueRey()
            For y As Integer = 0 To 7
                For x As Integer = 0 To 7
                    If caballosB(r).jaque(y, x) = True Then
                        jaqueN(y, x) = True
                    End If
                Next
            Next
        Next

        reinaB.jaqueRey()
        For y As Integer = 0 To 7
            For x As Integer = 0 To 7
                If reinaB.jaque(y, x) = True Then
                    jaqueN(y, x) = True
                End If
            Next
        Next
    End Sub

    Public Sub llenarJaqueB()
        limpiarJaqueB()
        For r As Integer = 0 To 7
            peonesN(r).jaqueRey()
            For y As Integer = 0 To 7
                For x As Integer = 0 To 7
                    If peonesN(r).jaque(y, x) Then
                        jaqueB(y, x) = True
                    End If
                Next
            Next
        Next

        For r As Integer = 0 To 1
            torresN(r).jaqueRey()
            For y As Integer = 0 To 7
                For x As Integer = 0 To 7
                    If torresN(r).jaque(y, x) Then
                        jaqueB(y, x) = True
                    End If
                Next
            Next
        Next

        For r As Integer = 0 To 1
            alfilesN(r).jaqueRey()
            For y As Integer = 0 To 7
                For x As Integer = 0 To 7
                    If alfilesN(r).jaque(y, x) = True Then
                        jaqueB(y, x) = True
                    End If
                Next
            Next
        Next

        For r As Integer = 0 To 1
            caballosN(r).jaqueRey()
            For y As Integer = 0 To 7
                For x As Integer = 0 To 7
                    If caballosN(r).jaque(y, x) = True Then
                        jaqueB(y, x) = True
                    End If
                Next
            Next
        Next

        reinaN.jaqueRey()
        For y As Integer = 0 To 7
            For x As Integer = 0 To 7
                If reinaN.jaque(y, x) = True Then
                    jaqueB(y, x) = True
                End If
            Next
        Next
    End Sub

    Public Sub limpiarJaqueB()
        For y As Integer = 0 To 7
            For x As Integer = 0 To 7
                jaqueB(y, x) = False
            Next
        Next
    End Sub

    Public Sub limpiarJaqueN()
        For y As Integer = 0 To 7
            For x As Integer = 0 To 7
                jaqueN(y, x) = False
            Next
        Next
    End Sub

    Public Sub MostrarPosMov(ByVal estados As Boolean(,))
        For a As Integer = 0 To 7
            For s As Integer = 0 To 7
                If estados(a, s) = True Then
                    tableroGraf(a, s).BackgroundImage = My.Resources.selection
                    posibles(a, s) = True
                End If
            Next
        Next
    End Sub

    Public Sub LimpiarResaltado()
        For y = 0 To 7
            For x = 0 To 7
                tableroGraf(x, y).BackgroundImage = Nothing
            Next
        Next
    End Sub

    Public Sub posiblesMovimientos(ByVal y As Integer, ByVal x As Integer)
        If tableroPosiciones(y, x) <> 0 Then
            tableroGraf(y, x).BackgroundImage = My.Resources.selection
        End If
        If turno = True Then
            Select Case tableroPosiciones(y, x)
                Case 1
                    For z As Integer = 0 To 7
                        If peonesB(z).PiezaPosicionX = x And peonesB(z).PiezaPosicionY = y Then
                            MostrarPosMov(peonesB(z).posibleMovimiento())
                        End If
                    Next
                Case 3
                    For z As Integer = 0 To 1
                        If caballosB(z).PiezaPosicionX = x And caballosB(z).PiezaPosicionY = y Then
                            MostrarPosMov(caballosB(z).posibleMovimiento())
                        End If
                    Next
                Case 4
                    For z As Integer = 0 To 1
                        If alfilesB(z).PiezaPosicionX = x And alfilesB(z).PiezaPosicionY = y Then
                            MostrarPosMov(alfilesB(z).posibleMovimiento())
                        End If
                    Next
                Case 5
                    For z As Integer = 0 To 1
                        If torresB(z).PiezaPosicionX = x And torresB(z).PiezaPosicionY = y Then
                            MostrarPosMov(torresB(z).posibleMovimiento())
                        End If
                    Next
                Case 10
                    MostrarPosMov(reinaB.posibleMovimiento())
                Case 100
                    MostrarPosMov(reyB.posibleMovimiento())
            End Select
        Else
            Select Case tableroPosiciones(y, x)
                Case -1
                    For z As Integer = 0 To 7
                        If peonesN(z).PiezaPosicionX = x And peonesN(z).PiezaPosicionY = y Then
                            MostrarPosMov(peonesN(z).posibleMovimiento())
                        End If
                    Next
                Case -3
                    For z As Integer = 0 To 1
                        If caballosN(z).PiezaPosicionX = x And caballosN(z).PiezaPosicionY = y Then
                            MostrarPosMov(caballosN(z).posibleMovimiento())
                        End If
                    Next
                Case -4
                    For z As Integer = 0 To 1
                        If alfilesN(z).PiezaPosicionX = x And alfilesN(z).PiezaPosicionY = y Then
                            MostrarPosMov(alfilesN(z).posibleMovimiento())
                        End If
                    Next
                Case -5
                    For z As Integer = 0 To 1
                        If torresN(z).PiezaPosicionX = x And torresN(z).PiezaPosicionY = y Then
                            MostrarPosMov(torresN(z).posibleMovimiento())
                        End If
                    Next
                Case -10
                    MostrarPosMov(reinaN.posibleMovimiento())
                Case -100
                    MostrarPosMov(reyN.posibleMovimiento())
            End Select
        End If
    End Sub

    Public Sub limpiarPosibles()
        For y = 0 To 7
            For x = 0 To 7
                posibles(x, y) = False
            Next
        Next
    End Sub

    Public Sub moverPieza(piece As Integer, posY As Integer, posX As Integer, posSelY As Integer, posSelX As Integer)
        Select Case piece
            Case 1
                For z As Integer = 0 To 7
                    If peonesB(z).PiezaPosicionX = posSelX And peonesB(z).PiezaPosicionY = posSelY Then
                        peonesB(z).MoverPeon(posY, posX, posSelY, posSelX)
                    End If
                Next
                turno = False
                llenarJaqueN()
                llenarJaqueB()
                ActualizarPosiciones()
            Case 3
                For z As Integer = 0 To 1
                    If caballosB(z).PiezaPosicionX = posSelX And caballosB(z).PiezaPosicionY = posSelY Then
                        caballosB(z).MoverCaballo(posY, posX, posSelY, posSelX)
                    End If
                Next
                llenarJaqueN()
                llenarJaqueB()
                ActualizarPosiciones()
                turno = False
            Case 4
                For z As Integer = 0 To 1
                    If alfilesB(z).PiezaPosicionX = posSelX And alfilesB(z).PiezaPosicionY = posSelY Then
                        alfilesB(z).MoverAlfil(posY, posX, posSelY, posSelX)
                    End If
                Next
                llenarJaqueN()
                llenarJaqueB()
                ActualizarPosiciones()
                turno = False
            Case 5
                For z As Integer = 0 To 1
                    If torresB(z).PiezaPosicionX = posSelX And torresB(z).PiezaPosicionY = posSelY Then
                        torresB(z).MoverTorre(posY, posX, posSelY, posSelX)
                    End If
                Next
                llenarJaqueN()
                llenarJaqueB()
                ActualizarPosiciones()
                turno = False
            Case 10
                If reinaB.PiezaPosicionX = posSelX And reinaB.PiezaPosicionY = posSelY Then
                    reinaB.MoverReina(posY, posX, posSelY, posSelX)
                End If
                llenarJaqueN()
                llenarJaqueB()
                ActualizarPosiciones()
                turno = False
            Case 100
                If reyB.PiezaPosicionX = posSelX And reyB.PiezaPosicionY = posSelY Then
                    reyB.MoverRey(posY, posX, posSelY, posSelX)
                End If
                llenarJaqueN()
                llenarJaqueB()
                ActualizarPosiciones()
                turno = False
            Case -1
                For z As Integer = 0 To 7
                    If peonesN(z).PiezaPosicionX = posSelX And peonesN(z).PiezaPosicionY = posSelY Then
                        peonesN(z).MoverPeon(posY, posX, posSelY, posSelX)
                    End If
                Next
                turno = True
                llenarJaqueN()
                llenarJaqueB()
                ActualizarPosiciones()
            Case -3
                For z As Integer = 0 To 1
                    If caballosN(z).PiezaPosicionX = posSelX And caballosN(z).PiezaPosicionY = posSelY Then
                        caballosN(z).MoverCaballo(posY, posX, posSelY, posSelX)
                    End If
                Next
                llenarJaqueN()
                llenarJaqueB()
                ActualizarPosiciones()
                turno = True
            Case -4
                For z As Integer = 0 To 1
                    If alfilesN(z).PiezaPosicionX = posSelX And alfilesN(z).PiezaPosicionY = posSelY Then
                        alfilesN(z).MoverAlfil(posY, posX, posSelY, posSelX)
                    End If
                Next
                llenarJaqueN()
                llenarJaqueB()
                ActualizarPosiciones()
                turno = True
            Case -5
                For z As Integer = 0 To 1
                    If torresN(z).PiezaPosicionX = posSelX And torresN(z).PiezaPosicionY = posSelY Then
                        torresN(z).MoverTorre(posY, posX, posSelY, posSelX)
                    End If
                Next
                llenarJaqueN()
                llenarJaqueB()
                ActualizarPosiciones()
                turno = True
            Case -10
                If reinaN.PiezaPosicionX = posSelX And reinaN.PiezaPosicionY = posSelY Then
                    reinaN.MoverReina(posY, posX, posSelY, posSelX)
                End If
                llenarJaqueN()
                llenarJaqueB()
                ActualizarPosiciones()
                turno = True
            Case -100
                If reyN.PiezaPosicionX = posSelX And reyN.PiezaPosicionY = posSelY Then
                    reyN.MoverRey(posY, posX, posSelY, posSelX)
                End If
                llenarJaqueN()
                llenarJaqueB()
                ActualizarPosiciones()
                turno = True
            Case Else

        End Select
    End Sub

    Private Sub c00_Click(sender As Object, e As EventArgs) Handles c00.Click
        limpiarResaltado()
        posicionY = 0
        posicionX = 0
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c01_Click(sender As Object, e As EventArgs) Handles c01.Click
        limpiarResaltado()
        posicionY = 0
        posicionX = 1
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c02_Click(sender As Object, e As EventArgs) Handles c02.Click
        limpiarResaltado()
        posicionY = 0
        posicionX = 2
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c03_Click(sender As Object, e As EventArgs) Handles c03.Click
        limpiarResaltado()
        posicionY = 0
        posicionX = 3
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c04_Click(sender As Object, e As EventArgs) Handles c04.Click
        limpiarResaltado()
        posicionY = 0
        posicionX = 4
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c05_Click(sender As Object, e As EventArgs) Handles c05.Click
        limpiarResaltado()
        posicionY = 0
        posicionX = 5
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c06_Click(sender As Object, e As EventArgs) Handles c06.Click
        limpiarResaltado()
        posicionY = 0
        posicionX = 6
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c07_Click(sender As Object, e As EventArgs) Handles c07.Click
        limpiarResaltado()
        posicionY = 0
        posicionX = 7
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c10_Click(sender As Object, e As EventArgs) Handles c10.Click
        limpiarResaltado()
        posicionY = 1
        posicionX = 0
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c76_Click(sender As Object, e As EventArgs) Handles c76.Click
        limpiarResaltado()
        posicionY = 7
        posicionX = 6
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c75_Click(sender As Object, e As EventArgs) Handles c75.Click
        limpiarResaltado()
        posicionY = 7
        posicionX = 5
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c74_Click(sender As Object, e As EventArgs) Handles c74.Click
        limpiarResaltado()
        posicionY = 7
        posicionX = 4
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c73_Click(sender As Object, e As EventArgs) Handles c73.Click
        limpiarResaltado()
        posicionY = 7
        posicionX = 3
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c72_Click(sender As Object, e As EventArgs) Handles c72.Click
        limpiarResaltado()
        posicionY = 7
        posicionX = 2
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c71_Click(sender As Object, e As EventArgs) Handles c71.Click
        limpiarResaltado()
        posicionY = 7
        posicionX = 1
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c70_Click(sender As Object, e As EventArgs) Handles c70.Click
        limpiarResaltado()
        posicionY = 7
        posicionX = 0
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c67_Click(sender As Object, e As EventArgs) Handles c67.Click
        limpiarResaltado()
        posicionY = 6
        posicionX = 7
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c66_Click(sender As Object, e As EventArgs) Handles c66.Click
        limpiarResaltado()
        posicionY = 6
        posicionX = 6
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c65_Click(sender As Object, e As EventArgs) Handles c65.Click
        limpiarResaltado()
        posicionY = 6
        posicionX = 5
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c64_Click(sender As Object, e As EventArgs) Handles c64.Click
        limpiarResaltado()
        posicionY = 6
        posicionX = 4
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c63_Click(sender As Object, e As EventArgs) Handles c63.Click
        limpiarResaltado()
        posicionY = 6
        posicionX = 3
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c62_Click(sender As Object, e As EventArgs) Handles c62.Click
        limpiarResaltado()
        posicionY = 6
        posicionX = 2
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c61_Click(sender As Object, e As EventArgs) Handles c61.Click
        limpiarResaltado()
        posicionY = 6
        posicionX = 1
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then

                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c60_Click(sender As Object, e As EventArgs) Handles c60.Click
        limpiarResaltado()
        posicionY = 6
        posicionX = 0
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c57_Click(sender As Object, e As EventArgs) Handles c57.Click
        limpiarResaltado()
        posicionY = 5
        posicionX = 7
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c56_Click(sender As Object, e As EventArgs) Handles c56.Click
        limpiarResaltado()
        posicionY = 5
        posicionX = 6
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c55_Click(sender As Object, e As EventArgs) Handles c55.Click
        limpiarResaltado()
        posicionY = 5
        posicionX = 5
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c54_Click(sender As Object, e As EventArgs) Handles c54.Click
        limpiarResaltado()
        posicionY = 5
        posicionX = 4
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c53_Click(sender As Object, e As EventArgs) Handles c53.Click
        limpiarResaltado()
        posicionY = 5
        posicionX = 3
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c52_Click(sender As Object, e As EventArgs) Handles c52.Click
        limpiarResaltado()
        posicionY = 5
        posicionX = 2
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c51_Click(sender As Object, e As EventArgs) Handles c51.Click
        limpiarResaltado()
        posicionY = 5
        posicionX = 1
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c50_Click(sender As Object, e As EventArgs) Handles c50.Click
        limpiarResaltado()
        posicionY = 5
        posicionX = 0
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c47_Click(sender As Object, e As EventArgs) Handles c47.Click
        limpiarResaltado()
        posicionY = 4
        posicionX = 7
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c46_Click(sender As Object, e As EventArgs) Handles c46.Click
        limpiarResaltado()
        posicionY = 4
        posicionX = 6
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c45_Click(sender As Object, e As EventArgs) Handles c45.Click
        limpiarResaltado()
        posicionY = 4
        posicionX = 5
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c44_Click(sender As Object, e As EventArgs) Handles c44.Click
        limpiarResaltado()
        posicionY = 4
        posicionX = 4
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c43_Click(sender As Object, e As EventArgs) Handles c43.Click
        limpiarResaltado()
        posicionY = 4
        posicionX = 3
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c42_Click(sender As Object, e As EventArgs) Handles c42.Click
        limpiarResaltado()
        posicionY = 4
        posicionX = 2
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c41_Click(sender As Object, e As EventArgs) Handles c41.Click
        limpiarResaltado()
        posicionY = 4
        posicionX = 1
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c40_Click(sender As Object, e As EventArgs) Handles c40.Click
        limpiarResaltado()
        posicionY = 4
        posicionX = 0
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c37_Click(sender As Object, e As EventArgs) Handles c37.Click
        limpiarResaltado()
        posicionY = 3
        posicionX = 7
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c36_Click(sender As Object, e As EventArgs) Handles c36.Click
        limpiarResaltado()
        posicionY = 3
        posicionX = 6
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c35_Click(sender As Object, e As EventArgs) Handles c35.Click
        limpiarResaltado()
        posicionY = 3
        posicionX = 5
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c34_Click(sender As Object, e As EventArgs) Handles c34.Click
        limpiarResaltado()
        posicionY = 3
        posicionX = 4
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c33_Click(sender As Object, e As EventArgs) Handles c33.Click
        limpiarResaltado()
        posicionY = 3
        posicionX = 3
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c32_Click(sender As Object, e As EventArgs) Handles c32.Click
        limpiarResaltado()
        posicionY = 3
        posicionX = 2
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c31_Click(sender As Object, e As EventArgs) Handles c31.Click
        limpiarResaltado()
        posicionY = 3
        posicionX = 1
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c30_Click(sender As Object, e As EventArgs) Handles c30.Click
        limpiarResaltado()
        posicionY = 3
        posicionX = 0
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c27_Click(sender As Object, e As EventArgs) Handles c27.Click
        limpiarResaltado()
        posicionY = 2
        posicionX = 7
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c26_Click(sender As Object, e As EventArgs) Handles c26.Click
        limpiarResaltado()
        posicionY = 2
        posicionX = 6
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c25_Click(sender As Object, e As EventArgs) Handles c25.Click
        limpiarResaltado()
        posicionY = 2
        posicionX = 5
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c24_Click(sender As Object, e As EventArgs) Handles c24.Click
        limpiarResaltado()
        posicionY = 2
        posicionX = 4
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c23_Click(sender As Object, e As EventArgs) Handles c23.Click
        limpiarResaltado()
        posicionY = 2
        posicionX = 3
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c22_Click(sender As Object, e As EventArgs) Handles c22.Click
        limpiarResaltado()
        posicionY = 2
        posicionX = 2
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
            moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
        End If
        haySeleccion = False
        ActualizarPosiciones()
        End If
    End Sub

    Private Sub c21_Click(sender As Object, e As EventArgs) Handles c21.Click
        limpiarResaltado()
        posicionY = 2
        posicionX = 1
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c20_Click(sender As Object, e As EventArgs) Handles c20.Click
        limpiarResaltado()
        posicionY = 2
        posicionX = 0
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c17_Click(sender As Object, e As EventArgs) Handles c17.Click
        limpiarResaltado()
        posicionY = 1
        posicionX = 7
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c16_Click(sender As Object, e As EventArgs) Handles c16.Click
        limpiarResaltado()
        posicionY = 1
        posicionX = 6
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c15_Click(sender As Object, e As EventArgs) Handles c15.Click
        limpiarResaltado()
        posicionY = 1
        posicionX = 5
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c14_Click(sender As Object, e As EventArgs) Handles c14.Click
        limpiarResaltado()
        posicionY = 1
        posicionX = 4
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c13_Click(sender As Object, e As EventArgs) Handles c13.Click
        limpiarResaltado()
        posicionY = 1
        posicionX = 3
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c12_Click(sender As Object, e As EventArgs) Handles c12.Click
        limpiarResaltado()
        posicionY = 1
        posicionX = 2
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c11_Click(sender As Object, e As EventArgs) Handles c11.MouseClick
        limpiarResaltado()
        posicionY = 1
        posicionX = 1
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub

    Private Sub c77_Click(sender As Object, e As EventArgs) Handles c77.Click
        limpiarResaltado()
        posicionY = 7
        posicionX = 7
        If haySeleccion <> True Then
            limpiarPosibles()
            pieza = tableroPosiciones(posicionY, posicionX)
            posicionSelY = posicionY
            posicionSelX = posicionX
            posiblesMovimientos(posicionY, posicionX)
            haySeleccion = True
        Else
            If posibles(posicionY, posicionX) = True Then
                moverPieza(pieza, posicionY, posicionX, posicionSelY, posicionSelX)
            End If
            haySeleccion = False
            ActualizarPosiciones()
        End If
    End Sub
End Class
