Option Explicit On 

Imports System.Data.SqlClient

Public Class frmModiPers

    Inherits System.Windows.Forms.Form

    Dim cCoa As String
    Dim cObli As String
    Dim cAv1 As String
    Dim cAv2 As String
    Dim cTipo As String
    Dim cCusnam As String
    Dim cTipocoa As String
    Dim cTipobli As String
    Dim cTipoav1 As String
    Dim cTipoav2 As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cCliente As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        txtCliente.Text = cCliente


        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtCusnam As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As TabControlEx
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents lblnRepcte As System.Windows.Forms.Label
    Friend WithEvents txtnRepcte As System.Windows.Forms.TextBox
    Friend WithEvents lblPoderRep As System.Windows.Forms.Label
    Friend WithEvents lblGenerep As System.Windows.Forms.Label
    Friend WithEvents lblGeneCte As System.Windows.Forms.Label
    Friend WithEvents txtPoderRep As System.Windows.Forms.TextBox
    Friend WithEvents txtGeneRep As System.Windows.Forms.TextBox
    Friend WithEvents txtGeneCte As System.Windows.Forms.TextBox
    Friend WithEvents lblCoac As System.Windows.Forms.Label
    Friend WithEvents txtCoac As System.Windows.Forms.TextBox
    Friend WithEvents txtRepCoa As System.Windows.Forms.TextBox
    Friend WithEvents lblRepcoa As System.Windows.Forms.Label
    Friend WithEvents lblPoderepc As System.Windows.Forms.Label
    Friend WithEvents lblGenerepc As System.Windows.Forms.Label
    Friend WithEvents lblGenecoa As System.Windows.Forms.Label
    Friend WithEvents txtPoderepc As System.Windows.Forms.TextBox
    Friend WithEvents txtGenerepc As System.Windows.Forms.TextBox
    Friend WithEvents txtGenecoa As System.Windows.Forms.TextBox
    Friend WithEvents lblObl As System.Windows.Forms.Label
    Friend WithEvents txtRepobl As System.Windows.Forms.TextBox
    Friend WithEvents lblRepobl As System.Windows.Forms.Label
    Friend WithEvents lblPodeobli As System.Windows.Forms.Label
    Friend WithEvents lblRepobli As System.Windows.Forms.Label
    Friend WithEvents lblObli As System.Windows.Forms.Label
    Friend WithEvents txtPodeobli As System.Windows.Forms.TextBox
    Friend WithEvents txtRepobli As System.Windows.Forms.TextBox
    Friend WithEvents txtObli As System.Windows.Forms.TextBox
    Friend WithEvents txtpava As System.Windows.Forms.TextBox
    Friend WithEvents lblpav As System.Windows.Forms.Label
    Friend WithEvents lblRepa1 As System.Windows.Forms.Label
    Friend WithEvents lblPodeav1 As System.Windows.Forms.Label
    Friend WithEvents lblRepav1 As System.Windows.Forms.Label
    Friend WithEvents lblAval1 As System.Windows.Forms.Label
    Friend WithEvents txtPodeav1 As System.Windows.Forms.TextBox
    Friend WithEvents txtRepav1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAval1 As System.Windows.Forms.TextBox
    Friend WithEvents txtobl As System.Windows.Forms.TextBox
    Friend WithEvents txtRepa1 As System.Windows.Forms.TextBox
    Friend WithEvents txtsaval As System.Windows.Forms.TextBox
    Friend WithEvents lblsaval As System.Windows.Forms.Label
    Friend WithEvents txtsava As System.Windows.Forms.TextBox
    Friend WithEvents lblRepsav As System.Windows.Forms.Label
    Friend WithEvents lblAval2 As System.Windows.Forms.Label
    Friend WithEvents lblRepav2 As System.Windows.Forms.Label
    Friend WithEvents lblPodeav2 As System.Windows.Forms.Label
    Friend WithEvents txtPodeav2 As System.Windows.Forms.TextBox
    Friend WithEvents txtRepav2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAval2 As System.Windows.Forms.TextBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.lblNombre = New System.Windows.Forms.Label
        Me.txtCusnam = New System.Windows.Forms.TextBox
        Me.TabControl1 = New Agil.TabControlEx
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btnSalir = New System.Windows.Forms.Button
        Me.lblnRepcte = New System.Windows.Forms.Label
        Me.txtnRepcte = New System.Windows.Forms.TextBox
        Me.lblPoderRep = New System.Windows.Forms.Label
        Me.lblGenerep = New System.Windows.Forms.Label
        Me.lblGeneCte = New System.Windows.Forms.Label
        Me.txtPoderRep = New System.Windows.Forms.TextBox
        Me.txtGeneRep = New System.Windows.Forms.TextBox
        Me.txtGeneCte = New System.Windows.Forms.TextBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.lblCoac = New System.Windows.Forms.Label
        Me.txtCoac = New System.Windows.Forms.TextBox
        Me.txtRepCoa = New System.Windows.Forms.TextBox
        Me.lblRepcoa = New System.Windows.Forms.Label
        Me.lblPoderepc = New System.Windows.Forms.Label
        Me.lblGenerepc = New System.Windows.Forms.Label
        Me.lblGenecoa = New System.Windows.Forms.Label
        Me.txtPoderepc = New System.Windows.Forms.TextBox
        Me.txtGenerepc = New System.Windows.Forms.TextBox
        Me.txtGenecoa = New System.Windows.Forms.TextBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.txtobl = New System.Windows.Forms.TextBox
        Me.lblObl = New System.Windows.Forms.Label
        Me.txtRepobl = New System.Windows.Forms.TextBox
        Me.lblRepobl = New System.Windows.Forms.Label
        Me.lblPodeobli = New System.Windows.Forms.Label
        Me.lblRepobli = New System.Windows.Forms.Label
        Me.lblObli = New System.Windows.Forms.Label
        Me.txtPodeobli = New System.Windows.Forms.TextBox
        Me.txtRepobli = New System.Windows.Forms.TextBox
        Me.txtObli = New System.Windows.Forms.TextBox
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.txtpava = New System.Windows.Forms.TextBox
        Me.lblpav = New System.Windows.Forms.Label
        Me.txtRepa1 = New System.Windows.Forms.TextBox
        Me.lblRepa1 = New System.Windows.Forms.Label
        Me.lblPodeav1 = New System.Windows.Forms.Label
        Me.lblRepav1 = New System.Windows.Forms.Label
        Me.lblAval1 = New System.Windows.Forms.Label
        Me.txtPodeav1 = New System.Windows.Forms.TextBox
        Me.txtRepav1 = New System.Windows.Forms.TextBox
        Me.txtAval1 = New System.Windows.Forms.TextBox
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.txtsaval = New System.Windows.Forms.TextBox
        Me.lblsaval = New System.Windows.Forms.Label
        Me.txtsava = New System.Windows.Forms.TextBox
        Me.lblRepsav = New System.Windows.Forms.Label
        Me.lblAval2 = New System.Windows.Forms.Label
        Me.lblRepav2 = New System.Windows.Forms.Label
        Me.lblPodeav2 = New System.Windows.Forms.Label
        Me.txtPodeav2 = New System.Windows.Forms.TextBox
        Me.txtRepav2 = New System.Windows.Forms.TextBox
        Me.txtAval2 = New System.Windows.Forms.TextBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(800, 8)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(24, 20)
        Me.txtCliente.TabIndex = 8
        Me.txtCliente.Visible = False
        '
        'lblNombre
        '
        Me.lblNombre.Location = New System.Drawing.Point(16, 9)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(112, 20)
        Me.lblNombre.TabIndex = 10
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCusnam
        '
        Me.txtCusnam.Location = New System.Drawing.Point(144, 9)
        Me.txtCusnam.Name = "txtCusnam"
        Me.txtCusnam.ReadOnly = True
        Me.txtCusnam.Size = New System.Drawing.Size(496, 20)
        Me.txtCusnam.TabIndex = 9
        Me.txtCusnam.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(16, 48)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(840, 656)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnSalir)
        Me.TabPage1.Controls.Add(Me.lblnRepcte)
        Me.TabPage1.Controls.Add(Me.txtnRepcte)
        Me.TabPage1.Controls.Add(Me.lblPoderRep)
        Me.TabPage1.Controls.Add(Me.lblGenerep)
        Me.TabPage1.Controls.Add(Me.lblGeneCte)
        Me.TabPage1.Controls.Add(Me.txtPoderRep)
        Me.TabPage1.Controls.Add(Me.txtGeneRep)
        Me.TabPage1.Controls.Add(Me.txtGeneCte)
        Me.TabPage1.Controls.Add(Me.btnGuardar)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(832, 630)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cliente"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Enabled = False
        Me.btnSalir.Location = New System.Drawing.Point(696, 24)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(104, 23)
        Me.btnSalir.TabIndex = 20
        Me.btnSalir.Text = "Salir"
        '
        'lblnRepcte
        '
        Me.lblnRepcte.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnRepcte.Location = New System.Drawing.Point(28, 218)
        Me.lblnRepcte.Name = "lblnRepcte"
        Me.lblnRepcte.Size = New System.Drawing.Size(176, 23)
        Me.lblnRepcte.TabIndex = 19
        Me.lblnRepcte.Text = "Nombre del Representante"
        Me.lblnRepcte.Visible = False
        '
        'txtnRepcte
        '
        Me.txtnRepcte.Location = New System.Drawing.Point(236, 218)
        Me.txtnRepcte.Name = "txtnRepcte"
        Me.txtnRepcte.Size = New System.Drawing.Size(496, 20)
        Me.txtnRepcte.TabIndex = 18
        Me.txtnRepcte.Visible = False
        '
        'lblPoderRep
        '
        Me.lblPoderRep.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPoderRep.Location = New System.Drawing.Point(28, 434)
        Me.lblPoderRep.Name = "lblPoderRep"
        Me.lblPoderRep.Size = New System.Drawing.Size(232, 16)
        Me.lblPoderRep.TabIndex = 17
        Me.lblPoderRep.Text = "Poderes del Representante del Cliente"
        Me.lblPoderRep.Visible = False
        '
        'lblGenerep
        '
        Me.lblGenerep.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGenerep.Location = New System.Drawing.Point(28, 258)
        Me.lblGenerep.Name = "lblGenerep"
        Me.lblGenerep.Size = New System.Drawing.Size(232, 16)
        Me.lblGenerep.TabIndex = 16
        Me.lblGenerep.Text = "Generales del Representante del Cliente"
        Me.lblGenerep.Visible = False
        '
        'lblGeneCte
        '
        Me.lblGeneCte.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGeneCte.Location = New System.Drawing.Point(28, 42)
        Me.lblGeneCte.Name = "lblGeneCte"
        Me.lblGeneCte.Size = New System.Drawing.Size(232, 16)
        Me.lblGeneCte.TabIndex = 15
        Me.lblGeneCte.Text = "Generales del Cliente"
        '
        'txtPoderRep
        '
        Me.txtPoderRep.AccessibleDescription = "Text box containing the text to write to or text read from a file."
        Me.txtPoderRep.AccessibleName = "File Text TextBox"
        Me.txtPoderRep.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPoderRep.Location = New System.Drawing.Point(28, 464)
        Me.txtPoderRep.Multiline = True
        Me.txtPoderRep.Name = "txtPoderRep"
        Me.txtPoderRep.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPoderRep.Size = New System.Drawing.Size(776, 130)
        Me.txtPoderRep.TabIndex = 14
        Me.txtPoderRep.Visible = False
        '
        'txtGeneRep
        '
        Me.txtGeneRep.AccessibleDescription = "Text box containing the text to write to or text read from a file."
        Me.txtGeneRep.AccessibleName = "File Text TextBox"
        Me.txtGeneRep.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGeneRep.Location = New System.Drawing.Point(28, 288)
        Me.txtGeneRep.Multiline = True
        Me.txtGeneRep.Name = "txtGeneRep"
        Me.txtGeneRep.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGeneRep.Size = New System.Drawing.Size(776, 130)
        Me.txtGeneRep.TabIndex = 13
        Me.txtGeneRep.Visible = False
        '
        'txtGeneCte
        '
        Me.txtGeneCte.AccessibleDescription = "Text box containing the text to write to or text read from a file."
        Me.txtGeneCte.AccessibleName = "File Text TextBox"
        Me.txtGeneCte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGeneCte.Location = New System.Drawing.Point(28, 66)
        Me.txtGeneCte.Multiline = True
        Me.txtGeneCte.Name = "txtGeneCte"
        Me.txtGeneCte.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGeneCte.Size = New System.Drawing.Size(776, 130)
        Me.txtGeneCte.TabIndex = 12
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(576, 24)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(104, 23)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "Guardar Cambios"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblCoac)
        Me.TabPage2.Controls.Add(Me.txtCoac)
        Me.TabPage2.Controls.Add(Me.txtRepCoa)
        Me.TabPage2.Controls.Add(Me.lblRepcoa)
        Me.TabPage2.Controls.Add(Me.lblPoderepc)
        Me.TabPage2.Controls.Add(Me.lblGenerepc)
        Me.TabPage2.Controls.Add(Me.lblGenecoa)
        Me.TabPage2.Controls.Add(Me.txtPoderepc)
        Me.TabPage2.Controls.Add(Me.txtGenerepc)
        Me.TabPage2.Controls.Add(Me.txtGenecoa)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(832, 630)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Coa/Aval"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblCoac
        '
        Me.lblCoac.Location = New System.Drawing.Point(28, 30)
        Me.lblCoac.Name = "lblCoac"
        Me.lblCoac.Size = New System.Drawing.Size(192, 16)
        Me.lblCoac.TabIndex = 23
        Me.lblCoac.Text = "Nombre del Primer Aval"
        Me.lblCoac.Visible = False
        '
        'txtCoac
        '
        Me.txtCoac.Location = New System.Drawing.Point(228, 22)
        Me.txtCoac.Name = "txtCoac"
        Me.txtCoac.Size = New System.Drawing.Size(496, 20)
        Me.txtCoac.TabIndex = 22
        Me.txtCoac.Visible = False
        '
        'txtRepCoa
        '
        Me.txtRepCoa.Location = New System.Drawing.Point(228, 238)
        Me.txtRepCoa.Name = "txtRepCoa"
        Me.txtRepCoa.Size = New System.Drawing.Size(496, 20)
        Me.txtRepCoa.TabIndex = 21
        Me.txtRepCoa.Visible = False
        '
        'lblRepcoa
        '
        Me.lblRepcoa.Location = New System.Drawing.Point(28, 246)
        Me.lblRepcoa.Name = "lblRepcoa"
        Me.lblRepcoa.Size = New System.Drawing.Size(192, 16)
        Me.lblRepcoa.TabIndex = 20
        Me.lblRepcoa.Text = "Representante del Primer Aval"
        Me.lblRepcoa.Visible = False
        '
        'lblPoderepc
        '
        Me.lblPoderepc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPoderepc.Location = New System.Drawing.Point(28, 454)
        Me.lblPoderepc.Name = "lblPoderepc"
        Me.lblPoderepc.Size = New System.Drawing.Size(288, 16)
        Me.lblPoderepc.TabIndex = 19
        Me.lblPoderepc.Text = "Poderes del Representante del Primer Aval"
        Me.lblPoderepc.Visible = False
        '
        'lblGenerepc
        '
        Me.lblGenerepc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGenerepc.Location = New System.Drawing.Point(28, 278)
        Me.lblGenerepc.Name = "lblGenerepc"
        Me.lblGenerepc.Size = New System.Drawing.Size(304, 16)
        Me.lblGenerepc.TabIndex = 18
        Me.lblGenerepc.Text = "Generales del Representante del  Primer Aval"
        Me.lblGenerepc.Visible = False
        '
        'lblGenecoa
        '
        Me.lblGenecoa.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGenecoa.Location = New System.Drawing.Point(28, 62)
        Me.lblGenecoa.Name = "lblGenecoa"
        Me.lblGenecoa.Size = New System.Drawing.Size(232, 16)
        Me.lblGenecoa.TabIndex = 17
        Me.lblGenecoa.Text = "Generales del Primer  Aval"
        '
        'txtPoderepc
        '
        Me.txtPoderepc.AccessibleDescription = "Text box containing the text to write to or text read from a file."
        Me.txtPoderepc.AccessibleName = "File Text TextBox"
        Me.txtPoderepc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPoderepc.Location = New System.Drawing.Point(28, 478)
        Me.txtPoderepc.Multiline = True
        Me.txtPoderepc.Name = "txtPoderepc"
        Me.txtPoderepc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPoderepc.Size = New System.Drawing.Size(776, 130)
        Me.txtPoderepc.TabIndex = 16
        Me.txtPoderepc.Visible = False
        '
        'txtGenerepc
        '
        Me.txtGenerepc.AccessibleDescription = "Text box containing the text to write to or text read from a file."
        Me.txtGenerepc.AccessibleName = "File Text TextBox"
        Me.txtGenerepc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGenerepc.Location = New System.Drawing.Point(28, 302)
        Me.txtGenerepc.Multiline = True
        Me.txtGenerepc.Name = "txtGenerepc"
        Me.txtGenerepc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGenerepc.Size = New System.Drawing.Size(776, 130)
        Me.txtGenerepc.TabIndex = 15
        Me.txtGenerepc.Visible = False
        '
        'txtGenecoa
        '
        Me.txtGenecoa.AccessibleDescription = "Text box containing the text to write to or text read from a file."
        Me.txtGenecoa.AccessibleName = "File Text TextBox"
        Me.txtGenecoa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGenecoa.Location = New System.Drawing.Point(28, 86)
        Me.txtGenecoa.Multiline = True
        Me.txtGenecoa.Name = "txtGenecoa"
        Me.txtGenecoa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGenecoa.Size = New System.Drawing.Size(776, 130)
        Me.txtGenecoa.TabIndex = 14
        Me.txtGenecoa.Visible = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtobl)
        Me.TabPage3.Controls.Add(Me.lblObl)
        Me.TabPage3.Controls.Add(Me.txtRepobl)
        Me.TabPage3.Controls.Add(Me.lblRepobl)
        Me.TabPage3.Controls.Add(Me.lblPodeobli)
        Me.TabPage3.Controls.Add(Me.lblRepobli)
        Me.TabPage3.Controls.Add(Me.lblObli)
        Me.TabPage3.Controls.Add(Me.txtPodeobli)
        Me.TabPage3.Controls.Add(Me.txtRepobli)
        Me.TabPage3.Controls.Add(Me.txtObli)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(832, 630)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "2° Aval  "
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtobl
        '
        Me.txtobl.Location = New System.Drawing.Point(228, 22)
        Me.txtobl.Name = "txtobl"
        Me.txtobl.Size = New System.Drawing.Size(496, 20)
        Me.txtobl.TabIndex = 23
        Me.txtobl.Visible = False
        '
        'lblObl
        '
        Me.lblObl.Location = New System.Drawing.Point(28, 30)
        Me.lblObl.Name = "lblObl"
        Me.lblObl.Size = New System.Drawing.Size(192, 16)
        Me.lblObl.TabIndex = 22
        Me.lblObl.Text = "Nombre del Segundo Aval"
        Me.lblObl.Visible = False
        '
        'txtRepobl
        '
        Me.txtRepobl.Location = New System.Drawing.Point(228, 238)
        Me.txtRepobl.Name = "txtRepobl"
        Me.txtRepobl.Size = New System.Drawing.Size(496, 20)
        Me.txtRepobl.TabIndex = 21
        Me.txtRepobl.Visible = False
        '
        'lblRepobl
        '
        Me.lblRepobl.Location = New System.Drawing.Point(28, 246)
        Me.lblRepobl.Name = "lblRepobl"
        Me.lblRepobl.Size = New System.Drawing.Size(192, 16)
        Me.lblRepobl.TabIndex = 20
        Me.lblRepobl.Text = "Representante del Segundo Aval"
        Me.lblRepobl.Visible = False
        '
        'lblPodeobli
        '
        Me.lblPodeobli.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPodeobli.Location = New System.Drawing.Point(28, 454)
        Me.lblPodeobli.Name = "lblPodeobli"
        Me.lblPodeobli.Size = New System.Drawing.Size(304, 16)
        Me.lblPodeobli.TabIndex = 19
        Me.lblPodeobli.Text = "Poderes  del Representante del Segundo Aval"
        Me.lblPodeobli.Visible = False
        '
        'lblRepobli
        '
        Me.lblRepobli.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRepobli.Location = New System.Drawing.Point(28, 278)
        Me.lblRepobli.Name = "lblRepobli"
        Me.lblRepobli.Size = New System.Drawing.Size(320, 16)
        Me.lblRepobli.TabIndex = 18
        Me.lblRepobli.Text = "Generales del Representante del Segundo Aval"
        Me.lblRepobli.Visible = False
        '
        'lblObli
        '
        Me.lblObli.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObli.Location = New System.Drawing.Point(28, 62)
        Me.lblObli.Name = "lblObli"
        Me.lblObli.Size = New System.Drawing.Size(232, 16)
        Me.lblObli.TabIndex = 17
        Me.lblObli.Text = "Generales del Segundo Aval"
        Me.lblObli.Visible = False
        '
        'txtPodeobli
        '
        Me.txtPodeobli.AccessibleDescription = "Text box containing the text to write to or text read from a file."
        Me.txtPodeobli.AccessibleName = "File Text TextBox"
        Me.txtPodeobli.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPodeobli.Location = New System.Drawing.Point(28, 478)
        Me.txtPodeobli.Multiline = True
        Me.txtPodeobli.Name = "txtPodeobli"
        Me.txtPodeobli.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPodeobli.Size = New System.Drawing.Size(776, 130)
        Me.txtPodeobli.TabIndex = 16
        Me.txtPodeobli.Visible = False
        '
        'txtRepobli
        '
        Me.txtRepobli.AccessibleDescription = "Text box containing the text to write to or text read from a file."
        Me.txtRepobli.AccessibleName = "File Text TextBox"
        Me.txtRepobli.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRepobli.Location = New System.Drawing.Point(28, 302)
        Me.txtRepobli.Multiline = True
        Me.txtRepobli.Name = "txtRepobli"
        Me.txtRepobli.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRepobli.Size = New System.Drawing.Size(776, 130)
        Me.txtRepobli.TabIndex = 15
        Me.txtRepobli.Visible = False
        '
        'txtObli
        '
        Me.txtObli.AccessibleDescription = "Text box containing the text to write to or text read from a file."
        Me.txtObli.AccessibleName = "File Text TextBox"
        Me.txtObli.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObli.Location = New System.Drawing.Point(28, 86)
        Me.txtObli.Multiline = True
        Me.txtObli.Name = "txtObli"
        Me.txtObli.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObli.Size = New System.Drawing.Size(776, 130)
        Me.txtObli.TabIndex = 14
        Me.txtObli.Visible = False
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.txtpava)
        Me.TabPage4.Controls.Add(Me.lblpav)
        Me.TabPage4.Controls.Add(Me.txtRepa1)
        Me.TabPage4.Controls.Add(Me.lblRepa1)
        Me.TabPage4.Controls.Add(Me.lblPodeav1)
        Me.TabPage4.Controls.Add(Me.lblRepav1)
        Me.TabPage4.Controls.Add(Me.lblAval1)
        Me.TabPage4.Controls.Add(Me.txtPodeav1)
        Me.TabPage4.Controls.Add(Me.txtRepav1)
        Me.TabPage4.Controls.Add(Me.txtAval1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(832, 630)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "3° Aval "
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtpava
        '
        Me.txtpava.Location = New System.Drawing.Point(228, 22)
        Me.txtpava.Name = "txtpava"
        Me.txtpava.Size = New System.Drawing.Size(496, 20)
        Me.txtpava.TabIndex = 23
        Me.txtpava.Visible = False
        '
        'lblpav
        '
        Me.lblpav.Location = New System.Drawing.Point(28, 30)
        Me.lblpav.Name = "lblpav"
        Me.lblpav.Size = New System.Drawing.Size(192, 16)
        Me.lblpav.TabIndex = 22
        Me.lblpav.Text = "Nombre del Tercer Aval"
        Me.lblpav.Visible = False
        '
        'txtRepa1
        '
        Me.txtRepa1.Location = New System.Drawing.Point(228, 238)
        Me.txtRepa1.Name = "txtRepa1"
        Me.txtRepa1.Size = New System.Drawing.Size(496, 20)
        Me.txtRepa1.TabIndex = 21
        Me.txtRepa1.Visible = False
        '
        'lblRepa1
        '
        Me.lblRepa1.Location = New System.Drawing.Point(28, 246)
        Me.lblRepa1.Name = "lblRepa1"
        Me.lblRepa1.Size = New System.Drawing.Size(192, 16)
        Me.lblRepa1.TabIndex = 20
        Me.lblRepa1.Text = "Representante del Tercer Aval"
        Me.lblRepa1.Visible = False
        '
        'lblPodeav1
        '
        Me.lblPodeav1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPodeav1.Location = New System.Drawing.Point(28, 454)
        Me.lblPodeav1.Name = "lblPodeav1"
        Me.lblPodeav1.Size = New System.Drawing.Size(288, 16)
        Me.lblPodeav1.TabIndex = 19
        Me.lblPodeav1.Text = "Poderes  del Representante del Tercer Aval"
        Me.lblPodeav1.Visible = False
        '
        'lblRepav1
        '
        Me.lblRepav1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRepav1.Location = New System.Drawing.Point(28, 278)
        Me.lblRepav1.Name = "lblRepav1"
        Me.lblRepav1.Size = New System.Drawing.Size(288, 16)
        Me.lblRepav1.TabIndex = 18
        Me.lblRepav1.Text = "Generales del Representante del Tercer Aval"
        Me.lblRepav1.Visible = False
        '
        'lblAval1
        '
        Me.lblAval1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAval1.Location = New System.Drawing.Point(28, 62)
        Me.lblAval1.Name = "lblAval1"
        Me.lblAval1.Size = New System.Drawing.Size(232, 16)
        Me.lblAval1.TabIndex = 17
        Me.lblAval1.Text = "Generales del Tercer Aval"
        '
        'txtPodeav1
        '
        Me.txtPodeav1.AccessibleDescription = "Text box containing the text to write to or text read from a file."
        Me.txtPodeav1.AccessibleName = "File Text TextBox"
        Me.txtPodeav1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPodeav1.Location = New System.Drawing.Point(28, 478)
        Me.txtPodeav1.Multiline = True
        Me.txtPodeav1.Name = "txtPodeav1"
        Me.txtPodeav1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPodeav1.Size = New System.Drawing.Size(776, 130)
        Me.txtPodeav1.TabIndex = 16
        Me.txtPodeav1.Visible = False
        '
        'txtRepav1
        '
        Me.txtRepav1.AccessibleDescription = "Text box containing the text to write to or text read from a file."
        Me.txtRepav1.AccessibleName = "File Text TextBox"
        Me.txtRepav1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRepav1.Location = New System.Drawing.Point(28, 302)
        Me.txtRepav1.Multiline = True
        Me.txtRepav1.Name = "txtRepav1"
        Me.txtRepav1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRepav1.Size = New System.Drawing.Size(776, 130)
        Me.txtRepav1.TabIndex = 15
        Me.txtRepav1.Visible = False
        '
        'txtAval1
        '
        Me.txtAval1.AccessibleDescription = "Text box containing the text to write to or text read from a file."
        Me.txtAval1.AccessibleName = "File Text TextBox"
        Me.txtAval1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAval1.Location = New System.Drawing.Point(28, 86)
        Me.txtAval1.Multiline = True
        Me.txtAval1.Name = "txtAval1"
        Me.txtAval1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAval1.Size = New System.Drawing.Size(776, 130)
        Me.txtAval1.TabIndex = 14
        Me.txtAval1.Visible = False
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.txtsaval)
        Me.TabPage5.Controls.Add(Me.lblsaval)
        Me.TabPage5.Controls.Add(Me.txtsava)
        Me.TabPage5.Controls.Add(Me.lblRepsav)
        Me.TabPage5.Controls.Add(Me.lblAval2)
        Me.TabPage5.Controls.Add(Me.lblRepav2)
        Me.TabPage5.Controls.Add(Me.lblPodeav2)
        Me.TabPage5.Controls.Add(Me.txtPodeav2)
        Me.TabPage5.Controls.Add(Me.txtRepav2)
        Me.TabPage5.Controls.Add(Me.txtAval2)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(832, 630)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "4° Aval "
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'txtsaval
        '
        Me.txtsaval.Location = New System.Drawing.Point(228, 22)
        Me.txtsaval.Name = "txtsaval"
        Me.txtsaval.Size = New System.Drawing.Size(496, 20)
        Me.txtsaval.TabIndex = 24
        Me.txtsaval.Visible = False
        '
        'lblsaval
        '
        Me.lblsaval.Location = New System.Drawing.Point(28, 30)
        Me.lblsaval.Name = "lblsaval"
        Me.lblsaval.Size = New System.Drawing.Size(192, 16)
        Me.lblsaval.TabIndex = 23
        Me.lblsaval.Text = "Nombre del Cuarto Aval"
        Me.lblsaval.Visible = False
        '
        'txtsava
        '
        Me.txtsava.Location = New System.Drawing.Point(228, 238)
        Me.txtsava.Name = "txtsava"
        Me.txtsava.Size = New System.Drawing.Size(496, 20)
        Me.txtsava.TabIndex = 22
        Me.txtsava.Visible = False
        '
        'lblRepsav
        '
        Me.lblRepsav.Location = New System.Drawing.Point(28, 246)
        Me.lblRepsav.Name = "lblRepsav"
        Me.lblRepsav.Size = New System.Drawing.Size(192, 16)
        Me.lblRepsav.TabIndex = 21
        Me.lblRepsav.Text = "Representante del Cuarto Aval"
        Me.lblRepsav.Visible = False
        '
        'lblAval2
        '
        Me.lblAval2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAval2.Location = New System.Drawing.Point(28, 62)
        Me.lblAval2.Name = "lblAval2"
        Me.lblAval2.Size = New System.Drawing.Size(232, 16)
        Me.lblAval2.TabIndex = 20
        Me.lblAval2.Text = "Generales del Cuarto Aval"
        '
        'lblRepav2
        '
        Me.lblRepav2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRepav2.Location = New System.Drawing.Point(28, 278)
        Me.lblRepav2.Name = "lblRepav2"
        Me.lblRepav2.Size = New System.Drawing.Size(296, 16)
        Me.lblRepav2.TabIndex = 19
        Me.lblRepav2.Text = "Generales del Representante del Cuarto  Aval"
        Me.lblRepav2.Visible = False
        '
        'lblPodeav2
        '
        Me.lblPodeav2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPodeav2.Location = New System.Drawing.Point(28, 454)
        Me.lblPodeav2.Name = "lblPodeav2"
        Me.lblPodeav2.Size = New System.Drawing.Size(304, 16)
        Me.lblPodeav2.TabIndex = 18
        Me.lblPodeav2.Text = "Poderes  del Representante del Cuarto Aval"
        Me.lblPodeav2.Visible = False
        '
        'txtPodeav2
        '
        Me.txtPodeav2.AccessibleDescription = "Text box containing the text to write to or text read from a file."
        Me.txtPodeav2.AccessibleName = "File Text TextBox"
        Me.txtPodeav2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPodeav2.Location = New System.Drawing.Point(28, 478)
        Me.txtPodeav2.Multiline = True
        Me.txtPodeav2.Name = "txtPodeav2"
        Me.txtPodeav2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPodeav2.Size = New System.Drawing.Size(776, 130)
        Me.txtPodeav2.TabIndex = 17
        Me.txtPodeav2.Visible = False
        '
        'txtRepav2
        '
        Me.txtRepav2.AccessibleDescription = "Text box containing the text to write to or text read from a file."
        Me.txtRepav2.AccessibleName = "File Text TextBox"
        Me.txtRepav2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRepav2.Location = New System.Drawing.Point(28, 302)
        Me.txtRepav2.Multiline = True
        Me.txtRepav2.Name = "txtRepav2"
        Me.txtRepav2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRepav2.Size = New System.Drawing.Size(776, 130)
        Me.txtRepav2.TabIndex = 16
        Me.txtRepav2.Visible = False
        '
        'txtAval2
        '
        Me.txtAval2.AccessibleDescription = "Text box containing the text to write to or text read from a file."
        Me.txtAval2.AccessibleName = "File Text TextBox"
        Me.txtAval2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAval2.Location = New System.Drawing.Point(28, 86)
        Me.txtAval2.Multiline = True
        Me.txtAval2.Name = "txtAval2"
        Me.txtAval2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAval2.Size = New System.Drawing.Size(776, 130)
        Me.txtAval2.TabIndex = 15
        Me.txtAval2.Visible = False
        '
        'frmModiPers
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(872, 716)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtCusnam)
        Me.Controls.Add(Me.txtCliente)
        Me.Name = "frmModiPers"
        Me.Text = "Modificar Personalidades"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmModiPers1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daDatosCliente As New SqlDataAdapter(cm1)
        Dim drCliente As DataRow

        Dim cGenCliF As String
        Dim cGenCliM As String
        Dim cGenRep As String
        Dim cPoderM As String

        cGenCliF = "LLAMARSE ___, MANIFIESTA POR SUS GENERALES SER DE NACIONALIDAD ___, "
        cGenCliF = cGenCliF & "ORIGINARIO DE LA CIUDAD DE ___, LUGAR DONDE NACIO EL ___, DE ESTADO "
        cGenCliF = cGenCliF & "CIVIL ___, CON DOMICILIO EN ___, Y CON R.F.C. ___."

        cGenCliM = "A) ES UNA SOCIEDAD LEGALMENTE CONSTITUIDA CONFORME A DERECHO, SEGUN "
        cGenCliM = cGenCliM & "ESCRITURA PUBLICA No. ___ DE FECHA ___ ANTE LA FE DEL LIC. ___ "
        cGenCliM = cGenCliM & "NOTARIO PUBLICO No. ___, DE LA CIUDAD DE ___, E INSCRITA EN EL REGISTRO "
        cGenCliM = cGenCliM & "PUBLICO DEL COMERCIO DE LA CIUDAD DE ___, EN EL LIBRO ___, PARTIDA No. ___, "
        cGenCliM = cGenCliM & "VOLUMEN ___, FOJAS ___, DE FECHA ___."

        cGenRep = "MANIFIESTA POR SUS GENERALES SER DE NACIONALIDAD ___, "
        cGenRep = cGenRep & "ORIGINARIO DE LA CIUDAD DE ___, LUGAR DONDE NACIO EL ___, DE ESTADO CIVIL ___, "
        cGenRep = cGenRep & "CON DOMICILIO EN ___, Y CON R.F.C. ___."

        cPoderM = "CUENTA CON FACULTADES SUFICIENTES PARA OBLIGARLA EN LOS TERMINOS DEL PRESENTE "
        cPoderM = cPoderM & "CONTRATO COMO LO ACREDITA EN LA ESCRITURA PUBLICA No. ___ DE FECHA___, ANTE LA "
        cPoderM = cPoderM & "FE DEL LIC. ___, NOTARIO PUBLICO No. ___, DE LA CIUDAD DE ___, FACULTADES QUE BAJO "
        cPoderM = cPoderM & "PROTESTA DE DECIR VERDAD NO LE HAN SIDO MODIFICADAS NI REVOCADAS A LA FECHA CUYA "
        cPoderM = cPoderM & "INSCRIPCION EN EL REGISTRO PUBLICO DEL COMERCIO SE ENCUENTRA EN EL LIBRO ___, "
        cPoderM = cPoderM & "PARTIDA No. ___, VOLUMEN ___, FOJAS ___, DE FECHA ___."

        TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed

        ' Este Stored Procedure trae todos los atributos de la tabla Clientes,
        ' para un cliente dado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosClie1"
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = txtCliente.Text
            .Connection = cnAgil
        End With

        daDatosCliente.Fill(dsAgil, "Cliente")

        'Extraer los datos necesarios para la captura de los Datos Generales

        drCliente = dsAgil.Tables("Cliente").Rows(0)

        cCoa = drCliente("Coac")
        cObli = drCliente("Obli")
        cAv1 = drCliente("Aval1")
        cAv2 = drCliente("Aval2")
        cTipo = drCliente("Tipo")
        cCusnam = drCliente("Descr")
        txtnRepcte.Text = drCliente("Nomrepr")
        cTipocoa = drCliente("Tipcoac")
        txtCoac.Text = drCliente("Nomcoac")
        txtRepCoa.Text = drCliente("Nomrcoac")
        cTipobli = drCliente("Tipoobli")
        txtobl.Text = drCliente("Nomobli")
        txtRepobl.Text = drCliente("Nomrobl")
        cTipoav1 = drCliente("Tipaval1")
        txtpava.Text = drCliente("Nomaval1")
        txtRepa1.Text = drCliente("Nomrava1")
        cTipoav2 = drCliente("Tipaval2")
        txtsaval.Text = drCliente("Nomaval2")
        txtsava.Text = drCliente("Nomrava2")
        txtGeneCte.Text = drCliente("Geneclie")

        If Trim(drCliente("Geneclie")) <> "" Then
            txtGeneCte.Text = drCliente("Geneclie")
            txtGeneRep.Text = IIf(Trim(drCliente("Generepr")) <> "", drCliente("Generepr"), "")
            txtPoderRep.Text = IIf(Trim(drCliente("Poderepr")) <> "", drCliente("Poderepr"), "")
        ElseIf cTipo = "M" Then
            txtGeneCte.Text = cGenCliM
            txtGeneRep.Text = cGenRep
            txtPoderRep.Text = cPoderM
        ElseIf cTipo = "F" Or cTipo = "E" Then
            txtGeneCte.Text = cGenCliF
        Else
            txtGeneCte.Text = ""
            txtGeneRep.Text = ""
            txtPoderRep.Text = ""
        End If

        If Trim(drCliente("Genecoac")) > "" And (cCoa = "S" Or cCoa = "C") Then
            txtGenecoa.Text = drCliente("Genecoac")
            txtGenerepc.Text = IIf(Trim(drCliente("Genercoa")) <> "", drCliente("Genercoa"), "")
            txtPoderepc.Text = IIf(Trim(drCliente("Podercoa")) <> "", drCliente("Podercoa"), "")
        ElseIf cTipocoa = "M" Then
            txtGenecoa.Text = cGenCliM
            txtGenerepc.Text = cGenRep
            txtPoderepc.Text = cPoderM
        ElseIf cTipocoa = "F" Or cTipocoa = "E" Then
            txtGenecoa.Text = cGenCliF
        Else
            txtGenecoa.Text = ""
            txtGenerepc.Text = ""
            txtPoderepc.Text = ""
        End If

        If Trim(drCliente("GeneObli")) > "" And cObli = "S" Then
            txtObli.Text = drCliente("GeneObli")
            txtRepobli.Text = IIf(Trim(drCliente("Generobl")) <> "", drCliente("Generobl"), "")
            txtPodeobli.Text = IIf(Trim(drCliente("Poderobl")) <> "", drCliente("Poderobl"), "")
        ElseIf cTipobli = "M" Then
            txtObli.Text = cGenCliM
            txtRepobli.Text = cGenRep
            txtPodeobli.Text = cPoderM
        ElseIf cTipobli = "E" Or cTipobli = "F" Then
            txtObli.Text = cGenCliF
        Else
            txtObli.Text = ""
            txtRepobli.Text = ""
            txtPodeobli.Text = ""
        End If

        If Trim(drCliente("GeneAva1")) > "" And cAv1 = "S" Then
            txtAval1.Text = drCliente("GeneAva1")
            txtRepav1.Text = IIf(Trim(drCliente("Generav1")) <> "", drCliente("Generav1"), "")
            txtPodeav1.Text = IIf(Trim(drCliente("Poderav1")) <> "", drCliente("Poderav1"), "")
        ElseIf cTipoav1 = "M" Then
            txtAval1.Text = cGenCliM
            txtRepav1.Text = cGenRep
            txtPodeav1.Text = cPoderM
        ElseIf cTipoav1 = "F" Or cTipoav1 = "E" Then
            txtAval1.Text = cGenCliF
        Else
            txtAval1.Text = ""
            txtRepav1.Text = ""
            txtPodeav1.Text = ""
        End If

        If Trim(drCliente("GeneAva2")) > "" And cAv2 = "S" Then
            txtAval2.Text = drCliente("GeneAva2")
            txtRepav2.Text = IIf(Trim(drCliente("Generav2")) <> "", drCliente("Generav2"), "")
            txtPodeav2.Text = IIf(Trim(drCliente("Poderav2")) <> "", drCliente("Poderav2"), "")
        ElseIf cTipoav2 = "M" Then
            txtAval2.Text = cGenCliM
            txtRepav2.Text = cGenRep
            txtPodeav2.Text = cPoderM
        ElseIf cTipoav2 = "F" Or cTipoav2 = "E" Then
            txtAval2.Text = cGenCliF
        Else
            txtAval2.Text = ""
            txtRepav2.Text = ""
            txtPodeav2.Text = ""
        End If

        If cTipo = "M" Then
            lblnRepcte.Visible = True
            txtnRepcte.Visible = True
            lblGenerep.Visible = True
            txtGeneRep.Visible = True
            lblPoderRep.Visible = True
            txtPoderRep.Visible = True
        End If

        If cTipocoa = "M" Then
            lblGenerepc.Visible = True
            txtGenerepc.Visible = True
            lblRepcoa.Visible = True
            txtRepCoa.Visible = True
            lblPoderepc.Visible = True
            txtPoderepc.Visible = True
        End If

        If cTipobli = "M" Then
            lblRepobli.Visible = True
            txtRepobli.Visible = True
            lblRepobl.Visible = True
            txtRepobl.Visible = True
            lblPodeobli.Visible = True
            txtPodeobli.Visible = True
        End If

        If cTipoav1 = "M" Then
            lblRepav1.Visible = True
            txtRepav1.Visible = True
            lblRepa1.Visible = True
            txtRepa1.Visible = True
            lblPodeav1.Visible = True
            txtPodeav1.Visible = True
        End If

        If cTipoav2 = "M" Then
            lblRepav2.Visible = True
            txtRepav2.Visible = True
            lblRepsav.Visible = True
            txtsava.Visible = True
            lblPodeav2.Visible = True
            txtPodeav2.Visible = True
        End If

        With TabControl1.TabPages
            .Clear()
            .Add(TabPage1)
            .Add(TabPage2)
            .Add(TabPage3)
            .Add(TabPage4)
            .Add(TabPage5)
        End With

        If cCoa = "N" And cObli = "N" And cAv1 = "N" And cAv2 = "N" Then
            TabControl1.DisablePage(TabPage5)
            TabControl1.DisablePage(TabPage4)
            TabControl1.DisablePage(TabPage3)
            TabControl1.DisablePage(TabPage2)
        ElseIf (cCoa = "S" Or cCoa = "C") And cObli = "S" And cAv1 = "S" And cAv2 = "N" Then
            TabControl1.DisablePage(TabPage5)
        ElseIf (cCoa = "S" Or cCoa = "C") And cObli = "S" And cAv1 = "N" And cAv2 = "N" Then
            TabControl1.DisablePage(TabPage5)
            TabControl1.DisablePage(TabPage4)
        ElseIf (cCoa = "S" Or cCoa = "C") And cObli = "N" And cAv1 = "S" And cAv2 = "S" Then
            TabControl1.DisablePage(TabPage3)
        ElseIf (cCoa = "S" Or cCoa = "C") And cObli = "N" And cAv1 = "S" And cAv2 = "N" Then
            TabControl1.DisablePage(TabPage5)
            TabControl1.DisablePage(TabPage3)
        ElseIf (cCoa = "S" Or cCoa = "C") And cObli = "N" And cAv1 = "N" And cAv2 = "N" Then
            TabControl1.DisablePage(TabPage5)
            TabControl1.DisablePage(TabPage4)
            TabControl1.DisablePage(TabPage3)
        ElseIf cCoa = "N" And cObli = "S" And cAv1 = "S" And cAv2 = "S" Then
            TabControl1.DisablePage(TabPage2)
        ElseIf cCoa = "N" And cObli = "S" And cAv1 = "S" And cAv2 = "N" Then
            TabControl1.DisablePage(TabPage5)
            TabControl1.DisablePage(TabPage2)
        ElseIf cCoa = "N" And cObli = "N" And cAv1 = "S" And cAv2 = "S" Then
            TabControl1.DisablePage(TabPage3)
            TabControl1.DisablePage(TabPage2)
        ElseIf cCoa = "N" And cObli = "S" And cAv1 = "N" And cAv2 = "N" Then
            TabControl1.DisablePage(TabPage5)
            TabControl1.DisablePage(TabPage4)
            TabControl1.DisablePage(TabPage2)
        ElseIf cCoa = "N" And cObli = "N" And cAv1 = "S" And cAv2 = "N" Then
            TabControl1.DisablePage(TabPage5)
            TabControl1.DisablePage(TabPage3)
            TabControl1.DisablePage(TabPage2)
        End If
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        lblNombre.Text = "Cliente"
        txtCusnam.Text = cCusnam

        Select Case TabControl1.SelectedIndex
            Case 1
                If (cCoa = "S" Or cCoa = "C") Then
                    lblGenecoa.Visible = True
                    lblCoac.Visible = True
                    txtCoac.Visible = True
                    txtGenecoa.Visible = True
                End If
            Case 2
                If cObli = "S" Then
                    lblObli.Visible = True
                    lblObl.Visible = True
                    txtobl.Visible = True
                    txtObli.Visible = True
                End If
            Case 3
                If cAv1 = "S" Then
                    lblAval1.Visible = True
                    lblpav.Visible = True
                    txtpava.Visible = True
                    txtAval1.Visible = True
                End If
            Case 4
                If cAv2 = "S" Then
                    lblAval2.Visible = True
                    lblsaval.Visible = True
                    txtsaval.Visible = True
                    txtAval2.Visible = True
                End If
        End Select

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim strActualiza As String
        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()

        Try
            cnAgil.Open()
            strActualiza = "UPDATE Clientes SET Geneclie = " & "'" & txtGeneCte.Text & "'," & _
                                                            " Nomrepr = " & "'" & txtnRepcte.Text & "'," & _
                                                            " Generepr = " & "'" & txtGeneRep.Text & "'," & _
                                                            " Poderepr = " & "'" & txtPoderRep.Text & "'," & _
                                                            " Nomcoac = " & "'" & txtCoac.Text & "'," & _
                                                            " Genecoac = " & "'" & txtGenecoa.Text & "'," & _
                                                            " Nomrcoac = " & "'" & txtRepCoa.Text & "'," & _
                                                            " Genercoa = " & "'" & txtGenerepc.Text & "'," & _
                                                            " Podercoa = " & "'" & txtPoderepc.Text & "'," & _
                                                            " Nomobli = " & "'" & txtobl.Text & "'," & _
                                                            " GeneObli = " & "'" & txtObli.Text & "'," & _
                                                            " Nomrobl = " & "'" & txtRepobl.Text & "'," & _
                                                            " Generobl = " & "'" & txtRepobli.Text & "'," & _
                                                            " Poderobl = " & "'" & txtPodeobli.Text & "'," & _
                                                            " Nomaval1 = " & "'" & txtpava.Text & "'," & _
                                                            " GeneAva1 = " & "'" & txtAval1.Text & "'," & _
                                                            " Nomrava1 = " & "'" & txtRepa1.Text & "'," & _
                                                            " Generav1 = " & "'" & txtRepav1.Text & "'," & _
                                                            " Poderav1 = " & "'" & txtPodeav1.Text & "'," & _
                                                            " Nomaval2 = " & "'" & txtsaval.Text & "'," & _
                                                            " GeneAva2 = " & "'" & txtAval2.Text & "'," & _
                                                            " Nomrava2 = " & "'" & txtsava.Text & "'," & _
                                                            " Generav2 = " & "'" & txtRepav2.Text & "'," & _
                                                            " Poderav2 = " & "'" & txtPodeav2.Text & "'" & _
                                                            "WHERE Cliente = " & "'" & txtCliente.Text & "'"
            cm1 = New SqlCommand(strActualiza, cnAgil)
            cm1.ExecuteNonQuery()
            cnAgil.Close()
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de error")
        End Try

        cnAgil.Dispose()
        cm1.Dispose()

        btnGuardar.Enabled = False
        btnSalir.Enabled = True

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
