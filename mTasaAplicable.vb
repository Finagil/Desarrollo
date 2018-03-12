Module mTasaAplicable

    Public Sub TasaAplicable(ByVal cTipar As String, ByVal cTipta As String, ByVal nPlazo As Integer, ByVal nIvaEq As Decimal, ByVal lRD As Boolean, ByVal nRD As Byte, ByVal lDG As Boolean, ByVal nDG As Byte, ByVal dsAgil As DataSet, ByRef nTasas As Decimal, ByRef nDifer As Decimal, ByRef nPorOp As Decimal)

        ' Esta función determina la tasa aplicable a un contrato (si es tasa fija),
        ' el diferencial (si es un contrato con tasa variable) y 
        ' el porcentaje de valor residual (si se trata de un arrendamiento puro)

        ' Declaración de variables de conexión ADO .NET

        Dim drTasasAplicables As DataRowCollection
        Dim drTasaAplicable As DataRow

        If cTipta <> "7" Then

            ' Se trata de un crédito a Tasa Variable

            If cTipar = "F" Then

                ' Arrendamiento Financiero

                If nIvaEq = 0 Then
                    drTasasAplicables = dsAgil.Tables("TVAFsinIVA").Rows
                    For Each drTasaAplicable In drTasasAplicables
                        If nPlazo >= drTasaAplicable("Límite Inferior") And nPlazo <= drTasaAplicable("Límite Superior") Then
                            nDifer = drTasaAplicable("Diferencial Aplicable")
                            If lRD = True Then
                                If nRD = 1 Then
                                    nDifer = drTasaAplicable("1 RD")
                                ElseIf nRD = 2 Then
                                    nDifer = drTasaAplicable("2 RD")
                                ElseIf nRD = 3 Then
                                    nDifer = drTasaAplicable("3 RD")
                                End If
                            End If
                        End If
                    Next
                Else
                    drTasasAplicables = dsAgil.Tables("TVAFconIVA").Rows
                    For Each drTasaAplicable In drTasasAplicables
                        If nPlazo >= drTasaAplicable("Límite Inferior") And nPlazo <= drTasaAplicable("Límite Superior") Then
                            nDifer = drTasaAplicable("Diferencial Aplicable")
                            If lRD = True Then
                                If lDG = True Then
                                    If nRD = 1 Then
                                        nDifer = drTasaAplicable("1 RD y DG")
                                    ElseIf nRD = 2 Then
                                        nDifer = drTasaAplicable("2 RD y DG")
                                    ElseIf nRD = 3 Then
                                        nDifer = drTasaAplicable("3 RD y DG")
                                    End If
                                Else
                                    If nRD = 1 Then
                                        nDifer = drTasaAplicable("1 RD")
                                    ElseIf nRD = 2 Then
                                        nDifer = drTasaAplicable("2 RD")
                                    ElseIf nRD = 3 Then
                                        nDifer = drTasaAplicable("3 RD")
                                    End If
                                End If
                            Else
                                If lDG = True Then
                                    nDifer = drTasaAplicable("Depósito")
                                End If
                            End If
                        End If
                    Next
                End If

            ElseIf cTipar = "P" Then

                ' Arrendamiento Puro

                drTasasAplicables = dsAgil.Tables("TVAP").Rows
                For Each drTasaAplicable In drTasasAplicables
                    If nPlazo >= drTasaAplicable("Límite Inferior") And nPlazo <= drTasaAplicable("Límite Superior") Then
                        nDifer = drTasaAplicable("Diferencial Aplicable")
                        nPorOp = drTasaAplicable("VR")
                        If lRD = True Then
                            If nRD = 1 Then
                                nPorOp = drTasaAplicable("VR 1RD")
                            ElseIf nRD = 2 Then
                                nPorOp = drTasaAplicable("VR 2RD")
                            ElseIf nRD = 3 Then
                                nPorOp = drTasaAplicable("VR 3RD")
                            End If
                        End If
                    End If
                Next

            ElseIf cTipar = "R" Then

                ' Crédito Refaccionario

                drTasasAplicables = dsAgil.Tables("TVCR").Rows
                For Each drTasaAplicable In drTasasAplicables
                    If nPlazo >= drTasaAplicable("Límite Inferior") And nPlazo <= drTasaAplicable("Límite Superior") Then
                        nDifer = drTasaAplicable("Diferencial Aplicable")
                        If lDG = True Then
                            If nDG = 1 Then
                                nDifer = drTasaAplicable("5% DG")
                            ElseIf nDG = 2 Then
                                nDifer = drTasaAplicable("10% DG")
                            ElseIf nDG = 3 Then
                                nDifer = drTasaAplicable("15% DG")
                            End If
                        End If
                    End If
                Next

            ElseIf cTipar = "S" Then

                ' Crédito Simple

                drTasasAplicables = dsAgil.Tables("TVCS").Rows
                For Each drTasaAplicable In drTasasAplicables
                    If nPlazo >= drTasaAplicable("Límite Inferior") And nPlazo <= drTasaAplicable("Límite Superior") Then
                        nDifer = drTasaAplicable("Diferencial Aplicable")
                        If lDG = True Then
                            If nDG = 1 Then
                                nDifer = drTasaAplicable("5% DG")
                            ElseIf nDG = 2 Then
                                nDifer = drTasaAplicable("10% DG")
                            ElseIf nDG = 3 Then
                                nDifer = drTasaAplicable("15% DG")
                            End If
                        End If
                    End If
                Next

            End If

        End If

        If cTipta = "7" Then

            ' Se trata de un crédito a Tasa Fija

            If cTipar = "F" Then

                ' Arrendamiento Financiero

                If nIvaEq = 0 Then
                    drTasasAplicables = dsAgil.Tables("AFsinIVA").Rows
                    For Each drTasaAplicable In drTasasAplicables
                        If nPlazo >= drTasaAplicable("Límite Inferior") And nPlazo <= drTasaAplicable("Límite Superior") Then
                            nTasas = drTasaAplicable("Tasa Aplicable")
                            If lRD = True Then
                                If nRD = 1 Then
                                    nTasas = drTasaAplicable("1 RD")
                                ElseIf nRD = 2 Then
                                    nTasas = drTasaAplicable("2 RD")
                                ElseIf nRD = 3 Then
                                    nTasas = drTasaAplicable("3 RD")
                                End If
                            End If
                        End If
                    Next
                Else
                    drTasasAplicables = dsAgil.Tables("AFconIVA").Rows
                    For Each drTasaAplicable In drTasasAplicables
                        If nPlazo >= drTasaAplicable("Límite Inferior") And nPlazo <= drTasaAplicable("Límite Superior") Then
                            nTasas = drTasaAplicable("Tasa Aplicable")
                            If lRD = True Then
                                If lDG = True Then
                                    If nRD = 1 Then
                                        nTasas = drTasaAplicable("1 RD y DG")
                                    ElseIf nRD = 2 Then
                                        nTasas = drTasaAplicable("2 RD y DG")
                                    ElseIf nRD = 3 Then
                                        nTasas = drTasaAplicable("3 RD y DG")
                                    End If
                                Else
                                    If nRD = 1 Then
                                        nTasas = drTasaAplicable("1 RD")
                                    ElseIf nRD = 2 Then
                                        nTasas = drTasaAplicable("2 RD")
                                    ElseIf nRD = 3 Then
                                        nTasas = drTasaAplicable("3 RD")
                                    End If
                                End If
                            Else
                                If lDG = True Then
                                    nTasas = drTasaAplicable("Depósito")
                                End If
                            End If
                        End If
                    Next
                End If

            End If

            If cTipar = "P" Then

                ' Arrendamiento Puro

                drTasasAplicables = dsAgil.Tables("AP").Rows
                For Each drTasaAplicable In drTasasAplicables
                    If nPlazo >= drTasaAplicable("Límite Inferior") And nPlazo <= drTasaAplicable("Límite Superior") Then
                        nTasas = drTasaAplicable("Tasa Aplicable")
                        nPorOp = drTasaAplicable("VR")
                        If lRD = True Then
                            If nRD = 1 Then
                                nPorOp = drTasaAplicable("VR 1RD")
                            ElseIf nRD = 2 Then
                                nPorOp = drTasaAplicable("VR 2RD")
                            ElseIf nRD = 3 Then
                                nPorOp = drTasaAplicable("VR 3RD")
                            End If
                        End If
                    End If
                Next

            End If

            If cTipar = "R" Then

                ' Crédito Refaccionario

                drTasasAplicables = dsAgil.Tables("CR").Rows
                For Each drTasaAplicable In drTasasAplicables
                    If nPlazo >= drTasaAplicable("Límite Inferior") And nPlazo <= drTasaAplicable("Límite Superior") Then
                        nTasas = drTasaAplicable("Tasa Aplicable")
                        If lDG = True Then
                            If nDG = 1 Then
                                nTasas = drTasaAplicable("5% DG")
                            ElseIf nDG = 2 Then
                                nTasas = drTasaAplicable("10% DG")
                            ElseIf nDG = 3 Then
                                nTasas = drTasaAplicable("15% DG")
                            End If
                        End If
                    End If
                Next

            End If

            If cTipar = "S" Or cTipar = "N" Then

                ' Crédito Simple o Crédito de Nómina

                drTasasAplicables = dsAgil.Tables("CS").Rows
                For Each drTasaAplicable In drTasasAplicables
                    If nPlazo >= drTasaAplicable("Límite Inferior") And nPlazo <= drTasaAplicable("Límite Superior") Then
                        nTasas = drTasaAplicable("Tasa Aplicable")
                        If lDG = True Then
                            If nDG = 1 Then
                                nTasas = drTasaAplicable("5% DG")
                            ElseIf nDG = 2 Then
                                nTasas = drTasaAplicable("10% DG")
                            ElseIf nDG = 3 Then
                                nTasas = drTasaAplicable("15% DG")
                            End If
                        End If
                    End If
                Next

            End If

        End If

    End Sub

End Module
