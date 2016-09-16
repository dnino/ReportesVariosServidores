Imports Excel = Microsoft.Office.Interop.Excel

Partial Public Class BL
    Function ExportarDatatable(_Dt As DataTable, ByRef _Msg As String) As Boolean
        Try
            Dim _excel As New Microsoft.Office.Interop.Excel.Application
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

            wBook = _excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            Dim dt As System.Data.DataTable = _Dt
            Dim dc As System.Data.DataColumn
            Dim dr As System.Data.DataRow
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0

            For Each dc In dt.Columns
                colIndex = colIndex + 1
                _excel.Cells(1, colIndex) = dc.ColumnName
            Next

            For Each dr In dt.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    _excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                Next
            Next

            wSheet.Columns.AutoFit()
            Dim rutaArchivo As String = My.Computer.FileSystem.SpecialDirectories.Temp
            Dim nombreArchivo As String = "Rep" & Now.ToString("yyyyMMddHHmmss")
            Dim strFileName As String = String.Format("{0}\{1}.xlsx", rutaArchivo, nombreArchivo)
            _Msg = strFileName
            If System.IO.File.Exists(strFileName) Then
                System.IO.File.Delete(strFileName)
            End If

            wBook.SaveAs(strFileName)
            wBook.Close()
            _excel.Quit()
            Return True
        Catch ex As Exception
            _Msg = ex.Message
            Return False
        End Try

    End Function

End Class
