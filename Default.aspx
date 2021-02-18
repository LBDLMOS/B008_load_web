<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="健康码上传._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>上传</h1>
        <p class="lead">姓名：<asp:TextBox ID="TextBox1" runat="server" BorderStyle="Double"></asp:TextBox>
        </p>
        <p class="lead">学号：<asp:TextBox ID="TextBox2" runat="server" Width="176px" BorderStyle="Double" TextMode="Number"></asp:TextBox>
        </p>
        <p class="lead">
            <asp:FileUpload ID="FileUpload1" runat="server" BorderStyle="Double" />
        </p>
        <p class="lead">
            <asp:Button ID="Button1" runat="server" BackColor="#0066FF" BorderColor="White" BorderStyle="None" ForeColor="White" Height="38px" Text="提交" Width="63px" />
        </p>
    </div>

</asp:Content>
