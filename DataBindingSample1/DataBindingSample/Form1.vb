Public Class Form1

    ''' <summary>
    ''' form load event handler
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            ' load database ke dataset
            ' data otomatis tampil di semua control yang bind ke DsSample1 
            Me.CompaniesTableAdapter1.Fill(Me.DsSample1.Companies)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Button1_Click untuk menangani add new data
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            ' tambah row baru ke dataset
            Me.BindingContext(Me.DsSample1, "Companies").AddNew()
            ' pindahkan cursor ke textbox pertama
            Me.TextBox1.Focus()
        Catch ex As Exception
            ' inform user
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Button2_Click untuk menyimpan data ke database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        ' validasi data
        If String.IsNullOrEmpty(TextBox1.Text) _
            Or String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("Company Code dan Company Name HARUS terisi", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Try
            ' simpan perubahan di control ke dataset
            Me.BindingContext(Me.DsSample1, "Companies").EndCurrentEdit()
            ' simpan perubahan di dataset ke database
            Me.CompaniesTableAdapter1.Update(Me.DsSample1.Companies)
            ' commit perubahan di dataset
            Me.DsSample1.AcceptChanges()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Button3_Click menangani proses hapus data
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim res As DialogResult
        Dim company, message As String
        Dim position As Integer
        Try
            ' tentukan message konfirmasi
            company = DataGridView1.CurrentRow.Cells("CompanyNameDataGridViewTextBoxColumn").Value
            message = "Hapus data perusahaan ini [" & company & "] ?"
            ' tanyakan konfirmasi user
            res = MessageBox.Show(message, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            ' hapus jika user setuju
            If res = Windows.Forms.DialogResult.Yes Then
                ' hapus data pada posisi cursor di dataset
                position = Me.BindingContext(Me.DsSample1, "Companies").Position
                Me.BindingContext(Me.DsSample1, "Companies").RemoveAt(position)
                ' simpan perubahan di dataset ke database
                Me.CompaniesTableAdapter1.Update(Me.DsSample1.Companies)
                ' commit perubahan di dataset
                Me.DsSample1.AcceptChanges()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' handle cancel add new row
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Try
            ' batalkan perubahan di control ke dataset
            Me.BindingContext(Me.DsSample1, "Companies").CancelCurrentEdit()
            ' batalkan perubahan di dataset
            Me.DsSample1.RejectChanges()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
