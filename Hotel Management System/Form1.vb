Imports System.Data.SqlClient
Public Class Form1
    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kunal\source\repos\Hotel Management System\Hotel Management System\hotel_db.mdf;Integrated Security=True")

        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("insert into users values ('" & rid.Text & "', '" & nm.Text & "', '" & ComboBox1.Text & "', '" & mob_no.Text & "', '" & DateTimePicker1.Text & "', '" & DateTimePicker2.Text & "')", con)
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Data inserted")
        bindData()
    End Sub

    Private Sub bindData()
        Dim ds As New DataSet
        ds.Clear()
        Dim con As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kunal\source\repos\Hotel Management System\Hotel Management System\hotel_db.mdf;Integrated Security=True")

        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("select * from users", con)
        Dim sda As New SqlDataAdapter(cmd)
        sda.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Dim query As String = "update users set cust_name = '" & nm.Text & "', cust_city = '" & ComboBox1.Text & "',cust_no = '" & mob_no.Text & "', check_in = '" & DateTimePicker1.Text & "', check_out = '" & DateTimePicker2.Text & "' where room_id = '" & rid.Text & "'"
        Dim con As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kunal\source\repos\Hotel Management System\Hotel Management System\hotel_db.mdf;Integrated Security=True")
        Dim cmd As SqlCommand = New SqlCommand(query, con)

        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Updated Successfully")
        bindData()
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        Dim query As String = "delete from users where room_id = '" & rid.Text & "'"
        Dim con As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kunal\source\repos\Hotel Management System\Hotel Management System\hotel_db.mdf;Integrated Security=True")

        con.Open()
        Dim cmd As New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Deleted Successfully")
        bindData()
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim query As String = "select * from users where room_id = '" & rid.Text & "'"
        Dim con As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kunal\source\repos\Hotel Management System\Hotel Management System\hotel_db.mdf;Integrated Security=True")
        Dim cmd As SqlCommand = New SqlCommand(query, con)

        Dim sda As New SqlDataAdapter()
        sda.SelectCommand = cmd

        Dim dt As New DataTable()
        sda.Fill(dt)
        If dt.Rows.Count > 0 Then
            nm.Text = dt.Rows(0)(1).ToString()
            ComboBox1.Text = dt.Rows(0)(2).ToString()
            mob_no.Text = dt.Rows(0)(3).ToString()
            DateTimePicker1.Text = dt.Rows(0)(4).ToString()
            DateTimePicker2.Text = dt.Rows(0)(5).ToString()
        End If
        bindData()
    End Sub
End Class
