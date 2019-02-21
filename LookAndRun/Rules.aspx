<%@ Page Title="Look&run" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rules.aspx.cs" Inherits="WebApplication1.Rules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<img class="img-responsive" src="img/rules.jpg" alt="">

<div id="English" runat="server">

<h2>The rules </h2>
<h4 class="grey">Instructions</h4>
<ol class="rules">
    <li>
        First, you need to register for the chosen game at our website: lookandrun.fi.
    </li>
    <li>
        Then, you need to appear at the start at a particular location and time (all information is stated in the Facebook event; the link may be found in the section "Coming games")
    </li>
    <li>
        Listen to the information given during the briefing very carefully.
    </li>
    <li>
        The teams begin in a queue and are allowed to start with intervals. Your queue number will be given to you during the briefing.
    </li>
    <li>
        When your start time is coming up, you pay the game fee and receive a set of tasks in the language you selected during registration. From this moment on, your game has begun!
    </li>
    <li>
        You need to perform all the tasks before your competitors and arrive at the finish point stated at the end of all tasks.
    </li>
    <li>
        At the finish, your time is stopped ONLY WHEN you give the filled-out answer sheet to one of the coordinators (you will be given the sheet along with the initial set of tasks).
    </li>
    <li>
        Photos and other evidence proving that you performed the tasks are shown to the coordinators also in a queue.
    </li>
    <li>
        During the process of calculating the results, you need to stay around the coordinators. As soon as your turn comes, your team will be asked to present your evidence.
    </li>
    <li>
        During the process of calculating the results, all the teams must wait for the others to arrive so that the results of the game may be presented and the rewards given out.
    </li>
    <li>
        IT IS IMPORTANT to take with you: a pen, a camera (or the phone with camera), a phone with Internet access, cash fo paying the fee (without change). Don't forget to warm properly, it is an outdoors game!
    </li>
</ol>
<h4 class="grey">Final time calculation rules</h4>
<p>
    Each game consists of a set of tasks and bonuses. The logic of final time calculations may be found below.
</p>
<ol class="rules">
    <li>
        If you performed a task, your time remains the same.
    </li>
    <li>
        If you didn't perform a task or performed it partly, you will get penalty minutes. The amount of penalty minutes is set up for every particular task individually and is not stated before the finish.
    </li>
    <li>
        If you did a bonus task, your time is decreased by the amount of minutes directly proportional to the complexity of that bonus task. The exact weight of each bonus task is also not stated before the finish.
    </li>
    <li>
        If you didn't do a bonus task, your time remains the same.
    </li>
    <li>
        The final time is calculated by taking your real time and subtracting (adding) bonus (penalty) minutes from (to) it.
    </li>
    <li>
        In case you have problems, you get lost or you want to get a hint, you may call the coordinators from a number you gave during registration. The coordinators' phone numbers are stated in the task set. You need to remember, however, that you are given penalty minutes for getting such help.
    </li>
</ol>
</div>

<div id="Russian" runat="server" Visible = "False">

<h2>Правила игры</h2>
<h4 class="grey">Инструкции</h4>
<ol class="rules">
    <li>
        Для начала необходимо зарегистрироваться на игру на нашем сайте lookandrun.fi.
    </li>
    <li>Надо явиться на старт в указанное место и указанное время (все данные указываются на странице встречи в Facebook - см. раздел "Предстоящие игры")</li>
    <li>Внимательно прослушать инструктаж</li>
    <li>Команды начинают соревнование по очереди. Ваш номер в очереди будет озвучен во время инструктажа.</li>
    <li>Когда подходит очередь Вашей команды, Вы оплачиваете взнос за игру и получаете задания на выбранном (при регистрации) Вами языке. С этого момента игра для Вас началась.</li>
    <li>Вам необходимо выполнить указанные задания раньше соперников и прийти на финиш, обоначенный в выданном задании.</li>
    <li>На финише Ваше время останавливается ТОЛЬКО ТОГДА КОГДА Вы отдали координатору заполненный бланк ответов (он также выдаётся вместе с заданиями).</li>
    <li>Фотографии и прочие доказательства выполнения Вами заданий предоставляются также в порядке очереди.</li>
    <li>Во время подведения итогов Вам необходимо находиться вблизи координаторов. Как только Ваша очередь показывать фото/прочие материалы подойдет - Вашу команду вызовут.</li>
    <li>Во время подведения итогов все команды дожидаются прибытия остальных, а также подведения итогов и награждения!</li>
    <li>ВАЖНО взять с собой ручку, фотоаппарат (или телефон с камерой), телефон с выходом в Интернет, оплату наличными без сдачи. Не забудьте тепло одеться!</li>
</ol>
<h4 class="grey">Система подсчета финального времени</h4>
<p>
    Игра состоит из набора заданий и бонусов. Ниже представлена система учета заданий.
</p>
<ol class="rules">
    <li>Если Вы выполнили задание - Ваше время остаётся прежним.</li>
<li>Если Вы не выполнили задание или выполнили его частично - Вам будут начислены штрафные минуты. Количество минут устанавливается организаторами индивидуально одельно для каждого задания каждой игры и не оглашается до финиша.</li>
<li>Если Вы выполнили бонус - Ваше время уменьшается на количество минут, прямо пропорциональное сложности задания. Точный вес каждого задания не оглашается до финиша.</li>
<li>Если Вы не выполнили бонус - Ваше время остаётся прежним.</li>
<li>Итоговое время считается путем изменения Вашего реального времени прохождения трассы посредством добавления/вычитания выигранных/проигранных Вами минут.</li>
<li>Если у Вас возникли проблемы, Вы потерялись или Вам нужна подсказка, Вы можете позвонить координаторам по телефону, указанному на бланках заданий. Важно помнить, что Вам начисляются штрафные минуты за звонки помощи.</li>
</ol>

</div>


</asp:Content>
