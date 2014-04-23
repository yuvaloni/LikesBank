<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Liker.aspx.cs" Inherits="LikesBank.Liker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
        <img src ="bg.jpg" style="height:100%;width:100%;top:0;left:0;position:absolute;" />
    <p style="position:absolute;color:white;top:0%;left:25%;font-size:100%;">Your request is being processed <br /> please don't close this window</p>
    <form id="form1" runat="server">
    <div>

    <%
        work();
        Response.Write("<p style=\"position:absolute;color:white;top:50%;left:25%;font-size:100%;\">Completed successfully! <br/> feel free to close this window</p>");
       %>
    </div>
    </form>
</body>
</html>
