<%@ Page Title="Explosm" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExplosmPage.aspx.cs" Inherits="ExplosmPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <title>
        Explosm
    </title>

    <div>
        Explosm Page
    </div>

    <br />
    <asp:ImageButton ID="ImageButton1" runat="server" 
        onclick="ImageButton1_Click"/>


    <br />
    <asp:LinkButton ID="LinkButtonFirst"    runat="server" 
        onclick="LinkButtonFirst_Click">First Comic</asp:LinkButton> &nbsp
    <asp:LinkButton ID="LinkButtonPrevious" runat="server" 
        onclick="LinkButtonPrevious_Click">Previous</asp:LinkButton> &nbsp
    <asp:LinkButton ID="LinkButtonRandom"   runat="server" 
        onclick="LinkButtonRandom_Click">Random</asp:LinkButton> &nbsp
    <asp:LinkButton ID="LinkButtonNext"     runat="server" 
        onclick="LinkButtonNext_Click">Next</asp:LinkButton> &nbsp
    <asp:LinkButton ID="LinkButtonLast"     runat="server" 
        onclick="LinkButtonLast_Click">Latest Comic</asp:LinkButton>

   <br />
   <br />
   <asp:LinkButton ID="LinkButtonLike" runat="server">I Like It!</asp:LinkButton>


</asp:Content>

