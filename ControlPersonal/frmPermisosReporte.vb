Imports Reglas

Public Class frmPermisosReporte

    Public Property tipoPermiso As String
    Private Sub frmPermisosReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim rn As New RNPermiso
        Dim ds As New DataSet1
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local

        ReportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Report3.rdlc"
        ReportViewer1.LocalReport.DataSources.Clear()


        Dim dt As DataTable = rn.llenarReporte(tipoPermiso)   ' Get the table from your storage

        'Dim dsOld = dt.DataSet        ' Retrieve the DataSet where the table has been originally added
        'If dsOld IsNot Nothing Then
        '    dsOld.Tables.Remove(dt.TableName)  ' Remove the table from its dataset tables collection
        'End If
        'ds.Tables.Add(dt)  ' Add to the destination dataset.
        'MsgBox(ds.Tables.Count)

        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
        ReportViewer1.DocumentMapCollapsed = True

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class