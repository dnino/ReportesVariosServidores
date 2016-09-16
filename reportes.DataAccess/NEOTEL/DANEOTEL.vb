Imports System.Data.SqlClient
Imports reportes.Entities
Public Class DANEOTEL



    Public Function selectReporteDt(be As NEOTEL) As DataTable

        Dim dt As New DataTable
        Dim sqlCon As String = String.Format("Data Source={0};Initial Catalog=master;uid={1}; pwd={2};", be.INSTANCIA, be.USUARIO_SQL, be.PWD_SQL)
        Using cn As New SqlConnection(sqlCon)
            Try
                Dim cmd As New SqlCommand(be.PROCEDIMIENTO, cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandTimeout = 1000
                cmd.Parameters.Add("@INICIO", SqlDbType.Date).Value = be.INICIO
                cmd.Parameters.Add("@TERMINO", SqlDbType.Date).Value = be.TERMINO
                Dim da As New SqlDataAdapter(cmd)
                cn.Open()
                da.Fill(dt)
            Catch ex As Exception
                be.errores = ex.Message
            Finally
                cn.Close()
            End Try
        End Using
        Return dt

    End Function
End Class
