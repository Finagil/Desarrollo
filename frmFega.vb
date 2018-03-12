Imports System.Data.SqlClient
Imports System.Windows.Forms.SendKeys

Public Class frmFega

#Region "Funciones"

    Public Sub HabDes(ByVal HabDes As Boolean)
        btnagregar.Visible = HabDes
        btnmodificar.Visible = HabDes
        btneliminar.Visible = HabDes
        btnimprimir.Visible = HabDes
        btnsalir.Visible = HabDes
        dtgFega.Visible = HabDes
        dtpVigenciaFega.Enabled = Not HabDes
        txtFega.Enabled = Not HabDes
        btncancelar.Visible = Not HabDes
    End Sub

    Public Sub llenaHistorialFega()
        Dim cnFega As New SqlConnection(strConn)
        Dim daFega As New SqlDataAdapter("SELECT IdFega,FechaVigencia,Fega FROM " & _
            "Fega order by FechaVigencia", cnFega)
        Dim dsFega As New DataSet
        Try
            daFega.Fill(dsFega, "Fega")
            dtgFega.DataSource = dsFega.Tables("Fega")
            dsFega.Dispose()
            daFega.Dispose()
            cnFega.Close()
            cnFega.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub frmFega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'lblFega.Text = rm.GetString("lblFega").ToString
        'lblVigenciaFega.Text = rm.GetString("lblVenceVigencia").ToString
        'btnagregar.Text = rm.GetString("Add").ToString
        'btncancelar.Text = rm.GetString("Cancel").ToString
        'btneliminar.Text = rm.GetString("Delete").ToString
        'btneliminar1.Text = rm.GetString("Delete").ToString
        'btnimprimir.Text = rm.GetString("Print").ToString
        'btnsalir.Text = rm.GetString("Exit").ToString
        'btnmodificar.Text = rm.GetString("Modify").ToString
        'btnmodificar1.Text = rm.GetString("Modify").ToString
        'btnguardar.Text = rm.GetString("Save").ToString
        'Me.Text = rm.GetString("Fega").ToString

        llenaHistorialFega()
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        llenaHistorialFega()
        HabDes(True)
        btnguardar.Visible = False
        btneliminar1.Visible = False
        btnmodificar1.Visible = False
        dtpVigenciaFega.Value = Date.Today
        txtFega.Text = Nothing
    End Sub

    Private Sub btnagregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregar.Click
        HabDes(False)
        btnguardar.Visible = True
        '  tsslMensaje.Text = rm.GetString("lblAgregaFega").ToString
    End Sub

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        dtpVigenciaFega.Value = dtgFega.CurrentRow.Cells(1).Value.ToString
        txtFega.Text = dtgFega.CurrentRow.Cells(2).Value.ToString
        HabDes(False)
        btnmodificar1.Visible = True
        '   tsslMensaje.Text = rm.GetString("lblModificarFega").ToString
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        dtpVigenciaFega.Value = dtgFega.CurrentRow.Cells(1).Value.ToString
        txtFega.Text = dtgFega.CurrentRow.Cells(2).Value.ToString
        HabDes(False)
        dtpVigenciaFega.Enabled = False
        txtFega.Enabled = False
        btneliminar1.Visible = True
        '      tsslMensaje.Text = rm.GetString("lblEliminarFega").ToString
    End Sub

    Private Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        If validar() Then
            Dim cnGuardar As New SqlConnection(strConn)
            Dim cmGuardar As New SqlCommand("INSERT INTO Fega(FechaVigencia,Fega) VALUES ('" & dtpVigenciaFega.Value.Month & "/" & dtpVigenciaFega.Value.Day & "/" & dtpVigenciaFega.Value.Year & "', " & _
                txtFega.Text & ")", cnGuardar)
            Try
                cnGuardar.Open()
                cmGuardar.ExecuteNonQuery()
                MsgBox("Se inserto correctamente el registro")
                cmGuardar.Dispose()
                cnGuardar.Close()
                cnGuardar.Dispose()
                btncancelar_Click(sender, e)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Verifique la información")
        End If
    End Sub

    Private Sub btnmodificar1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmodificar1.Click
        If ((txtFega.Text <> Nothing) Or (txtFega.Text < 0)) Then
            Dim cnActualiza As New SqlConnection(strConn)
            Dim cmActualiza As New SqlCommand("UPDATE Fega SET " & _
                "FechaVigencia = '" & dtpVigenciaFega.Value.Month & "/" & dtpVigenciaFega.Value.Day & "/" & dtpVigenciaFega.Value.Year & "'" & _
                ",Fega = " & txtFega.Text & _
                " WHERE IdFega = " & dtgFega.CurrentRow.Cells(0).Value.ToString, cnActualiza)
            Try
                cnActualiza.Open()
                cmActualiza.ExecuteNonQuery()
                MsgBox("Se modifico correctamente el registro")
                cmActualiza.Dispose()
                cnActualiza.Close()
                cnActualiza.Dispose()
                btncancelar_Click(sender, e)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            btncancelar_Click(sender, e)
        Else
            MsgBox("Verifique la información")
        End If
    End Sub

    Private Sub btneliminar1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btneliminar1.Click
        Dim cnEliminar As New SqlConnection(strConn)
        Dim cmEliminar As New SqlCommand("DELETE FROM Fega WHERE IdFega = " & dtgFega.CurrentRow.Cells(0).Value.ToString, cnEliminar)
        Try
            cnEliminar.Open()
            cmEliminar.ExecuteNonQuery()
            MsgBox("Se elimino el registro")
            cmEliminar.Dispose()
            cnEliminar.Close()
            cnEliminar.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        btncancelar_Click(sender, e)
    End Sub

    Private Sub txtFega_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFega.KeyPress
        If (Not IsNumeric(e.KeyChar)) Then
            If (e.KeyChar <> ".") Then
                If (e.KeyChar <> "") Then
                    e.KeyChar = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
    End Sub

    Public Function validar()
        Dim cnFecha As New SqlConnection(strConn)
        Dim cmFecha As New SqlCommand("select max(FechaVigencia) as Fecha from Fega", cnFecha)
        Dim drFecha As SqlDataReader
        Try
            cnFecha.Open()
            drFecha = cmFecha.ExecuteReader
            If drFecha.Read Then
                If dtpVigenciaFega.Value >= CDate(drFecha("Fecha").ToString) Then
                    If txtFega.Text <> Nothing Then
                        If txtFega.Text > 0 Then
                            Return True
                        Else
                            MsgBox("El valor de fega no puede ser menor a 0 ")
                        End If
                    Else
                        MsgBox("Digite el valor de Fega")
                    End If
                Else
                    MsgBox("La fecha de caducidad no puede ser menor a la fecha anterior")
                End If
                End If
        Catch ex As Exception
            MsgBox("Ocurrio un error: " & ex.Message)
            Return False
        End Try
        Return False
    End Function


End Class