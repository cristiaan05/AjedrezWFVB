Public Class Reina
    Dim color As String
    Dim posicionX As Integer
    Dim posicionY As Integer
    Dim tipo As String
    Dim datos As Integer
    Dim movimientos(7, 7) As Boolean
    Public jaque(7, 7) As Boolean
    Dim ameRey As Boolean

    Public Sub New(datos As Integer, posicionY As Integer, posicionX As Integer)
        Me.tipo = "reina"
        If datos < 0 Then
            color = "N"
        Else
            color = "B"
        End If

        Me.posicionX = posicionX
        Me.posicionY = posicionY
        Me.datos = datos
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
        Dim x As Integer = posicionX
        Dim y As Integer = posicionY

        While (x < 7 And y > 0)
            x = x + 1
            y = y - 1
            If Ajedrez.tableroPosiciones(y, x) <= 0 Then
                movimientos(y, x) = True
                If Ajedrez.tableroPosiciones(y, x) < 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        x = posicionX
        y = posicionY
        While (x > 0 And y < 7)
            x = x - 1
            y = y + 1
            If Ajedrez.tableroPosiciones(y, x) <= 0 Then
                movimientos(y, x) = True
                If Ajedrez.tableroPosiciones(x, y) < 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        x = posicionX
        y = posicionY
        While (x < 7 And y < 7)
            x = x + 1
            y = y + 1
            If Ajedrez.tableroPosiciones(y, x) <= 0 Then
                movimientos(y, x) = True
                If Ajedrez.tableroPosiciones(y, x) < 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        x = posicionX
        y = posicionY
        While (x > 0 And y > 0)
            x = x - 1
            y = y - 1
            If Ajedrez.tableroPosiciones(y, x) <= 0 Then
                movimientos(y, x) = True
                If Ajedrez.tableroPosiciones(y, x) < 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        If posicionX > 0 Then
            For i As Integer = posicionY - 1 To 0 Step -1
                If Ajedrez.tableroPosiciones(i, posicionX) <= 0 Then
                    movimientos(i, posicionX) = True
                    If Ajedrez.tableroPosiciones(i, posicionX) < 0 Then
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If

        If posicionX <= 7 Then
            For i As Integer = posicionY + 1 To 7
                If Ajedrez.tableroPosiciones(i, posicionX) <= 0 Then
                    movimientos(i, posicionX) = True
                    If Ajedrez.tableroPosiciones(i, posicionX) < 0 Then
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If

        If posicionX > 0 Then
            For i As Integer = posicionX - 1 To 0 Step -1
                If Ajedrez.tableroPosiciones(posicionY, i) <= 0 Then
                    movimientos(posicionY, i) = True
                    If Ajedrez.tableroPosiciones(posicionY, i) < 0 Then
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If

        If posicionX <= 7 Then
            For i As Integer = posicionX + 1 To 7
                If Ajedrez.tableroPosiciones(posicionY, i) <= 0 Then
                    movimientos(posicionY, i) = True
                    If Ajedrez.tableroPosiciones(posicionY, i) < 0 Then
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If
    End Sub

    Public Sub movimientosNegro()
        Dim x As Integer = posicionX
        Dim y As Integer = posicionY

        While (x < 7 And y > 0)
            x = x + 1
            y = y - 1
            If Ajedrez.tableroPosiciones(y, x) >= 0 Then
                movimientos(y, x) = True
                If Ajedrez.tableroPosiciones(y, x) > 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        x = posicionX
        y = posicionY
        While (x > 0 And y < 7)
            x = x - 1
            y = y + 1
            If Ajedrez.tableroPosiciones(y, x) >= 0 Then
                movimientos(y, x) = True
                If Ajedrez.tableroPosiciones(x, y) > 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        x = posicionX
        y = posicionY
        While (x < 7 And y < 7)
            x = x + 1
            y = y + 1
            If Ajedrez.tableroPosiciones(y, x) >= 0 Then
                movimientos(y, x) = True
                If Ajedrez.tableroPosiciones(y, x) > 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        x = posicionX
        y = posicionY
        While (x > 0 And y > 0)
            x = x - 1
            y = y - 1
            If Ajedrez.tableroPosiciones(y, x) >= 0 Then
                movimientos(y, x) = True
                If Ajedrez.tableroPosiciones(y, x) > 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        If posicionX > 0 Then
            For i As Integer = posicionY - 1 To 0 Step -1
                If Ajedrez.tableroPosiciones(i, posicionX) >= 0 Then
                    movimientos(i, posicionX) = True
                    If Ajedrez.tableroPosiciones(i, posicionX) > 0 Then
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If

        If posicionX <= 7 Then
            For i As Integer = posicionY + 1 To 7
                If Ajedrez.tableroPosiciones(i, posicionX) >= 0 Then
                    movimientos(i, posicionX) = True
                    If Ajedrez.tableroPosiciones(i, posicionX) > 0 Then
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If

        If posicionX > 0 Then
            For i As Integer = posicionX - 1 To 0 Step -1
                If Ajedrez.tableroPosiciones(posicionY, i) >= 0 Then
                    movimientos(posicionY, i) = True
                    If Ajedrez.tableroPosiciones(posicionY, i) > 0 Then
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If

        If posicionX <= 7 Then
            For i As Integer = posicionX + 1 To 7
                If Ajedrez.tableroPosiciones(posicionY, i) >= 0 Then
                    movimientos(posicionY, i) = True
                    If Ajedrez.tableroPosiciones(posicionY, i) > 0 Then
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
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

    Public Sub MoverReina(posY As Integer, posX As Integer, posSelY As Integer, posSelX As Integer)
        Ajedrez.tableroPosiciones(posY, posX) = datos
        Ajedrez.tableroPosiciones(posSelY, posSelX) = 0
        posicionX = posX
        posicionY = posY
    End Sub
End Class
