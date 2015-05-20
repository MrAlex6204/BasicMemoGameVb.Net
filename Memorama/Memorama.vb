Public Class Memorama


    Dim CountTotal As Integer = 0
    Dim CountClick As Integer = 0
    Dim btn1, btn2 As Object

    Private Sub SortearImagenes()
        Dim Aleatorio As New Random(0)
        Dim lstNumerosAsignados1 As New ArrayList '//===>Lista de numeros aleatorios asignados ala primera mitad
        Dim lstNumerosAsignados2 As New ArrayList '//===>Lista de numeros aleatorios asignados ala seg. mitad
        '//===>Lista de botones que hay en el formulario
        Dim LstBotones() As Button = { _
                                        Me.Button1, Me.Button2, Me.Button3, Me.Button4, Me.Button5, _
                                        Me.Button6, Me.Button7, Me.Button8, Me.Button9, Me.Button10, _
                                        Me.Button11, Me.Button12, Me.Button13, Me.Button14, Me.Button15, _
                                        Me.Button16, Me.Button17, Me.Button18, Me.Button19, Me.Button20 _
                                    }


        CountTotal = 0 '//===>Reseteamos el total acertadas.

        For Idx = 0 To 9 '//===>Asignar numero aleatorio ala primera mitad
OtroNum:
            Dim NumAleatorio As Integer = Aleatorio.Next(10)

            If NumAleatorio = 10 Then
                NumAleatorio = -1
            End If

            '//===>Verificamos que el numero aletarorio no haiga sido asignado anteriormente!
            'para evitar imagenes repetidas.
            If lstNumerosAsignados1.Contains(NumAleatorio) = False Then
                With LstBotones(Idx)
                    .ImageIndex = -1
                    .FlatStyle = FlatStyle.Standard
                    .Tag = NumAleatorio '//===>Asignar el numero aleatorio ala propiedad Tag
                End With
                lstNumerosAsignados1.Add(NumAleatorio)
                AddHandler LstBotones(Idx).Click, AddressOf bntClick '//===>Agregamos la funcion click dinamicamente
            Else
                GoTo OtroNum '//===>Obtener otro numero aleatorio diferente.
            End If
        Next

        For Index = 10 To 19 '//===>Asignar numero aleatorio ala segunda mitad
ObtenerOtroNum:
            Dim NumAleatorio As Integer = Aleatorio.Next(10)

            If NumAleatorio = 10 Then
                NumAleatorio = -1
            End If

            '//===>Verificamos si el numero fue asignado en la primera mitad y en la segunda todavia no
            If lstNumerosAsignados1.Contains(NumAleatorio) = True And lstNumerosAsignados2.Contains(NumAleatorio) = False Then
                With LstBotones(Index)
                    .ImageIndex = -1
                    .FlatStyle = FlatStyle.Standard
                    .Tag = NumAleatorio '//===>Asignar el numero aleatorio ala propiedad Tag
                End With
                AddHandler LstBotones(Index).Click, AddressOf bntClick '//===>Agregamos la funcion click dinamicamente
                lstNumerosAsignados2.Add(NumAleatorio)

            Else
                '//===>Obtener otro numero que ya haiga sido asignado.
                GoTo ObtenerOtroNum
            End If

        Next

        
    End Sub

    Private Sub bntClick(sender As Object, e As EventArgs)

        '//===>Verificamos que el boton no este presionado.
        If CType(sender, Button).FlatStyle <> FlatStyle.Flat Then

            CountClick += 1 '//===>Contar los clicks

            If CountClick = 1 Then
                btn1 = sender '//===>El primer boton que dio click

                CType(sender, Button).FlatStyle = FlatStyle.Flat '//===>Cambiar el estilo del boton
                CType(sender, Button).ImageIndex = CType(sender, Button).Tag '//===>Asignar el Index de la imagen que sele asigno aleatoriamente

            ElseIf CountClick = 2 Then
                btn2 = sender '//===>El segundo boton que dio click

                CType(sender, Button).FlatStyle = FlatStyle.Flat '//===>Cambiar el estilo del boton
                CType(sender, Button).ImageIndex = CType(sender, Button).Tag '//===>Asignar el Index de la imagen que sele asigno aleatoriamente

                If CType(btn1, Button).Tag = CType(btn2, Button).Tag Then

                    RemoveHandler CType(btn1, Button).Click, AddressOf bntClick
                    RemoveHandler CType(btn2, Button).Click, AddressOf bntClick
                    CountTotal += 1 '//===>Sumamos la cantidad de veces acertadas
                Else
                    '//===>Resetear el estilo del boton 1 y 2 ala apariencia normal
                    MsgBox("Intenta otra vez!")
                    CType(btn1, Button).FlatStyle = FlatStyle.Standard
                    CType(btn2, Button).FlatStyle = FlatStyle.Standard

                    CType(btn1, Button).ImageIndex = -1
                    CType(btn2, Button).ImageIndex = -1


                End If

                CountClick = 0

            End If

            If CountTotal = 10 Then
                MsgBox("!!!!!Felicidades has terminado!!!!!")
            End If

        End If







    End Sub

    Private Sub cmdPlay_Click(sender As Object, e As EventArgs) Handles cmdPlay.Click
        SortearImagenes()
        MsgBox("Listo!")
    End Sub
End Class
