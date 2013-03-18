<%@ Page Title="Antics" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AnticsPage.aspx.cs" Inherits="AnticsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <title>
        Antics
    </title>
    <div>
        Antics Page
    </div>


    <br />
    <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/Test/Antics2008-10-25.jpg" onclick="ImageButton1_Click"/>
    <br />

    <asp:LinkButton ID="LinkButtonFirst"    runat="server" 
        onclick="LinkButtonFirst_Click">First</asp:LinkButton>
    &nbsp
    <asp:LinkButton ID="LinkButtonPrevious" runat="server" 
        onclick="LinkButtonPrevious_Click">Previous</asp:LinkButton>
    &nbsp
    <asp:LinkButton ID="LinkButtonRandom"   runat="server" 
        onclick="LinkButtonRandom_Click">Random</asp:LinkButton>
    &nbsp
    <asp:LinkButton ID="LinkButtonNext"     runat="server" 
        onclick="LinkButtonNext_Click">Next</asp:LinkButton>
    &nbsp
    <asp:LinkButton ID="LinkButtonNewest"   runat="server" 
        onclick="LinkButtonNewest_Click">Newest</asp:LinkButton>

    <br />
    <br />



    <asp:LinkButton ID="LinkButtonLike" runat="server">I Like It!</asp:LinkButton>



    </asp:Content>

