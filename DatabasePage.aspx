<%@ Page Title="Database" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DatabasePage.aspx.cs" Inherits="DatabasePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <title>
        Database
    </title>

    <h1>
        DatabasePage
    </h1>
    <asp:ImageButton ID="ImageButton1" runat="server" 
    onclick="ImageButton1_Click"  />


    <asp:Button ID="ExplosmLinqButton" runat="server" Text="ExplosmLinqButton" 
    onclick="LinqButton_Click" />


    <asp:Button ID="AnticsLinqButton" runat="server" Text="AnticsLinqButton" 
        onclick="AnticsLinqButton_Click" />

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

    </asp:Content>

