Public Class Site1
    Inherits System.Web.UI.MasterPage
    Dim oConfig As New System.Configuration.AppSettingsReader()
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Not IsPostBack Then
            ListaServidores()
        Else
            Dim dt As DataTable = Session("tablaServidor")
            If dt.Rows.Count = 0 Then
                ListaServidores()
            End If
        End If

        
    End Sub
    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If IsNothing(Session("tablaServidor")) Then
                ListaServidores()
            End If
        End If
    End Sub
    Sub ListaServidores()
        Dim dtServidores As New DataTable
        dtServidores = Session("tablaServidor")

        If dtServidores.Rows.Count > 0 Then Exit Sub

        Dim Servidores As String = oConfig.GetValue("Servidores", GetType(System.String)).ToString()
        Dim Split() As String = Servidores.Split("|")
        For i = 0 To Split.Length - 1
            Dim dr As DataRow = dtServidores.NewRow
            dr(0) = Split(i)
            dtServidores.Rows.InsertAt(dr, dtServidores.Rows.Count)
        Next

        Dim reporte1 As String = oConfig.GetValue("ProcedureRep1", GetType(System.String)).ToString()
        Dim Splitr1() As String = reporte1.Split("|")

        Dim reporte2 As String = oConfig.GetValue("ProcedureRep2", GetType(System.String)).ToString()
        Dim Splitr2() As String = reporte2.Split("|")

        Dim reporte3 As String = oConfig.GetValue("ProcedureRep3", GetType(System.String)).ToString()
        Dim Splitr3() As String = reporte3.Split("|")

        Dim reporte4 As String = oConfig.GetValue("ProcedureRep4", GetType(System.String)).ToString()
        Dim Splitr4() As String = reporte4.Split("|")

        Dim DataSource As String = oConfig.GetValue("DataSource", GetType(System.String)).ToString()
        Dim SplitDataSource() As String = DataSource.Split("|")

        Dim ususql As String = oConfig.GetValue("ususql", GetType(System.String)).ToString()
        Dim Splitususql() As String = ususql.Split("|")

        Dim pwdsql As String = oConfig.GetValue("pwdsql", GetType(System.String)).ToString()
        Dim Splitpwdsql() As String = pwdsql.Split("|")

   

        For i = 0 To dtServidores.Rows.Count - 1

            dtServidores.Rows(i)("DataSource") = SplitDataSource(i)
            dtServidores.Rows(i)("ususql") = Splitususql(i)
            dtServidores.Rows(i)("pwdsql") = Splitpwdsql(i)

            dtServidores.Rows(i)("ProcedureRep1") = Splitr1(i)
            dtServidores.Rows(i)("ProcedureRep2") = Splitr2(i)
            dtServidores.Rows(i)("ProcedureRep3") = Splitr3(i)
            dtServidores.Rows(i)("ProcedureRep4") = Splitr4(i)
            
        Next
        Session("tablaServidor") = dtServidores
    End Sub

    
End Class