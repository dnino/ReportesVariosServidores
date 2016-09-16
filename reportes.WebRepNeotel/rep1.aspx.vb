Imports System.Web.Services
Imports reportes.Entities
Imports reportes.BusinessLogic
Imports System.IO


Public Class rep1
    Inherits System.Web.UI.Page
    Dim dtServidor As New DataTable
    Dim bl As New BL
    Dim oConfig As New System.Configuration.AppSettingsReader()
    Dim nomSesion As String = "rep1"
    Dim ProcedureRep As String = "ProcedureRep1"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                ltMsg.Text = String.Empty
                dtServidor = Session("tablaServidor")
                With ckbListaServidore
                    .DataSource = dtServidor
                    .DataTextField = "SERVIDOR"
                    .DataValueField = "DataSource"
                    .DataBind()
                End With
                txtFecIni.Text = Now.ToString("yyyy-MM-dd")
                txtFecFin.Text = Now.ToString("yyyy-MM-dd")
                For fila = 0 To ckbListaServidore.Items.Count - 1
                    ckbListaServidore.Items(fila).Selected = True
                Next
                txtLimitacion.Text = oConfig.GetValue("limitacion", GetType(System.String)).ToString()
                grvReporte.PageSize = oConfig.GetValue("paginacion", GetType(System.String)).ToString()
            Catch ex As Exception
                Mensaje(ex.Message, "Red")
            End Try
        End If
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ltMsg.Text = String.Empty
        Try
            Session(nomSesion) = New DataTable
            Dim dtObtieneDatos As New DataTable
            Dim dtReporte As New DataTable
            Dim dtServidor As New DataTable
            dtServidor = Session("tablaServidor")

            Dim recorrido As Integer = 0

            For fila = 0 To ckbListaServidore.Items.Count - 1
                If ckbListaServidore.Items(fila).Selected = True Then
                    Dim be As New NEOTEL
                    be.INICIO = txtFecIni.Text
                    be.TERMINO = txtFecFin.Text
                    be.INSTANCIA = dtServidor.Rows(fila)("DataSource").ToString
                    be.USUARIO_SQL = dtServidor.Rows(fila)("ususql").ToString
                    be.PWD_SQL = dtServidor.Rows(fila)("pwdsql").ToString
                    be.PROCEDIMIENTO = dtServidor.Rows(fila)(ProcedureRep).ToString
                    dtObtieneDatos = bl.selectReporteDt(be)

                    If recorrido = 0 Then
                        For column = 0 To dtObtieneDatos.Columns.Count - 1
                            Dim tipo As String = dtObtieneDatos.Columns(column).DataType.FullName
                            dtReporte.Columns.Add(dtObtieneDatos.Columns(column).ColumnName.ToString, Type.GetType(tipo))
                        Next
                        dtReporte.Columns.Add("SERVIDOR_NEO", Type.GetType("System.String"))
                    End If

                    For rows = 0 To dtObtieneDatos.Rows.Count - 1
                        Dim dr As DataRow = dtReporte.NewRow
                        For cols = 0 To dtObtieneDatos.Columns.Count - 1
                            dr(cols) = dtObtieneDatos.Rows(rows)(cols).ToString
                        Next
                        dr(dtObtieneDatos.Columns.Count) = dtServidor.Rows(fila)("SERVIDOR").ToString

                        dtReporte.Rows.InsertAt(dr, dtReporte.Rows.Count)
                    Next
                    recorrido += 1
                End If
            Next
            If dtReporte.Rows.Count > 0 Then
                Session(nomSesion) = dtReporte
                btnExportar.Visible = True
                btnExportarCsv.Visible = True
                txtLimitacion.Visible = True
                Mensaje("Cantidad de filas " & dtReporte.Rows.Count, "Blue")
            Else
                btnExportar.Visible = False
                btnExportarCsv.Visible = False
                txtLimitacion.Visible = False
                Mensaje("No se encontro datos con parametro de busqueda", "Red")
            End If
            mostrarDatos()
        Catch ex As Exception
            Mensaje(ex.Message, "Red")
        End Try
    End Sub
    Sub mostrarDatos()
        Dim dtReporte As New DataTable
        dtReporte = Session(nomSesion)
        grvReporte.DataSource = dtReporte
        grvReporte.DataBind()
    End Sub
    Private Sub grvReporte_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grvReporte.PageIndexChanging
        ltMsg.Text = String.Empty
        Try
            grvReporte.PageIndex = e.NewPageIndex
            mostrarDatos()
        Catch ex As Exception
            Mensaje(ex.Message, "Red")
        End Try
    End Sub
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ltMsg.Text = ""
        Dim msg As String = ""
        Dim dt As New DataTable
        dt = Session(nomSesion)

        If bl.ExportarDatatable(dt, msg) Then
            abrir(msg)
        Else
            Mensaje(msg, "Red")
        End If
    End Sub
    Private Sub btnExportarCsv_Click(sender As Object, e As EventArgs) Handles btnExportarCsv.Click
        ltMsg.Text = ""
        Dim dt As New DataTable
        dt = Session(nomSesion)
        Dim limitacion As String = txtLimitacion.Text
        If Not limitacion.Trim.Length.Equals(1) Then
            Mensaje("La limitacion debe tener logintud de 1", "Red")
            Exit Sub
        End If
        ExportCSV(limitacion, dt)
    End Sub
    Sub abrir(ruta)
        Response.Clear()
        Response.ContentType = "application/xlsx"
        Response.AddHeader("Content-disposition", "attachment; filename=" & ruta)
        Response.WriteFile(ruta)
        Response.Flush()
        Response.Close()
    End Sub
    Protected Sub ExportCSV(delimitacion As String, dt As DataTable)

        Dim csv As String = String.Empty

        For Each column As DataColumn In dt.Columns
            csv += column.ColumnName + delimitacion
        Next
        csv += vbCr & vbLf

        For Each row As DataRow In dt.Rows
            For Each column As DataColumn In dt.Columns
                csv += row(column.ColumnName).ToString().Replace(delimitacion, ".") + delimitacion
            Next
            csv += vbCr & vbLf
        Next

        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=Reporte.csv")
        Response.Charset = ""
        Response.ContentType = "application/text"
        Response.Output.Write(csv)
        Response.Flush()
        Response.End()

    End Sub

    Sub Mensaje(Texto As String, Color As String)
        ltMsg.Text = String.Format("<FONT COLOR='{0}'>{1}</FONT><br />", Color, Texto)
    End Sub
 
End Class