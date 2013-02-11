Imports System.Data.SqlServerCe

''' <summary>
''' Data Access Layer ke table Contacts
''' </summary>
''' <remarks>Data Access Layer ke table Contacts, implements IDataAccess</remarks>
Public Class CContacts
    Implements IDataAccess

    Private QueryString = "SELECT * FROM Contacts"

    Function Fill(ByRef dt As DataTable) As Integer Implements IDataAccess.Fill
        Try
            dt.Clear()
            dt.Merge(Me.GetData())
        Catch ex As Exception
            Throw New ApplicationException("Exception Occured: " & ex.Message)
        End Try
        Return dt.Rows.Count
    End Function

    Function GetData() As DataTable Implements IDataAccess.GetData
        Dim dt As New DataTable
        Try
            Dim cn As New SqlCeConnection(My.MySettings.Default.dbAksesConnectionString)
            Dim da As New SqlCeDataAdapter(QueryString, cn)
            dt.TableName = "Contacts"
            dt.Clear()
            da.Fill(dt)
        Catch ex As Exception
            Throw New ApplicationException("Exception Occured: " & ex.Message)
        End Try
        Return dt
    End Function

    Function Update(ByRef dt As DataTable) As Integer Implements IDataAccess.Update
        Try
            Dim cn As New SqlCeConnection(My.MySettings.Default.dbAksesConnectionString)
            Dim da As New SqlCeDataAdapter(QueryString, cn)
            Dim cb As New SqlCeCommandBuilder(da)
            da.Update(dt)
        Catch ex As Exception
            Throw New ApplicationException("Exception Occured: " & ex.Message)
        End Try
        Return dt.Rows.Count
    End Function

End Class
