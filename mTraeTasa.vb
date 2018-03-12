Option Explicit On 

' Todos los programas que llamen a este módulo, deberán enviar el parámetro drTasas con la llave primaria creada;
' de otra forma, el programa fallará.

Module mTraeTasa

    Public Sub TraeTasa(ByVal drTasas As DataRowCollection, ByVal cTipta As String, ByVal cFeven As String, ByRef nTasaFact As Decimal, ByVal cFechacon As String)

        ' El parámetro drTasas contiene los valores de las diferentes tasas de interés.   En primera instancia
        ' contiene TODAS las tasas de interés del archivo HISTA.   Sin embargo, tiene asignada una Llave Primaria
        ' a fin de que la búsqueda se realice en forma directa en vez de secuencial.

        ' Declaración de variables de conexión ADO .NET

        Dim drTasa As DataRow

        For Each drTasa In drTasas

            If drTasa("Vigencia") = cFeven Then

                If cTipta = "1" And InStr(1, "34", drTasa("Tasa"), CompareMethod.Text) > 0 Then

                    ' Tasa Líder entre TIIP, TIIE

                    nTasaFact = IIf(drTasa("Valor") > nTasaFact, drTasa("Valor"), nTasaFact)

                ElseIf cTipta = "2" And InStr(1, "134", drTasa("Tasa"), CompareMethod.Text) > 0 Then

                    ' Tasa Líder entre CPP, TIIP, TIIE

                    nTasaFact = IIf(drTasa("Valor") > nTasaFact, drTasa("Valor"), nTasaFact)

                ElseIf cTipta = "3" And InStr(1, "123", drTasa("Tasa"), CompareMethod.Text) > 0 Then

                    ' Tasa Líder entre CPP, CETES, TIIP

                    nTasaFact = IIf(drTasa("Valor") > nTasaFact, drTasa("Valor"), nTasaFact)

                ElseIf cTipta = "4" And InStr(1, "1234", drTasa("Tasa"), CompareMethod.Text) > 0 Then

                    ' Tasa Líder entre CPP, CETES, TIIP, TIIE

                    nTasaFact = IIf(drTasa("Valor") > nTasaFact, drTasa("Valor"), nTasaFact)

                ElseIf cTipta = "5" And InStr(1, "5", drTasa("Tasa"), CompareMethod.Text) > 0 Then

                    ' Tasa NAFIN

                    nTasaFact = IIf(drTasa("Valor") > nTasaFact, drTasa("Valor"), nTasaFact)

                ElseIf cTipta = "6" And InStr(1, "4", drTasa("Tasa"), CompareMethod.Text) > 0 Then

                    ' Tasa TIIE

                    nTasaFact = IIf(drTasa("Valor") > nTasaFact, drTasa("Valor"), nTasaFact)

                ElseIf cTipta = "8" And InStr(1, "4", drTasa("Tasa"), CompareMethod.Text) > 0 Then

                    ' Tasa PROTEGIDA

                    Select Case cFechacon
                        Case Is >= "20020601"
                            nTasaFact = IIf(drTasa("Valor") < 13, drTasa("Valor"), 13)
                        Case Is >= "20020501"
                            nTasaFact = IIf(drTasa("Valor") < 12, drTasa("Valor"), 12)
                        Case Is >= "20020301"
                            nTasaFact = IIf(drTasa("Valor") < 13, drTasa("Valor"), 13)
                        Case Else
                            nTasaFact = IIf(drTasa("Valor") < 14, drTasa("Valor"), 14)
                    End Select

                End If

            End If

        Next

    End Sub

End Module
