<%@ Page Title="Look&run" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComingSoon.aspx.cs" Inherits="WebApplication1.ComingSoon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%--<img class="img-responsive" src="http://lookandrun.fi/Albums/Winners/Ad.jpg?v=037" alt=""/>--%>
<div id="English" runat="server">
    <p>The games are currently held only in private mode (birthday parties, team buildings, romantic surprises etc.). If you want to book a game for you and your friends contact us by e-mail look.and.run.fi@gmail.com </p>

   <%-- <h2>Game 28.09.2018! </h2>
    <h4 class="grey">What do you need to know:</h4>
    <ul class="time">
        <li>18:00 Briefing.</li>
        <li>18:30 Start.</li>
    </ul>
    <a href="Registration.aspx" class="btn">Online registration</a>
    <ul class="time mb2em">
        <li>1) Teams may contain 1-4 people.</li>
        <li>2) Game fee is 10 eur per person if you register online 12 eur otherwise.</li>
        <li>3) TAKE WITH YOU: a phone with camera and Internet access, a pen.</li>
        <li>4) It is a sport game and it is also an outdoors game! Dress properly!</li>
        <li>5) People under 18 may play the game ONLY with parents!</li>
        <li>6) The game takes about 4-5 hours (including meeting, briefing, the game itself, waiting for all the teams at the finish and announcing the results).</li>
        <li>7) The exact start location is the bar SportsAcademy, Keskuskatu 6, 2nd floor.</li>
        <li>8) The DEADLINE for online registration is 23:00 26.09!!!</li>
        <li>9) The sooner you register, the better starting position you will have :).</li>
    </ul>--%>
</div>

<div id="Russian" runat="server">
<p>На данный момент игры проводятся только в частном формате (дни рождения, тим-билдинги, романтические квесты). Если Вы хотите организовать игру для себя и своих друзей, свяжитесь с нами по почте look.and.run.fi@gmail.com</p>
   <%--<h2>Игра 28.09.2018 </h2>
    <h4 class="grey">Что надо знать:</h4>
    <ul class="time">
        <li>18:00 Инструктаж.</li>
        <li>18:30 Старт.</li>
    </ul>
    <a href="Registration.aspx" class="btn">Онлайн регистрация</a>
    <ul class="time mb2em">
        <li>1) Команды от 1 до 4 человек.</li>
        <li>2) Стоимость игры 10 евро на человека при условии онлайн регистрации, 12 евро в обратном случае</li>
        <li>3) ВЗЯТЬ С СОБОЙ: телефон с камерой и выходом в Интернет, ручку.</li>
        <li>4) Игра носит спортивный характер, а также проводится на улице! Оденьтесь тепло и в удобную одежду!</li>
        <li>5) Лица до 18 лет допускаются ТОЛЬКО с родителями!</li>
        <li>6) Игра занимает около 4-5 часов (включая сбор, инструктаж, саму игру, ожидание всех команд на финише и подведение итогов).</li>
        <li>7) Локация старта - бар SportsAcademy, Keskuskatu 6, 2й этаж.</li>
        <li>8) ДЕДЛАЙН онлайн регистрации 23:00 26.08!!!</li>9
        <li>9) Чем раньше зарегистрируетесь - тем лучше будет ваша стартовая позиция :).</li>
    </ul>--%>
</div>
<div runat="server" visible="False">
        <table class="results">
                    <thead>
                        <tr>
                            <td>№</td>
                            <td><asp:Label ID="TeamName" runat="server" meta:resourceKey="Name" /></td>
                            <td><asp:Label ID="Members" runat="server" meta:resourceKey="Members" /></td>
                        </tr>
                    </thead>                    
                    <tbody>
                       <% for (var i = 0; i < TeamList.Count;i++ )
                          {
                              var team = TeamList[i];
                             %>
                              <tr>
                                <td><%= i + 1%></td>
                                <td><%= team.Name%></td>
                                <td><%= team.Members%></td>
                              </tr>
                    <% } %>
                        
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="4">
                                <a id="fbLink" href="" runat="server">Facebook event</a>
                            </td>
                        </tr>
                    </tfoot>
                </table>
</div>
 </br>
    <img class="img-responsive" src="http://lookandrun.fi/Albums/Winners/Comics.jpg?v=018" alt=""/>
</asp:Content>
