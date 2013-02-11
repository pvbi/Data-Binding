''' <summary>
''' Form Utama
''' </summary>
''' <remarks>Form Utama</remarks>
Public Class Form1

    Dim kontak As New CContacts
    Dim data As New DataTable

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' isi data
        kontak.Fill(data)
        ' binding ke grid
        DataGridView1.DataSource = data
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ' pastikan perubahan data yang dilakukan user melalui 
        ' user interface sudah dipindahkan ke dataset 
        Me.BindingContext(data).EndCurrentEdit()
        ' simpan perubahan data di dataset ke database
        Me.kontak.Update(data)
        ' update sukses, terima perubahan di dataset  
        data.AcceptChanges()
        ' ambil ulang data dari database (refresh kolom ID)
        kontak.Fill(data)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        ' pastikan perubahan data yang dilakukan user melalui 
        ' user interface *tidak* dipindahkan ke dataset 
        Me.BindingContext(data).CancelCurrentEdit()
        ' batalkan semua perubahan di dataset  
        data.RejectChanges()
    End Sub
End Class
