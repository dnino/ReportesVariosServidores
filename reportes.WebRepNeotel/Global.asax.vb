Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al iniciar la aplicación
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al iniciar la sesión
        Dim dtServidores As New DataTable
        dtServidores.Columns.Add("SERVIDOR", Type.GetType("System.String"))
        dtServidores.Columns.Add("DataSource", Type.GetType("System.String"))
        dtServidores.Columns.Add("ususql", Type.GetType("System.String"))
        dtServidores.Columns.Add("pwdsql", Type.GetType("System.String"))

        dtServidores.Columns.Add("ProcedureRep1", Type.GetType("System.String"))
        dtServidores.Columns.Add("ProcedureRep2", Type.GetType("System.String"))
        dtServidores.Columns.Add("ProcedureRep3", Type.GetType("System.String"))
        dtServidores.Columns.Add("ProcedureRep4", Type.GetType("System.String"))

        Session("tablaServidor") = dtServidores
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al comienzo de cada solicitud
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al intentar autenticar el uso
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando se produce un error
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la sesión
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la aplicación
    End Sub

End Class