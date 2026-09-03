Imports System
Module juego_de_memoria
    Sub Main(args As String())
        Dim posiciones(15) As Integer
        Dim elementos(15) As String
        Dim descubiertas(15) As Boolean
        Dim parejasEncontradas As Integer = 0
        Dim intentos As Integer = 0
        Dim aciertos As Integer = 0
        Dim fallos As Integer = 0
        Dim opcion As Integer
        Dim juegoIniciado As Boolean = False
        elementos(0) = "A"
        elementos(1) = "B"
        elementos(2) = "C"
        elementos(3) = "D"
        elementos(4) = "E"
        elementos(5) = "F"
        elementos(6) = "G"
        elementos(7) = "H"
        elementos(8) = "H"
        elementos(9) = "G"
        elementos(10) = "F"
        elementos(11) = "E"
        elementos(12) = "D"
        elementos(13) = "C"
        elementos(14) = "B"
        elementos(15) = "A"
        For i As Integer = 0 To 15
            posiciones(i) = i + 1
            descubiertas(i) = False
        Next
        '-------------------------------------'
        '--|menu_principal_juego_de_memoria|--'
        '-------------------------------------'
        Do
            Console.WriteLine("menu principal juego de memoria")
            Console.WriteLine("1) Iniciar juego")
            Console.WriteLine("2) Mostrar tablero")
            Console.WriteLine("3) Mostrar estadisticas")
            Console.WriteLine("4) Reiniciar juego")
            Console.WriteLine("5) Salir")
            Console.Write("Seleccione una opcion: ")
            opcion = Convert.ToInt32(Console.ReadLine())
            Select Case opcion
                '-------------------'
                '--|iniciar_juego|--'
                '-------------------'
                Case 1
                    If parejasEncontradas = 8 Then
                        Console.WriteLine("El juego ya ha terminado. Reinicie la partida para jugar nuevamente.")
                    Else
                        juegoIniciado = True
                        Console.WriteLine("juego de memoria iniciado.")
                        Console.WriteLine("Seleccione dos posiciones diferentes para encontrar una pareja.")
                        Do While parejasEncontradas < 8
                            Console.WriteLine(" ")
                            Console.WriteLine("Tablero actual:")
                            For i As Integer = 0 To 15
                                If descubiertas(i) Then
                                    Console.Write(posiciones(i) & ": " & elementos(i) & " | ")
                                Else
                                    Console.Write(posiciones(i) & ": ? | ")
                                End If
                                If (i + 1) Mod 4 = 0 Then
                                    Console.WriteLine()
                                End If
                            Next
                            Console.Write("Ingrese la primera posicion: ")
                            Dim primeraPosicion As Integer = Convert.ToInt32(Console.ReadLine())
                            Console.Write("Ingrese la segunda posicion: ")
                            Dim segundaPosicion As Integer = Convert.ToInt32(Console.ReadLine())
                            If primeraPosicion < 1 OrElse primeraPosicion > 16 OrElse segundaPosicion < 1 OrElse segundaPosicion > 16 Then
                                Console.WriteLine("Las posiciones deben estar entre 1 y 16.")
                            ElseIf primeraPosicion = segundaPosicion Then
                                Console.WriteLine("Debe seleccionar dos posiciones diferentes.")
                            Else
                                Dim indicePrimero As Integer = primeraPosicion - 1
                                Dim indiceSegundo As Integer = segundaPosicion - 1
                                If descubiertas(indicePrimero) OrElse descubiertas(indiceSegundo) Then
                                    Console.WriteLine("Una de las posiciones seleccionadas ya fue descubierta.")
                                Else
                                    intentos += 1
                                    Console.WriteLine("Primera posicion: " & posiciones(indicePrimero) & " | Elemento: " & elementos(indicePrimero))
                                    Console.WriteLine("Segunda posicion: " & posiciones(indiceSegundo) & " | Elemento: " & elementos(indiceSegundo))
                                    If elementos(indicePrimero) = elementos(indiceSegundo) Then
                                        descubiertas(indicePrimero) = True
                                        descubiertas(indiceSegundo) = True
                                        parejasEncontradas += 1
                                        aciertos += 1
                                        Console.WriteLine("Pareja encontrada correctamente.")
                                        Console.WriteLine("Parejas encontradas: " & parejasEncontradas & " de 8")
                                    Else
                                        fallos += 1
                                        Console.WriteLine("No coinciden. Intente nuevamente.")
                                    End If
                                    If parejasEncontradas = 8 Then
                                        Console.WriteLine(" ")
                                        Console.WriteLine("Felicidades. Ha encontrado todas las parejas.")
                                        Console.WriteLine("Intentos realizados: " & intentos)
                                        Console.WriteLine("Aciertos: " & aciertos)
                                        Console.WriteLine("Fallos: " & fallos)
                                    End If
                                End If
                            End If
                            If parejasEncontradas < 8 Then
                                Console.WriteLine("Presione ENTER para continuar.")
                                Console.ReadLine()
                            End If
                        Loop
                    End If
                '---------------------'
                '--|mostrar_tablero|--'
                '---------------------'
                Case 2
                    If Not juegoIniciado Then
                        Console.WriteLine("Debe iniciar el juego primero.")
                    Else
                        Console.WriteLine("tablero del juego de memoria")
                        For i As Integer = 0 To 15
                            If descubiertas(i) Then
                                Console.Write(posiciones(i) & ": " & elementos(i) & " | ")
                            Else
                                Console.Write(posiciones(i) & ": ? | ")
                            End If
                            If (i + 1) Mod 4 = 0 Then
                                Console.WriteLine()
                            End If
                        Next
                    End If
                '--------------------------'
                '--|mostrar_estadisticas|--'
                '--------------------------'
                Case 3
                    If Not juegoIniciado Then
                        Console.WriteLine("Debe iniciar el juego primero.")
                    Else
                        Dim porcentajeAciertos As Double = 0
                        If intentos > 0 Then
                            porcentajeAciertos = (aciertos / intentos) * 100
                        End If
                        Console.WriteLine("Parejas encontradas: " & parejasEncontradas)
                        Console.WriteLine("Parejas restantes: " & (8 - parejasEncontradas))
                        Console.WriteLine("Intentos realizados: " & intentos)
                        Console.WriteLine("Aciertos: " & aciertos)
                        Console.WriteLine("Fallos: " & fallos)
                        Console.WriteLine("Porcentaje de aciertos: " & porcentajeAciertos.ToString("N2") & "%")
                    End If
                '---------------------'
                '--|reiniciar_juego|--'
                '---------------------'
                Case 4
                    For i As Integer = 0 To 15
                        descubiertas(i) = False
                    Next
                    parejasEncontradas = 0
                    intentos = 0
                    aciertos = 0
                    fallos = 0
                    juegoIniciado = False
                    Console.WriteLine("Juego reiniciado correctamente.")
                '------------------------------'
                '--|salir_del_menu_principal|--'
                '------------------------------'
                Case 5
                    Console.WriteLine("Gracias por jugar Juego de Memoria.")
                Case Else
                    Console.WriteLine("Opcion no valida.")
            End Select
        Loop While opcion <> 5
    End Sub
End Module