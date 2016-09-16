Imports reportes.DataAccess
Imports reportes.Entities
Partial Public Class BL
    Dim daNeotel As New DANEOTEL

   
    Public Function selectReporteDt(be As NEOTEL) As DataTable
        Return daNeotel.selectReporteDt(be)
    End Function
End Class
