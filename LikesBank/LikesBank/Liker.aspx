<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Liker.aspx.cs" Inherits="LikesBank.Liker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
        <img src ="bg.jpg" style="height:100%;width:100%;top:0;left:0;" />
    <p style="position:absolute;width:100%;height:100%;color:white;">Your request is being processed <br /> please don't close this window</p>
    <form id="form1" runat="server">
    <div>

    <%
        Response.Write("Your request is being processed <br /> please don't close this window");
        work();
       %>
    </div>
    </form>
</body>
</html>
