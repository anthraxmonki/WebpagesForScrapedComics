<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AllComics.aspx.cs" Inherits="AllComics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <title>
        All Comics
    </title>

    <div>
        All Comics Page
    </div>

    <asp:ImageButton ID="ImageButton1" runat="server" 
        onclick="ImageButton1_Click" />
    <br />


    <asp:LinkButton ID="LinkButtonFirst"    runat="server" 
        onclick="LinkButtonFirst_Click" >First</asp:LinkButton>
    &nbsp
    <asp:LinkButton ID="LinkButtonPrevious" runat="server" 
        onclick="LinkButtonPrevious_Click" >Previous</asp:LinkButton>
    &nbsp
    <asp:LinkButton ID="LinkButtonRandom"   runat="server" 
        onclick="LinkButtonRandom_Click" >Random</asp:LinkButton>
    &nbsp
    <asp:LinkButton ID="LinkButtonNext"     runat="server" 
        onclick="LinkButtonNext_Click" >Next</asp:LinkButton>
    &nbsp
    <asp:LinkButton ID="LinkButtonNewest"   runat="server" 
        onclick="LinkButtonNewest_Click" >Newest</asp:LinkButton>

    <br />
    <br />


    <h2>
        <asp:LinkButton ID="LinkButtonLike" runat="server" onclick="LinkButtonLike_Click">I Like It!</asp:LinkButton>
        &nbsp
        <asp:Label ID="Label1" runat="server" ></asp:Label>
    </h2>
    </br>

    <asp:LinkButton ID="LinkButtonLeastLiked" runat="server" 
        onclick="LinkButtonLeastLiked_Click">Sort By Least Liked</asp:LinkButton>
    &nbsp
    <asp:LinkButton ID="LinkButtonMostLiked"  runat="server" 
        onclick="LinkButtonMostLiked_Click">Sort By Most Liked</asp:LinkButton>



</asp:Content> 
