Imports System.Data.OleDb
Public Class _Default

    Inherits Page
    Public odConnection As OleDbConnection = New OleDbConnection()

    Private Function Accsu(ByVal b As String, ByVal l As String, ByVal n As String， ByVal cl As String) As String
        Dim z As String
        '定义一个OLEDB连接并实例化它
        Dim con As New OleDbConnection
        '定义一个OLEDB命令并实例化他
        Dim cmd As New OleDbCommand
        '定义一个OLEDBReader方法来读取数据库
        Dim dr As OleDbDataReader
        '初始化con的连接属性，使用OLEDB模式，数据源为：你指定下路径，我的是在D盘
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\text\db\db.mdb"
        '打开OLEDB数据连接
        con.Open()
        '初始化OLEDB命令的连接属性为con,这个需要你理解下
        cmd.Connection = con
        '初始化OLEDB命令的语句 就是查询 什么字段从什么表 条件是ID等于你在t1中输入的内容
        cmd.CommandText = "select " & l & " from " & b & " where " & cl & "='" & n & "'"
        '执行OLEDB命令以ExecuteReader()方式，并返回一个OLEDBReader，赋值给dr
        dr = cmd.ExecuteReader()
        '判断下dr中是否有数据。如果有就把第一个值赋值给t2的值
        If dr.Read() Then
            z = dr(0)
            Accsu = z
        Else
            Response.Write("<Script Language=JavaScript>alert('未找到用户');</Script>")
            Accsu = ";"
        End If
        dr.Close()
        con.Close()
        '函数Accsu说明：b为查询的表，l为输出的列，n为查询列的值,cl为查询的列
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.TextBox1.Text = Nothing Or Me.TextBox1.Text = Nothing Then
            Response.Write("<script type='text/javascript'>alert('禁止，请输入姓名学号！')</script>")
        Else
            If Accsu("nam", "up", Me.TextBox1.Text, "nam") = "0" Then
                Try
                    If IsPostBack Then
                        Dim Pfile As HttpPostedFile = Nothing
                        For i = 0 To Request.Files.Count - 1
                            If Request.Files.Count > 0 Then
                                '获取上传的文件对象
                                Pfile = Request.Files(i)
                                '获取上传的文件完全限定名称(及包括后缀名)
                                Dim filename As String = Pfile.FileName
                                Dim xC As String = filename
                                xC = Strings.Right(xC, 3)
                                '获取上传文件的大小
                                Dim size As Int32 = Pfile.ContentLength
                                '设置存储路径
                                Dim path As String = "C:\text\image\"
                                '上传文件
                                If xC = "jpg" Or xC = "png" Or xC = "JPG" Or xC = "PNG" Then
                                    Pfile.SaveAs(path & TextBox2.Text & TextBox1.Text & filename)
                                    'write db
                                    odConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\text\db\db.mdb"
                                    odConnection.Open()
                                    Dim str As New System.Text.StringBuilder
                                    str.Append("UPDATE nam SET nam.up = '1' WHERE (([nam]='")
                                    str.Append(Me.TextBox1.Text)
                                    str.Append("'))")
                                    Debug.WriteLine("")
                                    Debug.WriteLine(str.ToString)
                                    Dim cmdn As New OleDb.OleDbCommand(str.ToString, odConnection)
                                    cmdn.ExecuteNonQuery()
                                    odConnection.Close()
                                    Response.Write("<script type='text/javascript'>alert('提交成功')</script>")
                                Else
                                    Response.Write("<script type='text/javascript'>alert('禁止，请上传图片文件！')</script>")
                                End If
                            End If
                        Next

                    End If
                Finally
                End Try
            Else
                Response.Write("<script type='text/javascript'>alert('名字错误或已提交')</script>")
            End If
        End If
    End Sub
End Class