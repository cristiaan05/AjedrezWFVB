Public Class Rey
    Dim color As String
    Dim posicionX As Integer
    Dim posicionY As Integer
    Dim tipo As String
    Dim datos As Integer
    Dim movimientos(7, 7) As Boolean
    Public jaque(7, 7) As Boolean
    Dim ameRey As Boolean

    Public Sub New(datos As Integer, posicionY As Integer, posicionX As Integer)
        Me.tipo = "rey"
        If datos < 0 Then
            color = "N"
        Else
            color = "B"
        End If

        Me.posicionX = posicionX
        Me.posicionY = posicionY

        Me.datos = datos
        'AddHandler imagen.MouseClick, AddressOf SeleccionarPieza
    End Sub

    Public Sub liberarMovs()
        For y As Integer = 0 To 7
            For x As Integer = 0 To 7
                movimientos(y, x) = False
            Next
        Next
    End Sub

    Public Function posibleMovimiento() As Boolean(,)
        liberarMovs()
        If datos > 0 Then
            movimientosBlanco()
        Else
            movimientosNegro()
        End If
        Return movimientos
    End Function

    Public Sub jaqueRey()
        posibleMovimiento()
        For y As Integer = 0 To 7
            For x As Integer = 0 To 7
                If posibleMovimiento(y, x) Then
                    jaque(y, x) = True
                Else
                    jaque(y, x) = False
                End If
            Next
        Next
    End Sub

    Public Sub movimientosBlanco()
        'Horizontal y Vertical
        If posicionX + 1 <= 7 Then
            If Ajedrez.tableroPosiciones(posicionY, posicionX + 1) <= 0 And Ajedrez.jaqueB(posicionY, posicionX + 1) = False Then
                movimientos(posicionY, posicionX + 1) = True
            End If
        End If
        If posicionX - 1 >= 0 Then
            If Ajedrez.tableroPosiciones(posicionY, posicionX - 1) <= 0 And Ajedrez.jaqueB(posicionY, posicionX - 1) = False Then
                movimientos(posicionY, posicionX - 1) = True
            End If
        End If
        If posicionY + 1 <= 7 Then
            If Ajedrez.tableroPosiciones(posicionY + 1, posicionX) <= 0 And Ajedrez.jaqueB(posicionY + 1, posicionX) = False Then
                movimientos(posicionY + 1, posicionX) = True
            End If
        End If
        If posicionY - 1 >= 0 Then
            If Ajedrez.tableroPosiciones(posicionY - 1, posicionX) <= 0 And Ajedrez.jaqueB(posicionY - 1, posicionX) = False Then
                movimientos(posicionY - 1, posicionX) = True
            End If
        End If

        'Diagonal
        If posicionX + 1 <= 7 And posicionY + 1 <= 7 Then
            If Ajedrez.tableroPosiciones(posicionY + 1, posicionX + 1) <= 0 And Ajedrez.jaqueB(posicionY + 1, posicionX + 1) = False Then
                movimientos(posicionY + 1, posicionX + 1) = True
            End If
        End If
        If posicionX - 1 >= 0 And posicionY - 1 >= 0 Then
            If Ajedrez.tableroPosiciones(posicionY - 1, posicionX - 1) <= 0 And Ajedrez.jaqueB(posicionY - 1, posicionX - 1) = False Then
                movimientos(posicionY - 1, posicionX - 1) = True
            End If
        End If
        If posicionX + 1 <= 7 And posicionY - 1 >= 0 Then
            If Ajedrez.tableroPosiciones(posicionY - 1, posicionX + 1) <= 0 And Ajedrez.jaqueB(posicionY - 1, posicionX + 1) = False Then
                movimientos(posicionY - 1, posicionX + 1) = True
            End If
        End If
        If posicionX - 1 >= 0 And posicionY + 1 <= 7 Then
            If Ajedrez.tableroPosiciones(posicionY + 1, posicionX - 1) <= 0 And Ajedrez.jaqueB(posicionY + 1, posicionX - 1) = False Then
                movimientos(posicionY + 1, posicionX - 1) = True
            End If
        End If
    End Sub

    Public Sub movimientosNegro()
        'Horizontal y Vertical
        If posicionX + 1 <= 7 Then
            If Ajedrez.tableroPosiciones(posicionY, posicionX + 1) >= 0 And Ajedrez.jaqueN(posicionY, posicionX + 1) = False Then
                movimientos(posicionY, posicionX + 1) = True
            End If
        End If
        If posicionX - 1 >= 0 Then
            If Ajedrez.tableroPosiciones(posicionY, posicionX - 1) >= 0 And Ajedrez.jaqueN(posicionY, posicionX + 1) = False Then
                movimientos(posicionY, posicionX - 1) = True
            End If
        End If
        If posicionY + 1 <= 7 Then
            If Ajedrez.tableroPosiciones(posicionY + 1, posicionX) >= 0 And Ajedrez.jaqueN(posicionY, posicionX + 1) = False Then
                movimientos(posicionY + 1, posicionX) = True
            End If
        End If
        If posicionY - 1 >= 0 Then
            If Ajedrez.tableroPosiciones(posicionY - 1, posicionX) >= 0 And Ajedrez.jaqueN(posicionY, posicionX + 1) = False Then
                movimientos(posicionY - 1, posicionX) = True
            End If
        End If

        'Diagonal
        If posicionX + 1 <= 7 And posicionY + 1 <= 7 Then
            If Ajedrez.tableroPosiciones(posicionY + 1, posicionX + 1) >= 0 And Ajedrez.jaqueN(posicionY + 1, posicionX + 1) = False Then
                movimientos(posicionY + 1, posicionX + 1) = True
            End If
        End If
        If posicionX - 1 >= 0 And posicionY - 1 >= 0 Then
            If Ajedrez.tableroPosiciones(posicionY - 1, posicionX - 1) >= 0 And Ajedrez.jaqueN(posicionY - 1, posicionX - 1) = False Then
                movimientos(posicionY - 1, posicionX - 1) = True
            End If
        End If
        If posicionX + 1 <= 7 And posicionY - 1 >= 0 Then
            If Ajedrez.tableroPosiciones(posicionY - 1, posicionX + 1) >= 0 And Ajedrez.jaqueN(posicionY - 1, posicionX + 1) = False Then
                movimientos(posicionY - 1, posicionX + 1) = True
            End If
        End If
        If posicionX - 1 >= 0 And posicionY + 1 <= 7 Then
            If Ajedrez.tableroPosiciones(posicionY + 1, posicionX - 1) >= 0 And Ajedrez.jaqueN(posicionY + 1, posicionX - 1) = False Then
                movimientos(posicionY + 1, posicionX - 1) = True
            End If
        End If
    End Sub

    Public Property ColorPieza() As String
        Get
            Return Me.color
        End Get
        Set(ByVal value As String)
            Me.color = value
        End Set
    End Property

    Public Property PiezaPosicionX() As Integer
        Get
            Return Me.posicionX
        End Get
        Set(ByVal value As Integer)
            Me.posicionX = value
        End Set
    End Property

    Public Property PiezaPosicionY() As Integer
        Get
            Return Me.posicionY
        End Get
        Set(ByVal value As Integer)
            Me.posicionY = value
        End Set
    End Property

    Public Property TipoPieza() As String
        Get
            Return Me.tipo
        End Get
        Set(ByVal value As String)
            Me.tipo = value
        End Set
    End Property

    Public Property DatosPieza() As Integer
        Get
            Return Me.datos
        End Get
        Set(value As Integer)
            Me.datos = value
        End Set
    End Property

    Public Sub MoverRey(posY As Integer, posX As Integer, posSelY As Integer, posSelX As Integer)
        Ajedrez.tableroPosiciones(posY, posX) = datos
        Ajedrez.tableroPosiciones(posSelY, posSelX) = 0
        posicionX = posX
        posicionY = posY
    End Sub
End Class
