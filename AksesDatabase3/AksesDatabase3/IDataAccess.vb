Imports System.Data

''' <summary>
''' Interface IDataAccess
''' </summary>
''' <remarks>Untuk keseragaman metode akses data</remarks>
Public Interface IDataAccess
    Function GetData() As DataTable
    Function Fill(ByRef dt As DataTable) As Integer
    Function Update(ByRef dt As DataTable) As Integer
End Interface
