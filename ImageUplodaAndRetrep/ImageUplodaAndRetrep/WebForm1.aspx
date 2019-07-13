<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ImageUplodaAndRetrep.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table border="0" cellpadding="2" width="500px">
            <tr>
                <td >
                    Upload File</td>
                <td >
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td >
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Upload" />
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" >
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        ShowHeader="False">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("id") %>'>"></asp:Label></td>
                                        <td>
                                            <asp:Image ID="Image1" Height="150" Width="150" ImageUrl='<%#Eval("Image") %>' runat="server" /></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>   
    </div>
    </form>
</body>
</html>
